CREATE PROCEDURE SessionsPostDep
AS
--DECLARE @number INT, @SessionsNum INT;
--DECLARE @GroupNum INT;
--SET @number = 1;
--SET @SessionsNum = 2
--WHILE @number <= @SessionsNum
--	BEGIN
--
--		INSERT INTO [Sessions]([Session])
--		VALUES (@number);
--
--		SET @number = @number + 1;
--
--	END;


SET IDENTITY_INSERT [dbo].[Sessions] ON
INSERT INTO [dbo].[Sessions] ([ID], [Session]) VALUES (1, 1)
INSERT INTO [dbo].[Sessions] ([ID], [Session]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[Sessions] OFF


GO


