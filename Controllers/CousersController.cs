using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestWeb1.Models.Services.Application;
using TestWeb1.Models.ViewModels;

namespace TestWeb1.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index(){
            ViewData["Title"] = "Catalogo dei corsi";
            //Creo istanza del serivizio applicativo CourseService
            var courseService = new CourseService();
            
            //Ottengo elenco corsi e lo inserisco in una lista di tipo CourseViewModel
            List<CourseViewModel> courses = courseService.GetCourses();

            //Passo la lista alla View in modo da poterlo presentare in html
            return View(courses);
        }

        public IActionResult Detail(int id){
            var courseService = new CourseService();
            CourseDetailViewModel viewModel =  courseService.GetCourse(id);
            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
        }

    }
}