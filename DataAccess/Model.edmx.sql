
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/25/2022 18:14:41
-- Generated from EDMX file: C:\Users\Zhircon\source\repos\ChinesseCheckersServer\DataAccess\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ChinesseCheckersDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PlayerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet];
GO
IF OBJECT_ID(N'[dbo].[ConfigurationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConfigurationSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [IdPlayer] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ConfigurationSet'
CREATE TABLE [dbo].[ConfigurationSet] (
    [IdConfiguration] int IDENTITY(1,1) NOT NULL,
    [idPlayerOwner] nvarchar(max)  NOT NULL,
    [volMusic] nvarchar(max)  NOT NULL,
    [volSFX] nvarchar(max)  NOT NULL,
    [language] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdPlayer] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([IdPlayer] ASC);
GO

-- Creating primary key on [IdConfiguration] in table 'ConfigurationSet'
ALTER TABLE [dbo].[ConfigurationSet]
ADD CONSTRAINT [PK_ConfigurationSet]
    PRIMARY KEY CLUSTERED ([IdConfiguration] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------