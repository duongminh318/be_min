/*
    Production - Variants: Quan hệ 1-N, 1 production có nhiều biến thế khác nhau
    AttributeTypes - Attribute: quan hệ 1-N
    Biến Thể - Thuộc Tính (VariantAttributes): Quan hệ N-N vì vậy tách ra 1 bản trung gian là VariantAttributes

*/

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    BasePrice DECIMAL(10, 2),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Variants (
    VariantID INT PRIMARY KEY IDENTITY,
    ProductID INT,
    Name VARCHAR(100) UNIQUE NOT NULL,
    Price DECIMAL(10, 2),
    NumberInStock INT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE AttributeTypes (
    AttributeTypeID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(63) NOT NULL 
);

select * from AttributeTypes

CREATE TABLE Attributes (
    AttributeID INT PRIMARY KEY IDENTITY,
    AttributeTypeID INT,
    AttributeValue VARCHAR(63) NOT NULL,  -- e.g., 'small', 'red'
    FOREIGN KEY (AttributeTypeID) REFERENCES AttributeTypes(AttributeTypeID)
);

select * from Attributes

CREATE TABLE VariantAttributes (
    VariantID INT,
    AttributeID INT,
    PRIMARY KEY (VariantID, AttributeID),
    FOREIGN KEY (VariantID) REFERENCES Variants(VariantID),
    FOREIGN KEY (AttributeID) REFERENCES Attributes(AttributeID)
);

select * from VariantAttributes
select * from Attributes

INSERT INTO Products (Name, Description, BasePrice)
VALUES 
('T-Shirt', 'Basic T-Shirt', 10.00),
('Jeans', 'Classic Blue Jeans', 40.00);

INSERT INTO AttributeTypes (Name)
VALUES 
('Color'),
('Size'),
('Material');

INSERT INTO Attributes (AttributeTypeID, AttributeValue)
VALUES 
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Color'), 'Red'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Color'), 'Blue'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Size'), 'Small'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Size'), 'Medium'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Material'), 'Cotton'),
((SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Material'), 'Denim');

INSERT INTO Variants (ProductID, Name, Price, NumberInStock)
VALUES 
(1, 'TSHIRT_RED_SMALL_COTTON', 12.00, 100),  -- T-Shirt variant
(2, 'JEANS_BLUE_MEDIUM_DENIM', 42.00, 20);   -- Jeans variant

-- For T-Shirt variant
INSERT INTO VariantAttributes (VariantID, AttributeID)
VALUES 
((SELECT VariantID FROM Variants WHERE Name = 'TSHIRT_RED_SMALL_COTTON'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Red')),
((SELECT VariantID FROM Variants WHERE Name = 'TSHIRT_RED_SMALL_COTTON'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Small')),
((SELECT VariantID FROM Variants WHERE Name = 'TSHIRT_RED_SMALL_COTTON'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Cotton'));

-- For Jeans variant
INSERT INTO VariantAttributes (VariantID, AttributeID)
VALUES 
((SELECT VariantID FROM Variants WHERE Name = 'JEANS_BLUE_MEDIUM_DENIM'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Blue')),
((SELECT VariantID FROM Variants WHERE Name = 'JEANS_BLUE_MEDIUM_DENIM'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Medium')),
((SELECT VariantID FROM Variants WHERE Name = 'JEANS_BLUE_MEDIUM_DENIM'), (SELECT AttributeID FROM Attributes WHERE AttributeValue = 'Denim'));


SELECT v.VariantID,
        p.ProductID, 
       p.Name AS ProductName,
       s.AttributeValue AS Size,
       c.AttributeValue AS Color,
       s1.AttributeValue as Material,
       v.Name as VariantName,
       v.Price,
       v.NumberInStock
FROM Products p 
    JOIN Variants v ON p.ProductID = v.ProductID   

    JOIN VariantAttributes cva ON v.VariantID = cva.VariantID
    JOIN Attributes c ON cva.AttributeID = c.AttributeID  
                    AND c.AttributeTypeID = (SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Color')

    JOIN VariantAttributes sva ON v.VariantID = sva.VariantID 
    JOIN Attributes s ON sva.AttributeID = s.AttributeID
                    AND s.AttributeTypeID = (SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Size')

    JOIN VariantAttributes tva ON v.VariantID = tva.VariantID
    JOIN Attributes s1 ON tva.AttributeID = s1.AttributeID
                 AND s1.AttributeTypeID = (SELECT AttributeTypeID FROM AttributeTypes WHERE Name = 'Material')  
                 
where p.ProductID = 1                 

