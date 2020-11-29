using Caliburn.Micro;
using PlanStudyOptionsLibrary.Data;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            }
        }

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

        public void PrintPage()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(MainPrint, "invoice");
            }
        }
        //TODO - get all future courses, allow removing
    }
}
