select 'Exec XoaBenhNhan('''|| MABN ||''');' from BENHNHAN
union
select 'Exec XoaNhanVien('''|| MANV ||''');' from NHANVIEN;

Drop user "BN000001" cascade;
Drop user "BN000002" cascade;
Drop user "BN000003" cascade;
Drop user "BN000004" cascade;
Drop user "BN000005" cascade;
Drop user "BN000006" cascade;
Drop user "BN000007" cascade;
Drop user "BN000008" cascade;
Drop user "BN000009" cascade;
Drop user "BN000010" cascade;


Drop user "NV0001" cascade;
Drop user "NV0002" cascade;
Drop user "NV0003" cascade;
Drop user "NV0004" cascade;
Drop user "NV0005" cascade;
Drop user "NV0006" cascade;
Drop user "NV0007" cascade;
Drop user "NV0008" cascade;
Drop user "NV0009" cascade;
Drop user "NV0010" cascade;
Drop user "NV0011" cascade;
Drop user "NV0012" cascade;
Drop user "NV0013" cascade;
Drop user "NV0014" cascade;
Drop user "NV0015" cascade;
Drop user "NV0016" cascade;
Drop user "NV0017" cascade;
Drop user "NV0018" cascade;
Drop user "NV0019" cascade;
Drop user "NV0020" cascade;
Drop user "NV0021" cascade;
Drop user "NV0022" cascade;
Drop user "NV0023" cascade;
Drop user "NV0024" cascade;
Drop user "NV0025" cascade;
Drop user "NV0026" cascade;
Drop user "NV0027" cascade;
Drop user "NV0028" cascade;
Drop user "NV0029" cascade;
Drop user "NV0030" cascade;
Drop user "NV0031" cascade;
Drop user "NV0032" cascade;
Drop user "NV0033" cascade;
Drop user "NV0034" cascade;
Drop user "NV0035" cascade;
Drop user "NV0036" cascade;
Drop user "NV0037" cascade;
Drop user "NV0038" cascade;
Drop user "NV0039" cascade;
Drop user "NV0040" cascade;
Drop user "NV0041" cascade;
Drop user "NV0042" cascade;
Drop user "NV0043" cascade;
Drop user "NV0044" cascade;
Drop user "NV0045" cascade;
Drop user "NV0046" cascade;
Drop user "NV0047" cascade;
Drop user "NV0048" cascade;
Drop user "NV0049" cascade;
Drop user "NV0050" cascade;
Drop user "NV0051" cascade;
Drop user "NV0052" cascade;
Drop user "NV0053" cascade;
Drop user "NV0054" cascade;
Drop user "NV0055" cascade;


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

grant select on VW_HSBAN to ROLE_GIAOVIEN with grant option;

select sys_context('userenv', 'SESSION_USER') from dual;