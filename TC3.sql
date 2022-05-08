CREATE OR REPLACE VIEW VW_HSBA_QLCSYT
AS SELECT MAHSBA,MABN, NGAY, CHANDOAN, MABS, MAKHOA, MACSYT, KETLUAN
    FROM HSBA 
    WHERE ((SELECT EXTRACT(DAY FROM sysdate) FROM dual) BETWEEN 5 AND 27) 
            AND (MACSYT IN (SELECT CSYT FROM NHANVIEN WHERE MANV = SYS_CONTEXT('userenv', 'session_user')))
    WITH CHECK OPTION;

/
CREATE OR REPLACE VIEW VW_HSBA_DV_QLCSYT
AS SELECT MAHSBA, MADV, NGAY, MAKTV, KETQUA
    FROM HSBA_DV
    WHERE  ((SELECT EXTRACT(DAY FROM sysdate) FROM dual) BETWEEN 5 AND 27) 
            AND (MAHSBA IN (SELECT MAHSBA FROM HSBA WHERE MACSYT IN (SELECT CSYT FROM NHANVIEN WHERE MANV = SYS_CONTEXT('userenv', 'session_user'))))
    WITH CHECK OPTION;
/

GRANT INSERT ON VW_HSBA_QLCSYT TO ROLE_CSYT;
GRANT DELETE ON VW_HSBA_QLCSYT TO ROLE_CSYT;
GRANT UPDATE ON VW_HSBA_QLCSYT TO ROLE_CSYT;

GRANT INSERT ON VW_HSBA_DV_QLCSYT TO ROLE_CSYT;
GRANT DELETE ON VW_HSBA_DV_QLCSYT TO ROLE_CSYT;
GRANT UPDATE ON VW_HSBA_DV_QLCSYT TO ROLE_CSYT;

