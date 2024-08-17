using ITISystem.Models;
using ITISystem.Models.Context;

namespace ITISystem.Service
{
    public class DepartmentService : IDepartmentService
    {
        ITIContext context = new ITIContext();


        public List<Department> GetAll()
            => context.Departments.Where(d => d.Active == true).ToList();

        public Department GetById(int? id)
          => context.Departments.SingleOrDefault(d => d.DeptId == id);


        public void Add(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }
        public void Update(Department dept)
        {
            context.Departments.Update(dept);
            context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var dept = context.Departments.FirstOrDefault(d => d.DeptId == id);
            dept.Active = false;
            //context.Departments.Remove(dept);
            context.SaveChanges();
        }


    }

    //public class DepartmentService2 : IDepartmentService
    //{
    //    List<Department> departments = [
    //        new Department(){DeptId = 1,DeptName ="Hamada",Capacity = 5 , Active = true}
    //        ,new Department(){DeptId = 2,DeptName ="Hamada2",Capacity = 5 , Active = true}
    //        ];

    //    public void Add(Department dept)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int? id)
    //    {
    //        var dept = departments.FirstOrDefault(d => d.DeptId == id);
    //        departments.Remove(dept);
    //    }

    //    public List<Department> GetAll() => departments;

    //    public Department GetById(int? id)
    //    {
    //        var dept = departments.FirstOrDefault(d => d.DeptId == id);
    //        return dept;
    //    }

    //    public void Update(Department dept)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
