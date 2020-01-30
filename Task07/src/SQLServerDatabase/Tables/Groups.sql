CREATE TABLE [dbo].[Groups] (
    [ID]            INT         IDENTITY(1,1) PRIMARY KEY,
    [GroupName]     NVARCHAR (40)               NOT NULL,
    SpecialtiesID   INT                         NOT NULL, 
    CONSTRAINT [FK_Groups_Specialties_ID] FOREIGN KEY ([SpecialtiesID]) REFERENCES [Specialties](ID)
)