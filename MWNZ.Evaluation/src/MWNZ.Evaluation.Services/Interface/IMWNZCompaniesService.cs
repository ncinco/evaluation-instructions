using MWNZ.Evaluation.Models;

namespace MWNZ.Evaluation.Services.Interface
{
    public interface IMWNZCompaniesService
    {
        Task<Company> GetCompanyAsync(int id);
    }
}