using MWNZ.Evaluation.Models;

namespace MWNZ.Evaluation.Services.Interface
{
    public interface IMWNZCompaniesService
    {
        Task<CompanyReponseViewModel> GetCompanyAsync(int id);
    }
}