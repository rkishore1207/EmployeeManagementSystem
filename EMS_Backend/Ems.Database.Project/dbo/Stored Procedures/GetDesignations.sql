CREATE PROCEDURE [dbo].[GetDesignations]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT Id,
		DisplayName,
		[Name],
		Level
	FROM [config].[Designation]
END