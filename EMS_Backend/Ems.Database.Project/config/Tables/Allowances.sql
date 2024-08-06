CREATE TABLE [config].[Allowances] (
    [Id]              INT           NOT NULL,
    [Name]            VARCHAR (500) NOT NULL,
    [DisplayName]     VARCHAR (500) NOT NULL,
    [AllowanceTypeID] INT           NOT NULL,
    [OrderNumber]     INT           NULL,
    CONSTRAINT [PK_Allowances] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AllowanceType] FOREIGN KEY ([AllowanceTypeID]) REFERENCES [config].[AllowanceType] ([Id])
);



