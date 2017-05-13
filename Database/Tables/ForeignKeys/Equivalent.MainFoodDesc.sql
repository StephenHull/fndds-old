ALTER TABLE [dbo].Equivalent
ADD CONSTRAINT FK_Equivalent_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
ON DELETE CASCADE