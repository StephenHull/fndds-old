ALTER TABLE [dbo].ModNut
ADD CONSTRAINT FK_ModNut_NutDesc
FOREIGN KEY (NutrientCode, [Version])
REFERENCES [dbo].NutDesc (NutrientCode, [Version])
ON DELETE CASCADE