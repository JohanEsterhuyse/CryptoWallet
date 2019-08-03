CREATE TABLE Trade
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[TradeType] INT,
	[Description] NVARCHAR (150),
	[Amount] Decimal
)
GO