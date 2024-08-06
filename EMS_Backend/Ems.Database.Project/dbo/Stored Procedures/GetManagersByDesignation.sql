CREATE PROCEDURE [dbo].[GetManagersByDesignation]
(
	@Level int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
   SELECT 
		CONCAT(U.FirstName,' ',U.LastName) AS UserName,
		U.Email,
		D.DisplayName AS Designation,
		U.EmployeeID
   FROM [config].[Designation] D 
   JOIN [data].[User] U ON U.DesignationID = D.Id
   WHERE D.[Level] > @Level
END