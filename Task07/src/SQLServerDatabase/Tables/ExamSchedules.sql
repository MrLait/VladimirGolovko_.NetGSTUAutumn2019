CREATE TABLE [dbo].[ExamSchedules] (
    [ID]                INT IDENTITY(1,1)    PRIMARY KEY,
    [SessionsID]        INT                     NOT NULL,
    [GroupsID]          INT                     NOT NULL,
    [SubjectsID]        INT           NOT NULL,
    [ExamDate]          DATETIME                NOT NULL,
    CONSTRAINT [FK_ExamSchedules_Sessions_ID] FOREIGN KEY ([SessionsID]) REFERENCES [Sessions]([ID]), 
    CONSTRAINT [FK_ExamSchedules_Groups_ID] FOREIGN KEY ([GroupsID]) REFERENCES [Groups]([ID]), 
    CONSTRAINT [FK_ExamSchedules_Subjects_ID] FOREIGN KEY ([SubjectsID]) REFERENCES [Subjects]([ID])
)