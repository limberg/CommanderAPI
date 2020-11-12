using System.ComponentModel.DataAnnotations;

namespace Commmander31.Dtos
{
    public class CommandUpdateDto{
        
        //public int Id { get; set; }

        [Required]
        [MaxLength (250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
        
    }
}