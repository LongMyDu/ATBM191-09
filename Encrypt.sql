-- 1. CÀI ĐẶT HÀM MÃ HÓA VÀ GIẢI MÃ. 
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
-- 1. CÀI ĐẶT HÀM GIẢI MÃ. 
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


Select ENCRYPT_STRING('Mạc Đĩnh Chi', 'BN0000011954-03-11') from dual;

Select DECRYPT_STRING('7C5047491E6DD588E8B528AA99DEEBCC2E99C9258EF37835547B21F3487E2E12', 'BN0000011954-03-11') from dual;