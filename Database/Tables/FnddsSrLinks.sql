CREATE TABLE [dbo].[FnddsSrLinks]
(
	FoodCode INT,
	SeqNum INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	SrCode VARCHAR(8) NOT NULL,
	SrDescription VARCHAR(255) NOT NULL,
	Amount DECIMAL(11,3) NOT NULL,
	Measure VARCHAR(3) NULL,
	PortionCode INT NULL,
	RetentionCode INT,
	Flag INT,
	[Weight] DECIMAL(11,3) NOT NULL,
	ChangeTypeToSrCode VARCHAR(1),
	ChangeTypeToWeight VARCHAR(1),
	ChangeTypeToRetnCode VARCHAR(1),
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_FnddsSrLinks PRIMARY KEY (FoodCode, SeqNum, [Version])
)