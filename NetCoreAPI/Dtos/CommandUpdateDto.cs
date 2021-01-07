using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.DTOs
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        
        [Required]
        public string HowTo { get; set; }
         
        [Required]
        public string Platform { get; set; }
    }
}