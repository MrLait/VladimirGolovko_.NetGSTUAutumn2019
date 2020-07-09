CREATE PROCEDURE ExaminersPostDep
AS
--DECLARE @number INT, @numberOfExaminers INT;
--DECLARE @Random INT;
--DECLARE @SurnamePrefix NVARCHAR(40), @FirstNamePrefix NVARCHAR(40), @MiddleNamePrefix NVARCHAR(40);
--
--SET @number = 1;
--SET @SurnamePrefix = 'Surname';
--SET @FirstNamePrefix = 'Firstname';
--SET @MiddleNamePrefix = 'Middlename';
--SET @numberOfExaminers = 1;
--WHILE @number <= 2
--	BEGIN
--		
--
--		INSERT INTO Examiners(Surname, FirstName, MiddleName)
--		VALUES (@SurnamePrefix + CONVERT(NVARCHAR, @number),
--				@FirstNamePrefix + CONVERT(NVARCHAR, @number),
--				@MiddleNamePrefix + CONVERT(NVARCHAR, @number));
--
--		SET @number = @number + 1;
--
--	END;


SET IDENTITY_INSERT [dbo].[Examiners] ON
INSERT INTO [dbo].[Examiners] ([ID], [Surname], [FirstName], [MiddleName]) VALUES (1, N'Surname1', N'Firstname1', N'Middlename1')
INSERT INTO [dbo].[Examiners] ([ID], [Surname], [FirstName], [MiddleName]) VALUES (2, N'Surname2', N'Firstname2', N'Middlename2')
SET IDENTITY_INSERT [dbo].[Examiners] OFF


GO


