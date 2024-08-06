CREATE TABLE [config].[Designation] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (500) NOT NULL,
    [DisplayName] VARCHAR (500) NOT NULL,
    [Level]       INT           NULL,
    CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED ([Id] ASC)
);



