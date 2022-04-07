/*
ĐỒ ÁN MÔN HỌC AN TOÀN BẢO MẬT DỮ LIỆU TRONG HỆ THỐNG THÔNG TIN
FILE TẠO DATABASE 
NHÓM 9

MSSV        HỌ TÊN          
19127366    Long Mỹ Du
19127377    Nguyễn Huỳnh Khánh Duy
19127476    Trần Thị Huế Minh
*/

-- Xóa tất cả bảng
--DROP TABLE HSBA CASCADE CONSTRAINTS;
--DROP TABLE HSBA_DV CASCADE CONSTRAINTS;
--DROP TABLE BENHNHAN CASCADE CONSTRAINTS;
--DROP TABLE CSYT CASCADE CONSTRAINTS;
--DROP TABLE NHANVIEN CASCADE CONSTRAINTS;

/
-- Tạo bảng
CREATE TABLE HSBA (
    MAHSBA CHAR(8),
    MABN CHAR(8),
    NGAY DATE,
    CHANDOAN NVARCHAR2(100),
    MABS CHAR(6),
    MAKHOA CHAR(6),
    MACSYT CHAR(6),
    KETLUAN NVARCHAR2(200),
	CONSTRAINT HSBA_PK PRIMARY KEY ( MAHSBA )
);

CREATE TABLE HSBA_DV (
    MAHSBA CHAR(8),
    MADV CHAR(6),
    NGAY DATE,
    MAKTV CHAR(6),
    KETQUA NVARCHAR2(200),
	CONSTRAINT HSBA_DV_PK PRIMARY KEY ( MAHSBA, MADV, NGAY )
);


CREATE TABLE BENHNHAN (
	MABN CHAR(8),
	MACSYT CHAR(6),
	TENBN NVARCHAR2(50),
	CMND CHAR(12),
	NGAYSINH DATE,
	SONHA VARCHAR2(20),
	TENDUONG NVARCHAR2(100),
	QUANHUYEN NVARCHAR2(50),
	TINHTP NVARCHAR2(50),
	TIENSUBENH NVARCHAR2(200),
	TIENSUBENHGD NVARCHAR2(200),
	DIUNGTHUOC NVARCHAR2(200),
	CONSTRAINT BENHNHAN_PK PRIMARY KEY ( MABN )

);

CREATE TABLE CSYT(
	MACSYT CHAR(6),
	TENCSYT NVARCHAR2(200),
	DCCSYT NVARCHAR2(200),
	SDTCSYT CHAR(10),
	CONSTRAINT CSYT_PK PRIMARY KEY ( MACSYT )
);

CREATE TABLE NHANVIEN(
	MANV CHAR(6),
	HOTEN NVARCHAR2(50),
	PHAI NVARCHAR2(5),
	NGAYSINH DATE,
	CMND CHAR(12),
	QUEQUAN NVARCHAR2(50),
	SODT CHAR(10),
	CSYT CHAR(6),
	VAITRO NVARCHAR2(20),
	CHUYENKHOA CHAR(6),
	CONSTRAINT NHANVIEN_PK PRIMARY KEY ( MANV )
);
/

-- Tạo các Foreign key constraints và check constraints
ALTER TABLE HSBA
ADD CONSTRAINT HSBA_BENHNHAN_FK FOREIGN KEY ( MABN )
        REFERENCES BENHNHAN ( MABN );
ALTER TABLE HSBA
ADD CONSTRAINT HSBA_NHANVIEN_FK FOREIGN KEY ( MABS )
        REFERENCES NHANVIEN ( MANV );
ALTER TABLE HSBA
ADD CONSTRAINT HSBA_CSYT_FK FOREIGN KEY ( MACSYT )
        REFERENCES CSYT ( MACSYT);

ALTER TABLE HSBA_DV
ADD CONSTRAINT HSBA_DV_HSBA_FK FOREIGN KEY ( MAHSBA )
        REFERENCES HSBA ( MAHSBA );

ALTER TABLE BENHNHAN
ADD CONSTRAINT BENHNHAN_CSYT_FK FOREIGN KEY ( MACSYT )
        REFERENCES CSYT ( MACSYT);

ALTER TABLE NHANVIEN
ADD CONSTRAINT NHANVIEN_CSYT_FK FOREIGN KEY ( CSYT )
        REFERENCES CSYT ( MACSYT);
ALTER TABLE NHANVIEN
ADD CONSTRAINT NHANVIEN_VAITRO_FK 
	CHECK (VAITRO IN (N'Thanh tra', N'Cơ sở y tế', N'Y sĩ/bác sĩ', N'Nghiên cứu'));


create view vw_hsban as select * from hsban;
create view vw_hsban_dv as select * from hsban_dv;


create table nhanvien(manv number, hoten varchar2(50));

insert into nhanvien values (1, 'My Du');
insert into nhanvien values (2, 'Khanh Duy');
insert into nhanvien values (3, 'Minh');
insert into nhanvien values (4, 'Nhi');

select * from nhanvien;


SELECT
*
FROM
 NHANVIEN   ;
 
 commit;
 
 
 SELECT * FROM USER_VIEWS

select * from user_views;

select column_id, 
       owner as schema_name,
       table_name, 
       column_name, 
       data_type, 
       data_length, 
       data_precision, 
       data_scale, 
       nullable
from sys.all_tab_columns
where owner = (select user from dual)
order by table_name;

select decode( col.table_name
, lag(col.table_name, 1) over(order by col.table_name)
, null
, col.table_name ) view_name,
col.column_name, 
col.data_type, 
col.data_length, 
col.data_precision, 
col.data_scale, 
col.nullable
from sys.all_tab_columns col
inner join sys.all_views v on col.owner = (select user from dual)
and col.table_name = v.view_name
order by col.table_name;

select decode( col.table_name
, lag(col.table_name, 1) over(order by col.table_name)
, null
, col.table_name ) view_name,
col.column_name, 
col.data_type, 
col.data_length, 
col.data_precision, 
col.data_scale, 
col.nullable
from sys.all_tab_columns col
inner join sys.all_tables v on col.owner = (select user from dual)
and col.table_name = v.table_name
order by col.table_name;
select * from sys.all_tables sat where sat.owner = (select user from dual);

select decode(role, lag(role, 1) over(order by role), null, role) role, privilege, admin_option, common, inherited from role_sys_privs order by role;
select * from dba_roles;
grant create any table to role_giaovu;
 select *
from role_sys_privs rsp
join dba_roles  dr on rsp.role = dr.role
order by rsp.role;

select * from User_col_privs where grantee='AAAAAA';

select granted_role, 'YES' is_granted from dba_role_privs where grantee='GIAOVU1';
(select granted_role, 'YES' is_granted, admin_option from dba_role_privs where grantee='GIAOVU1') union (select role as granted_role, 'NO' is_granted, 'NO' admin_option from dba_roles where role not in (select granted_role from dba_role_privs where grantee='GIAOVU1'));


select ar.role, gr.admin_option, gr.grantee
from dba_roles ar LEFT JOIN dba_role_privs gr on (ar.role = gr.granted_role and gr.grantee='GIAOVU1')
order by ar.role;


select distinct table_name from user_tab_columns;

select GRANTEE AS "USER", TABLE_NAME, "PRIVILEGE", GRANTABLE, GRANTOR from dba_tab_privs where GRANTEE ='AAAAAA';
select GRANTEE AS "USER", TABLE_NAME, COLUMN_NAME, "PRIVILEGE", GRANTABLE, GRANTOR from User_col_privs where GRANTEE = 'AAAAAA';


grant select, insert, update, delete on benhnhan to AAAAAA;
revoke update on benhnhan from AAAAAA;

grant update(macsyt, tiensubenh, tiensubenhgd) on benhnhan to AAAAAA;


select GRANTEE AS \"USER\", TABLE_NAME, \"PRIVILEGE\", GRANTABLE, GRANTOR from dba_tab_privs where GRANTEE ='{userProperties.username}';

select COLUMN_NAME, "PRIVILEGE", GRANTABLE from User_col_privs 
where table_name = 'BENHNHAN' and grantee = 'AAAAAA' and PRIVILEGE='UPDATE';




