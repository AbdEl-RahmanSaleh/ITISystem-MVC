using ITISystem.Models;
using ITISystem.Models.Context;
using ITISystem.Service;
using ITISystem.Service.Interfaces;
using ITISystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITISystem.Controllers
{
    [Authorize(Roles ="Student,Admin")]
    public class StudentController : Controller
    {

        ITIContext context ;
        IDepartmentService departmentService ;
        IStudentService studentService;

        public StudentController(IDepartmentService _departmentService,IStudentService _studentService,ITIContext _context)
        {
            studentService = _studentService;
            departmentService = _departmentService;
            context = _context;
        }
        public IActionResult Index()
        {
            var students = studentService.GetAll() ;
            return View(students);
        }

        public IActionResult Details(int? id) {
            if (id == null)
                return BadRequest();
            Student model = studentService.GetById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std) 
        {
            if (ModelState.IsValid)
            {
                std.ImgUrl = await DocumentSettings.UploadFile(std.stdImg);
                studentService.Add(std);
                //context.SaveChanges();
                return RedirectToAction("Index");   
            }
            else
            {
                ViewBag.Departments = departmentService.GetAll();
                return View(std);
            }
        }

        public IActionResult CheckEmailExist(string email,string name,int age,int id)
        {
            var res = context.Students.FirstOrDefault(s => s.Email == email);
            
            if (res != null && res.Id != id)
                return Json($"Email is not Valid you can use {name}{age}@iti.com");
            return Json(true);
        }



        public IActionResult Update(int? id) 
        {
            if (id == null)
                return BadRequest();
            Student std = studentService.GetById(id);

            if(std == null)
                return NotFound();

            var depts = departmentService.GetAll();
            ViewBag.Departments = depts;
            return View(std);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student newStd)
        {
           Student currentStd = studentService.GetById(newStd.Id);
            if (ModelState.IsValid)
            {
                currentStd.Name = newStd.Name;
                currentStd.Age = newStd.Age;
                currentStd.Gender = newStd.Gender;
                currentStd.Password = newStd.Password;
                currentStd.deptId = newStd.deptId;
                currentStd.Email = newStd.Email;
                if (newStd.stdImg is not null)
                {
                    currentStd.ImgUrl = await DocumentSettings.UploadFile(newStd.stdImg);
                }

                studentService.Update(currentStd);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var depts = departmentService.GetAll();
                ViewBag.Departments = depts;
                return View(newStd);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std = studentService.GetById(id);

            if (std == null)
                return NotFound();

           return View(std);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id) 
        {
            //Student std = studentService.GetById(id);
            //if (std == null)
            //    return NotFound();

            studentService.Delete(id);
            //context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
