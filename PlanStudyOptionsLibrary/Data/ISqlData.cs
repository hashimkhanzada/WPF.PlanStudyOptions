using PlanStudyOptionsLibrary.Models;
using System.Collections.Generic;

namespace PlanStudyOptionsLibrary.Data
{
    public interface ISqlData
    {
        List<CourseModel> GetAllCourses();
    }
}