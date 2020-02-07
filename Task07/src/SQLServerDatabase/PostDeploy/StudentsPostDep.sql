CREATE PROCEDURE StudentsPostDep
AS
--DECLARE @QuantityGroups INT;
--DECLARE @number INT;
--DECLARE @Random INT;
--DECLARE @StudentsNum INT;
--DECLARE @SurnamePrefix NVARCHAR(40), @FirstNamePrefix NVARCHAR(40), @MiddleNamePrefix NVARCHAR(40),
--@Gender NVARCHAR(40);
--
--SET @QuantityGroups = (SELECT COUNT(*) FROM Groups) + 1;
--SET @number = 1;
--SET @StudentsNum = 12
--SET @SurnamePrefix = 'Surname';
--SET @FirstNamePrefix = 'Firstname';
--SET @MiddleNamePrefix = 'Middlename';
--WHILE @number < @StudentsNum + 1
--	BEGIN
--
--		--SET @Random = (FLOOR(RAND()*(@QuantitySpecialties-1)+1));
--		IF (FLOOR(RAND()*(10-1)+1) < 5)
--			SET @Gender = 'Male';
--		ELSE
--			SET @Gender = 'Female';
--		
--		SET @Random = (FLOOR(RAND()*(@QuantityGroups-1)+1));
--
--		INSERT INTO Students(Surname, FirstName, MiddleName,Gender, DateOfBirth, GroupsID)
--		VALUES (@SurnamePrefix + CONVERT(NVARCHAR, @number),
--				@FirstNamePrefix + CONVERT(NVARCHAR, @number),
--				@MiddleNamePrefix + CONVERT(NVARCHAR, @number),
--				@Gender,
--				DATEADD(DAY, -@number, GETDATE()),
--				@Random);
--
--		SET @number = @number + 1;
--
--	END;


SET IDENTITY_INSERT [dbo].[Students] ON
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (1, N'Surname1', N'Firstname1', N'Middlename1', N'Male', N'2020-02-05 15:28:14', 4)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (2, N'Surname2', N'Firstname2', N'Middlename2', N'Female', N'2020-02-04 15:28:14', 4)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (3, N'Surname3', N'Firstname3', N'Middlename3', N'Female', N'2020-02-03 15:28:14', 1)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (4, N'Surname4', N'Firstname4', N'Middlename4', N'Male', N'2020-02-02 15:28:14', 2)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (5, N'Surname5', N'Firstname5', N'Middlename5', N'Male', N'2020-02-01 15:28:14', 1)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (6, N'Surname6', N'Firstname6', N'Middlename6', N'Female', N'2020-01-31 15:28:14', 3)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (7, N'Surname7', N'Firstname7', N'Middlename7', N'Male', N'2020-01-30 15:28:14', 3)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (8, N'Surname8', N'Firstname8', N'Middlename8', N'Male', N'2020-01-29 15:28:14', 4)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (9, N'Surname9', N'Firstname9', N'Middlename9', N'Female', N'2020-01-28 15:28:14', 4)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (10, N'Surname10', N'Firstname10', N'Middlename10', N'Female', N'2020-01-27 15:28:14', 2)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (11, N'Surname11', N'Firstname11', N'Middlename11', N'Female', N'2020-01-26 15:28:14', 1)
INSERT INTO [dbo].[Students] ([ID], [Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupsID]) VALUES (12, N'Surname12', N'Firstname12', N'Middlename12', N'Male', N'2020-01-25 15:28:14', 1)
SET IDENTITY_INSERT [dbo].[Students] OFF

GO


