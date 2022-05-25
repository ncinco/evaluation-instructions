namespace MWNZ.Evaluation.Models
{
    public abstract class BaseViewModel<T> where T : class
    {
        public T Data { get; set; }

        public Error Error { get; set; }
    }
}