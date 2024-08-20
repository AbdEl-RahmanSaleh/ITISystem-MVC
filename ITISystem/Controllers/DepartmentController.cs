using ITISystem.Models.Context;
using ITISystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ITISystem.Service.Interfaces;

namespace ITISystem.Controllers
{
    [Authorize(Roles ="Instructor,Admin")]
    public class DepartmentController : Controller
    {
        ITIContext context;
        //DepartmentService departmentService = new DepartmentService();

        IDepartmentService departmentService;
        public DepartmentController(IDepartmentService _departmentService, ITIContext _context)
        {
            departmentService = _departmentService;
            context = _context;
        }
        //public IActionResult MyFun([FromServices]IDepartmentService ds)
        //{
        //    string str = $"{departmentService.GetHashCode()} :: {ds.GetHashCode()}";
        //    return Content(str);
        //}

        public IActionResult Index()
        {
            var Departments = departmentService.GetAll();

            return View(Departments);
        }


        public IActionResult CheckDeptExist(string deptName,int deptId)
        {
            var res = context.Departments.FirstOrDefault(d => d.DeptName == deptName);

            if (res != null && (res.DeptId != deptId && res.DeptName == deptName))
                return Json($"This Department is Already Exists");
            return Json(true);
        }
        
        public IActionResult CheckDeptId(int deptId)
        {
            var res = departmentService.GetById(deptId);

            if (res != null && res.DeptId == deptId)
                return Json($"Invalid Department Id");
            return Json(true);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            Department model = departmentService.GetById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                departmentService.Add(dept);
                //context.Departments.Add(dept);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dept);
        }

        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = departmentService.GetById(id);

            if (department is null)
                return NotFound();


            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department dept)
        {
            Department department = departmentService.GetById(dept.DeptId);

            if (ModelState.IsValid)
            {
                department.DeptName = dept.DeptName;
                department.Capacity = dept.Capacity;
                departmentService.Update(department);
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            Department dept = departmentService.GetById(id);

            if (dept == null)
                return NotFound();

            return View(dept);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id)
        {
            //Department dept = context.Departments.FirstOrDefault(d => d.DeptId == id);
            //if (dept == null)
            //    return NotFound();

            //context.Departments.Remove(dept);
            //context.SaveChanges();

            departmentService.Delete(id);
            return RedirectToAction("Index");

        }


        public IActionResult ShowCourses(int id)
        {
            var model =context.Departments.Include(d => d.Courses).FirstOrDefault(a => a.DeptId ==id);
            return View(model);
        }
        
        public IActionResult ManageCourses(int id)
        {
            var allCourses = context.Courses.ToList();
            var dept =context.Departments.Include(d => d.Courses).FirstOrDefault(a => a.DeptId ==id);
            var crsNotInDept = allCourses.Except(dept.Courses);
            ViewBag.crsInDept = dept.Courses;
            ViewBag.crsNotInDept = crsNotInDept;
            ViewBag.DeptName = dept.DeptName;


            return View();
        }

        [HttpPost]
        public IActionResult ManageCourses(int id,List<int> coursesToRemove , List<int> coursesToAdd)
        {

            var dept = context.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DeptId ==id);
            foreach (int i in coursesToRemove) 
            {
                var crs = context.Courses.FirstOrDefault(c => c.Id == i);
                dept.Courses.Remove(crs);
            }
            
            foreach (int i in coursesToAdd) 
            {
                var crs = context.Courses.FirstOrDefault(c => c.Id == i);
                dept.Courses.Add(crs);
            }

            context.SaveChanges();

            return RedirectToAction(nameof(ShowCourses),new {id = id});
        }

        public IActionResult AddGrade(int deptId , int crsId)
        {
            var dept = context.Departments.Include(d => d.Students).FirstOrDefault(d => d.DeptId == deptId);
            var crs = context.Courses.FirstOrDefault(c => c.Id == crsId);

            ViewBag.crs = crs;

            return View(dept);
        }
        [HttpPost]
        public IActionResult AddGrade(int deptId , int crsId,Dictionary<int, int> deg)
        {
            foreach (var item in deg)
            {
                var stdcrs = context.StudentCourses.FirstOrDefault(s => s.CourseId == crsId && s.StudentId == item.Key);
                if (stdcrs == null)
                {
                    context.StudentCourses.Add(new StudentCourse() { CourseId = crsId, StudentId = item.Key, Grade = item.Value });
                }
                else
                {
                    stdcrs.Grade = item.Value;  
                }
            }
            context.SaveChanges();
            return Content("Added");
        }
    }
}
