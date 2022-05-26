using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MWNZ.Evaluation.Api.Examples;
using MWNZ.Evaluation.Models;
using MWNZ.Evaluation.Services.Interface;
using Swashbuckle.AspNetCore.Filters;
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
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CompaniesResponseExample))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
        [Produces("application/json")]
        [Route("/companies/{id}")]
        public async Task<ObjectResult> GetAsync(int id)
        {
            var result = await _MWNZCompaniesService.GetCompanyAsync(id);

            if (!result.HasError)
            {
                return Ok(result.Data);
            }
            else
            {
                // only 200 and 404 as per spec
                return NotFound(result.Error);
            }
        }
    }
}