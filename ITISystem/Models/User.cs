using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? Email { get; set; }
        
        [Required]
        [MinLength(4,ErrorMessage = "UserName Must Be at least 4 characters")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 character")]

        public string? Password { get; set; }
        [Required]

        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
