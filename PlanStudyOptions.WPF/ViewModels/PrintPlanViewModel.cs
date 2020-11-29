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
    public class PrintPlanViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        private readonly MajorModel _major;

        public PrintPlanViewModel(ISqlData sqlData, MajorModel major)
        {
            _sqlData = sqlData;
            _major = major;
        }
    }
}
