using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public virtual ICollection<InstructorCourse> CourseInstructors { get; set; }


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"{Id} :: {Name} :: {Salary}";
        }
    }
}
