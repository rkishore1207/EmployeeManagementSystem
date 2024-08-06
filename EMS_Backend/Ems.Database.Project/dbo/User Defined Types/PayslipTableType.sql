CREATE TYPE [dbo].[PayslipTableType] AS TABLE (
    [UID]             UNIQUEIDENTIFIER NOT NULL,
    [AllowanceId]     INT              NOT NULL,
    [DesignationId]   INT              NOT NULL,
    [Price]           BIGINT           NOT NULL,
    [AllowanceTypeId] INT              NOT NULL);

