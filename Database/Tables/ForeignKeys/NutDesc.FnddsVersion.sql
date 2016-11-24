ALTER TABLE [dbo].NutDesc
ADD CONSTRAINT FK_NutDesc_FnddsVersion
FOREIGN KEY ([Version])
REFERENCES [dbo].[FnddsVersion] (Id)
ON DELETE CASCADE