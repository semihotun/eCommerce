using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
           await new HttpClient().PostAsync($"http://host.docker.internal:8083/connectors",
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
        }
    }
}
