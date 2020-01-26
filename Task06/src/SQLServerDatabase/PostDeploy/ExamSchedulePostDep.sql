CREATE PROCEDURE ExamSchedulePostDep
AS
INSERT [dbo].[ExamSchedule] 
([NumberOfSessionID], [GroupID], [Subject], [ExamDate], [IsEstimated])
VALUES
(1, 1, 'Maths',  DATEADD(DAY, -100, GETDATE()),'True'),
(1, 2, 'Maths',  DATEADD(DAY, -100, GETDATE()),'True'),
(1, 3, 'Maths',  DATEADD(DAY, -100, GETDATE()),'True'),
(1, 1, 'Maths',  DATEADD(DAY, -100, GETDATE()),'False'),
(1, 2, 'Maths',  DATEADD(DAY, -100, GETDATE()),'False'),
(1, 3, 'Maths',  DATEADD(DAY, -100, GETDATE()),'False'),
(1, 1, 'English',  DATEADD(DAY, -100, GETDATE()),'True'),
(1, 2, 'English',  DATEADD(DAY, -100, GETDATE()),'True'),
(1, 3, 'English',  DATEADD(DAY, -100, GETDATE()),'True'),
(1, 1, 'English',  DATEADD(DAY, -100, GETDATE()),'False'),
(1, 2, 'English',  DATEADD(DAY, -100, GETDATE()),'False'),
(1, 3, 'English',  DATEADD(DAY, -100, GETDATE()),'False')
GO;