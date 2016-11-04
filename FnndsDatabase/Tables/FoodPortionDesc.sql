CREATE TABLE [dbo].[FoodPortionDesc]
(
	PortionCode INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	PortionDescription VARCHAR(120) NOT NULL,
	ChangeType VARCHAR(1) NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_FoodPortionDesc PRIMARY KEY (PortionCode, [Version])
)
