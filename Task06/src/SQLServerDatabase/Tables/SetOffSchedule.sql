CREATE TABLE [dbo].[SetOffSchedule] (
    [ID]                INT IDENTITY(1,1)    PRIMARY KEY,
    [NumberOfSession]   INT                     NOT NULL,
    [GroupID]           INT                     NOT NULL,
    [Subject]           NVARCHAR (40)           NOT NULL,
    [SetOffDate]        DATETIME                NOT NULL
)