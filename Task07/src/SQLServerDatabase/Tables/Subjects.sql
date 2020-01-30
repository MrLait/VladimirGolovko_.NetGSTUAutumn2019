CREATE TABLE [dbo].[Subjects] (
    [ID]            INT         IDENTITY(1,1) PRIMARY KEY,
    [SubjectName]     NVARCHAR (40)               NOT NULL,
    IsAssessment NVARCHAR(40)                   NOT NULL,
    ExaminersID   INT                         NOT NULL 
    CONSTRAINT [FK_Subjects_ExaminersID_ID] FOREIGN KEY ([ExaminersID]) REFERENCES [Examiners](ID)
)