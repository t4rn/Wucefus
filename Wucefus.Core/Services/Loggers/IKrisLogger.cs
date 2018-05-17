namespace Wucefus.Core.Services.Loggers
{
    public interface IKrisLogger
    {
        void Trace(string message, params object[] args);

        void Debug(string message, params object[] args);

        void Error(string message, params object[] args);
    }
}
