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
    dbms_output.put_line(encrypted_dtb);
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
    dbms_output.put_line(decrypted_raw);
    decrypted_string := UTL_RAW.CAST_TO_NVARCHAR2(decrypted_raw);
    dbms_output.put_line(decrypted_string);
    
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
    
    IF (vaitro = N'Thanh tra') THEN
        EXECUTE IMMEDIATE 'GRANT ROLE_THANHTRA TO "' || MANV || '"';     
    END IF;
    
    IF (vaitro = N'Cơ sở y tế') THEN
        EXECUTE IMMEDIATE 'GRANT ROLE_CSYT TO "' || MANV || '"';
    END IF;
    
    IF (vaitro = N'Nghiên cứu') THEN
        EXECUTE IMMEDIATE 'GRANT ROLE_NGHIENCUU TO "' || MANV || '"';
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

