CREATE PROCEDURE ExamSchedulesPostDep
AS
--DECLARE @QuantitySessions INT, @QuantityGroups INT, @QuantitySubjects INT;
--DECLARE @SessionsNum INT, @GroupsNum INT, @SubjectsNum INT;
--DECLARE @number INT;
--DECLARE @Random INT;
--SET @QuantitySessions = (SELECT COUNT(*) FROM [Sessions]);
--SET @QuantityGroups = (SELECT COUNT(*) FROM Groups);
--SET @QuantitySubjects = (SELECT COUNT(*) FROM Subjects);
--SET @number = 1; SET @SessionsNum = 1; SET @GroupsNum = 1; SET @SubjectsNum = 1;
--
--WHILE @SessionsNum <= @QuantitySessions
--	BEGIN
--		WHILE @GroupsNum <= @QuantityGroups
--			BEGIN
--				WHILE @SubjectsNum <= @QuantitySubjects
--					BEGIN
--
--						SET @Random = (FLOOR(RAND()*(100-1)+1));
--
--						INSERT INTO ExamSchedules (SessionsID,GroupsID,SubjectsID,ExamDate)
--						VALUES (@SessionsNum,
--						@GroupsNum,
--						@SubjectsNum,
--						DATEADD(DAY, -@Random, GETDATE())
--						);
--
--					SET @SubjectsNum = @SubjectsNum + 1;
--
--					END;
--			SET @GroupsNum = @GroupsNum + 1;
--			SET @SubjectsNum = 1;
--
--			END;
--	
--		SET @SessionsNum = @SessionsNum + 1;
--		SET @GroupsNum = 1;
--	END;


SET IDENTITY_INSERT [dbo].[ExamSchedules] ON
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (1, 1, 1, 1, N'2019-11-21 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (2, 1, 1, 2, N'2019-11-24 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (3, 1, 1, 3, N'2020-02-04 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (4, 1, 1, 4, N'2019-11-10 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (5, 1, 2, 1, N'2019-11-16 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (6, 1, 2, 2, N'2019-11-29 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (7, 1, 2, 3, N'2019-11-01 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (8, 1, 2, 4, N'2019-11-09 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (9, 1, 3, 1, N'2020-01-20 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (10, 1, 3, 2, N'2019-12-13 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (11, 1, 3, 3, N'2020-01-14 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (12, 1, 3, 4, N'2019-11-13 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (13, 1, 4, 1, N'2019-11-20 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (14, 1, 4, 2, N'2019-12-18 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (15, 1, 4, 3, N'2020-02-01 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (16, 1, 4, 4, N'2019-11-23 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (17, 2, 1, 1, N'2019-11-06 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (18, 2, 1, 2, N'2020-01-27 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (19, 2, 1, 3, N'2019-12-11 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (20, 2, 1, 4, N'2020-01-27 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (21, 2, 2, 1, N'2019-11-06 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (22, 2, 2, 2, N'2020-01-30 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (23, 2, 2, 3, N'2019-11-25 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (24, 2, 2, 4, N'2019-12-01 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (25, 2, 3, 1, N'2019-11-16 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (26, 2, 3, 2, N'2019-11-19 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (27, 2, 3, 3, N'2019-11-24 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (28, 2, 3, 4, N'2019-11-19 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (29, 2, 4, 1, N'2019-12-05 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (30, 2, 4, 2, N'2019-11-01 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (31, 2, 4, 3, N'2020-01-14 15:28:14')
INSERT INTO [dbo].[ExamSchedules] ([ID], [SessionsID], [GroupsID], [SubjectsID], [ExamDate]) VALUES (32, 2, 4, 4, N'2020-01-27 15:28:14')
SET IDENTITY_INSERT [dbo].[ExamSchedules] OFF


GO


