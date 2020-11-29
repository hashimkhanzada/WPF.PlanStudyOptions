using Dapper;
using PlanStudyOptionsLibrary.Databases;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanStudyOptionsLibrary.Data
{
    public class SqlData : ISqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<CourseModel> GetAllCourses()
        {
            return _db.LoadData<CourseModel, dynamic>("select * from dbo.Courses " +
                                                      "order by Year, Semester",
                                                 new { },
                                                 connectionStringName,
                                                 false);
        }

        public List<CourseModel> GetCoursesByYear(int Year)
        {
            return _db.LoadData<CourseModel, dynamic>("dbo.spGetCoursesByYear",
                                                 new {
                                                     Year
                                                 },
                                                 connectionStringName,
                                                 true);
        }

        public List<CompletedCourseModel> GetAllCompletedCourses(string StudentId)
        {
            return _db.LoadData<CompletedCourseModel, dynamic>("dbo.spCompletedCourse_GetAll",
                                                 new {
                                                     StudentId
                                                 },
                                                 connectionStringName,
                                                 true);
        }

        public List<MajorModel> GetAllMajors()
        {
            return _db.LoadData<MajorModel, dynamic>("select * from dbo.Majors ",
                                                 new { },
                                                 connectionStringName,
                                                 false);
        }



        
        public List<CourseModel> GetAllCourseOptionsByMajor(string MajorId, int Year)
        {
            return _db.LoadData<CourseModel, dynamic>("dbo.spGetAllCourseOptionsByMajor",
                                                 new
                                                 {
                                                     MajorId,
                                                     Year
                                                 },
                                                 connectionStringName,
                                                 true); ;
        }

        public List<CourseModel> GetAllElectiveCourses(string StudentId)
        {
            return _db.LoadData<CourseModel, dynamic>("dbo.spGetAllElectiveCourses",
                                                 new
                                                 {
                                                     StudentId
                                                 },
                                                 connectionStringName,
                                                 true); ;
        }

        public List<int> GetCreditsCompleted(string StudentId, string MajorId)
        {
            return _db.LoadData<int, dynamic>("SELECT SUM(Credits) FROM FutureCourses " +
                                              "INNER JOIN Courses ON FutureCourses.CourseId = Courses.CourseId WHERE StudentId = @StudentId AND MajorId = @MajorId",
                                                 new
                                                 {
                                                     StudentId,
                                                     MajorId
                                                 },
                                                 connectionStringName,
                                                 false); ;
        }

        //
        public List<CourseModel> GetSelectedFutureCourses(string StudentId, string MajorId)
        {
            return _db.LoadData<CourseModel, dynamic>("SELECT * FROM FutureCourses"
                                                      + " INNER JOIN Courses ON FutureCourses.CourseId = Courses.CourseId WHERE StudentId = @StudentId AND MajorId = @MajorId",
                                                 new
                                                 {
                                                     StudentId,
                                                     MajorId
                                                 },
                                                 connectionStringName,
                                                 false); ;
        }

        public List<CourseModel> GetPrintCourses(string StudentId, string MajorId, int Year)
        {
            return _db.LoadData<CourseModel, dynamic>("SELECT * FROM FutureCourses"
                                                      + " INNER JOIN Courses ON FutureCourses.CourseId = Courses.CourseId " +
                                                      "WHERE StudentId = @StudentId AND MajorId = @MajorId AND Year = @Year",
                                                 new
                                                 {
                                                     StudentId,
                                                     MajorId,
                                                     Year
                                                 },
                                                 connectionStringName,
                                                 false); ;
        }

        public List<int> GetCreditsDue(string StudentId, string MajorId)
        {
            return _db.LoadData<int, dynamic>("SELECT SUM(Credits) FROM Courses "
                                              + "WHERE CourseId Not in ( "
                                              + "SELECT FutureCourses.CourseId FROM FutureCourses INNER JOIN Courses ON FutureCourses.CourseId = Courses.CourseId WHERE StudentId = @StudentId AND MajorId = @MajorId"
                                              + " )",
                                                 new
                                                 {
                                                     StudentId,
                                                     MajorId
                                                 },
                                                 connectionStringName,
                                                 false); ;
        }

        public void InsertCompletedCourse(string StudentId, string CourseId)
        {
            _db.SaveData("dbo.spCompletedCourse_Insert",
                                       new
                                       {
                                           StudentId,
                                           CourseId
                                       },
                                       connectionStringName,
                                                 true);



        }

        public void RemoveCompletedCourse(string StudentId, string CourseId)
        {
            _db.SaveData("dbo.spCompletedCourse_Delete",
                                       new
                                       {
                                           StudentId,
                                           CourseId
                                       },
                                       connectionStringName,
                                                 true);



        }

        public void InsertFutureCourse(string StudentId, string CourseId, string MajorId)
        {
            _db.SaveData("dbo.spFutureCourse_Insert",
                                       new
                                       {
                                           StudentId,
                                           CourseId,
                                           MajorId
                                       },
                                       connectionStringName,
                                                 true);



        }

        public void RemoveFutureCourse(string StudentId, string CourseId, string MajorId)
        {
            _db.SaveData("dbo.spFutureCourse_Delete",
                                       new
                                       {
                                           StudentId,
                                           CourseId,
                                           MajorId
                                       },
                                       connectionStringName,
                                                 true);



        }

    }
}
