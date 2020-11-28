using Caliburn.Micro;
using PlanStudyOptionsLibrary.Data;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlanStudyOptions.WPF.ViewModels
{
    public class SelectCompletedCoursesViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        private BindableCollection<CourseModel> _allCourses;
        private List<CompletedCourseModel> _completedCourses;

        public BindableCollection<CompletedCourseModel> CompletedCourseModels { get; set; }

        public SelectCompletedCoursesViewModel(ISqlData sqlData)
        {
            _sqlData = sqlData;

            _allCourses = new BindableCollection<CourseModel>(_sqlData.GetAllCourses());
            _completedCourses = new List<CompletedCourseModel>(_sqlData.GetAllCompletedCourses(UserName));


        }

        public string UserName { get {
                return Environment.UserName;
            } }

        public BindableCollection<CourseModel> AllCourses
        {
            get 
            {
                foreach (var ac in _allCourses)
                {
                    foreach (var cc in _completedCourses)
                    {
                        if (ac.CourseId.Contains(cc.CourseId) == true)
                        {
                            ac.IsSelected = true;
                        }
                    }
                }
                return _allCourses;
            }
            set { _allCourses = value; }
        }

        public void AddCourses()
        {
            foreach (var item in _allCourses)
            {
                if (item.IsSelected == true)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = UserName,
                        CourseId = item.CourseId
                    };

                    _sqlData.InsertCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
                else if(item.IsSelected == false)
                {
                    CompletedCourseModel CompletedCourse = new CompletedCourseModel
                    {
                        StudentId = UserName,
                        CourseId = item.CourseId
                    };

                    _sqlData.RemoveCompletedCourse(CompletedCourse.StudentId, CompletedCourse.CourseId);
                }
            }
        }


    }
}
