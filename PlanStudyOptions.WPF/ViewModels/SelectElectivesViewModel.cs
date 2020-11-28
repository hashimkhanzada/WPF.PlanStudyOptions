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
    public class SelectElectivesViewModel : Screen, IHandle<MajorModel>
    {
        private readonly ISqlData _sqlData;
        private readonly IEventAggregator _eventAggregator;

        public string UserName { get {
                return Environment.UserName;
            } }

        private BindableCollection<CourseModel> _electiveCourses;
        private int _creditsCompleted;
        private int _creditsDue;
        private static string _majorId;
        private List<CompletedCourseModel> _completedCourses;

        public SelectElectivesViewModel(ISqlData sqlData, IEventAggregator eventAggregator)
        {
            _sqlData = sqlData;
            _eventAggregator = eventAggregator;
            _electiveCourses = new BindableCollection<CourseModel>(_sqlData.GetAllElectiveCourses(UserName));
            _completedCourses = new List<CompletedCourseModel>(_sqlData.GetAllCompletedCourses(UserName)); // future courses already added

            if (MajorId != null)
            {
                _creditsCompleted = _sqlData.GetCreditsCompleted(UserName, MajorId).FirstOrDefault();
                _creditsDue = 180;
            }

            //TODO - 
            _eventAggregator.Subscribe(this);
        }

        public static string MajorId
        {
            get { return _majorId; }
            set { _majorId = value; }
        }
        public static string MajorName { get; set; }

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
            set { _electiveCourses = value; }
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

        public void Handle(MajorModel message)
        {
            MajorId = message.MajorId;
            MajorName = message.Name;
        }
    }
}
