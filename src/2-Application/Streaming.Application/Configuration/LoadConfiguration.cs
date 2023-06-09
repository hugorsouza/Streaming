using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Configuration
{
    public class LoadConfiguration : ILoadConfiguration
    {
        private ILogger _logger;

        public bool TraceAtivado { get; set; }

        public ILogger Logger()
        {
            return _logger;
        }

        public LoadConfiguration(IConfiguration configuration)
        {
            //NLog configuration 
            //_logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            //TraceAtivado = Convert.ToBoolean(configuration.GetSection("Logging:TraceAtivado").Value);

            //var nlogTargetInfo = ((WrapperTargetBase)_logger.Factory.Configuration.FindTargetByName("mongoRelacionamentoDigitalLogsInfo")).WrappedTarget;
            //var mongoTargetInfo = (NLog.Mongo.MongoTarget)nlogTargetInfo;

            //var nlogTargetTrace = ((WrapperTargetBase)_logger.Factory.Configuration.FindTargetByName("mongoRelacionamentoDigitalLogsTrace")).WrappedTarget;
            //var mongoTargetTrace = (NLog.Mongo.MongoTarget)nlogTargetTrace;

            //var nlogTargetError = ((WrapperTargetBase)_logger.Factory.Configuration.FindTargetByName("mongoRelacionamentoDigitalLogsError")).WrappedTarget;
            //var mongoTargetError = (NLog.Mongo.MongoTarget)nlogTargetError;

            //mongoTargetInfo.ConnectionString = configuration.GetConnectionString("MongoDB");
            //mongoTargetError.ConnectionString = configuration.GetConnectionString("MongoDB");
            //mongoTargetTrace.ConnectionString = configuration.GetConnectionString("MongoDB");
        }
    }
    public interface ILoadConfiguration
    {
        public ILogger Logger();
    }
}
