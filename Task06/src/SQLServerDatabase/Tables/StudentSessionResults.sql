CREATE TABLE [dbo].[StudentSessionResults] (
    [ID]                INT     IDENTITY(1,1) PRIMARY KEY,
    [StudentID]         INT                     NOT NULL,
    [ExamScheduleID]    INT                     NOT NULL,
    [ExamValue]         INT,
    [SetOffValue]       NVARCHAR (40)
)