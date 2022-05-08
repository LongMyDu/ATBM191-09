select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN;

--OK
update QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN
set ngaysinh = TO_DATE('1999-09-15','yyyy-mm-dd'),
    CMND = '356938429384',
    CSYT = 'CS0001',
    QueQuan = N'Cần Thơ';

commit;

--Lỗi vì k được update manv
update QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN
set manv = 'NV0102';

commit;

