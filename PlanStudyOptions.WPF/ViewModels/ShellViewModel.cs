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
    public class ShellViewModel : Conductor<object>
    {
        private readonly ISqlData _sqlData;

        public BindableCollection<string> Pages { get; set; }
        public ShellViewModel(ISqlData sqlData)
        {
            Pages = new BindableCollection<string>
            {
                "Completed Courses",
                "Course Options",
                "*******",
                "Print"
            };

            _sqlData = sqlData;

            ActivateItem(new SelectCompletedCoursesViewModel(sqlData));
            
        }



    }
}
