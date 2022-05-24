namespace MWNZ.Evaluation.Models
{
    public class CompanyReponse
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}