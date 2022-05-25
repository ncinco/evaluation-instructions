using MWNZ.Evaluation.Integration;
using MWNZ.Evaluation.Models;

namespace MWNZ.Evaluation.Services
{
    public static class Mapper
    {
        public static CompanyReponseViewModel ToServiceModel(this CompanyReponse companyReponse)
        {
            // not the best
            var result = new CompanyReponseViewModel();

            if(companyReponse.Data != null)
            {
                result.Data.Id = companyReponse.Data.Id;
                result.Data.Name = companyReponse.Data.Name;
                result.Data.Description = companyReponse.Data.Description;
            }

            if (companyReponse.Error != null)
            {
                result.Error.ErrorCode = companyReponse.Error.ErrorCode;
                result.Error.ErrorDescription = companyReponse.Error.ErrorDescription;
            }

            return result;
        }
    }
}