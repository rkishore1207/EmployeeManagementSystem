CREATE PROCEDURE [dbo].[GetUserByEmail]
(
   @UserEmail NVARCHAR(500)
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
    -- Insert statements for procedure here
    SELECT U.UID,
		   U.FirstName,
		   U.LastName,
		   U.EmployeeID,
		   U.Email,
		   U.IsActive,
		   U.ManagerUID,
		   CONCAT(M.FirstName,' ',M.LastName) AS ManagerName		
	FROM [data].[User] U
	LEFT JOIN [data].[User] M ON M.UID = U.ManagerUID
	WHERE U.Email = @UserEmail;
END