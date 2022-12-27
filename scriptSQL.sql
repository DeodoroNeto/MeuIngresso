-- criar o Banco de Dados
create database BD_MeuIngresso
go

-- acessar o Banco de Dados BD_ECommerce
use BD_MeuIngresso
go

-- criar a tabela de Clientes
create table Clientes
(
	idCliente		int				not null		primary key		identity,
	nome			varchar(50)		not null,
	email			varchar(100)	not null,
	senha			varchar(20)		not null
)
go
-- cadastrar(inserir) 1 clientes na tabel Clientes
insert into Clientes (nome, email, senha)
values ('Deodoro Soares Cavalcanti Neto', 'deodoro@gmail.com', '123456')
go

--Criando a tabela de Produtos
create table Produtos
(
	-- idCategoria será chave prímaria(primary key)
	-- e seu valor será gerado automaticamente(identity) pelo Banco de Dados
	idProduto	int				not null	primary key		identity,
	nome		varchar(30)		not null,
	descricao	varchar(200)	not null,
	valor		decimal(10,2)	not null,
	tipo_De_Show	varchar(100)	not null
)
go
-- cadastrar (inserir) 5 produtos na tabela Produtos
insert into Produtos (nome, descricao, valor, tipo_De_Show)
values ('O Senhor dos Aneis', 'Ingresso para Filme O Senhor dos Aneis', 25.00, 'Cinema')

insert into Produtos (nome, descricao, valor, tipo_De_Show)
values ('Afonso Padilha', 'Ingresso para Stand-up do Afonso Padilha', 74.90, 'Stand-up')

insert into Produtos (nome, descricao, valor, tipo_De_Show)
values ('Corinthians x Flamengo', 'Ingresso para jogo de Corinthians x Flamengo', 17.00, 'Jogo de Futebol')
go

