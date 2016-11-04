ALTER TABLE [dbo].FnddsSrLinks
ADD CONSTRAINT FK_FnddsSrLinks_MoistNFatAdjust
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MoistNFatAdjust (FoodCode, [Version])
ON DELETE CASCADE