using Confluent.Kafka;
using DataAccess.Context;
using DataAccess.Cqrs;
using DataAccess.EventSourcing;
using Entities.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaWorkerService.Extensions
{
    public static class KafkaWorkerExtension
    {
        public static IConsumer<Ignore, string> CreateKafkaConsumer()
        {
            return new ConsumerBuilder<Ignore, string>(new ConsumerConfig()
            {
                GroupId = "ECommerce",
                BootstrapServers = $"s_kafka:29092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
            }).Build();
        }
        public static async Task AddCqrsWithKafkaConsumerAsync(this IHost host)
        {
            var configuration = host.Services.GetRequiredService<IConfiguration>();
            //MigrateDb
            var optionBuilder = new DbContextOptionsBuilder<ECommerceContext>()
               .UseSqlServer(configuration.GetConnectionString("EventSourcingDb"));
            using var ctxMigrate = new ECommerceContext(optionBuilder.Options);
            ctxMigrate.Database.EnsureCreated();
            ctxMigrate.Database.Migrate();
            //Kafka Consumer
            using var consumer = CreateKafkaConsumer();
            consumer.Subscribe($"^ECommerce\\.ECommerce\\.dbo\\..+");
            var assembly = EntitiesAssemblyExtenison.GetAssemlyExtension();
            while (true)
            {
                var source = new CancellationTokenSource();
                var state = KafkaError.NoError;
                try
                {
                    var consume = consumer.Consume();
                    var result = JsonConvert.DeserializeObject<KafkaModel>(consume.Message.Value);

                    using (var ctx = new ECommerceContext(optionBuilder.Options))
                    {
                        //Date Sınıfı TimeSpan Olarak geldiği için onları bulup date'e çeviriyorum Debezium'un doc'undaki çalışmıyor
                        var dateListItem = result.Schema.Fields[1]?.Fields?.Where(x => x.Name == "io.debezium.time.NanoTimestamp").Select(x=>x.Field);
                        var dynamicData = (dynamic)result.Payload.After;
                        foreach (var item in dateListItem)
                        {
                            long ticks = dynamicData[item] / 100;
                            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            DateTime dateTime = epoch.AddTicks(ticks);
                            dynamicData[item] = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        if(result.Payload.After != null)
                        {
                            var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
                            var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
                            ctx.Add(data);
                        }
                        else
                        {
                            source.Cancel();
                        }
                        //if (result.Payload.Op == DebeziumOperationType.Create && result.Payload.After != null)
                        //{
                        //    var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
                        //    var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
                        //    ctx.Add(data);
                        //}
                        //else if (result.Payload.Op == DebeziumOperationType.Update && result.Payload.After != null)
                        //{
                        //    var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
                        //    var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
                        //    ctx.Update(data);
                        //}
                        //else if (result.Payload.Op == DebeziumOperationType.Delete)
                        //{
                        //    var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
                        //    var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
                        //    ctx.Remove(data);
                        //}
                        //else
                        //{
                        //    source.Cancel();
                        //}
                        ctx.SaveChanges();
                        state = KafkaError.KafkaError;
                        consumer.Commit(consume);
                    }
                }
                catch (Exception ex)
                {
                    Log.Warning(ex.ToString());
                    Debug.WriteLine(ex);
                    if (state == KafkaError.KafkaError)
                    {
                        source.Cancel();
                    }
                }
            }
        }
    }
}
