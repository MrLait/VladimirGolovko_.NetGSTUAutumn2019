CREATE TABLE [dbo].[SessionsResults] (
    [ID]                INT     IDENTITY(1,1) PRIMARY KEY,
    [StudentsID]        INT                     NOT NULL,
    [ExamSchedulesID]   INT                     NOT NULL,
    [ExamValue]         INT,
    [SetOffValue]       NVARCHAR (40),
    CONSTRAINT [FK_SessionsResults_Students_ID] FOREIGN KEY ([StudentsID]) REFERENCES [Students]([ID]), 
    CONSTRAINT [FK_SessionsResults_ExamSchedules_ID] FOREIGN KEY ([ExamSchedulesID]) REFERENCES [ExamSchedules]([ID]),
)