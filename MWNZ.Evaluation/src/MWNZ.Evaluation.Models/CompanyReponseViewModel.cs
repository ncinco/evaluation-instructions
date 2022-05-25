namespace MWNZ.Evaluation.Models
{
    public class CompanyReponseViewModel : BaseViewModel<Company>
    {
        public CompanyReponseViewModel()
        {
            Data = new Company();
            Error = new Error();
        }

        public bool HasError { get { return !string.IsNullOrWhiteSpace(Error.ErrorCode); } }
    }
}