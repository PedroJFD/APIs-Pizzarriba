CREATE DATABASE `pizzarriba bd`;
USE `pizzarriba bd`;

create table Cliente (
	id_cli int primary key,
	nome_cli varchar(200),
	sexo_cli varchar(100),
	cpf_cli varchar(100),
	telefone_cli varchar(100),
	email_cli varchar(200),
	rua_cli varchar(200),
	bairro_cli varchar(100),
	numero_cli varchar(100),
	cidade_cli varchar(100),
	complemento_cli varchar(100)
);

create table Funcionario (
	nome_fun varchar(200),
	id_fun int primary key,
	email_fun varchar(200),
	telefone_fun varchar(20),
	cpf_fun varchar(20),
	rg_fun varchar(10),
	pis_nit_fun varchar(100),
	orgao_emissor_rg_fun varchar(20),
	cargo_fun varchar(100),
    endereco_fun varchar(200),
	rua_fun varchar(200),
	numero_fun varchar(5),
	cidade_fun varchar(100),
	bairro_fun varchar(100),
	complemento_fun varchar(100)
);

create table Fornecedor (
	id_for int primary key,
	nome_for varchar(200),
	telefone_for varchar(20),
	email_for varchar(200),
	cnpj_for varchar(20),
    endereco_for varchar(200),
    cep_for varchar(20),
    rua_for varchar(200),
	bairro_for varchar(100),
	numero_for varchar(5)
);

create table Ingrediente (
	id_ing int primary key,
	nome_ing varchar(200),
	medida_ing varchar(100),
	quantidade_ing double,
	id_for_fk int not null,
	foreign key (id_for_fk) references Fornecedor (id_for)
);

create table Produto (
	id_pro int primary key,
	nome_pro varchar(200),
	preco_pro float,
	id_ing_fk int not null,
	foreign key (id_ing_fk) references Ingrediente (id_ing)
);

insert into Cliente (id_cli, nome_cli, sexo_cli, cpf_cli, telefone_cli, email_cli, rua_cli, bairro_cli, numero_cli, cidade_cli, complemento_cli) values (1, 'Pedro Joaquim', 'Masculino', '043.389.642-60', '(69) 99303-48903', 'pedrojoca@gmail.com', 'Nossa Senhora Aparecida', 'União', '509', 'Ouro Preto do Oeste', 'Casa de Esquina');
SELECT * FROM pizzarriba.cliente;