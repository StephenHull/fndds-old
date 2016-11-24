ALTER TABLE [dbo].FnddsNutVal
ADD CONSTRAINT FK_FnddsNutVal_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
ON DELETE CASCADE