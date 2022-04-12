using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{

    public class RegisterViewModel
    {
        [Required] 
        [Display(Name = "FirstName")] 
        public string? FirstName { get; init; }
        
        [Required] 
        [Display(Name = "LastName")] 
        public string? LastName { get; init; }
        
        [Required] 
        [Display(Name = "Email")] 
        public string? Email { get; init; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; init; }
    }
}