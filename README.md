# GestaoProdutos
Gestão de Produtos com cadastro de Fornecedor e Produtos

Feito em .NET Core

Para executar tem que mudar a string de conexão dentro do appsettings.json (localizado dentro do projeto GestaoProdutos.App)

Foi feito com CodeFirst, ou seja é necessário rodar os comandos do migration:

// Já existe, mas caso queira apagar o existente e criar outro

add-migration NameMigration -context MeuDbContext

// Atualizar o banco

update-database -context MeuDbContext

Obs.: rodar no Package Manager Console e escolher o "GestaoProdutos.App" como Default projet.

Quem quiser adicionar melhorias, principalmente no teste, será de boa serventia.

Desenvolvido no Visual Studio 2019
Framework usado: .NET 5.0
