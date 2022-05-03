select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN;

--OK
update QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN
set tenbn = N'Long Mỹ Du';

-- Lỗi: Vì không được update mã
update QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN
set MaBN = 'BN000102';

commit;
rollback;
