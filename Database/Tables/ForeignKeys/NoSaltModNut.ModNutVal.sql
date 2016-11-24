ALTER TABLE [dbo].NoSaltModNutVal
ADD CONSTRAINT FK_NoSaltModNutVal_ModNutVal
FOREIGN KEY (FoodCode, ModificationCode, NutrientCode, [Version])
REFERENCES [dbo].ModNutVal (FoodCode, ModificationCode, NutrientCode, [Version])
ON DELETE CASCADE