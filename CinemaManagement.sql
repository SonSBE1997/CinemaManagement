CREATE DATABASE CinemaManagement	
GO

USE CinemaManagement
GO

----------------------- TẠO BẢNG ----------------------------------------------
-- Tạo bảng: Rạp
CREATE TABLE Rap
    (
      marap VARCHAR(50) NOT NULL ,
      tenrap NVARCHAR(255) NOT NULL ,
      diachi NVARCHAR(255) NOT NULL ,
      dienthoai VARCHAR(30) NOT NULL ,
      sophong INT NOT NULL ,
      tongsoghe INT NOT NULL
                    DEFAULT 0 ,
      CONSTRAINT pk_MaRap PRIMARY KEY ( marap )
    )
GO

-- Tạo bảng: Phòng Chiếu
CREATE TABLE PhongChieu
    (
      marap VARCHAR(50) NOT NULL ,
      maphong VARCHAR(50) NOT NULL ,
      tenphong NVARCHAR(255) ,
      soghe INT ,
      CONSTRAINT pk_MaPhong PRIMARY KEY ( maphong ) ,
      CONSTRAINT fk_PhongChieu_MaRap FOREIGN KEY ( marap ) REFERENCES dbo.Rap ( marap )
    )
GO

-- Tạo bảng: Giờ Chiếu
CREATE TABLE GioChieu
    (
      magiochieu VARCHAR(50) NOT NULL ,
      dongia INT ,
      CONSTRAINT pk_MaGioChieu PRIMARY KEY ( magiochieu )
    )
GO

-- Tạo bảng: Hãng Sản Xuất
CREATE TABLE HangSX
    (
      mahangsx VARCHAR(50) NOT NULL ,
      tenhangsx NVARCHAR(255) ,
      CONSTRAINT pk_MaHangSX PRIMARY KEY ( mahangsx )
    )
GO

-- Tạo bảng: Nước sản xuất
CREATE TABLE NuocSanXuat
    (
      manuocsx VARCHAR(50) NOT NULL ,
      tennuocsx NVARCHAR(255) ,
      CONSTRAINT pk_MaNuocSX PRIMARY KEY ( manuocsx )
    )
GO

-- Tạo bảng: Thể loại
CREATE TABLE TheLoai
    (
      matheloai VARCHAR(50) ,
      tentheloai NVARCHAR(100) ,
      CONSTRAINT pk_MaTheLoai PRIMARY KEY ( matheloai )
    )
GO

-- Tạo bảng: Phim
CREATE TABLE Phim
    (
      maphim VARCHAR(50) NOT NULL ,
      tenphim NVARCHAR(255) ,
      manuocsx VARCHAR(50) ,
      mahangsx VARCHAR(50) ,
      daodien NVARCHAR(100) ,
      matheloai VARCHAR(50) ,
      ngaykhoichieu DATETIME ,
      ngayketthuc DATETIME ,
      nudienvienchinh NVARCHAR(100) ,
      namdienvienchinh NVARCHAR(100) ,
      noidungchinh NVARCHAR(1000) ,
      tongchiphi BIGINT ,
      tongthu BIGINT DEFAULT 0 ,
      CONSTRAINT pk_MaPhim PRIMARY KEY ( maphim ) ,
      CONSTRAINT fk_Phim_MaNuocSX FOREIGN KEY ( manuocsx ) REFERENCES dbo.NuocSanXuat ( manuocsx ) ,
      CONSTRAINT fk_Phim_MaHangSX FOREIGN KEY ( mahangsx ) REFERENCES dbo.HangSX ( mahangsx ) ,
      CONSTRAINT fk_Phim_MaTheLoai FOREIGN KEY ( matheloai ) REFERENCES dbo.TheLoai ( matheloai )
    )
GO

-- Tạo bảng: Buổi Chiếu
CREATE TABLE BuoiChieu
    (
      mashow VARCHAR(50) NOT NULL ,
      maphim VARCHAR(50) ,
      marap VARCHAR(50) ,
      maphong VARCHAR(50) ,
      ngaychieu DATETIME ,
      magiochieu VARCHAR(50) ,
      sovedaban INT DEFAULT 0 ,
      tongtien BIGINT DEFAULT 0 ,
      CONSTRAINT pk_MaShow PRIMARY KEY ( mashow ) ,
      CONSTRAINT fk_BuoiChieu_MaPhim FOREIGN KEY ( maphim ) REFERENCES dbo.Phim ( maphim ) ,
      CONSTRAINT fk_BuoiChieu_MaRap FOREIGN KEY ( marap ) REFERENCES dbo.Rap ( marap ) ,
      CONSTRAINT fk_BuoiChieu_MaPhong FOREIGN KEY ( maphong ) REFERENCES dbo.PhongChieu ( maphong ) ,
      CONSTRAINT fk_BuoiChieu_MaGioChieu FOREIGN KEY ( magiochieu ) REFERENCES dbo.GioChieu ( magiochieu )
    )
GO

-- Tạo bảng: Vé
CREATE TABLE Ve
    (
      mashow VARCHAR(50) NOT NULL ,
      mave VARCHAR(50) NOT NULL ,
      hangghe VARCHAR(20) ,
      soghe INT ,
      trangthai NVARCHAR(50)
        DEFAULT N'Chưa đặt'
        CONSTRAINT pk_MaShow_MaVe PRIMARY KEY ( mashow, mave ) ,
      CONSTRAINT fk_Ve_MaShow FOREIGN KEY ( mashow ) REFERENCES dbo.BuoiChieu ( mashow )
    )
GO
-- Tạo bảng: tài khoản
CREATE TABLE TaiKhoan
    (
      userName VARCHAR(50) NOT NULL ,
      password VARCHAR(50) NOT NULL ,
      tenhienthi NVARCHAR(255) ,
      loaitaikhoan INT DEFAULT 0 , -- 0 là nhân viên , 1 là quản trị viên
      CONSTRAINT pk_TaiKhoan_Username PRIMARY KEY ( userName )
    )
GO


-------------------------------------- Tạo Store Procedure ----------------------------------

-- Check Login
CREATE PROC USP_Login
    @username VARCHAR(50) ,
    @password VARCHAR(50)
AS
    BEGIN
        SELECT  *
        FROM    dbo.TaiKhoan
        WHERE   userName = @username
                AND password = @password
    END
GO


-- Xóa Hãng sản xuất
CREATE PROC USP_XoaHangSX @mahangsx VARCHAR(50)
AS
    BEGIN
        SELECT  maphim
        INTO    Film
        FROM    dbo.Phim
        WHERE   mahangsx = @mahangsx;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    maphim IN ( SELECT  *
                                            FROM    Film )
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   maphim IN ( SELECT  *
                            FROM    Film )
        DELETE  dbo.Phim
        WHERE   mahangsx = @mahangsx
        DELETE  dbo.HangSX
        WHERE   mahangsx = @mahangsx
        DROP TABLE Film
    END
GO

-- Xóa nước sản xuất

CREATE PROC USP_XoaNuocSX @manuocsx VARCHAR(50)
AS
    BEGIN
        SELECT  maphim
        INTO    Film
        FROM    dbo.Phim
        WHERE   manuocsx = @manuocsx;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    maphim IN ( SELECT  *
                                            FROM    Film )
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   maphim IN ( SELECT  *
                            FROM    Film )
        DELETE  dbo.Phim
        WHERE   manuocsx = @manuocsx
        DELETE  dbo.NuocSanXuat
        WHERE   manuocsx = @manuocsx
        DROP TABLE Film
    END
GO

-- Xóa thể loại
CREATE PROC USP_XoaTheLoai @matheloai VARCHAR(50)
AS
    BEGIN
        SELECT  maphim
        INTO    Film
        FROM    dbo.Phim
        WHERE   matheloai = @matheloai;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    maphim IN ( SELECT  *
                                            FROM    Film )
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   maphim IN ( SELECT  *
                            FROM    Film )
        DELETE  dbo.Phim
        WHERE   matheloai = @matheloai
        DELETE  dbo.TheLoai
        WHERE   matheloai = @matheloai
        DROP TABLE Film
    END
GO

-- Xóa Giờ chiếu

CREATE PROC USP_XoaGioChieu
    @magiochieu VARCHAR(50)
AS
    BEGIN
		;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    magiochieu = @magiochieu
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   magiochieu = @magiochieu
        DELETE  dbo.GioChieu
        WHERE   magiochieu = @magiochieu
    END
GO

-- Xóa phòng chiếu
CREATE PROC USP_XoaPhongChieu
    @maphongchieu VARCHAR(50)
AS
    BEGIN
		;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    maphong = @maphongchieu
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   maphong = @maphongchieu
        DELETE  dbo.PhongChieu
        WHERE   maphong = @maphongchieu
    END
GO

-- Xóa rạp chiếu
CREATE PROC USP_XoaRapChieu
    @marapchieu VARCHAR(50)
AS
    BEGIN
		;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    marap = @marapchieu
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   marap = @marapchieu
        DELETE  dbo.PhongChieu
        WHERE   marap = @marapchieu
        DELETE  dbo.Rap
        WHERE   marap = @marapchieu
    END
GO	

-- Xóa phim
CREATE PROC USP_XoaPhim @maphim VARCHAR(50)
AS
    BEGIN
		;
        WITH    Show
                  AS ( SELECT   mashow
                       FROM     dbo.BuoiChieu
                       WHERE    maphim = @maphim
                     )
            DELETE  dbo.Ve
            WHERE   mashow IN ( SELECT  *
                                FROM    Show )
        DELETE  dbo.BuoiChieu
        WHERE   maphim = @maphim
        DELETE  dbo.Phim
        WHERE   maphim = @maphim
    END
GO

-- Xóa Buổi Chiếu
CREATE PROC USP_XoaBuoiChieu @mashow VARCHAR(50)
AS
    BEGIN
        DELETE  dbo.Ve
        WHERE   mashow = @mashow
        DELETE  dbo.BuoiChieu
        WHERE   mashow = @mashow
    END
GO	

-- Lấy tất cả thông tin phim
CREATE PROC USP_GetAllFilm
AS
    BEGIN

        SELECT  p.maphim ,
                p.tenphim ,
                n.tennuocsx ,
                h.tenhangsx ,
                p.daodien ,
                t.tentheloai ,
                p.ngaykhoichieu ,
                p.ngayketthuc ,
                p.nudienvienchinh ,
                p.namdienvienchinh ,
                p.noidungchinh ,
                p.tongchiphi ,
                p.tongthu
        FROM    dbo.Phim AS p ,
                dbo.HangSX AS h ,
                dbo.NuocSanXuat AS n ,
                dbo.TheLoai AS t
        WHERE   p.manuocsx = n.manuocsx
                AND p.mahangsx = h.mahangsx
                AND p.matheloai = t.matheloai

    END
GO


--------------------------------------------- TẠO CÁC TRIGGER -----------------------------------------------

