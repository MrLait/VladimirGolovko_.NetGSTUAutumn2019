CREATE PROCEDURE SessionsResultsPostDep
AS
--DECLARE @QuantityStudents INT, @QuantitySubjects INT, @QuantitySessions INT;
--DECLARE @StudentsNum INT, @ExamSchedulesNum INT, @SubjectsNum INT, @SessionsNum INT;--, @SubjectsNum INT;
--DECLARE @ExamSchedulesID INT;
--DECLARE @ExamValueINT INT, @ExamValueVarChar VARCHAR(max);
--DECLARE @IsAssessment VARCHAR(max);
--SET @QuantityStudents = (SELECT COUNT(*) FROM Students);
--SET @QuantitySessions =(SELECT COUNT(*) FROM [Sessions]);
--SET @StudentsNum = 0; SET @ExamSchedulesNum = 1; SET @SubjectsNum = 1; SET @SessionsNum = 1;
--
--	WHILE @SessionsNum <= @QuantitySessions
--	BEGIN
--		WHILE @StudentsNum <= @QuantityStudents
--		BEGIN
--					
--			WHILE @QuantitySubjects <=
--			(SELECT COUNT(*) FROM ExamSchedules Where ExamSchedules.GroupsID = 
--			(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum) AND ExamSchedules.SessionsID = @SessionsNum)
--			
--			BEGIN
--		
--				SET @ExamSchedulesID = (SELECT ExamSchedules.ID FROM ExamSchedules Where ExamSchedules.GroupsID = 
--				(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum)
--				AND ExamSchedules.SubjectsID = @QuantitySubjects AND ExamSchedules.SessionsID = @SessionsNum);
--		
--				SET @IsAssessment = 
--				(SELECT Subjects.IsAssessment FROM Subjects WHERE Subjects.ID = 
--				(SELECT ExamSchedules.SubjectsID FROM ExamSchedules WHERE ExamSchedules.ID = @ExamSchedulesID));
--		
--				IF (@IsAssessment = 'True')
--					begin
--						SET @ExamValueINT = (FLOOR(RAND()*(100-1)+1))
--						SET @ExamValueVarChar = NULL;
--					end;
--				else
--					begin
--						SET @ExamValueINT = NULL;
--						SET @ExamValueVarChar = 'True';
--					end;
--		
--				INSERT INTO SessionsResults(StudentsID,ExamSchedulesID,ExamValue,SetOffValue)
--				VALUES (@StudentsNum,
--						@ExamSchedulesID,
--						@ExamValueINT,
--						@ExamValueVarChar);
--		
--				SET @QuantitySubjects = @QuantitySubjects + 1;
--		
--			END;
--			SET @QuantitySubjects = 1;
--		
--			SET @StudentsNum = @StudentsNum + 1;
--		END;
--
--
--		SET @StudentsNum = 1;
--		SET @SessionsNum = @SessionsNum + 1;
--	END;


SET IDENTITY_INSERT [dbo].[SessionsResults] ON
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (1, 1, 13, 11, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (2, 1, 14, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (3, 1, 15, 8, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (4, 1, 16, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (5, 2, 13, 38, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (6, 2, 14, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (7, 2, 15, 36, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (8, 2, 16, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (9, 3, 1, 1, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (10, 3, 2, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (11, 3, 3, 13, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (12, 3, 4, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (13, 4, 5, 92, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (14, 4, 6, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (15, 4, 7, 65, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (16, 4, 8, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (17, 5, 1, 20, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (18, 5, 2, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (19, 5, 3, 96, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (20, 5, 4, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (21, 6, 9, 35, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (22, 6, 10, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (23, 6, 11, 95, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (24, 6, 12, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (25, 7, 9, 63, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (26, 7, 10, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (27, 7, 11, 5, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (28, 7, 12, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (29, 8, 13, 72, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (30, 8, 14, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (31, 8, 15, 49, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (32, 8, 16, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (33, 9, 13, 72, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (34, 9, 14, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (35, 9, 15, 97, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (36, 9, 16, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (37, 10, 5, 41, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (38, 10, 6, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (39, 10, 7, 81, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (40, 10, 8, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (41, 11, 1, 49, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (42, 11, 2, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (43, 11, 3, 13, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (44, 11, 4, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (45, 12, 1, 60, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (46, 12, 2, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (47, 12, 3, 42, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (48, 12, 4, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (49, 1, 29, 60, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (50, 1, 30, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (51, 1, 31, 23, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (52, 1, 32, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (53, 2, 29, 58, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (54, 2, 30, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (55, 2, 31, 12, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (56, 2, 32, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (57, 3, 17, 15, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (58, 3, 18, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (59, 3, 19, 21, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (60, 3, 20, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (61, 4, 21, 96, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (62, 4, 22, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (63, 4, 23, 84, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (64, 4, 24, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (65, 5, 17, 4, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (66, 5, 18, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (67, 5, 19, 39, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (68, 5, 20, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (69, 6, 25, 77, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (70, 6, 26, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (71, 6, 27, 95, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (72, 6, 28, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (73, 7, 25, 41, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (74, 7, 26, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (75, 7, 27, 89, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (76, 7, 28, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (77, 8, 29, 90, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (78, 8, 30, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (79, 8, 31, 70, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (80, 8, 32, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (81, 9, 29, 71, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (82, 9, 30, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (83, 9, 31, 28, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (84, 9, 32, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (85, 10, 21, 26, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (86, 10, 22, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (87, 10, 23, 31, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (88, 10, 24, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (89, 11, 17, 76, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (90, 11, 18, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (91, 11, 19, 98, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (92, 11, 20, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (93, 12, 17, 45, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (94, 12, 18, NULL, N'True')
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (95, 12, 19, 80, NULL)
INSERT INTO [dbo].[SessionsResults] ([ID], [StudentsID], [ExamSchedulesID], [ExamValue], [SetOffValue]) VALUES (96, 12, 20, NULL, N'True')
SET IDENTITY_INSERT [dbo].[SessionsResults] OFF


GO


