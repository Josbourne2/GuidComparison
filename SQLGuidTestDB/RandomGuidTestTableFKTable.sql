CREATE TABLE [dbo].[RandomGuidTestTableFKTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FK] UNIQUEIDENTIFIER NOT NULL REFERENCES RandomGuidTestTable(UUID)
)

GO

CREATE INDEX [IX_RandomGuidTestTableFKTable_FK] ON [dbo].[RandomGuidTestTableFKTable] (FK)
