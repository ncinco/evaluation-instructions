using MWNZ.Evaluation.Integration.Interface;
using MWNZ.Evaluation.Models;
using MWNZ.Evaluation.Services.Interface;

namespace MWNZ.Evaluation.Services
{
    public class MWNZCompaniesService : IMWNZCompaniesService
    {
        private readonly IMWNZCompaniesClient _MWNZCompaniesClient;

        public MWNZCompaniesService(IMWNZCompaniesClient mWNZCompaniesClient)
        {
            _MWNZCompaniesClient = mWNZCompaniesClient;
        }

        public async Task<CompanyReponseViewModel> GetCompanyAsync(int id)
        {
            var response = await _MWNZCompaniesClient.GetCompanyAsync(id);

            return response.ToServiceModel();
        }
    }
}