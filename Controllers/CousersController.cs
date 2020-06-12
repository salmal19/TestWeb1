using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index(){
            ViewData["Title"] = "Catalogo dei corsi";
           
            //Ottengo elenco corsi tramite la proprietà GetCourse e lo inserisco in una lista di tipo CourseViewModel
            List<CourseViewModel> courses = await courseService.GetCoursesAsync();

            //Passo la lista alla View in modo da poterlo presentare in html
            return View(courses);
        }

        public async Task<IActionResult> Detail(int id){
            
            CourseDetailViewModel viewModel =  await courseService.GetCourseAsync(id);

            ViewData["Title"] = viewModel.Title;

            return View(viewModel);
        }

    }
}