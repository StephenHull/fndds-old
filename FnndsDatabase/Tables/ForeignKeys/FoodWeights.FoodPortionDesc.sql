ALTER TABLE [dbo].FoodWeights
ADD CONSTRAINT FK_FoodWeights_FoodPortionDesc
FOREIGN KEY (PortionCode, [Version])
REFERENCES [dbo].FoodPortionDesc (PortionCode, [Version])
