ALTER TABLE [dbo].FnddsNutVal
ADD CONSTRAINT FK_FnddsNutVal_MoistNFatAdjust
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MoistNFatAdjust (FoodCode, [Version])
