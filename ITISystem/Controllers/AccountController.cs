using ITISystem.Models;
using ITISystem.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ITISystem.Service.Interfaces;

namespace ITISystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult CheckEmailExist(string email)
        {
            var res = _userService.GetUserByEmail(email);

            if (res != null)
                return Json($"Email is already used");
            return Json(true);
        }
        [HttpPost]
        public IActionResult SignUp(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = registerVM.Email,
                    Password = registerVM.Password,
                    UserName = registerVM.UserName                
                };
                _userService.Add(user);
            }    
            return RedirectToAction("LogIn");
        }
        
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var authenticated = _userService.Login(loginVM);
                if (authenticated)
                {
                    var user = _userService.GetUser(loginVM);
                    Claim c1 = new Claim(ClaimTypes.Name, user.UserName);
                    Claim c2 = new Claim(ClaimTypes.Email, $"{user.Email}");
                    //Claim c3 = new Claim(ClaimTypes.Role, "Student");

                    

                    ClaimsIdentity ci1 = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ci1.AddClaim(c1);
                    ci1.AddClaim(c2);
                    foreach(var role  in user.Roles)
                    {
                        Claim c = new Claim(ClaimTypes.Role, role.Name);
                        ci1.AddClaim(c);
                    }

                    ClaimsPrincipal cp = new ClaimsPrincipal(ci1);

                    await HttpContext.SignInAsync(cp);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is Incorrect");
                    return View();
                }
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("LogIn");
        }

    }
}
