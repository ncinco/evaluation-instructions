namespace MWNZ.Evaluation.Models
{
    public class CompanyReponseViewModel : BaseResponseViewModel<Company>
    {
        public CompanyReponseViewModel()
        {
            Data = new Company();
            Error = new Error();
        }
    }
}