using ITISystem.Models;
using ITISystem.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace ITISystem.Service
{
    public class StudentService : IStudentService
    {
        ITIContext context = new ITIContext();


        public List<Student> GetAll() 
            => context.Students.Include(s => s.department).ToList();

        public Student GetById(int? id)
            => context.Students.Include(s=>s.department).SingleOrDefault(s => s.Id == id);

        
        public void Add(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
        }
        public void Update(Student std)
        {
            context.Students.Update(std);
            context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var std = context.Students.FirstOrDefault(s => s.Id == id);
            context.Students.Remove(std);
            context.SaveChanges();
        }
    }
}
