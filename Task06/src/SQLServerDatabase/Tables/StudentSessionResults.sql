CREATE TABLE [dbo].[StudentSessionResults] (
    [StudentSessionResultsID]   INT     PRIMARY KEY     NOT NULL,
    [StudentID]                 INT                     NOT NULL,
    [SessionScheduleID]         INT                     NOT NULL,
    [ExamResult]                INT                     NOT NULL,
    [OffsettResult]             NVARCHAR (40)           NOT NULL
)