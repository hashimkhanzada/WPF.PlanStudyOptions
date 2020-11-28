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
    public class ShellViewModel : Conductor<object>
    {
        private readonly ISqlData _sqlData;
        private readonly IEventAggregator _eventAggregator;

        public BindableCollection<string> Pages { get; set; }
        private string _selectedPage;

        public ShellViewModel(ISqlData sqlData, IEventAggregator eventAggregator)
        {
            Pages = new BindableCollection<string>
            {
                "Completed Courses",
                "Majors",
                "Electives",
                "Print"
            };

            _sqlData = sqlData;
            _eventAggregator = eventAggregator;
        }

        public void LoadPage() 
        {
            if (SelectedPage != null && !string.IsNullOrWhiteSpace(SelectedPage))
            {
                switch(SelectedPage)
                {
                    case "Completed Courses":
                        ActivateItem(new SelectCompletedCoursesViewModel(_sqlData));
                        break;
                    case "Majors":
                        ActivateItem(new SelectFutureCoursesViewModel(_sqlData, _eventAggregator));
                        break;
                    case "Electives":
                        ActivateItem(new SelectElectivesViewModel(_sqlData, _eventAggregator));
                        break;
                        //TODO - add print
                }
            }
        }

        public string SelectedPage
        {
            get { return _selectedPage; }
            set 
            {
                _selectedPage = value;
                NotifyOfPropertyChange(() => SelectedPage);
                LoadPage();
            }
        }



    }
}
