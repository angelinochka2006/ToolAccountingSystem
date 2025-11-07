-- Создание базы данных
CREATE DATABASE ToolAccountingSystem;
GO

USE ToolAccountingSystem;
GO

-- Таблица ролей
CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL
);

-- Таблица пользователей
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    RoleId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

-- Таблица инструментов
CREATE TABLE Tools (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Article NVARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Таблица мест хранения
CREATE TABLE StorageLocations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    ResponsibleUserId INT NOT NULL,
    FOREIGN KEY (ResponsibleUserId) REFERENCES Users(Id)
);

-- Таблица операций с инструментом
CREATE TABLE ToolOperations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ToolId INT NOT NULL,
    StorageLocationId INT NOT NULL,
    UserId INT NOT NULL,
    WorkerUserId INT NULL,
    OperationType NVARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    OperationDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    Notes NVARCHAR(500),
    FOREIGN KEY (ToolId) REFERENCES Tools(Id),
    FOREIGN KEY (StorageLocationId) REFERENCES StorageLocations(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (WorkerUserId) REFERENCES Users(Id)
);