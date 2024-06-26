namespace DataAccess.EventSourcing
{
    public static class DebeziumOperationType
    {
        public const string Read = "r";
        public const string Create = "c";
        public const string Update = "u";
        public const string Delete = "d";
    }
}
