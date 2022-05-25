using System.ComponentModel.DataAnnotations;

namespace MWNZ.Evaluation.Models
{
    public class Company
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}