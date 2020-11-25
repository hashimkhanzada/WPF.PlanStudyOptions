CREATE PROCEDURE [dbo].[spFutureCourse_Delete]
	@StudentId nvarchar(50),
	@CourseId nvarchar(50),
	@MajorId nvarchar(50)

AS
if exists (select 1 from dbo.FutureCourses Where StudentId = @StudentId AND CourseId = @CourseId)
begin
	set nocount on;

	Delete FROM FutureCourses
	Where StudentId = @StudentId AND CourseId = @CourseId

end