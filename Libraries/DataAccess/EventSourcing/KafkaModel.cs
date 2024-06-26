using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataAccess.Cqrs
{
    public class KafkaModel
    {
        public class KafkaParameters
        {
            public string Allowed { get; set; }
        }
        public class KafkaPayload
        {
            public object? Before { get; set; }
            public object? After { get; set; }
            public KafkaSource? Source { get; set; }
            public string? Pp { get; set; }
            public long? Ts_ms { get; set; }
            public object? Transaction { get; set; }
            public string Op { get; set; }
        }
        public class KafkaSchema
        {
            public string Type { get; set; }
            public List<KafkaField> Fields { get; set; }
            public bool Optional { get; set; }
            public string Name { get; set; }
            public int Version { get; set; }
        }
        public class KafkaField
        {
            public string Type { get; set; }
            public List<KafkaField> Fields { get; set; }
            public bool Optional { get; set; }
            public string Name { get; set; }
            public string Field { get; set; }
            public int? Version { get; set; }
            public KafkaParameters Parameters { get; set; }
            public string Default { get; set; }
        }
        public class KafkaSource
        {
            public string Version { get; set; }
            public string Connector { get; set; }
            public string Name { get; set; }
            public long Ts_ms { get; set; }
            public string Snapshot { get; set; }
            public string Db { get; set; }
            public object Sequence { get; set; }
            public string Schema { get; set; }
            public string Table { get; set; }
            public string Change_lsn { get; set; }
            public string Commit_lsn { get; set; }
            public int Event_serial_no { get; set; }
        }
        public KafkaSchema Schema { get; set; }
        public KafkaPayload Payload { get; set; }
    }
}
