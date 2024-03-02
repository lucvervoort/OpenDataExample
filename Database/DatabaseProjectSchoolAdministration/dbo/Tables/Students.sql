CREATE TABLE [dbo].[Students] (
    [StudentId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [GradeId]   INT            NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CONSTRAINT [FK_Students_Grades_GradeId] FOREIGN KEY ([GradeId]) REFERENCES [dbo].[Grades] ([GradeId]) ON DELETE CASCADE
);


GO

CREATE NONCLUSTERED INDEX [IX_Students_GradeId]
    ON [dbo].[Students]([GradeId] ASC);


GO

