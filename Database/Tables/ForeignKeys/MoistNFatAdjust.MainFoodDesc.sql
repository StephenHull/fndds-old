ALTER TABLE [dbo].MoistNFatAdjust
ADD CONSTRAINT FK_MoistNFatAdjust_MainFoodDesc
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MainFoodDesc (FoodCode, [Version])
ON DELETE CASCADE