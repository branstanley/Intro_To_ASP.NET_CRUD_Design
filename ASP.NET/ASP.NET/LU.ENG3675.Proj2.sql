
drop database if exists "LU.ENG3675.Proj2";

drop role if exists "LU.ENG3675";
create role "LU.ENG3675" login;
comment on role "LU.ENG3675" is 'Restricted ISS app pool user';

drop role if exists "Iago";
create role "Iago" login superuser; 
comment on role "Iago" is 'Personal developer superuser';

create database "LU.ENG3675.Proj2";
comment on database "LU.ENG3675.Proj2" is 'Database for ENG3675 Project 2';

grant conect on database "LU.ENG3675.Proj2" to "LU.ENG3675";