CREATE TABLE [dbo].[NoSaltModNutVal]
(
	FoodCode INT,
	ModificationCode INT,
	NutrientCode INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	NutrientValue DECIMAL(10,3) NOT NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_NoSaltModNutVal PRIMARY KEY (FoodCode, ModificationCode, NutrientCode, [Version])
)