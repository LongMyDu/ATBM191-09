-- Mở sqlplus, connect bằng sys cdb, chạy các câu lệnh sau
--alter system set AUDIT_TRAIL=db, extended scope=spfile;
--shutdown immediate;
--startup;
--NOAUDIT EXECUTE ON SYS.DBMS_UTILITY;


--Connect bằng user pdb. Khuyến cáo: thao tác này xóa hết tất cả những gì đã từng audit từ trước tới giờ!!!
delete from SYS.AUD$;
commit; 
GRANT EXECUTE ON DBMS_FGA TO QLCSYTE_ADMIN;

--Từ khúc này có thể connect bằng QLCSYTE_ADMIN
--Xem thông tin đã được standart AUDIT :
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
   DBA_AUDIT_TRAIL
ORDER BY TIMESTAMP DESC;

-- Xem thông tin đã được Fine grain audit
select * from dba_fga_audit_trail;

-- (SA)Chính sách .1: Audit lại tất cả hành động exec các PROCEDURE sau: THEMBENHNHAN, XOABENHNHAN, THEMNHANVIEN, XOANHANVIEN
AUDIT EXECUTE ON QLCSYTE_ADMIN.THEMBENHNHAN BY ACCESS;
AUDIT EXECUTE ON QLCSYTE_ADMIN.XOABENHNHAN BY ACCESS;
AUDIT EXECUTE ON QLCSYTE_ADMIN.THEMNHANVIEN BY ACCESS;
AUDIT EXECUTE ON QLCSYTE_ADMIN.XOANHANVIEN BY ACCESS;

-- (SA)Chính sách .2: Audit lại tất cả hành động update, delete, insert trên bảng HSBA
AUDIT UPDATE, DELETE, INSERT ON QLCSYTE_ADMIN.HSBA BY ACCESS;

-- (SA)Chính sách .3: Audit lại tất cả hành động update, delete, insert trên bảng HSBA_DV
AUDIT UPDATE, DELETE, INSERT ON QLCSYTE_ADMIN.HSBA_DV BY ACCESS;

-- Để FGA, cần chỉnh lại cái này, audit trên bảng nào thì chỉnh lại trên bảng đó
ANALYZE TABLE BENHNHAN COMPUTE STATISTICS;

-- (FGA)Chính sách .4: Audit lại tất cả hành động select CMND trên bảng BENHNHAN của tất cả user mà không phải bệnh nhân đó
EXEC DBMS_FGA.ADD_POLICY (object_schema => 'QLCSYTE_ADMIN', object_name => 'BENHNHAN', policy_name =>  'Select_CMND_BENHNHAN', audit_condition => 'MABN != USER', audit_column => 'CMND', statement_types => 'SELECT'); 

