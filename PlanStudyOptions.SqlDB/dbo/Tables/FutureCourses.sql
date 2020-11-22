CREATE TABLE [dbo].[FutureCourses]
(
    [FutureCourseId] INT NOT NULL PRIMARY KEY IDENTITY,
	[StudentId] NVARCHAR(50) NOT NULL, 
    [CourseId] NVARCHAR(50) NOT NULL, 
    [MajorId] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_FutureCourses_Students] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_FutureCourses_Courses] FOREIGN KEY ([CourseId]) REFERENCES [Courses]([CourseId]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_FutureCourses_Majors] FOREIGN KEY ([MajorId]) REFERENCES [Majors]([MajorId]) ON DELETE CASCADE ON UPDATE CASCADE
)
