# ATBM191-09

Thứ tự chạy file SQL:
Connect bằng account sys, chạy file CREATE-ADMIN-USER.sql

Connect bằng account QLCSYTE_ADMIN, chạy các file theo thứ tự:
CREATE-TABLE.sql
CREATE-APPLICATION-CONTEXT.sql
CREATE-PROCEDURE.sql
INSERT_DATA.sql
TC2 --> TC8

Để xóa tất cả mọi thứ đã tạo, chạy file:
DELETE-DB.sql