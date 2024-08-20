using ITISystem.Models;

namespace ITISystem.Service.Interfaces
{
    public interface IRoleService
    {
        public void Add(Role role);
        public void Update(Role role);
        public Role GetRoleByName(string roleName);
        public Role GetRoleById(int id);
        public void DeleteRole(int id);
        public List<Role> GetRoles();
    }
}
