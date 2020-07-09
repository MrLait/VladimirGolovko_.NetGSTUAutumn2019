CREATE PROCEDURE GroupsPostDep
AS
--DECLARE @QuantitySpecialties INT;
--DECLARE @number INT;
--DECLARE @GroupPrefix NVARCHAR(40);
--DECLARE @Random INT;
--DECLARE @GroupNum INT;
--SET @QuantitySpecialties = (SELECT COUNT(*) FROM Specialties) + 1;
--SET @number = 1;
--SET @GroupPrefix = 'PM-';
--SET @GroupNum = 4
--WHILE @number < @GroupNum + 1
--	BEGIN
--
--		SET @Random = (FLOOR(RAND()*(@QuantitySpecialties-1)+1));
--
--		INSERT INTO Groups ([GroupName], SpecialtiesID)
--		VALUES (@GroupPrefix + CONVERT(NVARCHAR, @number),
--				@Random);
--
--		SET @number = @number + 1;
--
--	END;

SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT INTO [dbo].[Groups] ([ID], [GroupName], [SpecialtiesID]) VALUES (1, N'PM-1', 2)
INSERT INTO [dbo].[Groups] ([ID], [GroupName], [SpecialtiesID]) VALUES (2, N'PM-2', 2)
INSERT INTO [dbo].[Groups] ([ID], [GroupName], [SpecialtiesID]) VALUES (3, N'PM-3', 2)
INSERT INTO [dbo].[Groups] ([ID], [GroupName], [SpecialtiesID]) VALUES (4, N'PM-4', 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF




GO


