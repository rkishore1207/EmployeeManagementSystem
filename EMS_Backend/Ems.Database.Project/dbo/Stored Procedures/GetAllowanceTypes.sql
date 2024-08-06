
CREATE PROCEDURE [dbo].[GetAllowanceTypes]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT Id,
		DisplayName,
		[Name]
	FROM [config].[AllowanceType]
END