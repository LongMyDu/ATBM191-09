-- Test QLCSYTE_ADMIN.vw_hsba_dv_qlcsyt
--Update
UPDATE QLCSYTE_ADMIN.vw_hsba_qlcsyt
SET ketluan = N'Covid 19'
WHERE mahsba = 'HSBA0002';

--Delete
DELETE FROM QLCSYTE_ADMIN.vw_hsba_qlcsyt WHERE mahsba = 'HSBA0002';

--Insert
INSERT INTO  QLCSYTE_ADMIN.vw_hsba_qlcsyt
VALUES ('HSBA0011', 'BN000010', TO_DATE('2020-05-23', 'yyyy-mm-dd'), 'Viêm xoang', 'NV0030', 'K00001', 'CS0002', 'Viêm xoang');

------------------------------------------------------
-- Test QLCSYTE_ADMIN.vw_hsba_dv_qlcsyt
SELECT * FROM QLCSYTE_ADMIN.vw_hsba_dv_qlcsyt;

--Update
UPDATE QLCSYTE_ADMIN.vw_hsba_dv_qlcsyt
SET ketqua = N''
WHERE mahsba = 'HSBA0002' AND madv ='DV0001' AND TO_CHAR(ngay, 'YYYY-MM-DD') = '2018-02-05';

--Delete
DELETE FROM QLCSYTE_ADMIN.vw_hsba_dv_qlcsyt
WHERE mahsba = 'HSBA0002' AND madv ='DV0001' AND TO_CHAR(ngay, 'YYYY-MM-DD') = '2018-02-05';

--Insert
INSERT INTO QLCSYTE_ADMIN.vw_hsba_dv_qlcsyt
VALUES ('HSBA0002', 'DV0002',TO_DATE('2018-02-05', 'yyyy-mm-dd'), 'NV0027', 'ket qua dich vu 3_2');

COMMIT;
ROLLBACK;