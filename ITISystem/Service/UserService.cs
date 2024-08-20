using ITISystem.Models;
using ITISystem.Models.Context;
using ITISystem.Service.Interfaces;
using ITISystem.ViewModels;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ITISystem.Service
{
    public class UserService : IUserService
    {
        private readonly ITIContext db;
        IRoleService _roleService;
        public UserService(IRoleService roleService , ITIContext _db)
        {
            _roleService = roleService;
            db = _db;
        }

        public void Add(User user)
        {
            user.Password = user.Password.ToSHA256String();
            db.Add(user);
            db.SaveChanges();
        }

        public bool Login(LoginViewModel loginUser)
        {
            User user = db.Users.SingleOrDefault(u => u.Email == loginUser.Email);
            var userPass = loginUser.Password.ToSHA256String();
            if (user != null && user.Password == userPass)
            {
                return true;
            }
            return false;
        }
        
        public User GetUser(LoginViewModel loginUser)
        {
            User user = db.Users.Include(u => u.Roles).SingleOrDefault(u => u.Email == loginUser.Email);
            var userPass = loginUser.Password.ToSHA256String();
            if (user != null && user.Password == userPass)
            {
                return user;
            }
            return null;
        }
        
        public User GetUserById(int id)
        {
            User user = db.Users.Include(u => u.Roles).SingleOrDefault(u => u.Id == id);
                return user;
        }

        
        
        public User GetUserByEmail(string email)
        {
            User user = db.Users.SingleOrDefault(u => u.Email == email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public List<User> GetUsers()
        {
           return db.Users.Include(u => u.Roles).ToList();
        }

        public void AddRoleToUser(int userId,int roleId)
        {
            var user = GetUserById(userId);
            Role role = _roleService.GetRoleById(roleId);
            user.Roles.Add(role);
            db.SaveChanges();

        }
        public void RemoveFromRole(int userId,int roleId)
        {
            var user = GetUserById(userId);
            Role role = _roleService.GetRoleById(roleId);
            user.Roles.Remove(role);
            db.SaveChanges();

        }
    }
}
