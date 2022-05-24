using MWNZ.Evaluation.Integration.Interface;
using MWNZ.Evaluation.Models;
using Newtonsoft.Json;
using System.Xml;

namespace MWNZ.Evaluation.Integration.Clients
{
    public class MWNZCompaniesClient : IMWNZCompaniesClient
    {
        private readonly HttpClient _httpClient;

        public MWNZCompaniesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyReponse> GetCompanyAsync(int id)
        {
            CompanyReponse companyReponse = new CompanyReponse();
            var response = await _httpClient.GetAsync($"https://raw.githubusercontent.com/MiddlewareNewZealand/evaluation-instructions/main/xml-api/{id}.xml");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(content);

                var jsonString = JsonConvert.SerializeXmlNode(xmlDocument);
                companyReponse = JsonConvert.DeserializeObject<CompanyReponse>(jsonString);
            }
            else
            {

            }

            return companyReponse;
        }
    }
}