CREATE TABLE [dbo].[ModDesc]
(
	FoodCode INT,
	ModificationCode INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	ModificationDescription VARCHAR(240) NOT NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_ModDesc PRIMARY KEY (FoodCode, ModificationCode, [Version])
)