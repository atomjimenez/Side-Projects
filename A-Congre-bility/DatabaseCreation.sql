CREATE DATABASE AcongrebilityDatabase

DROP TABLE IF EXISTS Congressmembers
GO

CREATE TABLE Congressmembers (
    [ID] NVARCHAR(4) PRIMARY KEY,
    [Name] NVARCHAR(MAX),
	[Role] NVARCHAR(MAX),
	[Pic] NVARCHAR(MAX),
	[Party] NVARCHAR(3),
	[VotingHistory] NVARCHAR(MAX)
)

DROP TABLE IF EXISTS BillLibrary
GO

CREATE TABLE BillLibrary (
    [BillID] INT PRIMARY KEY,
    [BillLegalName] NVARCHAR(MAX),
	[BillStreetName] NVARCHAR(MAX),
	[ProposedBy] NVARCHAR(4),
	[PassedHouse] BIT,
	[PassedSenate] BIT,
	[DateProposed] DATETIME,
	[DatePassedFailed] DATETIME,
	[RepSupport] INT,
	[DemSupport] INT,
	[IndSupport] INT,
	FOREIGN KEY (ProposedBy) REFERENCES Congressmembers(ID)
)