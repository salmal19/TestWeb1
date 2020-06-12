using System;
using System.Collections.Generic;
using System.Data;
using TestWeb1.Models.Services.Infrastructure;
using TestWeb1.Models.ViewModels;

namespace TestWeb1.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetCourseService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public List<CourseViewModel> GetCourses(){
            FormattableString query = $"SELECT Id,Title,ImagePath,Author,Rating,FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses";
            DataSet dataSet = db.Query(query);
            var dataTable = dataSet.Tables[0];
            var courseList = new List<CourseViewModel>();
            foreach(DataRow courseRow in dataTable.Rows){
                 var course = CourseViewModel.FromDataRow(courseRow);
                 courseList.Add(course);
            }
            return courseList;
        }

        public CourseDetailViewModel GetCourse(int id){
            FormattableString query = $@"SELECT Id,Title,Description,ImagePath,Author,Rating,FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses WHERE Id={id}  
            ; SELECT Id,Title,Description,Duration FROM Lessons WHERE CourseId={id}";

            DataSet dataSet = db.Query(query);

            //Course
            var courseTable = dataSet.Tables[0];
            if(courseTable.Rows.Count !=1){
                throw new InvalidOperationException($"Non ci sono valori per il corso{id}");
            }
            var couseRow = courseTable.Rows[0];
            var courseDetailViewModel = CourseDetailViewModel.FromDataRow(couseRow);

            //Couse Lessons
            var lessonDataTable = dataSet.Tables[1];

            foreach (DataRow lessonRow in lessonDataTable.Rows)
            {
                LessonViewModel lessonViewModel = LessonViewModel.FromDataRow(lessonRow);
                courseDetailViewModel.Lessons.Add(lessonViewModel);
            }
            return courseDetailViewModel;
        }
    }
}