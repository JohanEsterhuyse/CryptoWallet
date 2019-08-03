CREATE TABLE NotificationMessage
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[NotificationMessageType] INT,
	[From] NVARCHAR (150),
	[To] NVARCHAR (150),
	[Subject] NVARCHAR (150),
	[Message] NVARCHAR (250)
)
GO