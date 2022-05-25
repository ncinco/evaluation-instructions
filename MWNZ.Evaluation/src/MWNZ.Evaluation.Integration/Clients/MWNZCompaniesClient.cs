using Microsoft.Extensions.Options;
using MWNZ.Evaluation.Integration.Interface;
using MWNZ.Evaluation.Models;
using Newtonsoft.Json;
using System.Xml;

namespace MWNZ.Evaluation.Integration.Clients
{
    public class MWNZCompaniesClient : IMWNZCompaniesClient
    {
        private readonly ServerOptions _serverOptions;
        private readonly HttpClient _httpClient;

        public MWNZCompaniesClient(IOptions<ServerOptions> serverOptions, HttpClient httpClient)
        {
            _serverOptions = serverOptions.Value;
            _httpClient = httpClient;
        }

        public async Task<CompanyReponse> GetCompanyAsync(int id)
        {
            CompanyReponse companyReponse = null;
            var response = await _httpClient.GetAsync($"{_serverOptions.BaseUrl}/MiddlewareNewZealand/evaluation-instructions/main/xml-api/{id}.xml");

            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var content = await response.Content.ReadAsStringAsync();
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(content);

                    var jsonString = JsonConvert.SerializeXmlNode(xmlDocument);
                    companyReponse = JsonConvert.DeserializeObject<CompanyReponse>(jsonString);
                    break;

                case System.Net.HttpStatusCode.NotFound:
                    companyReponse = new CompanyReponse
                    {
                        Error = new ErrorResponse
                        {
                            ErrorCode = $"{response.StatusCode}",
                            ErrorDescription = "Not found"
                        }
                    };
                    break;
            }

            return companyReponse;
        }
    }
}