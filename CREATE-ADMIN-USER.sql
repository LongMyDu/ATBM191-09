--Connect bằng tài khoản SYS và chạy các câu lệnh sau
CREATE USER QLCSYTE_ADMIN IDENTIFIED BY QLCSYTE_ADMIN;
/
GRANT ALL PRIVILEGES TO QLCSYTE_ADMIN;
/
-- Quyền để cài đặt mã hóa:
Grant execute on SYS.DBMS_CRYPTO to QLCSYTE_ADMIN;
-- Quyền để cài đặt VPD:
Grant execute on dbms_rls to QLCSYTE_ADMIN;
-- Quyền để cài đặt FGA:
Grant execute on DBMS_FGA TO QLCSYTE_ADMIN;
