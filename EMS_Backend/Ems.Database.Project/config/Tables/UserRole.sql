CREATE TABLE [config].[UserRole] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (500) NOT NULL,
    [DisplayName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

