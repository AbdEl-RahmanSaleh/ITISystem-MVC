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


    }
}
