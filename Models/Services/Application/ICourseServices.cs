using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb1.Models.ViewModels;

namespace TestWeb1{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetCoursesAsync();
        Task<CourseDetailViewModel> GetCourseAsync(int id);
    }
}