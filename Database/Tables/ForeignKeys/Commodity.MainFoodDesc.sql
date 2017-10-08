ALTER TABLE [dbo].Commodity
ADD CONSTRAINT FK_Commodity_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
ON DELETE CASCADE