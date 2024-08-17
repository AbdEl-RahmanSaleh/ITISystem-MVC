using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(50,MinimumLength =3,ErrorMessage = "Student name must be more than 2 character")]
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(20,30)]
        public int Age { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-z]+.[a-zA-Z]{2,4}",ErrorMessage ="Not Valid Email Format")]
        [Remote("CheckEmailExist","Student",AdditionalFields ="Id,Name,Age")]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]

        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        public string CPassword { get; set; }

        [NotMapped]
        public IFormFile? stdImg { get; set; }
        public string? ImgUrl { get; set; }

        public string Gender { get; set; }

        public virtual ICollection<StudentCourse>? StudentCourse { get; set; } = new HashSet<StudentCourse>();

        [ForeignKey("department")]
        public int deptId { get; set; }
        public virtual Department? department { get; set; } 

    }
}
