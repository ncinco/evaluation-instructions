using MWNZ.Evaluation.Models;

namespace MWNZ.Evaluation.Services
{
    public static class Mapper
    {
        public static Company ToServiceModel(this CompanyReponse companyReponse)
        {
            return new Company
            {
                Id = companyReponse.Data.Id,
                Name = companyReponse.Data.Name,
                Description = companyReponse.Data.Description
            };
        }
    }
}