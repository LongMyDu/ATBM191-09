create table HSBAN (
    MAHSBAN NUMBER NOT NULL,
    MABN NUMBER NOT NULL,
    NGAY DATE,
    CHANDOAN NVARCHAR2(100),
    MABS NUMBER,
    MAKHOA NUMBER,
    MACSYT NUMBER,
    KETLUAN NVARCHAR2(200)
);

CREATE TABLE HSBAN_DV (
    MAHSBAN NUMBER NOT NULL,
    MADV NUMBER,
    NGAY DATE,
    MAKTV NUMBER,
    KETQUA NVARCHAR2(200)
);

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

select * from dba_role_privs;

select granted_role, 'YES' is_granted from dba_role_privs where grantee='GIAOVU1';
(select granted_role, 'YES' is_granted, admin_option from dba_role_privs where grantee='GIAOVU1') union (select role as granted_role, 'NO' is_granted, 'NO' admin_option from dba_roles where role not in (select granted_role from dba_role_privs where grantee='GIAOVU1'));


select ar.role, gr.admin_option, gr.grantee
from dba_roles ar LEFT JOIN dba_role_privs gr on (ar.role = gr.granted_role and gr.grantee='GIAOVU1')
order by ar.role;


PTBHUE