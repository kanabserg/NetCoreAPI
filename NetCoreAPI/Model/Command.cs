using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Model
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        
        [Required]
        public string HowTo { get; set; }
        
        [Required]
        public string Platform { get; set; }
    }
}