using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MWNZ.Evaluation.Models
{
    public class Error
    {
        [Required]
        [JsonPropertyName("error")]
        public string ErrorCode { get; set; }

        [Required]
        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }
    }
}