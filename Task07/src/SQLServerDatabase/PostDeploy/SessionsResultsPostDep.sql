﻿CREATE PROCEDURE SessionsResultsPostDep
AS
DECLARE @QuantityStudents INT, @QuantitySubjects INT, @QuantitySessions INT;
DECLARE @StudentsNum INT, @ExamSchedulesNum INT, @SubjectsNum INT, @SessionsNum INT;--, @SubjectsNum INT;
DECLARE @ExamSchedulesID INT;
DECLARE @ExamValueINT INT, @ExamValueVarChar VARCHAR(max);
DECLARE @IsAssessment VARCHAR(max);
SET @QuantityStudents = (SELECT COUNT(*) FROM Students);
SET @QuantitySessions =(SELECT COUNT(*) FROM [Sessions]);
SET @StudentsNum = 0; SET @ExamSchedulesNum = 1; SET @SubjectsNum = 1; SET @SessionsNum = 1;

	WHILE @SessionsNum <= @QuantitySessions
	BEGIN
		WHILE @StudentsNum <= @QuantityStudents
		BEGIN
					
			WHILE @QuantitySubjects <=
			(SELECT COUNT(*) FROM ExamSchedules Where ExamSchedules.GroupsID = 
			(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum) AND ExamSchedules.SessionsID = @SessionsNum)
			
			BEGIN
		
				SET @ExamSchedulesID = (SELECT ExamSchedules.ID FROM ExamSchedules Where ExamSchedules.GroupsID = 
				(SELECT Students.GroupsID FROM Students Where Students.ID = @StudentsNum)
				AND ExamSchedules.SubjectsID = @QuantitySubjects AND ExamSchedules.SessionsID = @SessionsNum);
		
				SET @IsAssessment = 
				(SELECT Subjects.IsAssessment FROM Subjects WHERE Subjects.ID = 
				(SELECT ExamSchedules.SubjectsID FROM ExamSchedules WHERE ExamSchedules.ID = @ExamSchedulesID));
		
				IF (@IsAssessment = 'True')
					begin
						SET @ExamValueINT = (FLOOR(RAND()*(100-1)+1))
						SET @ExamValueVarChar = NULL;
					end;
				else
					begin
						SET @ExamValueINT = NULL;
						SET @ExamValueVarChar = 'True';
					end;
		
				INSERT INTO SessionsResults(StudentsID,ExamSchedulesID,ExamValue,SetOffValue)
				VALUES (@StudentsNum,
						@ExamSchedulesID,
						@ExamValueINT,
						@ExamValueVarChar);
		
				SET @QuantitySubjects = @QuantitySubjects + 1;
		
			END;
			SET @QuantitySubjects = 1;
		
			SET @StudentsNum = @StudentsNum + 1;
		END;


		SET @StudentsNum = 1;
		SET @SessionsNum = @SessionsNum + 1;
	END;
GO


