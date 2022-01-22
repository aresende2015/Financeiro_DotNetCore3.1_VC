# API para estudos

Para rodar a API será necessário o banco de dados.

Será necessário do Sqlite

- Para criar as migrations do EntityFrameworkCore, rodar o comando abaixo dentro da pasta da solução
dotnet ef migrations add inicial -p Investimento.Data -s Investimento.API 

- Para criar o banco de dados referente a migration, rodar dentro da pasta da solução
dotnet ef database update -s Investimento.API
