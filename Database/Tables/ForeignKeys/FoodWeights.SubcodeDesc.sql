ALTER TABLE [dbo].FoodWeights
ADD CONSTRAINT FK_FoodWeights_SubcodeDesc
FOREIGN KEY (Subcode, [Version])
REFERENCES [dbo].SubcodeDesc (Subcode, [Version])