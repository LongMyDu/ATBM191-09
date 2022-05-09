-- Mở sqlplus, connect bằng sys cdb, chạy các câu lệnh sau
--alter system set AUDIT_TRAIL=db, extended scope=spfile;
--shutdown immediate;
--startup;
--NOAUDIT EXECUTE ON SYS.DBMS_UTILITY;


--Connect bằng user pdb. Khuyến cáo: thao tác này xóa hết tất cả những gì đã từng audit từ trước tới giờ!!!
delete from SYS.AUD$;
commit; 
--Từ khúc này có thể connect bằng QLCSYTE_ADMIN
--Xem thông tin đã được AUDIT:
select
   os_username,
   username,
   obj_name,owner,
   action_name,
   timestamp,
   returncode,
   sql_bind,
   sql_text
from
   dba_audit_trail
ORDER BY TIMESTAMP DESC;


-- Chính sách: Audit lại tất cả hành động exec các PROCEDURE sau dù thành công hay không: THEMBENHNHAN, XOABENHNHAN, THEMNHANVIEN, XOANHANVIEN
AUDIT EXECUTE ON QLCSYTE_ADMIN.THEMBENHNHAN BY ACCESS;
AUDIT EXECUTE ON QLCSYTE_ADMIN.XOABENHNHAN BY ACCESS;
AUDIT EXECUTE ON QLCSYTE_ADMIN.THEMNHANVIEN BY ACCESS;
AUDIT EXECUTE ON QLCSYTE_ADMIN.XOANHANVIEN BY ACCESS;

-- Chính sách: Audit lại tất cả hành động update, delete, insert trên bảng HSBA
AUDIT UPDATE, DELETE, INSERT ON QLCSYTE_ADMIN.HSBA BY ACCESS;

-- Chính sách: Audit lại tất cả hành động update, delete, insert trên bảng HSBA_DV
AUDIT UPDATE, DELETE, INSERT ON QLCSYTE_ADMIN.HSBA_DV BY ACCESS;
