select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN;

update QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN
set tenbn = N'Long Mỹ Du';

update QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN
set MaBN = 'BN000102';

commit;
rollback;

select user from dual;