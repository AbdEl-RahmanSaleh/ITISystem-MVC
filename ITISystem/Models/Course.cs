using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string CrsName { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();

    }
}
