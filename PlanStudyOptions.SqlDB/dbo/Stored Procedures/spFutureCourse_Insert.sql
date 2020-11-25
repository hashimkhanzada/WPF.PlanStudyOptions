CREATE PROCEDURE [dbo].[spFutureCourse_Insert]
	@StudentId nvarchar(50),
	@CourseId nvarchar(50),
	@MajorId nvarchar(50)

AS
if not exists (select 1 from dbo.FutureCourses Where StudentId = @StudentId AND CourseId = @CourseId)
begin
	set nocount on;

	insert into dbo.[FutureCourses]([StudentId], [CourseId], [MajorId])
	values (@StudentId, @CourseId, @MajorId);

end