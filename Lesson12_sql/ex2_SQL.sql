--1 tạo database theo hình
-- Tạo cơ sở dữ liệu
IF DB_ID('QuanLyBanHang') IS NOT NULL
BEGIN
    DROP DATABASE QuanLyBanHang;
END
CREATE DATABASE QuanLyBanHang;
GO

USE QuanLyBanHang;

-- Tạo bảng Categories
CREATE TABLE Categories (
    CategoryId UNIQUEIDENTIFIER PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Status TINYINT NOT NULL,
    CreatedDate DATETIME NOT NULL
);

-- Tạo bảng Users
CREATE TABLE Users (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Mobile NVARCHAR(50),
    Status TINYINT NOT NULL,
    CreatedDate DATETIME NOT NULL
);

-- Tạo bảng Products
CREATE TABLE Products (
    ProductId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 0) NOT NULL,
    ManufactoringDate DATETIME NULL,
    CreatedDate DATETIME NULL,
    Description NVARCHAR(1000),
    Status TINYINT NOT NULL,
    CategoryId UNIQUEIDENTIFIER,
    UserId UNIQUEIDENTIFIER,
    Quantity INT NOT NULL,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
    CONSTRAINT FK_Products_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


--Bài tập 2: 
--1.	Insert dữ liệu cho 3 bảng đã tạo trong bài tập 1
-- Insert dữ liệu vào bảng Categories
INSERT INTO Categories (CategoryId, CategoryName, Status, CreatedDate)
VALUES 
(NEWID(), 'Electronics', 1, GETDATE()),
(NEWID(), 'Clothing', 1, GETDATE()),
(NEWID(), 'Books', 1, GETDATE());

-- Insert dữ liệu vào bảng Users
INSERT INTO Users (UserId, UserName, Password, Email, Mobile, Status, CreatedDate)
VALUES
(NEWID(), 'john_doe', 'password123', 'john.doe@example.com', '1234567890', 1, GETDATE()),
(NEWID(), 'jane_smith', 'securePass!', 'jane.smith@example.com', '0987654321', 1, GETDATE());

-- Insert dữ liệu vào bảng Products
DECLARE @CategoryIdElectronics UNIQUEIDENTIFIER, @UserIdJohn UNIQUEIDENTIFIER;

-- Lấy ID của 1 Category và User
SELECT TOP 1 @CategoryIdElectronics = CategoryId FROM Categories WHERE CategoryName = 'Electronics';
SELECT TOP 1 @UserIdJohn = UserId FROM Users WHERE UserName = 'john_doe';

INSERT INTO Products (ProductId, ProductName, Price, ManufactoringDate, CreatedDate, Description, Status, CategoryId, UserId, Quantity)
VALUES
(NEWID(), 'Smartphone', 500.00, '2023-01-01', GETDATE(), 'Latest smartphone model', 1, @CategoryIdElectronics, @UserIdJohn, 10),
(NEWID(), 'Laptop', 1000.00, '2022-12-01', GETDATE(), 'High-performance laptop', 1, @CategoryIdElectronics, @UserIdJohn, 5);

--2.	Cập nhật Price, Quantity cho 1 product bất kỳ theo Id của Product
-- Cập nhật Price và Quantity cho product có ProductId cụ thể
DECLARE @ProductIdToUpdate UNIQUEIDENTIFIER;

-- Lấy ProductId bất kỳ
SELECT TOP 1 @ProductIdToUpdate = ProductId FROM Products;

-- Cập nhật Price và Quantity
UPDATE Products
SET Price = 550.00, Quantity = 15
WHERE ProductId = @ProductIdToUpdate;

--3.	Cập nhật Quantity cho các product thuộc 1 category bất kỳ.
-- Cập nhật Quantity cho tất cả các product thuộc CategoryName = 'Electronics'
DECLARE @CategoryIdToUpdate UNIQUEIDENTIFIER;

-- Lấy CategoryId của Electronics
SELECT TOP 1 @CategoryIdToUpdate = CategoryId FROM Categories WHERE CategoryName = 'Electronics';

-- Cập nhật Quantity cho tất cả các product thuộc CategoryId
UPDATE Products
SET Quantity = Quantity + 5
WHERE CategoryId = @CategoryIdToUpdate;

--4.	Xóa 1 category bất kỳ theo Id của category
-- Lấy CategoryId bất kỳ để xóa
DECLARE @CategoryIdToDelete UNIQUEIDENTIFIER;

SELECT TOP 1 @CategoryIdToDelete = CategoryId FROM Categories;

-- Xóa các product liên quan trước (do có khóa ngoại)
DELETE FROM Products WHERE CategoryId = @CategoryIdToDelete;

-- Xóa category
DELETE FROM Categories WHERE CategoryId = @CategoryIdToDelete;


