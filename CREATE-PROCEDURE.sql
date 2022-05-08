-- 1. CÀI ĐẶT HÀM MÃ HÓA
CREATE OR REPLACE FUNCTION ENCRYPT_STRING(input_string NVARCHAR2, key_string VARCHAR2)
RETURN RAW
AS  
    raw_input RAW(1000);
    encrypted_dtb RAW(2048);
    raw_key RAW(128) := UTL_RAW.CAST_TO_RAW (CONVERT (key_string, 'AL32UTF8', 'US7ASCII'));
BEGIN   
    raw_input := UTL_RAW.CAST_TO_RAW (input_string);

    encrypted_dtb := DBMS_CRYPTO.Encrypt(src=> raw_input,
                                        typ => DBMS_CRYPTO.DES_CBC_PKCS5, 
                                        key => raw_key);
    --dbms_output.put_line(encrypted_dtb);
    RETURN(encrypted_dtb);
END;
/
-- 2. CÀI ĐẶT HÀM GIẢI MÃ. 
CREATE OR REPLACE FUNCTION DECRYPT_STRING (encrypted_dtb RAW, key_string VARCHAR2)
RETURN NVARCHAR2
AS
    raw_key RAW(128) := UTL_RAW.CAST_TO_RAW (CONVERT (key_string, 'AL32UTF8', 'US7ASCII'));
    decrypted_raw RAW(2048);
    decrypted_string VARCHAR2(30);
BEGIN
    decrypted_raw := dbms_crypto.Decrypt(src => encrypted_dtb, 
                                        typ => DBMS_CRYPTO.DES_CBC_PKCS5,
                                        key => raw_key);
    --dbms_output.put_line(decrypted_raw);
    decrypted_string := UTL_RAW.CAST_TO_NVARCHAR2(decrypted_raw);
    --dbms_output.put_line(decrypted_string);
    
    RETURN(decrypted_string);
END;
/


-- Procedure thêm nhân viên
CREATE OR REPLACE PROCEDURE  ThemNhanVien(
    manv IN NHANVIEN.MANV%TYPE,
    hoten  IN NHANVIEN.HOTEN%TYPE,
    phai  IN NHANVIEN.PHAI%TYPE,
    ngaysinh  IN VARCHAR2,
    cmnd  IN NHANVIEN.CMND%TYPE,
    quequan  IN NHANVIEN.QUEQUAN%TYPE,
    sodt  IN NHANVIEN.SODT%TYPE,
    csyt  IN NHANVIEN.CSYT%TYPE,
    vaitro  IN NHANVIEN.VAITRO%TYPE,
    chuyenkhoa  IN NHANVIEN.CHUYENKHOA%TYPE,
    pwd VARCHAR2)
AS
    key_string varchar2(30);
BEGIN
    key_string := manv || ngaysinh;
    INSERT INTO NHANVIEN ("MANV", "HOTEN", "PHAI", "SODT", "NGAYSINH", "QUEQUAN", "CMND", "CSYT", "VAITRO", "CHUYENKHOA") VALUES 
    (manv, hoten, phai, sodt, TO_DATE(ngaysinh,'yyyy-mm-dd'), quequan, ENCRYPT_STRING(cmnd, key_string), csyt, vaitro, chuyenkhoa);
    EXECUTE IMMEDIATE 'CREATE USER "' || MANV || '" IDENTIFIED BY "' || pwd || '"';
    EXECUTE IMMEDIATE 'GRANT ROLE_NHANVIEN TO "' || MANV || '"';
    
    IF (vaitro = N'Y sĩ/ bác sĩ') THEN
        EXECUTE IMMEDIATE 'GRANT ROLE_YBACSI TO "' || MANV || '"';
    END IF;
END;
/

-- Procedure thêm bệnh nhân
CREATE OR REPLACE PROCEDURE ThemBenhNhan(
    mabn IN BENHNHAN.MABN%TYPE,
    macsyt IN BENHNHAN.MACSYT%TYPE,
    tenbn IN BENHNHAN.TENBN%TYPE,
    cmnd IN BENHNHAN.CMND%TYPE,
    ngaysinh  IN VARCHAR2,
    sonha IN BENHNHAN.SONHA%TYPE,
    tenduong IN BENHNHAN.TENDUONG%TYPE,
    quanhuyen IN BENHNHAN.QUANHUYEN%TYPE,
    tinhtp IN BENHNHAN.TINHTP%TYPE,
    tiensubenh IN BENHNHAN.TIENSUBENH%TYPE,
    tiensubenhgd IN BENHNHAN.TIENSUBENHGD%TYPE,
    diungthuoc IN BENHNHAN.DIUNGTHUOC%TYPE,
    pwd VARCHAR2)
AS
    key_string varchar2(30);
BEGIN
    key_string := mabn || ngaysinh;
    INSERT INTO BENHNHAN VALUES 
    (mabn,macsyt,tenbn,ENCRYPT_STRING(cmnd, key_string),TO_DATE(ngaysinh,'yyyy-mm-dd'),sonha,ENCRYPT_STRING(tenduong, key_string),quanhuyen,tinhtp,tiensubenh,tiensubenhgd,diungthuoc);
    EXECUTE IMMEDIATE 'CREATE USER "' || mabn || '" IDENTIFIED BY "' || pwd || '"';
    EXECUTE IMMEDIATE 'GRANT ROLE_BENHNHAN TO "' || mabn || '"';
END;
/

CREATE OR REPLACE PROCEDURE XoaBenhNhan(mabn IN BENHNHAN.MABN%TYPE)
AS
BEGIN
    EXECUTE IMMEDIATE 'DROP USER "' || mabn || '" CASCADE';
    DELETE FROM BENHNHAN WHERE MABN = mabn;
END;
/

CREATE OR REPLACE PROCEDURE XoaNhanVien(manv IN NHANVIEN.MANV%TYPE)
AS
BEGIN
    EXECUTE IMMEDIATE 'DROP USER "' || manv || '" CASCADE';
    DELETE FROM NHANVIEN WHERE MANV = manv;
END;
/

CREATE OR REPLACE TRIGGER BN_UPDATE
BEFORE UPDATE ON BENHNHAN
FOR EACH ROW
DECLARE
   v_cmnd CHAR(12);
   v_tenDuong NVARCHAR2(100);
   key_string VARCHAR(30);

BEGIN
    -- Nếu là update NGAYSINH
    IF (:old.NGAYSINH != :new.NGAYSINH) THEN             
        key_string := :old.mabn || TO_CHAR(:old.NGAYSINH, 'yyyy-mm-dd');        
        -- Nếu không update cmnd --> giải mã để lấy cmnd cũ
        IF (:old.CMND = :new.CMND) THEN            
            v_cmnd := DECRYPT_STRING(:old.CMND, key_string);
        -- Ngược lại: có update cmnd --> chỉ cần lấy cmnd mới đi mã hóa
        ELSE
            v_cmnd := TRIM(:new.CMND);
        END IF;
        
         -- Nếu không update tenduong --> giải mã để lấy tenduong cũ
        IF (:old.TENDUONG = :new.TENDUONG) THEN            
            v_tenduong := DECRYPT_STRING(:old.TENDUONG, key_string);
        -- Ngược lại: có update tenduong --> chỉ cần lấy tenduong mới đi mã hóa
        ELSE
            v_tenduong := TRIM(:new.TENDUONG);
        END IF;
        
        -- Mã hóa lại 
        key_string := :old.mabn || TO_CHAR(:new.NGAYSINH, 'yyyy-mm-dd');
        :new.CMND := ENCRYPT_STRING(v_cmnd, key_string);
        :new.TENDUONG := ENCRYPT_STRING(v_tenduong, key_string);
    --Không update ngày sinh
    ELSE
        key_string := :old.mabn || TO_CHAR(:new.NGAYSINH, 'yyyy-mm-dd');
        -- Nếu update cmnd --> Chỉ cần mã hóa lại cmnd mới
        IF (:old.CMND != :new.CMND) THEN
            dbms_output.put_line('No ngasinh, only cmnd');
            :new.CMND := ENCRYPT_STRING(TRIM(:new.CMND), key_string);        
        END IF;
        -- Update tenduong --> Chỉ cần mã hóa lại tenduong mới
        IF (:old.TENDUONG != :new.TENDUONG) THEN
            dbms_output.put_line('No ngasinh, only cmnd');
            :new.TENDUONG := ENCRYPT_STRING(TRIM(:new.TENDUONG), key_string);        
        END IF;

    END IF;
END BN_UPDATE;
/

CREATE OR REPLACE TRIGGER NV_UPDATE
BEFORE UPDATE ON NHANVIEN
FOR EACH ROW
DECLARE
   v_cmnd CHAR(12);   
   key_string VARCHAR(30);

BEGIN
    -- Nếu là update NGAYSINH
    IF (:old.NGAYSINH != :new.NGAYSINH) THEN             
        key_string := :old.MANV || TO_CHAR(:old.NGAYSINH, 'yyyy-mm-dd');        
        -- Nếu không update cmnd --> giải mã để lấy cmnd cũ
        IF (:old.CMND = :new.CMND) THEN            
            v_cmnd := DECRYPT_STRING(:old.CMND, key_string);
        -- Ngược lại: có update cmnd --> chỉ cần lấy cmnd mới đi mã hóa
        ELSE
            v_cmnd := TRIM(:new.CMND);
        END IF;
        
        -- Mã hóa lại 
        key_string := :old.MANV || TO_CHAR(:new.NGAYSINH, 'yyyy-mm-dd');
        :new.CMND := ENCRYPT_STRING(v_cmnd, key_string);
    --Không update ngày sinh
    ELSE
        key_string := :old.MANV || TO_CHAR(:new.NGAYSINH, 'yyyy-mm-dd');
        -- Nếu update cmnd --> Chỉ cần mã hóa lại cmnd mới
        IF (:old.CMND != :new.CMND) THEN
            dbms_output.put_line('No ngasinh, only cmnd');
            :new.CMND := ENCRYPT_STRING(TRIM(:new.CMND), key_string);        
        END IF;
      
    END IF;
END NV_UPDATE;
/
