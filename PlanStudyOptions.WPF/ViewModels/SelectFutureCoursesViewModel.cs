using Caliburn.Micro;
using PlanStudyOptionsLibrary.Data;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanStudyOptions.WPF.ViewModels
{
    public class SelectFutureCoursesViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        private List<CompletedCourseModel> _completedCourses;
        private BindableCollection<CourseModel> _yearOneCourses;
        private BindableCollection<CourseModel> _yearTwoCourses;
        private BindableCollection<CourseModel> _yearThreeCourses;

        public BindableCollection<CompletedCourseModel> CompletedCourseModels { get; set; }

        public SelectFutureCoursesViewModel(ISqlData sqlData)
        {
            _sqlData = sqlData;

            _yearOneCourses = new BindableCollection<CourseModel>(_sqlData.GetCoursesByYear(1));
            _yearTwoCourses = new BindableCollection<CourseModel>(_sqlData.GetCoursesByYear(2));
            _yearThreeCourses = new BindableCollection<CourseModel>(_sqlData.GetCoursesByYear(3));

            _completedCourses = new List<CompletedCourseModel>(_sqlData.GetAllCompletedCourses("1"));
        }

        public BindableCollection<CourseModel> YearOneCourses
        {
            get 
            {
                foreach (var yo in _yearOneCourses)
                {
                    foreach (var cc in _completedCourses)
                    {
                        if (yo.CourseId.Contains(cc.CourseId) == true)
                        {
                            yo.IsSelected = true;
                        }
                    }
                }
                return _yearOneCourses; 
            }
            set { _yearOneCourses = value; }
        }

        public BindableCollection<CourseModel> YearTwoCourses
        {
            get 
            { 
                foreach (var yt in _yearTwoCourses)
                {
                    foreach (var cc in _completedCourses)
                    {
                        if (yt.CourseId.Contains(cc.CourseId) == true)
                        {
                            yt.IsSelected = true;
                        }
                    }
                }
                return _yearTwoCourses;
            }
            set { _yearTwoCourses = value; }
        }

        public BindableCollection<CourseModel> YearThreeCourses
        {
            get 
            {
                foreach (var yth in _yearThreeCourses)
                {
                    foreach (var cc in _completedCourses)
                    {
                        if (yth.CourseId.Contains(cc.CourseId) == true)
                        {
                            yth.IsSelected = true;
                        }
                    }
                }
                return _yearThreeCourses; 

            }
            set { _yearThreeCourses = value; }
        }

        public void AddCourses()
        {
            foreach (var item in _yearOneCourses)
            {
                if (item.IsSelected == true)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = "1",
                        CourseId = item.CourseId
                    };

                    _sqlData.InsertCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
                else if (item.IsSelected == false)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = "1",
                        CourseId = item.CourseId
                    };

                    _sqlData.RemoveCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
            }

            foreach (var item in _yearThreeCourses)
            {
                if (item.IsSelected == true)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = "1",
                        CourseId = item.CourseId
                    };

                    _sqlData.InsertCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
                else if (item.IsSelected == false)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = "1",
                        CourseId = item.CourseId
                    };

                    _sqlData.RemoveCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
            }

            foreach (var item in _yearTwoCourses)
            {
                if (item.IsSelected == true)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = "1",
                        CourseId = item.CourseId
                    };

                    _sqlData.InsertCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
                else if (item.IsSelected == false)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = "1",
                        CourseId = item.CourseId
                    };

                    _sqlData.RemoveCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
            }
        }

    }
}
