ALTER TABLE [dbo].MainFoodDesc
ADD CONSTRAINT FK_MainFoodDesc_FnddsVersion
FOREIGN KEY ([Version])
REFERENCES [dbo].[FnddsVersion] (Id)
ON DELETE CASCADE