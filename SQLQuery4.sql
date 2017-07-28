create table Caja(
id int identity(1,1) not null,
codigo varchar(30) not null,
nombre varchar(30) not null,
descripcion varchar(200),
)

alter table Caja
add constraint pk_caja primary key(id)

create table Bolsa(
id int identity(1,1) not null,
codigo varchar(30) not null,
nombre varchar(30) not null,
descripcion varchar(200),
)

alter table Bolsa
add constraint pk_bolsa primary key(Id)

create table Bolsa_por_caja(
id int identity(1,1) not null,
codigo int not null,
id_bolsa int not null,
cantidad int not null,
id_caja int not null,
id_producto int not null,
fec_entrada date not null,
fech_vencimiento date not null
)
alter table Bolsa_por_caja
--add constraint pk_bolsa_caja primary key(Id)
--add constraint fk_bolsa foreign key (id_bolsa) references bolsa(id) 
--add constraint fk_caja foreign key (id_caja) references caja(id)
--add constraint fk_producto foreign key (id_producto) references producto(id)
create table producto(
id int identity (1,1) not null,
nombre varchar(30) not null,
descripcion varchar(200),
peso int not null
)
alter table producto
add constraint pk_producto primary key(Id)