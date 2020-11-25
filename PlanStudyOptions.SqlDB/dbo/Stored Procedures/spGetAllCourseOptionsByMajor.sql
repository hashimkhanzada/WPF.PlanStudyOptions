CREATE PROCEDURE [dbo].[spGetAllCourseOptionsByMajor]
	@MajorId nvarchar(50),
    @Year int
AS

begin
	set nocount on;

	SELECT [MajorCourses].[MajorId], [MajorCourses].[CourseId], [Courses].[Name], [Courses].[Year], [Courses].[Semester] 
    FROM [MajorCourses]
    LEFT JOIN [CompletedCourses] ON [MajorCourses].[CourseId] = [CompletedCourses].[CourseId]
    LEFT JOIN [Courses] ON [MajorCourses].[CourseId] = [Courses].[CourseId]  
    WHERE [MajorId] = @MajorId AND [Year] = @Year
    ORDER BY [Semester]

    --[CompletedCourses].[CourseId] IS NULL AND 

end
