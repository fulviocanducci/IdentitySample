# SampleIdentity

Projeto para estudar a arquiteura utilizando um servidor de identidade uma ou mais API's com as regras de négocio e diversas aplicações utilizando a autenticadas acessando os serviços da API.

  - Utilizado .Net Core 2.0
  - Identity Server 4
  - EntityFramework Core 

Pré Requisitos para executar o projeto:
  - Uma base de sql (projeto está configurado para Localdb v12.0)
  - O Microsoft framework core 2.0

Executando o projeto
 - Configure os dados da sua base de dados no arquivo appsettings.json dos projetos API e Auth
 - Restaure os pacotes nuget (dotnet restore na raiz do repositório)
 - Execute o build da solução IdentitySample.sln (na raiz da pasta do projeto executar o comando "dotnet build IdentitySample.sln")
 - Execute os projetos IdentitySample.Api, IdentitySample.Auth e IdentitySample.Web  (na raiz da pasta de cada projeto executar o comando dotnet run)
 - Acesse a URL http://localhost:10692/swagger/ (Obs.: 10692 foi a porta padrão na minha máquina o comando utilize a porta informada no resultado da comando dotnet run)
 - Para interromper a execução na janela de comando execute o comando ctrl+c

