ALTER TABLE [dbo].AddFoodDesc
ADD CONSTRAINT FK_AddFoodDesc_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
