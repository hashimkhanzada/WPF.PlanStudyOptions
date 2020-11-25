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
        List<MajorModel> GetAllMajors();
        List<CourseModel> GetCoursesByYear(int Year);
        /// <summary>
        /// Gets all the subjects needed to complete the specified major
        /// </summary>
        /// <param name="MajorId"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        List<CourseModel> GetAllCourseOptionsByMajor(string MajorId, int Year);
        void InsertFutureCourse(string StudentId, string CourseId, string MajorId);
        void RemoveFutureCourse(string StudentId, string CourseId, string MajorId);
    }
}