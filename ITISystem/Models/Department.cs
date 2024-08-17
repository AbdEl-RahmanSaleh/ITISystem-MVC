using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISystem.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote("CheckDeptId", "Department")]
        public int DeptId { get; set; }
        [MaxLength(50)]
        [MinLength(2)]
        [Remote("CheckDeptExist", "Department", AdditionalFields = "DeptId")]
        public string DeptName { get; set; }
        [Range(15,40)]
        public int Capacity { get; set; }
        public bool Active { get; set; }
            

        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();


        public override string ToString()
        {
            return $"{DeptId} :: {DeptName}";
        }

    }
}
