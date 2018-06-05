Create table Usuario
(
	login varchar(50) not null primary key,
	password varchar(100) not null,
	email varchar(100),
	nutricionista varchar(1) not null
)

insert into Usuario values ('admin','admin','teste@teste.com','S');