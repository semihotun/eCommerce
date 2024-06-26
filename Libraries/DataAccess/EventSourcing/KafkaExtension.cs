﻿using Confluent.Kafka;
using DataAccess.Context;
using DataAccess.ContextSeed.eCommerceDbSeed;
using DataAccess.Cqrs;
using Entities.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EventSourcing
{
    public static class KafkaExtension
    {
        public static string GetWriteDbTableName(ECommerceContext ctx)
        {
            var tableNames = new List<string>();
            foreach (var entityType in ctx.Model.GetEntityTypes())
            {
                tableNames.Add($"dbo.{entityType.GetTableName()}");
            }
            return string.Join(",", tableNames.Select(e => $"{e}"));
        }
        public static async Task AddConnector(this ECommerceContext ctx)
        {
           var ss= await new HttpClient().PostAsync($"http://host.docker.internal:8083/connectors",
             new StringContent($@"
            {{
              ""name"": ""ECommerce.connector"",
              ""config"": {{
                ""topic.prefix"": ""ECommerce"",
                ""connector.class"": ""io.debezium.connector.sqlserver.SqlServerConnector"",
                ""schema.history.internal.kafka.topic"": ""ECommerce.schema"",
                ""database.names"": ""ECommerce"",
                ""table.include.list"": ""{GetWriteDbTableName(ctx)}"",
                ""database.hostname"": ""s_sqlserver"",
                ""database.port"": ""1433"",
                ""database.user"": ""sa"",
                ""database.password"": ""semihO123."",
                ""schema.history.internal.kafka.bootstrap.servers"": ""s_kafka:9092"",
                ""database.encrypt"": false,
                ""databse.trustServerCertificate"": true,
                ""schema.history.internal.kafka.query.timeout.ms"":3000,
                ""snapshot.mode"": ""initial""
              }}
            }}", System.Text.Encoding.UTF8, "application/json"));
            Debug.WriteLine(ss.Content);
        }
        //public static IConsumer<Ignore, string> CreateKafkaConsumer()
        //{
        //    return new ConsumerBuilder<Ignore, string>(new ConsumerConfig()
        //    {
        //        GroupId = "ECommerce",
        //        BootstrapServers = $"s_kafka:29092",
        //        AutoOffsetReset = AutoOffsetReset.Earliest,
        //        EnableAutoCommit = false,
        //    }).Build();
        //}
        //public static async Task AddCqrsWithKafkaConsumerAsync(this IHost host)
        //{
        //    var configuration = host.Services.GetRequiredService<IConfiguration>();
        //    using var consumer = CreateKafkaConsumer();
        //    consumer.Subscribe($"^ECommerce\\.ECommerce\\.dbo\\..+");
        //    var assembly = EntitiesAssemblyExtenison.GetAssemlyExtension();
        //    while (true)
        //    {
        //        var source = new CancellationTokenSource();
        //        var state = KafkaError.NoError;
        //        try
        //        {
        //            var consume = consumer.Consume();
        //            var result = JsonConvert.DeserializeObject<KafkaModel>(consume.Message.Value);
                  
        //            //using (var ctx = new ECommerceContext(optionBuilderReadCtx.Options))
        //            //{
        //            //    if (result.Payload.Op == DebeziumOperationType.Create && result.Payload.After != null)
        //            //    {
        //            //        var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
        //            //        var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
        //            //        ctx.Add(data);
        //            //    }
        //            //    else if (result.Payload.Op == DebeziumOperationType.Update && result.Payload.After != null)
        //            //    {
        //            //        var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
        //            //        var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
        //            //        ctx.Update(data);
        //            //    }
        //            //    else if (result.Payload.Op == DebeziumOperationType.Delete)
        //            //    {
        //            //        //var dataType = assembly.GetType("Entities.Concrete." + result.Payload.Source.Table);
        //            //        //var data = JsonConvert.DeserializeObject(result.Payload.After.ToString(), dataType);
        //            //        //ctx.Remove(data);
        //            //    }
        //            //    else
        //            //    {
        //            //        source.Cancel();
        //            //    }
        //            //    ctx.SaveChanges();
        //            //    state = KafkaError.KafkaError;
        //            //    consumer.Commit(consume);
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex);
        //            if (state == KafkaError.KafkaError)
        //            {
        //                source.Cancel();
        //            }
        //        }
        //    }
        //}
    }
}
