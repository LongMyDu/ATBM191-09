-- Thử xóa bệnh nhân BN000001
Exec QLCSYTE_ADMIN.XoaBenhNhan('BN000001');

-- Thử thêm bệnh nhân BN000001
EXEC QLCSYTE_ADMIN.THEMBENHNHAN('BN000001','CS0002', N'Trần Việt Đào Bình','916773394945', '1954-03-11', '148', N'3 tháng 2', N'Q.1', N'Cần Thơ', N'NULL', N'NULL', N'NULL','TyHFH6hOI2Hz97BX');

-- Thử thêm 1 dòng vào HSBA
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0001', 'BN000001', TO_DATE('2001-01-01', 'yyyy-mm-dd'), 'chuan doan 1', null, 'K00001', 'CS0001', 'ket luan 1');

UPDATE HSBA
SET MABS

DELETE FROM HSBA;

select* from nhanvien;