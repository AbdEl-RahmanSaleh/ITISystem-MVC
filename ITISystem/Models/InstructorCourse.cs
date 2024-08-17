using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISystem.Models
{
    public class InstructorCourse
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        [Column(TypeName = "varchar")]
        public string Evaluation { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
