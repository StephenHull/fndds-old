ALTER TABLE [dbo].ModNut
ADD CONSTRAINT FK_ModNut_MoistNFatAdjust
FOREIGN KEY (FoodCode, [Version])
REFERENCES [dbo].MoistNFatAdjust (FoodCode, [Version])
