CREATE TABLE [dbo].[MajorCourses]
(
	[MajorId] NVARCHAR(50) NOT NULL, 
    [CourseId] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([MajorId] ASC, [CourseId] ASC), 
    CONSTRAINT [FK_MajorCourses_MajorId_ToMajors] FOREIGN KEY ([MajorId]) REFERENCES [dbo].[Majors]([MajorId]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_MajorCourses_CourseId_ToCourses] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses]([CourseId]) ON DELETE CASCADE ON UPDATE CASCADE
)
