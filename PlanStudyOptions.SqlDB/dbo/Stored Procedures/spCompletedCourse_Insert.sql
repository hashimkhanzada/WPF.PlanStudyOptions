CREATE PROCEDURE [dbo].[spCompletedCourse_Insert]
	@StudentId nvarchar(50),
	@CourseId nvarchar(50)

AS
if not exists (select 1 from dbo.CompletedCourses Where StudentId = @StudentId AND CourseId = @CourseId)
begin
	set nocount on;

	insert into dbo.[CompletedCourses]([StudentId], [CourseId])
	values (@StudentId, @CourseId);

end
