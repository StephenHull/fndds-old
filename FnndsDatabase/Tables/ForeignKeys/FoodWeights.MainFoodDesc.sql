ALTER TABLE [dbo].FoodWeights
ADD CONSTRAINT FK_FoodWeights_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])