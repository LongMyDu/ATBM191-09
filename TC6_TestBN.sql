select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN;

--OK
update QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN
set tenbn = N'Long Mỹ Du',
    ngaysinh = TO_DATE('2001-09-15','yyyy-mm-dd'),
    tinhtp = N'TP. Hồ Chí Minh',
    tenduong = N'Nguyễn Huệ',
    CMND = '507780507980';

-- Lỗi: Vì không được update mã
update QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN
set MaBN = 'BN000102';

commit;
rollback;
