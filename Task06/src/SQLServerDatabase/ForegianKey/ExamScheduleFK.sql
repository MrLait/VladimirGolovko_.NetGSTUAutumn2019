ALTER TABLE [dbo].[ExamSchedule]
    ADD CONSTRAINT [FK_ExamSchedule_Group_ID] 
	FOREIGN KEY ([GroupID]) REFERENCES [dbo].[Group] ([ID]) 
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[ExamSchedule]
    ADD CONSTRAINT [FK_ExamSchedule_NumberOfSession_ID] 
	FOREIGN KEY ([NumberOfSessionID]) REFERENCES [dbo].[NumberOfSession] ([ID]) 
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO