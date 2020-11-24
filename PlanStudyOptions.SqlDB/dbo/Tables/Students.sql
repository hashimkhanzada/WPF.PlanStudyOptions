CREATE TABLE [dbo].[Students]
(
	[StudentId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Students_CourseId_ToCourses] FOREIGN KEY ([Name]) REFERENCES [dbo].[Courses]([CourseId])
)
