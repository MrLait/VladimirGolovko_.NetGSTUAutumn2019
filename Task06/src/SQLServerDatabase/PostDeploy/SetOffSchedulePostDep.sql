CREATE PROCEDURE SetOffSchedulePostDep
AS
INSERT [dbo].[SetOffSchedule]
([NumberOfSession], [GroupID], [Subject], [SetOffDate])
VALUES
(1, 1, 'Maths',  DATEADD(DAY, -110, GETDATE())),
(1, 1, 'English',  DATEADD(DAY, -110, GETDATE())),
(1, 2, 'Maths',  DATEADD(DAY, -110, GETDATE())),
(1, 2, 'English',  DATEADD(DAY, -110, GETDATE())),
(1, 3, 'Maths',  DATEADD(DAY, -110, GETDATE())),
(1, 3, 'English',  DATEADD(DAY, -110, GETDATE()))
GO;