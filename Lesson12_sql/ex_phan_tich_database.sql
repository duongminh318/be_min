-- Tạo cơ sở dữ liệu
CREATE DATABASE AnalyticPortal;
GO

-- Sử dụng cơ sở dữ liệu
USE AnalyticPortal;
GO

-- Tạo bảng Department (Phòng ban)
CREATE TABLE Department (
    DepartmentID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL
);

-- Tạo bảng User (Người dùng)
CREATE TABLE [User] (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    DepartmentID UNIQUEIDENTIFIER NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID) ON DELETE SET NULL
);

-- Tạo bảng Document (Tài liệu)
CREATE TABLE Document (
    DocumentID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    UploadedBy UNIQUEIDENTIFIER NOT NULL,
    UploadedDate DATETIME DEFAULT GETDATE(),
    Version INT DEFAULT 1,
    IsAnalyzed BIT DEFAULT 0,
    FOREIGN KEY (UploadedBy) REFERENCES [User](UserID) ON DELETE CASCADE
);

-- Tạo bảng AnalysisRequest (Yêu cầu phân tích)
CREATE TABLE AnalysisRequest (
    RequestID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DocumentID UNIQUEIDENTIFIER NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Pending',
    SubmittedDate DATETIME DEFAULT GETDATE(),
    CompletedDate DATETIME NULL,
    FOREIGN KEY (DocumentID) REFERENCES Document(DocumentID) ON DELETE CASCADE
);

-- Tạo bảng AnalysisResult (Kết quả phân tích)
CREATE TABLE AnalysisResult (
    ResultID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    RequestID UNIQUEIDENTIFIER NOT NULL,
    ResultDetails NVARCHAR(MAX) NOT NULL,
    MalwareType NVARCHAR(100) NULL,
    SeverityLevel NVARCHAR(50) NULL,
    FOREIGN KEY (RequestID) REFERENCES AnalysisRequest(RequestID) ON DELETE CASCADE
);

-- Tạo bảng Notification (Thông báo)
CREATE TABLE Notification (
    NotificationID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserID UNIQUEIDENTIFIER NOT NULL,
    Message NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsRead BIT DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES [User](UserID) ON DELETE CASCADE
);

-- Thêm chỉ mục để tăng hiệu suất
CREATE INDEX IX_Document_FileName ON Document(FileName);
CREATE INDEX IX_AnalysisRequest_Status ON AnalysisRequest(Status);
CREATE INDEX IX_Notification_IsRead ON Notification(IsRead);
