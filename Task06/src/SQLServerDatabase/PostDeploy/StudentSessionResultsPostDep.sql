CREATE PROCEDURE StudentSessionResultsPostDep
AS
INSERT [dbo].[StudentSessionResults]
([StudentID], [ExamScheduleID], [ExamResult], [SetOffResult])
VALUES
(1, 1, 10, N'Yes'),
(2, 1, 20, N'Yes'),
(3, 1, 30, N'Yes'),
(4, 2, 40, N'Yes'),
(5, 2, 50, N'Yes'),
(6, 3, 60, N'Yes'),
(7, 3, 70, N'Yes'),
(1, 4, 10, N'Yes'),
(2, 4, 20, N'Yes'),
(3, 4, 30, N'Yes'),
(4, 5, 40, N'Yes'),
(5, 5, 50, N'Yes'),
(6, 6, 60, N'Yes'),
(7, 6, 70, N'Yes')
GO;