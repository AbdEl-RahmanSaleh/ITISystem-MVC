using ITISystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ITISystem.Controllers
{
    public class TestController : Controller
    {
        public string display()
        {
            return "Hello MVC";
        }
        public int Add(int x,int y)
        {
            return x + y;
        }
        public ViewResult Show()
        {
            return View();
        }



        public IActionResult ReadArray() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ReadArray(string[] arr,IFormFile img)
        {
            var imgUrl = await DocumentSettings.UploadFile(img);
            Console.WriteLine(imgUrl);

            string s = "";
            foreach (string str in arr)
            {
                s += str;
            }
            ViewBag.name = s;
            ViewBag.image = imgUrl;
            return View("show2");
        }


        public IActionResult ReadDic()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReadDic(Dictionary<string,int> arr) 
        {
            return View();
        }

        //Cookies
        public IActionResult AddData(int id , string name)
        {

            CookieOptions cop = new CookieOptions() { Expires = DateTime.Now.AddMinutes(1)};
            Response.Cookies.Append("sid", id.ToString(),cop);
            Response.Cookies.Append("sname", name, cop);

            return Content($"{id} :: {name}");
        }    
        public IActionResult ReadData()
        {
            int id = int.Parse(Request.Cookies["sid"]);
            string name = Request.Cookies["sname"];
            return Content($"{id} :: {name}");
        }    
        
        //Session
        public IActionResult AddData2(int id , string name)
        {

            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);

            return Content($"{id} :: {name}");
        }    
        public IActionResult ReadData2()
        {
            //HttpContext.Session.Clear();
            int? id = HttpContext.Session.GetInt32("id");
            string name = HttpContext.Session.GetString("name");
            return Content($"{id} :: {name}");
        }    
    }
}
