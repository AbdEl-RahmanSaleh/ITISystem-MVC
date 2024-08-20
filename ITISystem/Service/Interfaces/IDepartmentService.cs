using ITISystem.Models;

namespace ITISystem.Service.Interfaces
{
    public interface IDepartmentService
    {
        public List<Department> GetAll();
        public Department GetById(int? id);
        public void Add(Department dept);
        public void Update(Department dept);
        public void Delete(int? id);
    }
}
