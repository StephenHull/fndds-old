ALTER TABLE [dbo].MainFoodDesc
ADD CONSTRAINT FK_MainFoodDesc_Version
FOREIGN KEY ([Version])
REFERENCES [dbo].[Version] (ID)