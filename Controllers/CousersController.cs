using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestWeb1.Models.Services.Application;
using TestWeb1.Models.ViewModels;

namespace TestWeb1.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
            
        }
        public IActionResult Index(){
            ViewData["Title"] = "Catalogo dei corsi";
           
            //Ottengo elenco corsi tramite la proprietà GetCourse e lo inserisco in una lista di tipo CourseViewModel
            List<CourseViewModel> courses = courseService.GetCourses();

            //Passo la lista alla View in modo da poterlo presentare in html
            return View(courses);
        }

        public IActionResult Detail(int id){
            
            CourseDetailViewModel viewModel =  courseService.GetCourse(id);

            ViewData["Title"] = viewModel.Title;

            return View(viewModel);
        }

    }
}