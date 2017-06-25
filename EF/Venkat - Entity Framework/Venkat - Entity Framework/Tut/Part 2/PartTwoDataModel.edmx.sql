
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/25/2017 19:00:52
-- Generated from EDMX file: E:\Users\GiHub\C-Sharp-titbits\EF\Venkat - Entity Framework\Venkat - Entity Framework\Tut\Part 2\PartTwoDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Venkat - Entity Framework];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID('[Venkat - Entity Framework].[DepartmentMFs]') IS NOT NULL
   DROP TABLE [Venkat - Entity Framework].[DepartmentMFs]
GO

IF OBJECT_ID('[Venkat - Entity Framework].[EmployeeMFs]') IS NOT NULL
   DROP TABLE [Venkat - Entity Framework].[EmployeeMFs]
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DepartmentMFs'
CREATE TABLE [dbo].[DepartmentMFs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'EmployeeMFs'
CREATE TABLE [dbo].[EmployeeMFs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Salary] decimal(18,0)  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DepartmentMFs'
ALTER TABLE [dbo].[DepartmentMFs]
ADD CONSTRAINT [PK_DepartmentMFs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeMFs'
ALTER TABLE [dbo].[EmployeeMFs]
ADD CONSTRAINT [PK_EmployeeMFs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentId] in table 'EmployeeMFs'
ALTER TABLE [dbo].[EmployeeMFs]
ADD CONSTRAINT [FK_DepartmentEmployee]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[DepartmentMFs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentEmployee'
CREATE INDEX [IX_FK_DepartmentEmployee]
ON [dbo].[EmployeeMFs]
    ([DepartmentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------