CREATE TABLE [dbo].[AddFoodDesc]
(
	FoodCode INT,
	SeqNum INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	AdditionalFoodDescription VARCHAR(80) NOT NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_AddFoodDesc PRIMARY KEY (FoodCode, SeqNum, [Version])
)