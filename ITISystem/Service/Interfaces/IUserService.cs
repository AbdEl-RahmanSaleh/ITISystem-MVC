using ITISystem.Models;
using ITISystem.ViewModels;

namespace ITISystem.Service.Interfaces
{
    public interface IUserService
    {
        public void Add(User user);
        public User GetUserById(int id);
        public List<User> GetUsers();
        public bool Login(LoginViewModel loginUser);

        public User GetUser(LoginViewModel loginUser);
        public User GetUserByEmail(string email);
        public void AddRoleToUser(int userId, int roleId);
        public void RemoveFromRole(int userId, int roleId);

    }
}
