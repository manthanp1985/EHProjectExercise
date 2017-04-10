using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainContacts.Services
{
    public class LoggerRepository : ILoggerRepository
    {
        private ILog _logger;

        public LoggerRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(this.GetType());
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message, Exception ex)
        {
            var exMessage = new StringBuilder();
            exMessage.Append(message);
            exMessage.Append(string.Concat("Message:", ex.Message, Environment.NewLine));
            exMessage.Append(string.Concat("Source:", ex.Source, Environment.NewLine));
            exMessage.Append(string.Concat("StackTrace:", ex.StackTrace, Environment.NewLine));

            _logger.Error(message, ex);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }
    }
}
