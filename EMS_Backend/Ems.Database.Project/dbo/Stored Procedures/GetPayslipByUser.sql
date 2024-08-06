CREATE PROCEDURE [dbo].[GetPayslipByUser]
(
   @UserUID UNIQUEIDENTIFIER
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
    -- Insert statements for procedure here

	SELECT
		A.DisplayName AS AllowanceName,
		ALT.DisplayName AS AllownceType,
		P.Price
	FROM (SELECT DesignationID FROM [data].[User] WHERE [UID] = @UserUID) U
	JOIN [data].[Payslip] P ON P.DesignationId = U.DesignationID
	JOIN [config].[Designation] D ON D.Id = P.DesignationId
	JOIN [config].[Allowances] A ON A.Id = P.AllowanceId
	JOIN [config].[AllowanceType] ALT ON ALT.Id = A.AllowanceTypeID		
END