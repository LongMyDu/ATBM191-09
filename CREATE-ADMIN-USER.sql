DROP USER QLCSYTE_ADMIN CASCADE;
DROP ROLE ROLE_BENHNHAN;
DROP ROLE ROLE_YBACSI;
DROP ROLE ROLE_NHANVIEN;
/
CREATE USER QLCSYTE_ADMIN IDENTIFIED BY QLCSYTE_ADMIN;
/
GRANT ALL PRIVILEGES TO QLCSYTE_ADMIN;
/
-- Lưu ý: Để có thể sử dụng hàm mã hóa: cần chạy câu lệnh:
Grant execute on SYS.DBMS_CRYPTO to QLCSYTE_ADMIN;
-- Lưu ý: Để có thể sử dụng add policy cho VPD: cần chạy câu lệnh:
grant execute on dbms_rls to QLCSYTE_ADMIN;
