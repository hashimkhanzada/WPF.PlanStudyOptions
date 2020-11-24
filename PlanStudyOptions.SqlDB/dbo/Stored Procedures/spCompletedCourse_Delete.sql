CREATE PROCEDURE [dbo].[spCompletedCourse_Delete]
	@StudentId nvarchar(50),
	@CourseId nvarchar(50)

AS
if exists (select 1 from dbo.CompletedCourses Where StudentId = @StudentId AND CourseId = @CourseId)
begin
	set nocount on;

	Delete FROM CompletedCourses
	Where StudentId = @StudentId AND CourseId = @CourseId

end