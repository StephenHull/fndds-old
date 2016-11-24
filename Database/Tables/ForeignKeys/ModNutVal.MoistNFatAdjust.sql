ALTER TABLE [dbo].ModNutVal
ADD CONSTRAINT FK_ModNutVal_ModDesc
FOREIGN KEY (FoodCode, ModificationCode, [Version])
REFERENCES [dbo].ModDesc (FoodCode, ModificationCode, [Version])
ON DELETE CASCADE