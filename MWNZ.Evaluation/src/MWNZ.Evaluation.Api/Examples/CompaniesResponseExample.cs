using MWNZ.Evaluation.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace MWNZ.Evaluation.Api.Examples
{
    public class CompaniesResponseExample : IMultipleExamplesProvider<Company>
    {
        public IEnumerable<SwaggerExample<Company>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "MWNZ",
                new Company
                {
                    Id = 1,
                    Name = "MWNZ",
                    Description = "..is awesome"
                });

            yield return SwaggerExample.Create(
                "Other",
                new Company
                {
                    Id = 2,
                    Name = "Other",
                    Description = "....is not"
                });
        }
    }
}