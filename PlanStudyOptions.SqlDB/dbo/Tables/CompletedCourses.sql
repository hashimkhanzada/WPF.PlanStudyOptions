CREATE TABLE [dbo].[CompletedCourses]
(
	[StudentId] NVARCHAR(50) NOT NULL, 
    [CourseId] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([StudentId] ASC, [CourseId] ASC), 
    CONSTRAINT [FK_CompletedCourses_StudentId_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_CompletedCourses_CourseId_ToCourses] FOREIGN KEY ([CourseId]) REFERENCES [Courses]([CourseId]) ON DELETE CASCADE ON UPDATE CASCADE

)
