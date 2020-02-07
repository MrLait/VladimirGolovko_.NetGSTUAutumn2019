CREATE PROCEDURE SpecialtiesPostDep
AS
--INSERT [dbo].[Specialties] ([Specialtie]) 
--VALUES (N'Programmer'), (N'Tester')
--GO;

SET IDENTITY_INSERT [dbo].[Specialties] ON
INSERT INTO [dbo].[Specialties] ([ID], [Specialtie]) VALUES (1, N'Programmer')
INSERT INTO [dbo].[Specialties] ([ID], [Specialtie]) VALUES (2, N'Tester')
SET IDENTITY_INSERT [dbo].[Specialties] OFF

GO;