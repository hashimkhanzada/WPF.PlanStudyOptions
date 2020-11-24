CREATE PROCEDURE [dbo].[spCompletedCourse_GetAll]
	@StudentId nvarchar(50)

AS

begin
	set nocount on;

	Select [CompletedCourses].[StudentId], [CompletedCourses].[CourseId], [Courses].[Name]
	FROM CompletedCourses
	INNER JOIN Courses ON CompletedCourses.CourseId = Courses.CourseId 
	WHERE StudentId = @StudentId

end