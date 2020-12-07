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
    public class ShellViewModel : Conductor<object>, IHandle<MajorModel>, IHandle<string>
    {
        private readonly ISqlData _sqlData;
        private readonly IEventAggregator _eventAggregator;

        public string UserName
        {
            get
            {
                return Environment.UserName;
            }
        }

        private string _selectedPage;
        private MajorModel _chosenMajor;

        public ShellViewModel(ISqlData sqlData, IEventAggregator eventAggregator)
        {

            _sqlData = sqlData;
            _eventAggregator = eventAggregator;
            
            _eventAggregator.Subscribe(this);

            SelectedPage = "0";
            LoadPage();
        }

        public void LoadPage() 
        {
            if (SelectedPage != null && !string.IsNullOrWhiteSpace(SelectedPage))
            {
                switch(SelectedPage)
                {
                    case "0":
                        ActivateItem(new SelectCompletedCoursesViewModel(_sqlData, _eventAggregator));
                        break;
                    case "1":
                        ActivateItem(new SelectFutureCoursesViewModel(_sqlData, _eventAggregator));
                        break;
                    case "2":
                        if(ChosenMajor != null)
                        {
                            ActivateItem(new SelectElectivesViewModel(_sqlData, _eventAggregator, ChosenMajor));
                            
                        } else
                        {
                            MessageBox.Show("Please select a major");
                        }
                        break;
                    case "3":
                        if (ChosenMajor != null)
                        {
                        ActivateItem(new PrintPlanViewModel(_sqlData, ChosenMajor));
                        } else
                        {
                            MessageBox.Show("Please select a major");
                        }
                        break;
                }
            }
        }

        public void Handle(MajorModel message)
        {
            ChosenMajor = message;
        }

        public void Handle(string message)
        {
            SelectedPage = message;
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
