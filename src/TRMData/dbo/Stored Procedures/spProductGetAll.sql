CREATE PROCEDURE [dbo].[spProductGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		p.[Id],
		p.[ProductName],
		p.[Description],
		p.[RetailPrice],
		p.[QuantityInStock],
		p.[IsTaxable]
	FROM 
		[dbo].[Product] AS p
	ORDER BY
		p.[ProductName]
END
