# Desafio Técnico Fullstack - Backend .NET

## Descrição

Impar Api é uma REST API que permite a leitura e gravação de dados do frontend [Impar Spa](https://github.com/matheusb432/impar-challenge-react)

## Tecnologias utilizadas

- [ASP.NET Core 6](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-6.0)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [OData](https://www.odata.org/documentation/)

## Arquitetura da API seguindo o DDD

1. Presentation: Compõe a API e os controladores de endpoints da mesma.
2. Application: Implementação da lógica da aplicação, envolvendo a implementação dos serviços.
3. Domain: Representa os modelos do sistema, junto com as validações desses modelos que serão utilizadas em Application.
4. Infra: camada da infraestrutura, aqui está a implementação do contexto de dados, as migrações do banco de dados e as tabelas representadas como 'DbSet<>'s do EF Core.

## Setup do projeto

### Pré-requisitos

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Microsoft® SQL Server® 2019 Express](https://www.microsoft.com/pt-br/download/details.aspx?id=101064)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Rodando a API em ambiente de desenvolvimento

1. Clonar este repositório com o comando `git clone`.
2. Abrir o arquivo appsettings.Development.json, ou appsettings.Production.json se quiser rodar API em modo de produção, e alterar o valor de `ConnectionStrings.ImparConnection` para a string de conexão do seu banco de dados.
3. Abrir a solução `ImparApp.sln` e definir `ImparApp.Presentation` como projeto de inicialização.
4. Compilar o projeto através do Visual Studio ou pela Dotnet CLI com `dotnet run` na raiz da pasta da camada `ImparApp.Presentation`, o banco de dados ImparDB deve ser criado automaticamente pela API neste ponto.
5. Acessar a API em <http://localhost:5000> para verificar seu funcionamento.
