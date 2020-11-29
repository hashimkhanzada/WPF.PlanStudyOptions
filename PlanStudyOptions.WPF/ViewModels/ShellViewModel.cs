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
    public class ShellViewModel : Conductor<object>, IHandle<MajorModel>
    {
        private readonly ISqlData _sqlData;
        private readonly IEventAggregator _eventAggregator;

        public BindableCollection<string> Pages { get; set; }
        private string _selectedPage;
        private MajorModel _chosenMajor;

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

            _eventAggregator.Subscribe(this);
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
                        ActivateItem(new SelectElectivesViewModel(_sqlData, ChosenMajor));
                        break;
                    case "Print":
                        ActivateItem(new PrintPlanViewModel(_sqlData, ChosenMajor));
                        break;
                }
            }
        }

        public void Handle(MajorModel message)
        {
            ChosenMajor = message;
        }

        public MajorModel ChosenMajor
        {
            get { return _chosenMajor; }
            set 
            { 
                _chosenMajor = value;
                NotifyOfPropertyChange(() => ChosenMajor);
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
