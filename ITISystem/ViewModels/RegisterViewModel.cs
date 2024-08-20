using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Remote("CheckEmailExist", "Account")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? Email { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "UserName Must Be at least 4 characters")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 character")]

        public string? Password { get; set; }
        
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password Mismatch")]
        public string? ConfirmPassword { get; set; }
    }
}
