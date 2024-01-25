using System.ComponentModel.DataAnnotations.Schema;

namespace Maxim.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image  { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }   
    }   
}
    