using System;
using System.Runtime.CompilerServices;
using log4net;

namespace ArgumentApp
{
    public class Logger
    {
        private static Logger logger;
        private ILog log;

        public static Logger Instance
        {
            get
            {
                if (logger == null)
                {
                    logger = new Logger();
                }
                return logger;
            }
        }

        private Logger()
        {
        }

        private void Initialize()
        {
            log = LogManager.GetLogger(typeof(Logger));
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Error(Exception ex, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            if (log == null)
            {
                Initialize();
            }
            log.Error(string.Format("Error is logged from method {0} in file {1}. {2} \r\nStack trace: {3} ", memberName, sourceFilePath, ex.Message, ex.StackTrace));
        }

        public void Warning(Exception ex, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            if (log == null)
            {
                Initialize();
            }
            log.Error(string.Format("Warning is logged from method {0} in file {1}. {2} \r\nStack trace: {3} ", memberName, sourceFilePath, ex.Message, ex.StackTrace));
        }

        public void Info(string ex, [CallerMemberName] string memberName = "")
        {
            if (log == null)
            {
                Initialize();
            }
            log.Info(string.Format("Info: the method {0} is passed ", memberName));
        }
    }
}
