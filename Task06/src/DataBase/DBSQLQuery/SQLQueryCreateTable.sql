PRINT N'Creating SessionResult...';
GO

CREATE SCHEMA SessionResult
    AUTHORIZATION [dbo];
GO

PRINT N'Creating SessionResult.Student...';
GO

CREATE TABLE [SessionResult].[Student] (
    [StudentID]     INT         IDENTITY (1, 1) NOT NULL,
    [Surname]       NVARCHAR (40)               NOT NULL,
    [FirstName]     NVARCHAR (40)               NOT NULL,
    [MiddleName]    NVARCHAR (40)               NOT NULL,
    [Gender]        NVARCHAR (40)               NOT NULL,
    [DateOfBirth]   DATETIME                    NOT NULL,
    [StudentGroup]  INT                         NOT NULL
);
GO

PRINT N'Creating SessionResult.SessionSchedule...';
GO

CREATE TABLE [SessionResult].[SessionSchedule] (
    [SessionScheduleID] INT     IDENTITY (1, 1) NOT NULL,
    [StudentGroup]      INT                     NOT NULL,
    [ExamDate]          DATETIME                NOT NULL,
    [OffsetDate]        DATETIME                NOT NULL,
    [NumberOfSession]   INT                     NOT NULL,
    [Subject]           NVARCHAR (40)           NOT NULL
);
GO

PRINT N'Creating SessionResult.StudentSessionResults...';
GO

CREATE TABLE [SessionResult].[StudentSessionResults] (
    [StudentSessionResultsID]   INT     IDENTITY (1, 1) NOT NULL,
    [StudentID]                 INT                     NOT NULL,
    [SessionScheduleID]         INT                     NOT NULL,
    [ExamResult]                INT                     NOT NULL,
    [OffsettResult]             NVARCHAR (40)           NOT NULL
);
GO

--3. Establish relationships between tables
PRINT N'Creating SessionResult.PK_Student_StudentID...';
GO
ALTER TABLE [SessionResult].[Student]
    ADD CONSTRAINT [PK_Student_StudentID] PRIMARY KEY CLUSTERED ([StudentID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
GO

PRINT N'Creating SessionResult.PK_SessionSchedule_SessionScheduleID...';
GO
ALTER TABLE [SessionResult].[SessionSchedule]
    ADD CONSTRAINT [PK_SessionSchedule_SessionScheduleID] PRIMARY KEY CLUSTERED ([SessionScheduleID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
GO

PRINT N'Creating SessionResult.PK_StudentSessionResults_StudentSessionResultsID...';
GO
ALTER TABLE [SessionResult].[StudentSessionResults]
    ADD CONSTRAINT [PK_StudentSessionResults_StudentSessionResultsID] PRIMARY KEY CLUSTERED ([StudentSessionResultsID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
GO

PRINT N'Creating SessionResult.FK_Orders_Customer_CustID...';
GO
ALTER TABLE [SessionResult].[StudentSessionResults]
    ADD CONSTRAINT [FK_StudentSessionResults_Student_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [SessionResult].[Student] ([StudentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

PRINT N'Creating SessionResult.FK_StudentSessionResults_SessionSchedule_SessionScheduleID...';
GO
ALTER TABLE [SessionResult].[StudentSessionResults]
    ADD CONSTRAINT [FK_StudentSessionResults_SessionSchedule_SessionScheduleID] FOREIGN KEY ([SessionScheduleID]) REFERENCES [SessionResult].[SessionSchedule] ([SessionScheduleID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

--4. Constraints
ALTER TABLE [SessionResult].[Student]
ADD CHECK (Gender IN ('Male','Female'))
GO

ALTER TABLE [SessionResult].[StudentSessionResults]
ADD CHECK (OffsettResult IN ('Offset', 'NotOffset'))
GO

ALTER TABLE [SessionResult].[SessionSchedule]
ADD CHECK (Subject IN ('Maths', 'English', 'Physics'))
GO

--5. Filling the table with data
INSERT [SessionResult].[Student]
(Surname, FirstName, MiddleName, Gender, DateOfBirth, StudentGroup)
VALUES
('Kosh', 'Vova', 'Nikolaevich', 'Male',  DATEADD(DAY, -85, GETDATE()), 1),
('Kosh2', 'Vova', 'Nikolaevich', 'Male',  DATEADD(DAY, -81, GETDATE()), 1),
('Kosh3', 'Serg', 'Andreevich', 'Male',  DATEADD(DAY, -15, GETDATE()), 1),
('Alg', 'Julia', 'Nikolaevna', 'Female',  DATEADD(DAY, -185, GETDATE()), 2),
('Ingalia', 'Inga', 'Sergeevna', 'Female',  DATEADD(DAY, -281, GETDATE()), 2),
('Kosh4', 'Dim', 'Andreevich', 'Male',  DATEADD(DAY, -315, GETDATE()), 2)
GO

INSERT [SessionResult].[SessionSchedule]
(StudentGroup, ExamDate, OffsetDate, NumberOfSession, Subject)
VALUES
(1, DATEADD(DAY, -100, GETDATE()), DATEADD(DAY, -101, GETDATE()), 1, 'Maths'),
(1, DATEADD(DAY, -105, GETDATE()), DATEADD(DAY, -107, GETDATE()), 1, 'English'),
(1, DATEADD(DAY, -110, GETDATE()), DATEADD(DAY, -111, GETDATE()), 1, 'Physics'),
(2, DATEADD(DAY, -120, GETDATE()), DATEADD(DAY, -121, GETDATE()), 1, 'Maths'),
(2, DATEADD(DAY, -125, GETDATE()), DATEADD(DAY, -127, GETDATE()), 1, 'English'),
(2, DATEADD(DAY, -120, GETDATE()), DATEADD(DAY, -121, GETDATE()), 1, 'Physics'),
(1, DATEADD(DAY, -200, GETDATE()), DATEADD(DAY, -201, GETDATE()), 2, 'Maths'),
(1, DATEADD(DAY, -205, GETDATE()), DATEADD(DAY, -207, GETDATE()), 2, 'English'),
(1, DATEADD(DAY, -210, GETDATE()), DATEADD(DAY, -211, GETDATE()), 2, 'Physics'),
(2, DATEADD(DAY, -220, GETDATE()), DATEADD(DAY, -221, GETDATE()), 2, 'Maths'),
(2, DATEADD(DAY, -225, GETDATE()), DATEADD(DAY, -227, GETDATE()), 2, 'English'),
(2, DATEADD(DAY, -220, GETDATE()), DATEADD(DAY, -221, GETDATE()), 2, 'Physics')
GO

INSERT [SessionResult].[StudentSessionResults]
(StudentID, SessionScheduleId, ExamResult, OffsettResult)
VALUES
(1,1,100,'Offset'),
(1,2,99,'Offset'),
(1,3,98,'Offset'),
(2,1,97,'Offset'),
(2,2,96,'Offset'),
(2,3,95,'Offset'),
(3,1,94,'Offset'),
(3,2,93,'Offset'),
(3,3,92,'Offset'),
(4,4,100,'Offset'),
(4,5,99,'Offset'),
(4,6,98,'Offset'),
(5,4,97,'Offset'),
(5,5,96,'Offset'),
(5,6,95,'Offset'),
(6,4,94,'Offset'),
(6,5,93,'Offset'),
(6,6,92,'Offset'),
(1,7,100,'Offset'),
(1,8,99,'Offset'),
(1,9,98,'Offset'),
(2,7,97,'Offset'),
(2,8,96,'Offset'),
(2,9,95,'Offset'),
(3,7,94,'Offset'),
(3,8,93,'Offset'),
(3,9,92,'Offset'),
(4,10,100,'Offset'),
(4,11,99,'Offset'),
(4,12,98,'Offset'),
(5,10,97,'Offset'),
(5,11,96,'Offset'),
(5,12,95,'Offset'),
(6,10,94,'Offset'),
(6,11,93,'Offset'),
(6,12,92,'Offset')
GO

SELECT * FROM [SessionResult].[Student]
SELECT * FROM [SessionResult].[SessionSchedule]
SELECT * FROM [SessionResult].[StudentSessionResults]
