CREATE TABLE [data].[User] (
    [UID]                      UNIQUEIDENTIFIER NOT NULL,
    [EmployeeID]               VARCHAR (500)    NOT NULL,
    [FirstName]                VARCHAR (500)    NOT NULL,
    [LastName]                 VARCHAR (500)    NULL,
    [RoleID]                   INT              NULL,
    [DesignationID]            INT              NULL,
    [ManagerUID]               UNIQUEIDENTIFIER NULL,
    [IsActive]                 BIT              NOT NULL,
    [Email]                    VARCHAR (500)    NOT NULL,
    [Address]                  VARCHAR (MAX)    NULL,
    [PhoneNumber]              VARCHAR (15)     NOT NULL,
    [DateOfBirth]              DATETIME         NULL,
    [DateOfJoin]               DATETIME         NOT NULL,
    [Location]                 VARCHAR (500)    NULL,
    [About]                    VARCHAR (MAX)    NULL,
    [PrivilegeLeave]           INT              NULL,
    [WellnessLeave]            INT              NULL,
    [EarnedLeave]              INT              NULL,
    [CompOff]                  INT              NULL,
    [OptionalLeave]            INT              NULL,
    [LossOfPay]                INT              NULL,
    [MaritalStatus]            VARCHAR (500)    NULL,
    [Age]                      INT              NULL,
    [Gender]                   VARCHAR (500)    NULL,
    [BloodGroup]               VARCHAR (500)    NULL,
    [EmergencyNumber]          VARCHAR (15)     NULL,
    [School]                   VARCHAR (500)    NULL,
    [College]                  VARCHAR (500)    NULL,
    [PreviousCompany]          VARCHAR (500)    NULL,
    [PasswordHash]             VARBINARY (MAX)  NULL,
    [HashKey]                  VARBINARY (MAX)  NULL,
    [ResetPasswordToken]       VARCHAR (MAX)    NULL,
    [ResetPasswordTokenExpiry] DATETIME         NULL,
    [CreatedBy]                UNIQUEIDENTIFIER NULL,
    [CreatedOn]                DATETIME         NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_Designation] FOREIGN KEY ([DesignationID]) REFERENCES [config].[Designation] ([Id]),
    CONSTRAINT [FK_Manager] FOREIGN KEY ([ManagerUID]) REFERENCES [data].[User] ([UID]),
    CONSTRAINT [FK_UserRole] FOREIGN KEY ([RoleID]) REFERENCES [config].[UserRole] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Email]
    ON [data].[User]([Email] ASC);

