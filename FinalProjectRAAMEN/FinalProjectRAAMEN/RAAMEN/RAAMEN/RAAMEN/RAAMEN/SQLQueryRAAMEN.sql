CREATE TABLE [dbo].[Role] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Roleid]   INT          NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [Gender]   VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_ToRole] FOREIGN KEY ([Roleid]) REFERENCES [dbo].[Role] ([Id])
);

CREATE TABLE [dbo].[Meat] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Ramen] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Meatid] INT          NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    [Broth]  VARCHAR (50) NOT NULL,
    [Price]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ramen_ToMeat] FOREIGN KEY ([Meatid]) REFERENCES [dbo].[Meat] ([Id])
);

CREATE TABLE [dbo].[Header] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [Customerid] INT      NOT NULL,
    [Staffid]    INT      NOT NULL,
    [Date]       DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Header_ToUser] FOREIGN KEY ([Customerid]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[Detail] (
    [Headerid] INT NOT NULL,
    [Ramenid]  INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [Primary Key] PRIMARY KEY CLUSTERED ([Headerid] ASC, [Ramenid] ASC),
    CONSTRAINT [FK_Detail_ToHeader] FOREIGN KEY ([Headerid]) REFERENCES [dbo].[Header] ([Id]),
    CONSTRAINT [FK_Detail_ToRamen] FOREIGN KEY ([Ramenid]) REFERENCES [dbo].[Ramen] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);