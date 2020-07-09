CREATE TABLE [dbo].[Student] (
    [ID]            INT         IDENTITY(1,1) PRIMARY KEY,
    [Surname]       NVARCHAR (40)               NOT NULL,
    [FirstName]     NVARCHAR (40)               NOT NULL,
    [MiddleName]    NVARCHAR (40)               NOT NULL,
    [Gender]        NVARCHAR (40)               NOT NULL,
    [DateOfBirth]   DATETIME                    NOT NULL,
    [GroupID]       INT                         NOT NULL
)
