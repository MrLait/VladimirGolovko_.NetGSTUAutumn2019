CREATE PROCEDURE StudentPostDep
AS
INSERT [dbo].[Student] 
([Surname], [FirstName], [MiddleName], [Gender], [DateOfBirth], [GroupID])
VALUES 
('Fedorov0', 'Vova0', 'Nikolaevich0', 'Male',  DATEADD(DAY, -85, GETDATE()), 1),
('Fedorov1', 'Vova1', 'Nikolaevich1', 'Male',  DATEADD(DAY, -81, GETDATE()), 1),
('Fedorov2', 'Serg', 'Andreevich', 'Male',  DATEADD(DAY, -15, GETDATE()), 1),
('Fedorovna0', 'Julia', 'Nikolaevna', 'Female',  DATEADD(DAY, -185, GETDATE()), 2),
('Fedorovna1', 'Inga', 'Sergeevna', 'Female',  DATEADD(DAY, -281, GETDATE()), 2),
('Kozlova0', 'Julia0', 'Andreevich', 'Female',  DATEADD(DAY, -315, GETDATE()), 3),
('Kozlova1', 'Julia1', 'Andreevich', 'Female',  DATEADD(DAY, -315, GETDATE()), 3)
GO;