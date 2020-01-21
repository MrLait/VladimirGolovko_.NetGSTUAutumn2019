CREATE TABLE [dbo].[SessionSchedule] (
    [SessionScheduleID] INT     PRIMARY KEY     NOT NULL,
    [StudentGroup]      INT                     NOT NULL,
    [ExamDate]          DATETIME                NOT NULL,
    [OffsetDate]        DATETIME                NOT NULL,
    [NumberOfSession]   INT                     NOT NULL,
    [Subject]           NVARCHAR (40)           NOT NULL
)