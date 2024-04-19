using Core.Const;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
namespace Core.Utilities.Logging.SeriLog
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                    .Get<MsSqlConfiguration>() ?? throw new Exception(CoreMessages.NullOptionsMessage);
            var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };
            var seriLogConfig = new LoggerConfiguration()
                                        .WriteTo.MSSqlServer(connectionString: logConfig.ConnectionString, sinkOptions: sinkOpts)
                                        .CreateLogger();
            Logger = seriLogConfig;
        }
    }
}
