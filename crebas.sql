/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     5/27/2022 4:15:13 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADD_UPDATE') and o.name = 'FK_ADD_UPDA_RELATIONS_ADMIN')
alter table ADD_UPDATE
   drop constraint FK_ADD_UPDA_RELATIONS_ADMIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN_PHONE') and o.name = 'FK_ADMIN_PH_HAS_A_ADMIN')
alter table ADMIN_PHONE
   drop constraint FK_ADMIN_PH_HAS_A_ADMIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLIENT_PHONE') and o.name = 'FK_CLIENT_P_HAS_CLIENT')
alter table CLIENT_PHONE
   drop constraint FK_CLIENT_P_HAS_CLIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GAME') and o.name = 'FK_GAME_DEVELOP_VENDOR')
alter table GAME
   drop constraint FK_GAME_DEVELOP_VENDOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GAME') and o.name = 'FK_GAME_RELATIONS_ADD_UPDA')
alter table GAME
   drop constraint FK_GAME_RELATIONS_ADD_UPDA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RENTAL') and o.name = 'FK_RENTAL_CONTAINS_WAREHOUS')
alter table RENTAL
   drop constraint FK_RENTAL_CONTAINS_WAREHOUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RENT_TO___RETURN') and o.name = 'FK_RENT_TO__RELATIONS_GAME')
alter table RENT_TO___RETURN
   drop constraint FK_RENT_TO__RELATIONS_GAME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RENT_TO___RETURN') and o.name = 'FK_RENT_TO__RELATIONS_CLIENT')
alter table RENT_TO___RETURN
   drop constraint FK_RENT_TO__RELATIONS_CLIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STOREDIN') and o.name = 'FK_STOREDIN_RELATIONS_GAME')
alter table STOREDIN
   drop constraint FK_STOREDIN_RELATIONS_GAME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STOREDIN') and o.name = 'FK_STOREDIN_RELATIONS_WAREHOUS')
alter table STOREDIN
   drop constraint FK_STOREDIN_RELATIONS_WAREHOUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENDOR_PHONE') and o.name = 'FK_VENDOR_P_H_VENDOR')
alter table VENDOR_PHONE
   drop constraint FK_VENDOR_P_H_VENDOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADD_UPDATE')
            and   name  = 'RELATIONSHIP_11_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADD_UPDATE.RELATIONSHIP_11_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADD_UPDATE')
            and   type = 'U')
   drop table ADD_UPDATE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMIN')
            and   type = 'U')
   drop table ADMIN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADMIN_PHONE')
            and   name  = 'HAS_A_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADMIN_PHONE.HAS_A_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMIN_PHONE')
            and   type = 'U')
   drop table ADMIN_PHONE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENT')
            and   type = 'U')
   drop table CLIENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLIENT_PHONE')
            and   name  = 'HAS_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLIENT_PHONE.HAS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENT_PHONE')
            and   type = 'U')
   drop table CLIENT_PHONE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GAME')
            and   name  = 'RELATIONSHIP_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index GAME.RELATIONSHIP_12_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GAME')
            and   name  = 'DEVELOP_FK'
            and   indid > 0
            and   indid < 255)
   drop index GAME.DEVELOP_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GAME')
            and   type = 'U')
   drop table GAME
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RENTAL')
            and   name  = 'CONTAINS_FK'
            and   indid > 0
            and   indid < 255)
   drop index RENTAL.CONTAINS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RENTAL')
            and   type = 'U')
   drop table RENTAL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RENT_TO___RETURN')
            and   name  = 'RELATIONSHIP_8_FK'
            and   indid > 0
            and   indid < 255)
   drop index RENT_TO___RETURN.RELATIONSHIP_8_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RENT_TO___RETURN')
            and   name  = 'RELATIONSHIP_9_FK'
            and   indid > 0
            and   indid < 255)
   drop index RENT_TO___RETURN.RELATIONSHIP_9_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RENT_TO___RETURN')
            and   type = 'U')
   drop table RENT_TO___RETURN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STOREDIN')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index STOREDIN.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STOREDIN')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index STOREDIN.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('STOREDIN')
            and   type = 'U')
   drop table STOREDIN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VENDOR')
            and   type = 'U')
   drop table VENDOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VENDOR_PHONE')
            and   name  = 'H_FK'
            and   indid > 0
            and   indid < 255)
   drop index VENDOR_PHONE.H_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VENDOR_PHONE')
            and   type = 'U')
   drop table VENDOR_PHONE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('WAREHOUSE')
            and   type = 'U')
   drop table WAREHOUSE
go

/*==============================================================*/
/* Table: ADD_UPDATE                                            */
/*==============================================================*/
create table ADD_UPDATE (
   ADMINID              int                  not null,
   NO                   numeric              null
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_11_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_11_FK on ADD_UPDATE (
ADMINID ASC
)
go

/*==============================================================*/
/* Table: ADMIN                                                 */
/*==============================================================*/
create table ADMIN (
   ADMINID              int                  not null,
   FIRST_NAME           varchar(25)          not null,
   LAST_NAME            varchar(25)          not null,
   EMAIL                text                 not null,
   PASSWORD             varchar(10)          not null,
   constraint PK_ADMIN primary key nonclustered (ADMINID)
)
go

/*==============================================================*/
/* Table: ADMIN_PHONE                                           */
/*==============================================================*/
create table ADMIN_PHONE (
   PADMINID             int                  not null,
   APHONE               varchar(12)          not null,
   ADMINID              int                  not null,
   constraint PK_ADMIN_PHONE primary key nonclustered (PADMINID, APHONE)
)
go

/*==============================================================*/
/* Index: HAS_A_FK                                              */
/*==============================================================*/
create index HAS_A_FK on ADMIN_PHONE (
ADMINID ASC
)
go

/*==============================================================*/
/* Table: CLIENT                                                */
/*==============================================================*/
create table CLIENT (
   CLIENTID             int                  not null,
   FIRST_NAME           varchar(25)          not null,
   LAST_NAME            varchar(25)          not null,
   ADDRESS              varchar(30)          not null,
   EMAIL                text                 null,
   BIRTHDATE            datetime             not null,
   SEX                  varchar(10)          null,
   STARTDATE            datetime             not null,
   ACTIVESUBSCRIPTION   varchar(20)          not null,
   constraint PK_CLIENT primary key nonclustered (CLIENTID)
)
go

/*==============================================================*/
/* Table: CLIENT_PHONE                                          */
/*==============================================================*/
create table CLIENT_PHONE (
   PHONE                varchar(12)          not null,
   PCLIENTID            int                  not null,
   CLIENTID             int                  not null,
   constraint PK_CLIENT_PHONE primary key nonclustered (PHONE, PCLIENTID)
)
go

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/
create index HAS_FK on CLIENT_PHONE (
CLIENTID ASC
)
go

/*==============================================================*/
/* Table: GAME                                                  */
/*==============================================================*/
create table GAME (
   GAMEID               int                  not null,
   VENDORID             int                  not null,
   TITLE                varchar(25)          not null,
   CATEGORY             varchar(20)          not null,
   RATING               decimal              null,
   PRICE                decimal              not null,
   DESCRIPTION          varchar(25)          null,
   PLAYERS              int                  not null,
   PLATFORM             varchar(20)          null,
   DATEOFPUBLICATION    datetime             null,
   PUBLISHER            varchar(20)          null,
   constraint PK_GAME primary key nonclustered (GAMEID)
)
go

/*==============================================================*/
/* Index: DEVELOP_FK                                            */
/*==============================================================*/
create index DEVELOP_FK on GAME (
VENDORID ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_12_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_12_FK on GAME (

)
go

/*==============================================================*/
/* Table: RENTAL                                                */
/*==============================================================*/
create table RENTAL (
   RENTALID             int                  not null,
   HOUSEID              int                  not null,
   RENTAL_DATE          datetime             null,
   CLIENT               int                  null,
   HOUSE                int                  null,
   constraint PK_RENTAL primary key nonclustered (RENTALID)
)
go

/*==============================================================*/
/* Index: CONTAINS_FK                                           */
/*==============================================================*/
create index CONTAINS_FK on RENTAL (
HOUSEID ASC
)
go

/*==============================================================*/
/* Table: RENT_TO___RETURN                                      */
/*==============================================================*/
create table RENT_TO___RETURN (
   CLIENTID             int                  not null,
   GAMEID               int                  not null,
   CLIENT               int                  null,
   GAME                 int                  null,
   NO_OF_GAMES          numeric              null,
   constraint PK_RENT_TO___RETURN primary key (CLIENTID, GAMEID)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_9_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_9_FK on RENT_TO___RETURN (
CLIENTID ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_8_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_8_FK on RENT_TO___RETURN (
GAMEID ASC
)
go

/*==============================================================*/
/* Table: STOREDIN                                              */
/*==============================================================*/
create table STOREDIN (
   GAMEID               int                  not null,
   HOUSEID              int                  not null,
   GID                  int                  null,
   HID                  int                  null,
   constraint PK_STOREDIN primary key (GAMEID, HOUSEID)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on STOREDIN (
GAMEID ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on STOREDIN (
HOUSEID ASC
)
go

/*==============================================================*/
/* Table: VENDOR                                                */
/*==============================================================*/
create table VENDOR (
   VENDORID             int                  not null,
   GAMENAME             varchar(15)          not null,
   FIRST_NAME           varchar(25)          not null,
   LAST_NAME            varchar(25)          not null,
   EMAIL                text                 not null,
   constraint PK_VENDOR primary key nonclustered (VENDORID)
)
go

/*==============================================================*/
/* Table: VENDOR_PHONE                                          */
/*==============================================================*/
create table VENDOR_PHONE (
   VID                  int                  not null,
   VPHONE               varchar(12)          not null,
   VENDORID             int                  not null,
   constraint PK_VENDOR_PHONE primary key nonclustered (VID, VPHONE)
)
go

/*==============================================================*/
/* Index: H_FK                                                  */
/*==============================================================*/
create index H_FK on VENDOR_PHONE (
VENDORID ASC
)
go

/*==============================================================*/
/* Table: WAREHOUSE                                             */
/*==============================================================*/
create table WAREHOUSE (
   HOUSEID              int                  not null,
   COUNTRY              varchar(15)          not null,
   CITY                 varchar(15)          not null,
   STATE                varchar(15)          not null,
   STREET               varchar(20)          not null,
   NUMBER               int                  not null,
   constraint PK_WAREHOUSE primary key nonclustered (HOUSEID)
)
go

alter table ADD_UPDATE
   add constraint FK_ADD_UPDA_RELATIONS_ADMIN foreign key (ADMINID)
      references ADMIN (ADMINID)
go

alter table ADMIN_PHONE
   add constraint FK_ADMIN_PH_HAS_A_ADMIN foreign key (ADMINID)
      references ADMIN (ADMINID)
go

alter table CLIENT_PHONE
   add constraint FK_CLIENT_P_HAS_CLIENT foreign key (CLIENTID)
      references CLIENT (CLIENTID)
go

alter table GAME
   add constraint FK_GAME_DEVELOP_VENDOR foreign key (VENDORID)
      references VENDOR (VENDORID)
go

alter table GAME
   add constraint FK_GAME_RELATIONS_ADD_UPDA foreign key ()
      references ADD_UPDATE
go

alter table RENTAL
   add constraint FK_RENTAL_CONTAINS_WAREHOUS foreign key (HOUSEID)
      references WAREHOUSE (HOUSEID)
go

alter table RENT_TO___RETURN
   add constraint FK_RENT_TO__RELATIONS_GAME foreign key (GAMEID)
      references GAME (GAMEID)
go

alter table RENT_TO___RETURN
   add constraint FK_RENT_TO__RELATIONS_CLIENT foreign key (CLIENTID)
      references CLIENT (CLIENTID)
go

alter table STOREDIN
   add constraint FK_STOREDIN_RELATIONS_GAME foreign key (GAMEID)
      references GAME (GAMEID)
go

alter table STOREDIN
   add constraint FK_STOREDIN_RELATIONS_WAREHOUS foreign key (HOUSEID)
      references WAREHOUSE (HOUSEID)
go

alter table VENDOR_PHONE
   add constraint FK_VENDOR_P_H_VENDOR foreign key (VENDORID)
      references VENDOR (VENDORID)
go

