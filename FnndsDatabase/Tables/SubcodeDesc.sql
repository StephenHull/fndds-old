CREATE TABLE [dbo].[SubcodeDesc]
(
	Subcode INT,
	[Version] INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	SubcodeDescription VARCHAR(80) NOT NULL,
	Created DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	CONSTRAINT PK_SubcodeDesc PRIMARY KEY (Subcode, [Version])
)
