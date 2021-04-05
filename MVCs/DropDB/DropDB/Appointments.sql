CREATE TABLE [dbo].[Appointment]
(
	[ApptId] INT IDENTITY(1,1) NOT NULL,
	[Date_and_time] DATETIME NOT NULL,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	PRIMARY KEY CLUSTERED ([ApptId] ASC)
)
