ALTER TABLE [dbo].[StudentSessionResults]
    ADD CONSTRAINT [FK_StudentSessionResults_Student_ID] 
	FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Student] ([ID]) 
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[StudentSessionResults]
    ADD CONSTRAINT [FK_StudentSessionResults_ExamShedule_ID] 
    FOREIGN KEY ([ExamScheduleID]) REFERENCES [dbo].[ExamSchedule] ([ID]) 
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
