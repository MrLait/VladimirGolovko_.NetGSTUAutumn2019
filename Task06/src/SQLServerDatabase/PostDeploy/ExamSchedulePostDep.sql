CREATE PROCEDURE ExamSchedulePostDep
AS
INSERT [dbo].[ExamSchedule] 
([NumberOfSession], [GroupID], [Subject], [ExamDate])
VALUES
(1, 1, 'Maths',  DATEADD(DAY, -100, GETDATE())),
(1, 2, 'Maths',  DATEADD(DAY, -100, GETDATE())),
(1, 3, 'Maths',  DATEADD(DAY, -100, GETDATE())),
(1, 1, 'English',  DATEADD(DAY, -100, GETDATE())),
(1, 2, 'English',  DATEADD(DAY, -100, GETDATE())),
(1, 3, 'English',  DATEADD(DAY, -100, GETDATE()))
GO;