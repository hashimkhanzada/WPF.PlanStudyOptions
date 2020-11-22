CREATE TABLE [dbo].[Students]
(
	[StudentId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [CourseId] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Students_CourseId_ToCourses] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses]([CourseId])
)
