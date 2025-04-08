IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Department] (
    [DepartmentId] int NOT NULL IDENTITY,
    [DepartmentName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([DepartmentId])
);
GO

CREATE TABLE [Employee] (
    [EmployeeId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [DepartmentId] int NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeId]),
    CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([DepartmentId]) ON DELETE SET NULL
);
GO

CREATE INDEX [IX_Employee_DepartmentId] ON [Employee] ([DepartmentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408163152_AllowNullDepartmentInEmployee', N'6.0.35');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408164257_MakeDepartmentIdNullable', N'6.0.35');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408164546_InitSchema', N'6.0.35');
GO

COMMIT;
GO

