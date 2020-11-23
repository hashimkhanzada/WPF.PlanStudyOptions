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
    public class SelectCompletedCoursesViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        public BindableCollection<CourseModel> AllCourses { get; set; }

        public SelectCompletedCoursesViewModel(ISqlData sqlData)
        {
            _sqlData = sqlData;

            AllCourses = new BindableCollection<CourseModel>(_sqlData.GetAllCourses());

        }


    }
}
