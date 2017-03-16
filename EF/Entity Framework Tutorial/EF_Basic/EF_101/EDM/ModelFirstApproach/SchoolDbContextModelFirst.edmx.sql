
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2017 03:24:12
-- Generated from EDMX file: E:\Users\GiHub\C-Sharp-titbits\EF\Entity Framework Tutorial\EF_Basic\EF_101\EDM\ModelFirstApproach\SchoolDbContextModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SchoolDbContextModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Courses1'
CREATE TABLE [dbo].[Courses1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TeacherId] int  NOT NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CourseStudent'
CREATE TABLE [dbo].[CourseStudent] (
    [Courses_Id] int  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Courses1'
ALTER TABLE [dbo].[Courses1]
ADD CONSTRAINT [PK_Courses1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Courses_Id], [Students_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [PK_CourseStudent]
    PRIMARY KEY CLUSTERED ([Courses_Id], [Students_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TeacherId] in table 'Courses1'
ALTER TABLE [dbo].[Courses1]
ADD CONSTRAINT [FK_TeacherCourse]
    FOREIGN KEY ([TeacherId])
    REFERENCES [dbo].[Teachers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherCourse'
CREATE INDEX [IX_FK_TeacherCourse]
ON [dbo].[Courses1]
    ([TeacherId]);
GO

-- Creating foreign key on [Courses_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [FK_CourseStudent_Course]
    FOREIGN KEY ([Courses_Id])
    REFERENCES [dbo].[Courses1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Students_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [FK_CourseStudent_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseStudent_Student'
CREATE INDEX [IX_FK_CourseStudent_Student]
ON [dbo].[CourseStudent]
    ([Students_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------