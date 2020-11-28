using PlanStudyOptionsLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlanStudyOptions.WPF.ViewModels
{
    public class SelectElectivesViewModel
    {
        private readonly ISqlData _sqlData;
        public string UserName { get {
                return Environment.UserName;
            } }

        public SelectElectivesViewModel(ISqlData sqlData)
        {
            _sqlData = sqlData;
        }



    }
}
