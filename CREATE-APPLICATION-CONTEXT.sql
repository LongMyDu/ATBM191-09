CREATE OR REPLACE CONTEXT USER_ROLE_CONTEXT USING USER_PACKAGE;
/
CREATE OR REPLACE PACKAGE USER_PACKAGE
AS
PROCEDURE SET_ROLE;
PROCEDURE CLEAR_ROLE;
END;
/

CREATE OR REPLACE PACKAGE BODY USER_PACKAGE
AS
    PROCEDURE SET_ROLE
    AS
    l_role nvarchar2(20);
    is_nv number;
    is_bn number;
    BEGIN
        l_role := '';
        SELECT COUNT(*) INTO IS_NV FROM NHANVIEN WHERE MANV = SYS_CONTEXT ('userenv', 'session_user');
        SELECT COUNT(*) INTO IS_BN FROM BENHNHAN WHERE MABN = SYS_CONTEXT ('userenv', 'session_user');
        
        IF (SYS_CONTEXT ('userenv', 'session_user') = 'QLCSYTE_ADMIN') THEN
            l_role := 'DBA';
        ELSIF (is_nv > 0) THEN
            SELECT VAITRO INTO l_role FROM NHANVIEN
                WHERE MANV = SYS_CONTEXT ('userenv', 'session_user');
        ELSIF (IS_BN > 0) THEN
            l_role := N'Bệnh nhân';
        ELSE 
            l_role := '';
        END IF;
        
        DBMS_SESSION.set_context (namespace => 'USER_ROLE_CONTEXT', ATTRIBUTE => 'user_role', VALUE => l_role);
    END SET_ROLE;
    
    PROCEDURE CLEAR_ROLE
    AS
    BEGIN
        DBMS_SESSION.clear_context (namespace => 'USER_ROLE_CONTEXT', ATTRIBUTE =>'user_role');
    END CLEAR_ROLE;
END USER_PACKAGE;
/

CREATE OR REPLACE TRIGGER SET_USER_ROLE
AFTER LOGON ON DATABASE
BEGIN
    QLCSYTE_ADMIN.USER_PACKAGE.SET_ROLE;
    EXCEPTION
        WHEN NO_DATA_FOUND
        THEN
        -- If user is not in table,
        -- a no_data_found is raised
        -- If exception is not handled, then users not in table
        -- will be unable to log on
        NULL;

END;
/

