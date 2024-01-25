
using System.ComponentModel.DataAnnotations;

namespace Maxim.Areas.Admin.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirimPassword { get; set; }
    } 
}
