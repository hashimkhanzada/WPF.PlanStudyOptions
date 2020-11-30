using Caliburn.Micro;
using PlanStudyOptionsLibrary.Data;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlanStudyOptions.WPF.ViewModels
{
    public class SelectElectivesViewModel : Screen
    {
        private readonly ISqlData _sqlData;
        private readonly MajorModel _major;

        public string UserName { get {
                return Environment.UserName;
            } }

        private BindableCollection<CourseModel> _electiveCourses;
        private int _creditsCompleted;
        private int _creditsDue;
        private List<CompletedCourseModel> _completedCourses;

        public SelectElectivesViewModel(ISqlData sqlData, MajorModel major)
        {
            _sqlData = sqlData;
            _major = major;
            
            if (major != null)
            {
                _electiveCourses = new BindableCollection<CourseModel>(_sqlData.GetAllElectiveCourses(UserName));
                _completedCourses = new List<CompletedCourseModel>(_sqlData.GetAllCompletedCourses(UserName));

                _creditsCompleted = _sqlData.GetCreditsCompleted(UserName, _major.MajorId).FirstOrDefault();
                _creditsDue = 360;
                MajorName = _major.Name;
            }
        }

        public string MajorName { get; set; }

        public int CreditsDue
        {
            get { return _creditsDue; }
            set 
            {
                _creditsDue = value;
                NotifyOfPropertyChange(() => CreditsDue);
            }
        }

        public int CreditsCompleted
        {
            get { return _creditsCompleted; }
            set 
            { 
                _creditsCompleted = value;
                NotifyOfPropertyChange(() => CreditsCompleted);
            }
        }

        public BindableCollection<CourseModel> ElectiveCourses
        {
            get { return checkIfCourseCompleted(_electiveCourses); }
            set
            {
                _electiveCourses = value;
                NotifyOfPropertyChange(() => ElectiveCourses);
            }
        }

        public BindableCollection<CourseModel> checkIfCourseCompleted(BindableCollection<CourseModel> courses)
        {
            //TODO - error if major not selected
            foreach (var course in courses)
            {
                foreach (var cc in _completedCourses)
                {
                    if (course.CourseId.Contains(cc.CourseId) == true)
                    {
                        course.IsSelected = true;
                    }
                }
            }

            return courses;
        }

        public void AddCourses()
        {
            AddOrDelete(_electiveCourses);
            if(_creditsCompleted < 360)
            {
                ElectiveCourses = new BindableCollection<CourseModel>(_sqlData.GetAllElectiveCourses(UserName));
                CreditsCompleted = _sqlData.GetCreditsCompleted(UserName, _major.MajorId).FirstOrDefault();
            }
        }

        public void AddOrDelete(BindableCollection<CourseModel> courses)
        {
            //TODO - add validation
            foreach (var item in courses)
            {
                if (item.IsSelected == true)
                {
                    _sqlData.InsertFutureCourse(UserName, item.CourseId, _major.MajorId);
                }
                else if (item.IsSelected == false)
                {
                    _sqlData.RemoveFutureCourse(UserName, item.CourseId, _major.MajorId);
                }
            }
        }

    }
}
