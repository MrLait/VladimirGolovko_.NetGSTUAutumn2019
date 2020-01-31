----DECLARE @QuantityStudents INT, @QuantityExamSchedules INT, @QuantitySubjects INT;
--DECLARE @StudentsNum INT, @ExamSchedulesNum INT, @SubjectsNum INT;--, @SubjectsNum INT;
--DECLARE @number INT;
--DECLARE @Random INT;
--DECLARE @StudentGroupID INT;
--DECLARE @Test INT;
--DECLARE @QuereTest VARCHAR(max);
--SET @QuantityStudents = (SELECT COUNT(*) FROM Students);
--SET @QuantityExamSchedules = (SELECT COUNT(*) FROM ExamSchedules);
----SET @QuantitySubjects = (SELECT COUNT(*) FROM Subjects);
--SET @number = 1; SET @StudentsNum = 1; SET @ExamSchedulesNum = 1; --SET @SubjectsNum = 1;
--
--WHILE @StudentsNum <= 1
--	BEGIN
--			
--		--SET @StudentGroupID = (Select GroupsID From Students where ID = @StudentsNum);
--		--SET @Test = (Select * From ExamSchedules Where GroupsID = @StudentGroupID);
--				
--		
--		--(Select * From ExamSchedules  
--		--Where GroupsID = (Select GroupsID From Students Where ID = @StudentsNum));
--		
--		--(Select Count(*) From ExamSchedules  
--		--				Where GroupsID = (Select GroupsID From Students Where ID = @StudentsNum));
--		
--				(SELECT COUNT(*) FROM ExamSchedules Where ExamSchedules.GroupsID = 
--		(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum));
--
--
--		SET @QuantitySubjects = (Select Count(*) From ExamSchedules  
--						Where GroupsID = (Select GroupsID From Students Where ID = @StudentsNum));
--		
--		While @SubjectsNum <= @QuantitySubjects 
--		BEGIN
--
--		(SELECT ID FROM ExamSchedules WHERE GroupsID = (Select GroupsID FROM Students Where ID = @StudentsNum)
--		AND ExamSchedules.SubjectsID = @SubjectsNum);
--
--		SET @SubjectsNum = @SubjectsNum + 1;
--
--		END;
--		SET @SubjectsNum = 1;
--
--		SET @StudentsNum = @StudentsNum + 1;
--
--	END;
----GO




--CREATE PROCEDURE SessionsResultsPostDep
--AS
DECLARE @QuantityStudents INT, @QuantityExamSchedules INT, @QuantitySubjects INT;
DECLARE @StudentsNum INT, @ExamSchedulesNum INT, @SubjectsNum INT;--, @SubjectsNum INT;
DECLARE @ExamSchedulesID INT;
DECLARE @number INT;
DECLARE @Random INT;
DECLARE @StudentGroupID INT;
DECLARE @Test INT;
SET @QuantityStudents = (SELECT COUNT(*) FROM Students);
SET @QuantityExamSchedules = (SELECT COUNT(*) FROM ExamSchedules);
--SET @QuantitySubjects = (SELECT COUNT(*) FROM Subjects);
SET @number = 1; SET @StudentsNum = 0; SET @ExamSchedulesNum = 1; SET @SubjectsNum = 1;
WHILE @StudentsNum <= @QuantityStudents
	BEGIN
			
		--SET @Random = (FLOOR(RAND()*(100-1)+1));
		--SET @StudentGroupID = (Select GroupsID From Students where ID = @StudentsNum);
		--SET @Test = (Select * From ExamSchedules Where GroupsID = @StudentGroupID);

		WHILE @QuantitySubjects <=
		(SELECT COUNT(*) FROM ExamSchedules Where ExamSchedules.GroupsID = 
		(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum))
		
		BEGIN

			--INSERT INTO SessionsResults(StudentsID,ExamSchedulesID,ExamValue,SetOffValue)
			--VALUES (@StudentsNum,
			--1,
			--1,
			--NULL);
			
			--Select @StudentsNum;

			--(SELECT ExamSchedules.ID FROM ExamSchedules Where ExamSchedules.GroupsID = 
			--(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum)
			--AND ExamSchedules.SubjectsID = @QuantitySubjects);

			SET @ExamSchedulesID = (SELECT ExamSchedules.ID FROM ExamSchedules Where ExamSchedules.GroupsID = 
			(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum)
			AND ExamSchedules.SubjectsID = @QuantitySubjects);

			(SELECT Subjects.IsAssessment FROM Subjects WHERE Subjects.ID = 
			(SELECT ExamSchedules.SubjectsID FROM ExamSchedules WHERE ExamSchedules.ID = @ExamSchedulesID));

			SET @QuantitySubjects = @QuantitySubjects + 1;

		END;
		SET @QuantitySubjects = 1;

		SET @StudentsNum = @StudentsNum + 1;
	END;
GO