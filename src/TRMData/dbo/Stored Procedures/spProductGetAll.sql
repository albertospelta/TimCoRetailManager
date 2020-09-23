CREATE PROCEDURE [dbo].[spProductGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		p.[Id],
		p.[ProductName],
		p.[Description],
		p.[RetailPrice],
		p.[QuantityInStock]
	FROM 
		[dbo].[Product] AS p
	ORDER BY
		p.[ProductName]
END
