namespace MWNZ.Evaluation.Integration.Interface
{
    public interface IMWNZCompaniesClient
    {
        Task<CompanyReponse> GetCompanyAsync(int id);
    }
}