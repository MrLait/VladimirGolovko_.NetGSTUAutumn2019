CREATE TABLE [dbo].[SessionSchedule] (
    [SessionScheduleID] INT     PRIMARY KEY     NOT NULL,
    [NumberOfSession]   INT                     NOT NULL,
    [StudentGroup]      INT                     NOT NULL,
    [Subject]           NVARCHAR (40)           NOT NULL,
    [SetOffDate]        DATETIME                NOT NULL,
    [ExamDate]          DATETIME                NOT NULL
)