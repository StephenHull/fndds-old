ALTER TABLE [dbo].FnddsSrLinks
ADD CONSTRAINT FK_FnddsSrLinks_FoodPortionDesc
FOREIGN KEY (PortionCode, [Version])
REFERENCES [dbo].FoodPortionDesc (PortionCode, [Version])
