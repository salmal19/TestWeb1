using System;
using System.Collections.Generic;
using TestWeb1.Models.ViewModels;

namespace TestWeb1{
    public interface ICourseService
    {
        List<CourseViewModel> GetCourses();
        CourseDetailViewModel GetCourse(int id);
    }
}