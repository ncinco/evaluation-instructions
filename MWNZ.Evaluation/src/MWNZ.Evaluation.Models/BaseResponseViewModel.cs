namespace MWNZ.Evaluation.Models
{
    public abstract class BaseResponseViewModel<T> where T : class
    {
        public T Data { get; set; }

        public Error Error { get; set; }

        public bool HasError { get { return !string.IsNullOrWhiteSpace(Error.ErrorCode); } }

    }
}