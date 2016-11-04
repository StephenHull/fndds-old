ALTER TABLE [dbo].NoSaltModNut
ADD CONSTRAINT FK_NoSaltModNut_NutDesc
FOREIGN KEY (NutrientCode, [Version])
REFERENCES [dbo].NutDesc (NutrientCode, [Version])
ON DELETE CASCADE