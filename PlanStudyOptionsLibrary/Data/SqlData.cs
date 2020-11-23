using PlanStudyOptionsLibrary.Databases;
using PlanStudyOptionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            return _db.LoadData<CourseModel, dynamic>("select * from dbo.Courses",
                                                 new { },
                                                 connectionStringName,
                                                 false);
        }
    }
}
