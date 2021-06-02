namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResults<T>
    {
        public ErrorDataResult(T data, string message) : base(data, true, message)
        {

        }
        public ErrorDataResult(T data) : base(data, true)
        {

        }
        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
