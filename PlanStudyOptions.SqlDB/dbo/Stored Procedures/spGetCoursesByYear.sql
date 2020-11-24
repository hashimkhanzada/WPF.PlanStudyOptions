CREATE PROCEDURE [dbo].[spGetCoursesByYear]
	@Year int
AS

begin
	set nocount on;

	Select [CourseId], [Name], [Description], [Semester], [PreRequisite], [Compulsory], [Credits], [Year]
	FROM Courses
	WHERE [Year] = @Year
	Order By Semester

end
