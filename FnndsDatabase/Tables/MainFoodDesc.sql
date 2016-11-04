CREATE TABLE [dbo].[MainFoodDesc]
(
	FoodCode INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	MainFoodDescription VARCHAR(200) NOT NULL,
	AbbreviatedMainFoodDescription VARCHAR(60),
	FortificationIdentifier INT DEFAULT 0 NOT NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_MainFoodDesc PRIMARY KEY (FoodCode, [Version])
)
