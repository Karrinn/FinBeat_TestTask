namespace FinBeat_TestTask.Application.Exceptions
{
    public class AppException : Exception
    {
        public virtual string Code { get; } = string.Empty;

        protected AppException(string message) : base(message)
        {
        }
    }
}
