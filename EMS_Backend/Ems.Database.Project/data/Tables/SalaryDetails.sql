CREATE TABLE [data].[SalaryDetails] (
    [UID]              UNIQUEIDENTIFIER NOT NULL,
    [AllowanceID]      INT              NOT NULL,
    [TraineeAssociate] BIGINT           NULL,
    [JuniorAssociate]  BIGINT           NULL,
    [Associate]        BIGINT           NULL,
    [SeniorAssociate]  BIGINT           NULL,
    [Manager]          BIGINT           NULL,
    [SeniorManager]    BIGINT           NULL,
    [Leadership]       BIGINT           NULL,
    CONSTRAINT [PK_SalaryDetails] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_Allowances] FOREIGN KEY ([AllowanceID]) REFERENCES [config].[Allowances] ([Id])
);

