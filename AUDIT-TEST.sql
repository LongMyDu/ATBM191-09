-- Test CS .1
-- Thử xóa bệnh nhân BN000001
Exec QLCSYTE_ADMIN.XoaBenhNhan('BN000001');

-- Thử thêm bệnh nhân BN000001
EXEC QLCSYTE_ADMIN.THEMBENHNHAN('BN000001','CS0002', N'Trần Việt Đào Bình','916773394945', '1954-03-11', '148', N'3 tháng 2', N'Q.1', N'Cần Thơ', N'NULL', N'NULL', N'NULL','TyHFH6hOI2Hz97BX');

-- Test CS .2
-- Thử thêm 1 dòng vào HSBA
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0001', 'BN000001', TO_DATE('2001-01-01', 'yyyy-mm-dd'), 'chuan doan 1', null, 'K00001', 'CS0001', 'ket luan 1');

-- Test CS .3
DELETE FROM HSBA;

-- Test CS .4
--Connect bang BACSI (hoặc bất kỳ user nào được select benhnhan), nếu select fga_trail có lưu lại là đúng
select * from qlcsyte_admin.benhnhan;
