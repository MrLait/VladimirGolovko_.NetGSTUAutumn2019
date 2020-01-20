
--2. CREATE TABLES
CREATE TABLE Students
(ID int NOT NULL IDENTITY,
Surname nvarchar(20) NULL,
FirstName nvarchar(20) NULL,
MiddleName nvarchar(20) NULL,
Gender nvarchar(20) NULL,
DateOfBirth date DEFAULT GETDATE(),
StudentGroup int NULL
)
GO

CREATE TABLE SessionSchedule
(ID int NOT NULL IDENTITY,
StudentGroup int NULL,
ExamDate date DEFAULT GETDATE(),
OffsetDate date DEFAULT GETDATE(),
NumberOfSession int NULL,
Subject nvarchar(20) NULL,
)
GO

CREATE TABLE StudentSessionResults
(ID int NOT NULL IDENTITY,
StudentID int NULL,
SessionScheduleId int NULL,
ExamResult int NULL,
OffsettResult nvarchar(20) NULL
)
GO

--3. Establish relationships between tables
ALTER TABLE Students
ADD
PRIMARY KEY(ID)
GO

ALTER TABLE SessionSchedule
ADD
PRIMARY KEY(ID)
GO

ALTER TABLE StudentSessionResults
ADD
PRIMARY KEY (ID)
GO

ALTER TABLE StudentSessionResults
ADD
FOREIGN KEY(StudentID) REFERENCES Students (ID)
ON DELETE CASCADE
GO

ALTER TABLE StudentSessionResults
ADD
FOREIGN KEY(SessionScheduleId) REFERENCES SessionSchedule (ID)
ON DELETE CASCADE
GO

--4. Constraints
ALTER TABLE Students
ADD
CHECK (Gender IN ('Male','Female'))
GO

ALTER TABLE StudentSessionResults
ADD
CHECK (OffsettResult IN ('Offset', 'NotOffset'))
GO

ALTER TABLE SessionSchedule
ADD
CHECK (Subject IN ('Maths', 'English', 'Physics'))
GO

--5. Filling the table with data
INSERT Students
(Surname, FirstName, MiddleName, Gender, DateOfBirth, StudentGroup)
VALUES
('Kosh', 'Vova', 'Nikolaevich', 'Male',  DATEADD(DAY, -85, GETDATE()), 1),
('Kosh2', 'Vova', 'Nikolaevich', 'Male',  DATEADD(DAY, -81, GETDATE()), 1),
('Kosh3', 'Serg', 'Andreevich', 'Male',  DATEADD(DAY, -15, GETDATE()), 1),
('Alg', 'Julia', 'Nikolaevna', 'Female',  DATEADD(DAY, -185, GETDATE()), 2),
('Ingalia', 'Inga', 'Sergeevna', 'Female',  DATEADD(DAY, -281, GETDATE()), 2),
('Kosh4', 'Dim', 'Andreevich', 'Male',  DATEADD(DAY, -315, GETDATE()), 2)
GO

INSERT SessionSchedule
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

INSERT StudentSessionResults
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

SELECT * FROM Students
SELECT * FROM SessionSchedule
SELECT * FROM StudentSessionResults
