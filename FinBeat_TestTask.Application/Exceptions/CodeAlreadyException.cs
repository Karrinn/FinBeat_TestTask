
namespace FinBeat_TestTask.Application.Exceptions
{
    public class CodeAlreadyExistException : AppException
    {
        public override string Code => "code_exists";

        public CodeAlreadyExistException() : base("Row with same Code already exists.")
        {
        }
    }
}
