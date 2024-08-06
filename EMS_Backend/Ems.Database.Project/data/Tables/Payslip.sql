CREATE TABLE [data].[Payslip] (
    [UID]           UNIQUEIDENTIFIER NOT NULL,
    [AllowanceId]   INT              NOT NULL,
    [DesignationId] INT              NOT NULL,
    [Price]         BIGINT           NOT NULL,
    CONSTRAINT [PK_Payslip] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_Allowance] FOREIGN KEY ([AllowanceId]) REFERENCES [config].[Allowances] ([Id]),
    CONSTRAINT [FK_Designation_Payslip] FOREIGN KEY ([DesignationId]) REFERENCES [config].[Designation] ([Id])
);

