--Bài tập: Quản lý thông tin sinh viên và phòng ban
--1.	Tạo bảng Departments để lưu trữ thông tin về các phòng ban với các trường sau:
--•	DepartmentID (kiểu uniqueidentifier làm khóa chính)
--•	DepartmentName (nvarchar(50)

--2.	Tạo bảng Students để lưu trữ thông tin sinh viên với các trường sau:
--•	StudentID (kiểu uniqueidentifier làm khóa chính)
--•	LastName (varchar(50))
--•	FirstName (varchar(50))
--•	DateOfBirth (datetime)
--•	DepartmentID (kiểu uniqueidentifier làm khóa ngoại tham chiếu tới bảng Departments)
--3.	Thêm dữ liệu vào các bảng và thực hiện thao tác thêm, sửa, xóa.

-- Kiểm tra xem database QLSV có tồn tại hay không
IF DB_ID('QLSV') IS NOT NULL
BEGIN
    DROP DATABASE QLSV; -- Xóa database nếu tồn tại
    PRINT 'Database QLSV dropped successfully.';
END

-- Tạo mới database QLSV
CREATE DATABASE QLSV;
PRINT 'Database QLSV created successfully.';

-- Sử dụng database QLSV
USE QLSV;

GO

CREATE TABLE Departments (
    DepartmentID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- Khóa chính tự động sinh GUID
    DepartmentName NVARCHAR(50) NOT NULL -- Tên phòng ban
);

CREATE TABLE Students (
    StudentID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- Khóa chính tự động sinh GUID
    LastName VARCHAR(50) NOT NULL, -- Họ sinh viên
    FirstName VARCHAR(50) NOT NULL, -- Tên sinh viên
    DateOfBirth DATETIME NOT NULL, -- Ngày sinh
    DepartmentID UNIQUEIDENTIFIER NOT NULL, -- Khóa ngoại tham chiếu phòng ban
    CONSTRAINT FK_Students_Departments FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
    ON DELETE CASCADE ON UPDATE CASCADE -- Cascade khi xóa/sửa phòng ban
);


INSERT INTO Departments (DepartmentName)
VALUES ('Computer Science'), 
       ('Mathematics'), 
       ('Physics');

-- Lấy ID của các phòng ban
DECLARE @CSID UNIQUEIDENTIFIER = (SELECT DepartmentID FROM Departments WHERE DepartmentName = 'Computer Science');
DECLARE @MathID UNIQUEIDENTIFIER = (SELECT DepartmentID FROM Departments WHERE DepartmentName = 'Mathematics');
DECLARE @PhysicsID UNIQUEIDENTIFIER = (SELECT DepartmentID FROM Departments WHERE DepartmentName = 'Physics');

-- Thêm sinh viên
INSERT INTO Students (LastName, FirstName, DateOfBirth, DepartmentID)
VALUES 
('Nguyen', 'Anh', '2000-05-10', @CSID),
('Tran', 'Binh', '2001-08-15', @CSID),
('Le', 'Chau', '1999-11-20', @MathID),
('Pham', 'Duc', '2002-01-10', @PhysicsID);


SELECT 
    s.StudentID,
    s.LastName + ' ' + s.FirstName AS FullName,
    s.DateOfBirth,
    d.DepartmentName
FROM Students s
INNER JOIN Departments d ON s.DepartmentID = d.DepartmentID;

--3 CRUD
INSERT INTO Departments (DepartmentName)
VALUES ('Chemistry');

DELETE FROM Departments
WHERE DepartmentName = 'Mathematics';

UPDATE Students
SET LastName = 'Phan', FirstName = 'An'
WHERE FirstName = 'Anh';

DELETE FROM Students
WHERE LastName = 'Tran';

select *from Departments

--xóa hoàn toàn cơ sở dữ liệu QLSV
--DROP DATABASE QLSV;
