CREATE TABLE [dbo].[Examiners] (
    [ID]            INT         IDENTITY(1,1) PRIMARY KEY,
    [Surname]       NVARCHAR (40)               NOT NULL,
    [FirstName]     NVARCHAR (40)               NOT NULL,
    [MiddleName]    NVARCHAR (40)               NOT NULL
)
