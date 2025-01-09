-- Nếu database HoaDonBanHang đã tồn tại, xóa nó đi
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'HoaDonBanHang')
BEGIN
    DROP DATABASE HoaDonBanHang;
END
GO

-- Tạo database HoaDonBanHang
CREATE DATABASE HoaDonBanHang;
GO

USE HoaDonBanHang;
GO

-- Tạo bảng DanhMuc
CREATE TABLE DanhMuc (
    MaDanhMuc UNIQUEIDENTIFIER PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    Ngay
	Tao DATETIME NOT NULL
);

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang UNIQUEIDENTIFIER PRIMARY KEY,
    TenKhachHang NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoai NVARCHAR(20)
);

-- Tạo bảng SanPham
CREATE TABLE SanPham (
    MaSanPham UNIQUEIDENTIFIER PRIMARY KEY,
    TenSanPham NVARCHAR(100) NOT NULL,
    Gia DECIMAL(18, 2) NOT NULL,
    SoLuong INT NOT NULL,
    MaDanhMuc UNIQUEIDENTIFIER,
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
);

-- Tạo bảng DonHang
CREATE TABLE DonHang (
    MaDonHang UNIQUEIDENTIFIER PRIMARY KEY,
    NgayDat DATETIME NOT NULL,
    MaKhachHang UNIQUEIDENTIFIER,
    TongTien DECIMAL(18, 2),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaChiTiet UNIQUEIDENTIFIER PRIMARY KEY,
    MaDonHang UNIQUEIDENTIFIER,
    MaSanPham UNIQUEIDENTIFIER,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);


-- Các bảng và quan hệ giữa chúng:
-- - KhachHang: Lưu thông tin khách hàng.
-- - DanhMuc: Lưu thông tin danh mục sản phẩm.
-- - SanPham: Lưu thông tin sản phẩm, có quan hệ với DanhMuc qua MaDanhMuc.
-- - DonHang: Lưu thông tin đơn hàng, có quan hệ với KhachHang qua MaKhachHang.
-- - ChiTietDonHang: Lưu thông tin chi tiết đơn hàng, liên kết với DonHang và SanPham qua MaDonHang và MaSanPham.
