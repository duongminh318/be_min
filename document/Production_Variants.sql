/*
    Production - Variants: Quan hệ 1-N, 1 production có nhiều biến thế khác nhau
    AttributeTypes - Attribute: quan hệ 1-N
    Biến Thể - Thuộc Tính (VariantAttributes): Quan hệ N-N vì vậy tách ra 1 bản trung gian là VariantAttributes

*/

-- Tạo bảng Products để lưu thông tin sản phẩm
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY, -- Khóa chính, tự tăng
    Name VARCHAR(255) NOT NULL,         -- Tên sản phẩm
    Description TEXT,                    -- Mô tả sản phẩm
    BasePrice DECIMAL(10, 2),            -- Giá cơ bản của sản phẩm
    CreatedAt DATETIME DEFAULT GETDATE(), -- Thời gian tạo
    UpdatedAt DATETIME DEFAULT GETDATE()  -- Thời gian cập nhật gần nhất
);

-- Tạo bảng Variants để lưu thông tin biến thể của sản phẩm
CREATE TABLE Variants (
    VariantID INT PRIMARY KEY IDENTITY,  -- Khóa chính, tự tăng
    ProductID INT,                        -- Liên kết với ProductID
    Name VARCHAR(100) UNIQUE NOT NULL,    -- Tên biến thể, không được trùng
    Price DECIMAL(10, 2),                 -- Giá của biến thể
    NumberInStock INT DEFAULT 0,          -- Số lượng tồn kho, mặc định là 0
    CreatedAt DATETIME DEFAULT GETDATE(), -- Thời gian tạo
    UpdatedAt DATETIME DEFAULT GETDATE(), -- Thời gian cập nhật
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) -- Khóa ngoại liên kết với Products
);

-- Tạo bảng AttributeTypes để lưu loại thuộc tính (màu sắc, kích thước, chất liệu)
CREATE TABLE AttributeTypes (
    AttributeTypeID INT PRIMARY KEY IDENTITY, -- Khóa chính, tự tăng
    Name VARCHAR(63) NOT NULL                 -- Tên loại thuộc tính
);

-- Kiểm tra dữ liệu trong bảng AttributeTypes
SELECT * FROM AttributeTypes;

-- Tạo bảng Attributes để lưu giá trị thuộc tính (Red, Small, Cotton, ...)
CREATE TABLE Attributes (
    AttributeID INT PRIMARY KEY IDENTITY, -- Khóa chính, tự tăng
    AttributeTypeID INT,                   -- Liên kết với loại thuộc tính
    AttributeValue VARCHAR(63) NOT NULL,   -- Giá trị thuộc tính (e.g., 'Red', 'Small')
    FOREIGN KEY (AttributeTypeID) REFERENCES AttributeTypes(AttributeTypeID) -- Khóa ngoại
);

-- Kiểm tra dữ liệu trong bảng Attributes
SELECT * FROM Attributes;

-- Tạo bảng trung gian VariantAttributes để liên kết Variants và Attributes (quan hệ N-N)
CREATE TABLE VariantAttributes (
    VariantID INT, -- Khóa chính kết hợp, liên kết với Variants
    AttributeID INT, -- Khóa chính kết hợp, liên kết với Attributes
    PRIMARY KEY (VariantID, AttributeID),
    FOREIGN KEY (VariantID) REFERENCES Variants(VariantID),
    FOREIGN KEY (AttributeID) REFERENCES Attributes(AttributeID)
);

-- Kiểm tra dữ liệu trong bảng VariantAttributes
SELECT * FROM VariantAttributes;
SELECT * FROM Attributes;

-- Chèn dữ liệu mẫu vào bảng Products
INSERT INTO Products (Name, Description, BasePrice)
VALUES 
('T-Shirt', 'Basic T-Shirt', 10.00),
('Jeans', 'Classic Blue Jeans', 40.00);

-- Chèn dữ liệu mẫu vào bảng AttributeTypes
INSERT INTO AttributeTypes (Name)
VALUES 
('Color'),    -- Màu sắc
('Size'),     -- Kích thước
('Material'); -- Chất liệu

-- Chèn dữ liệu mẫu vào bảng Attributes
INSERT INTO Attributes (AttributeTypeID, AttributeValue)
VALUES 
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Color'), 'Red'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Color'), 'Blue'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Size'), 'Small'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Size'), 'Medium'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Material'), 'Cotton'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Material'), 'Denim');

-- Chèn dữ liệu mẫu vào bảng Variants
INSERT INTO Variants (ProductID, Name, Price, NumberInStock)
VALUES 
(1, 'TSHIRT_RED_SMALL_COTTON', 12.00, 100),  -- Biến thể của T-Shirt
(2, 'JEANS_BLUE_MEDIUM_DENIM', 42.00, 20);   -- Biến thể của Jeans

-- Chèn dữ liệu vào VariantAttributes cho biến thể của T-Shirt
INSERT INTO VariantAttributes (VariantID, AttributeID)
VALUES 
((SELECT VariantID FROM Variants WHERE Name = 'TSHIRT_RED_SMALL_COTTON'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Red')),
((SELECT VariantID FROM Variants WHERE Name = 'TSHIRT_RED_SMALL_COTTON'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Small')),
((SELECT VariantID FROM Variants WHERE Name = 'TSHIRT_RED_SMALL_COTTON'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Cotton'));

-- Chèn dữ liệu vào VariantAttributes cho biến thể của Jeans
INSERT INTO VariantAttributes (VariantID, AttributeID)
VALUES 
((SELECT VariantID FROM Variants WHERE Name = 'JEANS_BLUE_MEDIUM_DENIM'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Blue')),
((SELECT VariantID FROM Variants WHERE Name = 'JEANS_BLUE_MEDIUM_DENIM'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Medium')),
((SELECT VariantID FROM Variants WHERE Name = 'JEANS_BLUE_MEDIUM_DENIM'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Denim'));

-- Lấy thông tin các biến thể của sản phẩm (trong ví dụ này là sản phẩm có ProductID = 1)
SELECT 
    v.VariantID,                     -- ID của biến thể
    p.ProductID,                     -- ID của sản phẩm
    p.Name AS ProductName,            -- Tên sản phẩm
    s.AttributeValue AS Size,         -- Kích thước của biến thể
    c.AttributeValue AS Color,        -- Màu sắc của biến thể
    s1.AttributeValue AS Material,    -- Chất liệu của biến thể
    v.Name AS VariantName,            -- Tên biến thể
    v.Price,                          -- Giá của biến thể
    v.NumberInStock                   -- Số lượng tồn kho
FROM Products p 
    JOIN Variants v ON p.ProductID = v.ProductID  -- Nối với bảng Variants dựa trên ProductID   

    -- Lấy thông tin màu sắc của biến thể
    JOIN VariantAttributes cva ON v.VariantID = cva.VariantID
    JOIN Attributes c ON cva.AttributeID = c.AttributeID  
                    AND c.AttributeTypeID = (SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Color')

    -- Lấy thông tin kích thước của biến thể
    JOIN VariantAttributes sva ON v.VariantID = sva.VariantID 
    JOIN Attributes s ON sva.AttributeID = s.AttributeID
                    AND s.AttributeTypeID = (SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Size')

    -- Lấy thông tin chất liệu của biến thể
    JOIN VariantAttributes tva ON v.VariantID = tva.VariantID
    JOIN Attributes s1 ON tva.AttributeID = s1.AttributeID
                 AND s1.AttributeTypeID = (SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Material')  

WHERE p.ProductID = 1;  -- Lọc theo sản phẩm có ID = 1 (T-Shirt)

--Giải thích tổng quát:
--Cấu trúc bảng:

--Products: Lưu sản phẩm chính.
--Variants: Lưu biến thể của sản phẩm.
--AttributeTypes: Loại thuộc tính (Màu sắc, Kích thước, Chất liệu...).
--Attributes: Giá trị của từng thuộc tính.
--VariantAttributes: Bảng trung gian liên kết Variants và Attributes.
--Chèn dữ liệu mẫu:

--Tạo một số sản phẩm (T-Shirt, Jeans).
--Tạo các thuộc tính (Red, Blue, Small, Medium, Cotton, Denim).
--Gán biến thể sản phẩm (TSHIRT_RED_SMALL_COTTON, JEANS_BLUE_MEDIUM_DENIM).
--Liên kết các thuộc tính với biến thể sản phẩm.
--Truy vấn thông tin biến thể:

--Truy vấn ProductID = 1 để lấy danh sách biến thể của sản phẩm T-Shirt, hiển thị màu sắc, kích thước, chất liệu và giá của từng biến thể.