CREATE PROCEDURE [dbo].[spCompletedCourse_GetAll]
	@StudentId nvarchar(50)

AS

begin
	set nocount on;

	Select [StudentId], [CourseId]
	FROM CompletedCourses
	WHERE StudentId = @StudentId

end