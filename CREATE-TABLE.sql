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

SELECT TABLE_NAME FROM user_tables; 

SELECT to_char(DBMS_METADATA.get_ddl('TABLE', 'HSBAN', 'QLCSYTE_ADMIN')) FROM DUAL;

select decode( t.table_name
              , lag(t.table_name, 1) over(order by t.table_name)
              , null
             , t.table_name ) as table_name -- <- just to eliminate 
      , t.column_name                       -- repeated tab_name    
      , t.data_type
      , cc.constraint_name
      , uc.constraint_type
   from user_tab_columns t
        left join user_cons_columns cc
          on (cc.table_name = t.table_name and
              cc.column_name = t.column_name)
        left join user_constraints uc
          on (t.table_name = uc.table_name and
              uc.constraint_name = cc.constraint_name );
 where t.table_name in ('HSBAN');
 
select decode( t.table_name
                        , lag(t.table_name, 1) over(order by t.table_name)
                        , null
                        , t.table_name) as table_name
                        , t.column_name
                        , t.data_type
                        , cc.constraint_name
                        , uc.constraint_type
                        from user_tab_columns t
                            left join user_cons_columns cc
                                on(cc.table_name = t.table_name and
                                    cc.column_name = t.column_name)
                            left join user_constraints uc
                                on(t.table_name = uc.table_name and
                                    uc.constraint_name = cc.constraint_name)
                        where t.table_name in ('HSBAN'); 