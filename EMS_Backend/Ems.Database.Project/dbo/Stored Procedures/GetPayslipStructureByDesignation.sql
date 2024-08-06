CREATE PROCEDURE [dbo].[GetPayslipStructureByDesignation]
(
	@Designation NVARCHAR(500)
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT P.AllowanceId,
		A.[Name] AS AllowanceName,
		A.DisplayName AS AllowanceDisplayName,
		P.DesignationId,
		D.[Name] AS DesignationName,
		D.DisplayName AS DesignationDisplayName,
		P.AllowanceTypeId,
		AT.[Name] AS AllowanceTypeName,
		AT.DisplayName AS AllowanceTypeDisplayName,
		P.Price
	FROM [data].[Payslip] P
	JOIN [config].[Designation] D ON D.Id = P.DesignationId
	JOIN [config].[Allowances] A ON A.Id = P.AllowanceId
	JOIN [config].[AllowanceType] AT ON AT.Id = A.AllowanceTypeID
	WHERE D.Name = @Designation
END