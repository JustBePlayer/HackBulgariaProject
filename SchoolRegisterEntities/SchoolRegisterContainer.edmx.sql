
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/17/2016 12:11:59
-- Generated from EDMX file: D:\Projects\SchoolRegister\SchoolRegisterEntities\SchoolRegisterContainer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'School'
CREATE TABLE [dbo].[School] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Class'
CREATE TABLE [dbo].[Class] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Letter] nvarchar(max)  NOT NULL,
    [Teacher] nvarchar(max)  NOT NULL,
    [SchoolId] int  NOT NULL
);
GO

-- Creating table 'Subject'
CREATE TABLE [dbo].[Subject] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mark] int  NOT NULL,
    [SubjectId] int  NOT NULL,
    [TeacherId] int  NOT NULL,
    [TeacherId1] int  NOT NULL,
    [Student_Id] int  NOT NULL
);
GO

-- Creating table 'Notification'
CREATE TABLE [dbo].[Notification] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SubjectId] int  NOT NULL
);
GO

-- Creating table 'User_Teacher'
CREATE TABLE [dbo].[User_Teacher] (
    [Password] nvarchar(max)  NOT NULL,
    [Salt] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [School_Id] int  NOT NULL
);
GO

-- Creating table 'User_Student'
CREATE TABLE [dbo].[User_Student] (
    [Egn] nvarchar(max)  NOT NULL,
    [Class] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ClassSubject'
CREATE TABLE [dbo].[ClassSubject] (
    [Class_Id] int  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'School'
ALTER TABLE [dbo].[School]
ADD CONSTRAINT [PK_School]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Class'
ALTER TABLE [dbo].[Class]
ADD CONSTRAINT [PK_Class]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subject'
ALTER TABLE [dbo].[Subject]
ADD CONSTRAINT [PK_Subject]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notification'
ALTER TABLE [dbo].[Notification]
ADD CONSTRAINT [PK_Notification]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User_Teacher'
ALTER TABLE [dbo].[User_Teacher]
ADD CONSTRAINT [PK_User_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User_Student'
ALTER TABLE [dbo].[User_Student]
ADD CONSTRAINT [PK_User_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Class_Id], [Subject_Id] in table 'ClassSubject'
ALTER TABLE [dbo].[ClassSubject]
ADD CONSTRAINT [PK_ClassSubject]
    PRIMARY KEY CLUSTERED ([Class_Id], [Subject_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [School_Id] in table 'User_Teacher'
ALTER TABLE [dbo].[User_Teacher]
ADD CONSTRAINT [FK_TeacherSchool]
    FOREIGN KEY ([School_Id])
    REFERENCES [dbo].[School]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherSchool'
CREATE INDEX [IX_FK_TeacherSchool]
ON [dbo].[User_Teacher]
    ([School_Id]);
GO

-- Creating foreign key on [SchoolId] in table 'Class'
ALTER TABLE [dbo].[Class]
ADD CONSTRAINT [FK_SchoolClass]
    FOREIGN KEY ([SchoolId])
    REFERENCES [dbo].[School]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolClass'
CREATE INDEX [IX_FK_SchoolClass]
ON [dbo].[Class]
    ([SchoolId]);
GO

-- Creating foreign key on [Class_Id] in table 'ClassSubject'
ALTER TABLE [dbo].[ClassSubject]
ADD CONSTRAINT [FK_ClassSubject_Class]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[Class]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Subject_Id] in table 'ClassSubject'
ALTER TABLE [dbo].[ClassSubject]
ADD CONSTRAINT [FK_ClassSubject_Subject]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[Subject]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassSubject_Subject'
CREATE INDEX [IX_FK_ClassSubject_Subject]
ON [dbo].[ClassSubject]
    ([Subject_Id]);
GO

-- Creating foreign key on [SubjectId] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_SubjectGrades]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subject]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectGrades'
CREATE INDEX [IX_FK_SubjectGrades]
ON [dbo].[Grades]
    ([SubjectId]);
GO

-- Creating foreign key on [SubjectId] in table 'Notification'
ALTER TABLE [dbo].[Notification]
ADD CONSTRAINT [FK_SubjectNotification]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subject]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectNotification'
CREATE INDEX [IX_FK_SubjectNotification]
ON [dbo].[Notification]
    ([SubjectId]);
GO

-- Creating foreign key on [Student_Id] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_StudentGrades]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[User_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentGrades'
CREATE INDEX [IX_FK_StudentGrades]
ON [dbo].[Grades]
    ([Student_Id]);
GO

-- Creating foreign key on [TeacherId1] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_TeacherGrades]
    FOREIGN KEY ([TeacherId1])
    REFERENCES [dbo].[User_Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherGrades'
CREATE INDEX [IX_FK_TeacherGrades]
ON [dbo].[Grades]
    ([TeacherId1]);
GO

-- Creating foreign key on [Id] in table 'User_Teacher'
ALTER TABLE [dbo].[User_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'User_Student'
ALTER TABLE [dbo].[User_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------