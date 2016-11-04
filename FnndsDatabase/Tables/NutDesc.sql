CREATE TABLE [dbo].[NutDesc]
(
	NutrientCode INT,
	[Version] INT,
	NutrientDescription VARCHAR(45) NOT NULL,
	Tagname VARCHAR(15) NOT NULL,
	Unit VARCHAR(10) NOT NULL,
	Decimals INT NOT NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_NutDesc PRIMARY KEY (NutrientCode, [Version])
)
