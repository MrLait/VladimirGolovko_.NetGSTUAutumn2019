﻿ALTER TABLE [dbo].[SetOffSchedule]
    ADD CONSTRAINT [FK_SetOffSchedule_Group_ID] 
	FOREIGN KEY ([GroupID]) 
	REFERENCES [dbo].[Group] ([ID]) 
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO