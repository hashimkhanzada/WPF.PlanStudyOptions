using Caliburn.Micro;
using PlanStudyOptionsLibrary.Data;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace PlanStudyOptions.WPF.ViewModels
{
    public class SelectFutureCoursesViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        private readonly IEventAggregator _eventAggregator;
        private List<CompletedCourseModel> _completedCourses;
        private BindableCollection<CourseModel> _yearOneCourses;
        private BindableCollection<CourseModel> _yearTwoCourses;
        private BindableCollection<CourseModel> _yearThreeCourses;
        private MajorModel _selectedMajor;

        public BindableCollection<MajorModel> Majors { get; set; }
        
        public SelectFutureCoursesViewModel(ISqlData sqlData, IEventAggregator eventAggregator)
        {
            _sqlData = sqlData;
            _eventAggregator = eventAggregator;
            _yearOneCourses = new BindableCollection<CourseModel>(_sqlData.GetCoursesByYear(1));
            _yearTwoCourses = new BindableCollection<CourseModel>(_sqlData.GetCoursesByYear(2));
            _yearThreeCourses = new BindableCollection<CourseModel>(_sqlData.GetCoursesByYear(3));

            _completedCourses = new List<CompletedCourseModel>(_sqlData.GetAllCompletedCourses(UserName));

            Majors = new BindableCollection<MajorModel>(_sqlData.GetAllMajors());
        }

        public string UserName { get {
                return Environment.UserName;
            } }

        public MajorModel SelectedMajor
        {
            get { return _selectedMajor; }
            set
            { 
                _selectedMajor = value;
                NotifyOfPropertyChange(() => SelectedMajor);
                ShowCoursesByMajor();
            }
        }

        public void ShowCoursesByMajor()
        {
            YearTwoCourses = new BindableCollection<CourseModel>(_sqlData.GetAllCourseOptionsByMajor(SelectedMajor.MajorId, 2));
            YearThreeCourses = new BindableCollection<CourseModel>(_sqlData.GetAllCourseOptionsByMajor(SelectedMajor.MajorId, 3));
        }

        public BindableCollection<CourseModel> YearOneCourses
        {
            get 
            {
                return checkIfCourseCompleted(_yearOneCourses);
            }
            set 
            {
                _yearOneCourses = value;
                NotifyOfPropertyChange(() => YearOneCourses);
            }
        }
        public BindableCollection<CourseModel> YearTwoCourses
        {
            get 
            {
                return checkIfCourseCompleted(_yearTwoCourses);
            }
            set 
            { 
                _yearTwoCourses = value;
                NotifyOfPropertyChange(() => YearTwoCourses);
            }
        }
        public BindableCollection<CourseModel> YearThreeCourses
        {
            get 
            {
                return checkIfCourseCompleted(_yearThreeCourses);

            }
            set 
            { 
                _yearThreeCourses = value;
                NotifyOfPropertyChange(() => YearThreeCourses);
            }
        }

        public void AddCourses()
        {
            if (SelectedMajor != null)
            {
                AddOrDelete(_yearOneCourses);

                AddOrDelete(_yearTwoCourses);

                AddOrDelete(_yearThreeCourses);

                _eventAggregator.PublishOnUIThread(SelectedMajor);
                _eventAggregator.PublishOnUIThread("2");
            }
            else
            {
                MessageBox.Show("Please select a major");
            }
            

        }

        public BindableCollection<CourseModel> checkIfCourseCompleted(BindableCollection<CourseModel> courses)
        {
            foreach (var yo in courses)
            {
                foreach (var cc in _completedCourses)
                {
                    if (yo.CourseId.Contains(cc.CourseId) == true)
                    {
                        yo.IsSelected = true;
                    }
                }
            }

            return courses;
        }

        public void AddOrDelete(BindableCollection<CourseModel> courses)
        {
            //TODO - add validation
            foreach (var item in courses)
            {
                if (item.IsSelected == true)
                {
                    _sqlData.InsertFutureCourse(UserName, item.CourseId, SelectedMajor.MajorId);
                }
                else if (item.IsSelected == false)
                {
                    _sqlData.RemoveFutureCourse(UserName, item.CourseId, SelectedMajor.MajorId);
                }

            }
            
            
        }

    }
}
