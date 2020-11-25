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
