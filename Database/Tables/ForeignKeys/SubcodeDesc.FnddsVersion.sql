ALTER TABLE [dbo].SubcodeDesc
ADD CONSTRAINT FK_SubcodeDesc_FnddsVersion
FOREIGN KEY ([Version])
REFERENCES [dbo].[FnddsVersion] (Id)
ON DELETE CASCADE