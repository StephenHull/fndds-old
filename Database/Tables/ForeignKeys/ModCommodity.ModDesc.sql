ALTER TABLE [dbo].ModCommodity
ADD CONSTRAINT FK_ModCommodity_ModDesc
FOREIGN KEY (FoodCode, ModCode, [Version])
REFERENCES [dbo].ModDesc (FoodCode, ModificationCode, [Version])
ON DELETE CASCADE