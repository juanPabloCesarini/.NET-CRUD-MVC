create database agenda;
use agenda;

create table tblUsuarios (
id int not null identity (1,1) primary key,
nombre varchar(50) not null,
apellido varchar(50) not null,
mail varchar(70) not null,
clave varchar(10) not null
);

insert into tblUsuarios
values
('juan','cesarini','jpc@gmail','jpc1765');

select * from tblUsuarios;