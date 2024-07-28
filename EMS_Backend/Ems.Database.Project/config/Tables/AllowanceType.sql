CREATE TABLE [config].[AllowanceType] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (500) NOT NULL,
    [DisplayName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_AllowanceType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

