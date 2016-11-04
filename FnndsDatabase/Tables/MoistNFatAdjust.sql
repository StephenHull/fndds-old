CREATE TABLE [dbo].[MoistNFatAdjust]
(
	FoodCode INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	MoistureChange DECIMAL(5,1) NULL,
	FatChange DECIMAL(5,1),
	TypeOfFat INT,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_MoistNFatAdjust PRIMARY KEY (FoodCode, [Version])
)