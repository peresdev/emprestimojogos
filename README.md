# Empréstimo de Jogos
Projeto para gerenciar o Empréstimo de Jogos a amigos

# Tecnologias utilizadas
- ASP.NET Core 2.0
- Entity Framework
- Framework CSS Bulma (https://bulma.io)
- jQuery
- Docker (Opcional - necessário para subir SQL Server em Linux/Mac)

# Banco de dados - SQL Server
1. Criar base de dados
```sql
CREATE DATABASE emprestimo_jogos;
```
2. Usar a base criada
```sql
USE emprestimo_jogos;
```
3. Criar tabelas
```sql
CREATE TABLE Amigo (
	AmigoID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome varchar(255) NULL
);

CREATE TABLE Jogo (
	JogoID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome varchar(255) NULL,
	AmigoID int NULL
);

CREATE TABLE Usuario (
	UsuarioID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Login varchar(255) NULL,
	Senha varchar(255)
);
```
4. Inserir dados (opcional)
```sql
INSERT Amigo (Nome) VALUES ('Mateus');
INSERT Amigo (Nome) VALUES ('Rafael');
INSERT Amigo (Nome) VALUES ('Allan');
INSERT Amigo (Nome) VALUES ('Fernanda');
INSERT Amigo (Nome) VALUES ('Joana');
INSERT Amigo (Nome) VALUES ('Eduardo');
INSERT Amigo (Nome) VALUES ('Paula');
INSERT Amigo (Nome) VALUES ('Michel');
INSERT Amigo (Nome) VALUES ('Stela');
INSERT Amigo (Nome) VALUES ('Ícaro');

INSERT INTO Jogo (Nome, AmigoID) VALUES ('God of War',1);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Horizon Zero Dawn',2);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Assassin’s Creed Origins',3);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Call Of Duty: WWII',4);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Dragon Ball FighterZ',5);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Monster Hunter World',6);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Far Cry 5',7);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Detroit: Become Human',8);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('Wolfenstein II: The New Colossus',9);
INSERT INTO Jogo (Nome, AmigoID) VALUES ('FIFA 2018',10);
INSERT INTO Jogo (Nome) VALUES ('Nier Automata');
INSERT INTO Jogo (Nome) VALUES ('Shadow of the Colossus');
INSERT INTO Jogo (Nome) VALUES ('Destiny 2');
INSERT INTO Jogo (Nome) VALUES ('Terra-Média: Sombras da Guerra');
INSERT INTO Jogo (Nome) VALUES ('Ni No Kuni II: Revenant Kingdom');
INSERT INTO Jogo (Nome) VALUES ('The Witcher III');
INSERT INTO Jogo (Nome) VALUES ('Persona 5');
INSERT INTO Jogo (Nome) VALUES ('Street Fighter V');
INSERT INTO Jogo (Nome) VALUES ('Resident Evil 7');
INSERT INTO Jogo (Nome) VALUES ('Uncharted: The Lost Legacy');
INSERT INTO Jogo (Nome) VALUES ('Tekken 7');
INSERT INTO Jogo (Nome) VALUES ('Bloodborne');
INSERT INTO Jogo (Nome) VALUES ('Final Fantasy XV');
INSERT INTO Jogo (Nome) VALUES ('Need for Speed Payback');
INSERT INTO Jogo (Nome) VALUES ('Injustice 2');

INSERT Usuario (Login, Senha) VALUES ('admin', 'admin');
```

# Configurar conexão com o banco de dados - appsettings.json
Default (porta: 1433, nome da base: emprestimo_jogos, usuário da base: SA, senha: SENHA)
```
  "ConnectionStrings": {
    "BaseEmprestimoJogos": "Server=tcp:localhost,1433;Initial Catalog=emprestimo_jogos;Persist Security Info=True;User Id=SA;Password=SENHA;"
  },
 ```

# Possíveis melhorias
- Verificação de usuário logado nas páginas internas
- Criptografar senha
- Utilizar algum serviço em Nuvem, como o Azure para a realização de Login.
- Testes unitários

# Autor
Leandro Peres