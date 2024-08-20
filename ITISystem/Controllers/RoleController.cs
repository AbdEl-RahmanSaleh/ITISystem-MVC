using ITISystem.Models;
using ITISystem.Service;
using ITISystem.Service.Interfaces;
using ITISystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var roles = _roleService.GetRoles();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public IActionResult Delete(int id)
        {
            _roleService.DeleteRole(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id, string viewName = "Details")
        {
            if (id == null)
                return BadRequest();
            Role role = _roleService.GetRoleById(id);
            if (role == null)
                return NotFound();

            return View(viewName, role);
        }


        public IActionResult Update(int id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, Role role)
        {
            if (id != role.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _roleService.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);

        }

        public IActionResult AddOrRemoveUsers(int roleId)
        {
            var role =  _roleService.GetRoleById(roleId);

            if (role == null)
                return BadRequest();

            ViewBag.RoleId = roleId;
            ViewBag.RoleName = role.Name;

            var usersInRole = new List<UserInRoleViewModel>();

            foreach (var user in _userService.GetUsers())
            {
                var userInRole = new UserInRoleViewModel
                {
                    UserName = user.UserName,
                    UserId = user.Id,
                };

                

                if ( user.Roles.Any(u => u.Id == roleId))
                    userInRole.IsSelected = true;
                else
                    userInRole.IsSelected = false;

                usersInRole.Add(userInRole);

            }

            return View(usersInRole);
        }
        [HttpPost]
        public IActionResult AddOrRemoveUsers(List<UserInRoleViewModel> users, int roleId)
        {
            var role =  _roleService.GetRoleById(roleId);

            if (role == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    var appUser = _userService.GetUserById(user.UserId);

                    if (appUser != null)
                    {
                        if (user.IsSelected && !(appUser.Roles.Any(u => u.Id == role.Id)))
                             _userService.AddRoleToUser(appUser.Id, role.Id);
                        else if (!user.IsSelected && (appUser.Roles.Any(u => u.Id == role.Id)))
                             _userService.RemoveFromRole(appUser.Id, role.Id);
                    }
                }
                return RedirectToAction(nameof(Update), new { id = roleId });
            }
            return View(users);
        }
    }
}