ALTER TABLE [dbo].ModDesc
ADD CONSTRAINT FK_ModDesc_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
ON DELETE CASCADE