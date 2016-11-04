ALTER TABLE [dbo].FnddsNutVal
ADD CONSTRAINT FK_FnddsNutVal_NutDesc
FOREIGN KEY (NutrientCode, [Version])
REFERENCES [dbo].NutDesc (NutrientCode, [Version])
