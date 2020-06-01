using Microsoft.AspNetCore.Mvc;

namespace TestWeb1.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index(){
            return Content("Sono Index");
        }

        public IActionResult Detail(string id){
            return Content($"Sono detail e ho ricevuto l'id {id}");
        }

    }
}