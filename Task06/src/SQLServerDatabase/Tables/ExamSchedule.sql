CREATE TABLE [dbo].[ExamSchedule] (
    [ID]                INT IDENTITY(1,1)    PRIMARY KEY,
    [NumberOfSession]   INT                     NOT NULL,
    [GroupID]           INT                     NOT NULL,
    [Subject]           NVARCHAR (40)           NOT NULL,
    [ExamDate]          DATETIME                NOT NULL,
    [IsEstimated]       NVARCHAR (40)           NOT NULL
)