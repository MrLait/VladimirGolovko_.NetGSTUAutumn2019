CREATE TABLE [dbo].[StudentSessionResults] (
    [ID]                INT     IDENTITY(1,1) PRIMARY KEY,
    [StudentID]         INT                     NOT NULL,
    [ExamScheduleID]    INT                     NOT NULL,
    [ExamResult]        INT                     NOT NULL,
    [SetOffResult]      NVARCHAR (40)           NOT NULL
)