ALTER TABLE [dbo].NoSaltModNut
ADD CONSTRAINT FK_NoSaltModNut_MoistNFatAdjust
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MoistNFatAdjust (FoodCode, [Version])
ON DELETE CASCADE