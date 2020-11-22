CREATE TABLE [dbo].[Courses]
(
	[CourseId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Semester] INT NOT NULL, 
    [PreRequisite] NVARCHAR(50) NULL, 
    [Compulsory] BIT NULL, 
    [Credits] INT NULL, 
    [Year] INT NOT NULL
)
