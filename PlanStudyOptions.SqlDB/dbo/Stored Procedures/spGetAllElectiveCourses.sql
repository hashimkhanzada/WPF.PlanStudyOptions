CREATE PROCEDURE [dbo].[spGetAllElectiveCourses]
	@StudentId nvarchar(50)
AS

begin
	set nocount on;

	SELECT * FROM Courses WHERE CourseId Not in 
	(
		SELECT [FutureCourses].[CourseId]
			FROM FutureCourses 
			INNER JOIN Courses ON FutureCourses.CourseId = Courses.CourseId 
			WHERE StudentId = @StudentId
	)
	ORDER BY Year, Semester

end
