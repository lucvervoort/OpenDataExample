CREATE TABLE [dbo].[Grades] (
    [GradeId]   INT            IDENTITY (1, 1) NOT NULL,
    [GradeName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED ([GradeId] ASC)
);


GO

