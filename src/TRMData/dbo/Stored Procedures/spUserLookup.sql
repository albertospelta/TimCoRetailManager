CREATE PROCEDURE [dbo].[spUserLookup]
	@id NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		t.[Id],
		t.[FirstName],
		t.[LastName],
		t.[EmailAddress],
		t.[CreateData]
	FROM 
		[dbo].[User] AS t
	WHERE 
		t.[Id] = @id
END