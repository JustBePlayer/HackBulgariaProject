
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2016 17:01:11
-- Generated from EDMX file: C:\Users\Nicky\Documents\GitHub\HackBulgariaProject\SchoolEntities\SchoolEntityContainer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SchoolSystemDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SchoolClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_SchoolClass];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherGrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [FK_TeacherGrade];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_ClassTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subjects] DROP CONSTRAINT [FK_ClassSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectGrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [FK_SubjectGrade];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectNotification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notifications] DROP CONSTRAINT [FK_SubjectNotification];
GO
IF OBJECT_ID(N'[dbo].[FK_SchoolTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Teacher] DROP CONSTRAINT [FK_SchoolTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentGrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [FK_StudentGrade];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Student] DROP CONSTRAINT [FK_ClassStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Teacher] DROP CONSTRAINT [FK_Teacher_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Student] DROP CONSTRAINT [FK_Student_inherits_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classes];
GO
IF OBJECT_ID(N'[dbo].[Schools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schools];
GO
IF OBJECT_ID(N'[dbo].[Subjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subjects];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[Grades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grades];
GO
IF OBJECT_ID(N'[dbo].[Users_Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Teacher];
GO
IF OBJECT_ID(N'[dbo].[Users_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Student];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] int  NOT NULL,
    [Letter] nvarchar(max)  NOT NULL,
    [SchoolId] int  NOT NULL,
    [Teacher_Id] int  NOT NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ClassId] int  NOT NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SubjectId] int  NOT NULL
);
GO

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mark] int  NOT NULL,
    [TeacherId] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [SubjectId] int  NOT NULL,
    [StudentId1] int  NOT NULL
);
GO

-- Creating table 'Users_Teacher'
CREATE TABLE [dbo].[Users_Teacher] (
    [Password] nvarchar(max)  NOT NULL,
    [Salt] nvarchar(max)  NOT NULL,
    [SchoolId] int  NOT NULL,
    [SchoolId1] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Users_Student'
CREATE TABLE [dbo].[Users_Student] (
    [Egn] nvarchar(max)  NOT NULL,
    [ClassId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [PK_Users_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [PK_Users_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SchoolId] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_SchoolClass]
    FOREIGN KEY ([SchoolId])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolClass'
CREATE INDEX [IX_FK_SchoolClass]
ON [dbo].[Classes]
    ([SchoolId]);
GO

-- Creating foreign key on [TeacherId] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_TeacherGrade]
    FOREIGN KEY ([TeacherId])
    REFERENCES [dbo].[Users_Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherGrade'
CREATE INDEX [IX_FK_TeacherGrade]
ON [dbo].[Grades]
    ([TeacherId]);
GO

-- Creating foreign key on [Teacher_Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_ClassTeacher]
    FOREIGN KEY ([Teacher_Id])
    REFERENCES [dbo].[Users_Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassTeacher'
CREATE INDEX [IX_FK_ClassTeacher]
ON [dbo].[Classes]
    ([Teacher_Id]);
GO

-- Creating foreign key on [ClassId] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [FK_ClassSubject]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[Classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassSubject'
CREATE INDEX [IX_FK_ClassSubject]
ON [dbo].[Subjects]
    ([ClassId]);
GO

-- Creating foreign key on [SubjectId] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_SubjectGrade]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectGrade'
CREATE INDEX [IX_FK_SubjectGrade]
ON [dbo].[Grades]
    ([SubjectId]);
GO

-- Creating foreign key on [SubjectId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_SubjectNotification]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectNotification'
CREATE INDEX [IX_FK_SubjectNotification]
ON [dbo].[Notifications]
    ([SubjectId]);
GO

-- Creating foreign key on [SchoolId1] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [FK_SchoolTeacher]
    FOREIGN KEY ([SchoolId1])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolTeacher'
CREATE INDEX [IX_FK_SchoolTeacher]
ON [dbo].[Users_Teacher]
    ([SchoolId1]);
GO

-- Creating foreign key on [StudentId1] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_StudentGrade]
    FOREIGN KEY ([StudentId1])
    REFERENCES [dbo].[Users_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentGrade'
CREATE INDEX [IX_FK_StudentGrade]
ON [dbo].[Grades]
    ([StudentId1]);
GO

-- Creating foreign key on [ClassId] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [FK_ClassStudent]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[Classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassStudent'
CREATE INDEX [IX_FK_ClassStudent]
ON [dbo].[Users_Student]
    ([ClassId]);
GO

-- Creating foreign key on [Id] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------