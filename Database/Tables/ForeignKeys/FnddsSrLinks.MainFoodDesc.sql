ALTER TABLE [dbo].FnddsSrLinks
ADD CONSTRAINT FK_FnddsSrLinks_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
ON DELETE CASCADE