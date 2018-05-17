using NLog;
using System;

namespace Wucefus.Core.Services.Loggers
{
    public class KrisLogger : IKrisLogger
    {
        private readonly string _guid;
        private readonly Logger _mainLogger;

        public KrisLogger()
        {
            _mainLogger = LogManager.GetLogger("LOG_MAIN");
            _guid = Guid.NewGuid().ToString("N");
        }

        public void Debug(string message, params object[] args)
        {
            message = PrepareMsg(message);
            _mainLogger.Debug(message, args);
        }

        public void Error(string message, params object[] args)
        {
            message = PrepareMsg(message);
            _mainLogger.Error(message, args);
        }

        public void Trace(string message, params object[] args)
        {
            message = PrepareMsg(message);
            _mainLogger.Trace(message, args);
        }

        private string PrepareMsg(string message)
        {
            return $"[{_guid}] {message}";
        }
    }
}
