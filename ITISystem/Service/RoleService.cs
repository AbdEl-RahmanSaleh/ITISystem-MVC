using ITISystem.Models;
using ITISystem.Models.Context;
using ITISystem.Service.Interfaces;

namespace ITISystem.Service
{
    public class RoleService : IRoleService
    {
        private readonly ITIContext db;

        public RoleService(ITIContext _db)
        {
            db = _db;
        }
        public void Add(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public Role GetRoleById(int id)
            => db.Roles.SingleOrDefault(x => x.Id == id);
        public Role GetRoleByName(string name) => db.Roles.FirstOrDefault(x => x.Name == name);
        public List<Role> GetRoles() => db.Roles.ToList();
        public void DeleteRole(int id) 
        {
            Role role = GetRoleById(id);
            db.Roles.Remove(role);
            db.SaveChanges();
        }
        public void Update(Role role)
        {
            db.Roles.Update(role);
            db.SaveChanges();
        }



    }
}
