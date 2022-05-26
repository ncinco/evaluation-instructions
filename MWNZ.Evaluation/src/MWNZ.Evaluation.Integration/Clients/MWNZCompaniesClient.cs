using Microsoft.Extensions.Options;
using MWNZ.Evaluation.Integration.Interface;
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

            try
            {
                var response = await _httpClient.GetAsync($"{_serverOptions.BaseUrl}/MiddlewareNewZealand/evaluation-instructions/main/xml-api/{id}.xml");

                switch (response.StatusCode)
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
                                ErrorDescription = $"Company with id '{id}' could not be found."
                            }
                        };
                        break;
                }                
            }
            catch (Exception ex)
            {
                // although not part of open api spec, just return 500 if we can't figure out whats wrong
                // add logs in real world
                companyReponse = new CompanyReponse
                {
                    Error = new ErrorResponse
                    {
                        ErrorCode = 500.ToString(),
                        ErrorDescription = "InternalServerError"
                    }
                };
            }

            return companyReponse;
        }
    }
}