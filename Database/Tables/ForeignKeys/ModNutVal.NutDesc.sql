ALTER TABLE [dbo].ModNutVal
ADD CONSTRAINT FK_ModNutVal_NutDesc
FOREIGN KEY (NutrientCode, [Version])
REFERENCES [dbo].NutDesc (NutrientCode, [Version])