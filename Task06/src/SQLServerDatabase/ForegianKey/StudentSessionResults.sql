ALTER TABLE [dbo].[StudentSessionResults]
    ADD CONSTRAINT [FK_StudentSessionResults_Student_StudentID] 
	FOREIGN KEY ([StudentID]) 
	REFERENCES [dbo].[Student] ([StudentID]) 
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[StudentSessionResults]
    ADD CONSTRAINT [FK_StudentSessionResults_SessionSchedule_SessionScheduleID] 
    FOREIGN KEY ([SessionScheduleID]) 
    REFERENCES [dbo].[SessionSchedule] ([SessionScheduleID]) 
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
