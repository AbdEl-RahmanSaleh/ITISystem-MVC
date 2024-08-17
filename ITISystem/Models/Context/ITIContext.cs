using Microsoft.EntityFrameworkCore;

namespace ITISystem.Models.Context
{
    public class ITIContext : DbContext
    {
        //public ITIContext(DbContextOptions options) : base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(PK => new { PK.StudentId, PK.CourseId });

            modelBuilder.Entity<InstructorCourse>().HasKey(PK => new { PK.InstructorId, PK.CourseId });


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=ITISystemMVC;Integrated security=sspi;trustservercertificate=true;encrypt=true");

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; }
    }
}
