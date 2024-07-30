CREATE PROCEDURE [dbo].[GetUsers]
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
		   UR.DisplayName AS UserRole,
		   D.DisplayName AS Designation,
		   U.[Address],
		   U.PhoneNumber,
		   U.DateOfBirth,
		   U.DateOfJoin,
		   U.ManagerUID,
		   CONCAT(M.FirstName,' ',M.LastName) AS ManagerName,
		   U.[Location],
		   U.MaritalStatus,
		   U.Age,
		   U.Gender,
		   U.BloodGroup,
		   U.EmergencyNumber,
		   U.About,
		   U.School,
		   U.College,
		   U.PreviousCompany,
		   U.PrivilegeLeave,
		   U.WellnessLeave,
		   U.EarnedLeave,
		   U.CompOff,
		   U.OptionalLeave,
		   U.LossOfPay,
		   U.PasswordHash,
		   U.HashKey,
		   U.ResetPasswordToken,
		   U.ResetPasswordTokenExpiry
	FROM [data].[User] U
	LEFT JOIN [data].[User] M ON M.UID = U.ManagerUID
	LEFT JOIN [config].[Designation] D ON D.Id = U.DesignationID
	LEFT JOIN [config].[UserRole] UR ON UR.Id = U.RoleID
END