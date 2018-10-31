CREATE PROCEDURE [dbo].[GetRowcountFromTable]
	@schema_name varchar(250) = 0,
	@table_name varchar(250),
	@row_count int OUTPUT
AS
BEGIN
	DECLARE @Rowcount INT;

	SELECT @Rowcount = SUM([Partitions].[rows]) 
	FROM sys.schemas AS [Schemas]
	JOIN sys.tables AS [Tables]
		ON [Schemas].[schema_id] = [Tables].[schema_id]
	JOIN sys.partitions AS [Partitions]
	ON [Tables].[object_id] = [Partitions].[object_id]
	AND [Partitions].index_id IN ( 0, 1 )
	WHERE [Schemas].name = @schema_name
		AND [Tables].name = @table_name;

	SELECT @row_count = @Rowcount;
END
