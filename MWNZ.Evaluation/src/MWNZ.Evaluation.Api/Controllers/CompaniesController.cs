using Microsoft.AspNetCore.Mvc;
using MWNZ.Evaluation.Services.Interface;
using System.Threading.Tasks;

namespace MWNZ.Evaluation.Api.Controllers
{
    [Route("v1/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMWNZCompaniesService _MWNZCompaniesService;

        public CompaniesController(IMWNZCompaniesService mWNZCompaniesService)
        {
            _MWNZCompaniesService = mWNZCompaniesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _MWNZCompaniesService.GetCompanyAsync(id);

            return Ok(result);
        }
    }
}