# Prova FH

Desafio proposto da empresa fictícia FH, utilizando:

 - ASP.NET Core 3.1;
 - Swagger Tools;
 - XUnit;
 - Fluent Assertions; 
 - Entity Framework Core (ORM);
 - PostGres (Database); 
 - Docker + Docker Compose;

## Instruções para execução

1. `git clone https://github.com/leandroribeiro/prova-f.git`

2. `cd prova-f`

3. `docker-compose up --build`

4. `cd ProvaF.Infrastructure`

5. `dotnet ef database update`

6.  Acesse no seu navegador http://localhost:5000