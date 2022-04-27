select 'Drop user "'||CMND||'" cascade;' from NHANVIEN;

Drop user "916773394945" cascade;
Drop user "477197069125" cascade;
Drop user "644198063807" cascade;
Drop user "307780507980" cascade;
Drop user "480148058972" cascade;
Drop user "625421696262" cascade;
Drop user "093142227246" cascade;
Drop user "908519739639" cascade;
Drop user "611825513067" cascade;
Drop user "828559055899" cascade;


Drop user "410963698240" cascade;
Drop user "917138329545" cascade;
Drop user "829252737656" cascade;
Drop user "758234874761" cascade;
Drop user "084456993664" cascade;
Drop user "675756075261" cascade;
Drop user "859242462428" cascade;
Drop user "486589763960" cascade;
Drop user "503192156214" cascade;
Drop user "770179263005" cascade;
Drop user "626511554232" cascade;
Drop user "088272820825" cascade;
Drop user "651823963095" cascade;
Drop user "705720922190" cascade;
Drop user "287673062535" cascade;
Drop user "313847922476" cascade;
Drop user "196893690493" cascade;
Drop user "324913323649" cascade;
Drop user "792452447502" cascade;
Drop user "803019783337" cascade;
Drop user "031900361300" cascade;
Drop user "648537445435" cascade;
Drop user "997835560317" cascade;
Drop user "931361921026" cascade;
Drop user "580295250641" cascade;
Drop user "865766193037" cascade;
Drop user "478136075046" cascade;
Drop user "799272390265" cascade;
Drop user "740214271755" cascade;
Drop user "557610679443" cascade;
Drop user "814924308375" cascade;
Drop user "734664302041" cascade;
Drop user "427628358443" cascade;
Drop user "459171471634" cascade;
Drop user "453679954272" cascade;
Drop user "399981059659" cascade;
Drop user "108914194564" cascade;
Drop user "435425344998" cascade;
Drop user "203322515882" cascade;
Drop user "747376189404" cascade;
Drop user "041006808743" cascade;
Drop user "529609359645" cascade;
Drop user "076110272515" cascade;
Drop user "465442648845" cascade;
Drop user "341370236279" cascade;
Drop user "491646195877" cascade;
Drop user "831053317484" cascade;
Drop user "669560958954" cascade;
Drop user "192131394187" cascade;
Drop user "081066600741" cascade;
Drop user "149142094761" cascade;
Drop user "246664081455" cascade;
Drop user "486029082553" cascade;
Drop user "434137157331" cascade;
Drop user "139101531202" cascade;


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