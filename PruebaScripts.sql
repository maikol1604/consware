create table aut_user(
id int primary key identity not null,
user_aut varchar(150),
password_aut varchar(150),
estado_aut varchar(3)
)

--USUARIO DE LOGUE
--insert into aut_user values('admin','admin123','ACT')

create table Producto(
id_key int primary key identity not null,
Nombre varchar(100),
precio decimal,
)

drop TABLE Cliente
create table Cliente(
id_key int primary key identity not null,
Nombre varchar(100),
Apellido varchar(100),
CC varchar(100),
estado varchar(3),
)

create procedure GetCliente
as
begin
select * from Cliente
end
