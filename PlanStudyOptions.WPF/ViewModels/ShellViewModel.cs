﻿using Caliburn.Micro;
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
        }

        public void LoadPage() 
        {
            if (SelectedPage != null && !string.IsNullOrWhiteSpace(SelectedPage))
            {
                switch(SelectedPage)
                {
                    case "0":
                        ActivateItem(new SelectCompletedCoursesViewModel(_sqlData));
                        break;
                    case "1":
                        ActivateItem(new SelectFutureCoursesViewModel(_sqlData, _eventAggregator));
                        break;
                    case "2":
                        ActivateItem(new SelectElectivesViewModel(_sqlData, ChosenMajor));
                        break;
                    case "3":
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
