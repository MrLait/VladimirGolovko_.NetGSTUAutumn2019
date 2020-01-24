CREATE PROCEDURE StudentSessionResultsPostDep
AS
INSERT [dbo].[StudentSessionResults]
([StudentID], [ExamScheduleID], [ExamValue], [SetOffValue])
VALUES
--Group 1
	--Exam Maths
(1, 1, 10, null),
(2, 1, 20, null),
(3, 1, 30, null),
	--SetOff Maths
(1, 4, null, 'True'),
(2, 4, null, 'True'),
(3, 4, null, 'True'),

--Group 2
	--Exam Maths
(4, 2, 30, null),
(5, 2, 40, null),
	--SetOff Maths
(4, 5, null, 'True'),
(5, 5, null, 'True'),

--Group 3
	--Exam Maths
(6, 3, 50, null),
(7, 3, 60, null),
	--SetOff Maths
(6, 6, null, 'True'),
(7, 6, null, 'True'),

--Group 1
	--Exam English
(1, 7, 10, null),
(2, 7, 20, null),
(3, 7, 30, null),
	--SetOff English
(1, 10, null, 'True'),
(2, 10, null, 'True'),
(3, 10, null, 'True'),

--Group 2
	--Exam English
(4, 8, 30, null),
(5, 8, 40, null),
	--SetOff English
(4, 11, null, 'True'),
(5, 11, null, 'True'),

--Group 3
	--Exam English
(6, 9, 50, null),
(7, 9, 60, null),
	--SetOff English
(6, 12, null, 'True'),
(7, 12, null, 'True')
GO;