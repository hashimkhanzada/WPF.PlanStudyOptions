using PlanStudyOptionsLibrary.Models;
using System.Collections.Generic;

namespace PlanStudyOptionsLibrary.Data
{
    public interface ISqlData
    {
        List<CourseModel> GetAllCourses();
        void InsertCompletedCourse(string StudentId, string CourseId);
        void RemoveCompletedCourse(string StudentId, string CourseId);
        List<CompletedCourseModel> GetAllCompletedCourses(string StudentId);
    }
}