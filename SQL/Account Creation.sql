CREATE TABLE [account].[Account](
	UUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	Email varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Name varchar(25) NOT NULL,
	Surname varchar(25) NOT NULL,
	Title varchar(5) NULL,
	UTCCreatedDateTime DATETIME2 DEFAULT getdate() NOT NULL,
    UTCUpdatedDateTime DATETIME2 DEFAULT getdate() NOT NULL,
   PRIMARY KEY (UUID, Email));