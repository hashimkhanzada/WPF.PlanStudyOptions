using Caliburn.Micro;
using GalaSoft.MvvmLight.Command;
using PlanStudyOptionsLibrary.Data;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PlanStudyOptions.WPF.ViewModels
{
    public class PrintPlanViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        private readonly MajorModel _major;
        private BindableCollection<CourseModel> _printYearOne;
        private BindableCollection<CourseModel> _printYearTwo;
        private BindableCollection<CourseModel> _printYearThree;

        public string UserName
        {
            get
            {
                return Environment.UserName;
            }
        }

        public PrintPlanViewModel(ISqlData sqlData, MajorModel major)
        {
            _sqlData = sqlData;
            _major = major;

            if(major != null)
            {
                PrintYearOne = new BindableCollection<CourseModel>(_sqlData.GetPrintCourses(UserName, major.MajorId, 1));
                PrintYearTwo = new BindableCollection<CourseModel>(_sqlData.GetPrintCourses(UserName, major.MajorId, 2));
                PrintYearThree = new BindableCollection<CourseModel>(_sqlData.GetPrintCourses(UserName, major.MajorId, 3));

                MajorName = _major.Name;
            }
        }

        public string MajorName { get; set; }

        public BindableCollection<CourseModel> PrintYearThree
        {
            get { return _printYearThree; }
            set { _printYearThree = value; }
        }

        public BindableCollection<CourseModel> PrintYearTwo
        {
            get { return _printYearTwo; }
            set { _printYearTwo = value; }
        }

        public BindableCollection<CourseModel> PrintYearOne
        {
            get { return _printYearOne; }
            set { _printYearOne = value; }
        }

        public Grid MainPrint { get; set; }

        public RelayCommand<Visual> PrintCommand
        {
            get
            {
                return new RelayCommand<Visual>(v =>
                {
                    PrintDialog printDlg = new PrintDialog();
                    printDlg.PrintVisual(v, "Grid Printing.");
                });
            }
        }
    }
}
