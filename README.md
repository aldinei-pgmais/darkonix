# DarkOnix - Gestão de Mini Loja Virtual com Cadastro de Produtos e Categorias

Bem-vindo ao repositório do projeto DarkOnix. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo Introdução ao Desenvolvimento ASP.NET Core. O objetivo é desenvolver uma aplicação web básica usando conceitos do Módulo 1 (C#, ASP.NET Core MVC, SQL, EF Core, APIs REST) para gestão simplificada de produtos e categorias em um formato tipo e-commerce marketplace.

Autor:

    Aldinei Sampaio

## 1. Proposta do Projeto

A aplicação consistirá em uma plataforma web básica com uma interface intuitiva, que possibilite ao usuário realizar registro/login de usuário, cadastrar, visualizar, atualizar e remover categorias e produtos, além de consultar esses dados através de uma API REST básica.

A solução será estruturada nos apectos principais:

- **Frontend (Interface de Usuário):** Desenvolvido em ASP.NET Core MVC,
permitindo interações claras e simples com o usuário. Este projeto tem como objetivo ser a área administrativa de um ecommerce.
- **Backend (API):** Uma API REST simples, também em ASP.NET Core,
responsável por expor funcionalidades básicas de autenticação, consultas
e modificações.
- **Banco de Dados:** SQL Server/SQLite com EF Core para persistência e
gerenciamento de dados.

A aplicação deve suportar autenticação e autorização, por se tratar de uma aplicação e-commerce tipo marketplace, cada usuário é um “vendedor”, portanto deve ter acesso apenas aos seus próprios produtos cadastrados.

- **Separação de Responsabilidades entre a Aplicação MVC e a API:**
  - A aplicação MVC não deve consumir a API, ambas devem oferecer o mesmo mecanismo de funcionalidades (busque uma maneira inteligente de não duplicar código).
- **Definição Estrutural do Modelo:**
  - A aplicação deve possuir ao menos três entidades principais: Vendedor, Categoria e Produto.
- **Mecanismo de CRUD para Categorias e Produtos:**
  - A aplicação deve permitir a criação, leitura, atualização e exclusão de Categorias e Produtos. Este mecanismo deve ser robusto, com tratamento de erros adequado, como por ex: verificação de campos obrigatórios.
- **Exibição de Produtos na Página Inicial:**
  - A home page deve exibir uma lista dos Produtos com informações como título, descrição, valor, etc. Deve exbir a imagem do produto.
  - Além disto, acesso as telas de CRUD para Produtos e Categorias devem estar expostas no menu.
- **Acesso Anônimo aos Produtos:**
  - Produtos devem ser publicamente acessíveis a todos os usuários via API, independentemente de estarem autenticados. Isso inclui a exibição completa dos dados dos Produtos e suas Categorias.
- **Ações de Escrita Restrita a Usuários Logados:**
  - Somente usuários autenticados podem adicionar, editar e remover um produto ou categoria.
- **Associação de Produtos a Venderores:**
  - Cada Produto deve estar associado a um único Vendedor, e esta associação deve ser persistida no banco de dados. O sistema deve garantir que apenas o Vendedor proprietário pode consultar, visualizar e modificar dados do Produto.
- **Categorias são “Livres”**
  - As categorias não estão restritas a um único vendedor, todos podem ver as categorias e editar. Futuramente essa funcionalidade será tranferida a um perfil administrador.
- **Identidade do Vendedor como Usuário Registrado:**
  - O sistema deve garantir que todos os Venderores sejam usuários registrados, utilizando o ASP.NET Core Identity. Deve haver uma validação para garantir que apenas usuários autenticados possam registrar produtos.
- **Gerenciamento de Usuários:**
  - O sistema deve utilizar as funcionalidades padrão do ASP.NET Core Identity para o registro e autenticação de usuários.
  - O user do Identity deve co-existir com a entidade Vendedor, ambos compartilham o mesmo ID e devem ser criados no mesmo processo.
- **Validação e Tratamento de Erros:**
  - Deve haver uma validação robusta em todas as operações de CRUD para garantir que os dados inseridos sejam válidos e seguros. O sistema deve fornecer feedback de erro claro e informativo, tanto na aplicação MVC quanto na API.
- **Segurança da API:**
  - A API deve ser protegida com autenticação JWT, garantindo que apenas usuários autenticados possam acessar endpoints que modificam dados (criação, atualização, exclusão).
- **Recursos Extras**
  - Recursos adicionais não são necessários.
  - Recomendo que você concentre seus esforços em entregar com excelência os requisitos obrigatórios já definidos. Adicionar complexidade desnecessária não é preciso neste momento (guarde seus skills técnicos para projetos mais avançados).
  - Se desejar acrescentar algo a mais, mantenha o projeto simples e funcional. Um bom investimento de tempo seria melhorar a experiência do usuário (UX).

## 2. Requisitos Funcionais

### 2.1. Gerenciamento de Usuários

- Cadastro e Login de usuários
- Autenticação via ASPNET Identity
- Autenticação via Cookie (MVC) e JWT (API)

### 2.2. Gerenciamento de Categorias

- Cadastro de novas categorias, com informações básicas (Nome e descrição).
- Visualização de uma lista de categorias cadastradas.
- Edição e exclusão de categorias existentes.
- Impedir exclusão de categorias com produtos associados.

### 2.3. Gerenciamento de Produtos

- Cadastro de produtos contendo nome, descrição, imagem, preço, estoque e categoria associada.
- Edição, visualização e exclusão de produtos cadastrados.
- Validação dos campos obrigatórios com feedback visual claro ao usuário.

### 2.4. API REST para Produtos

- Expor endpoints anonimos para:
  - Login
  - Listagem completa de produtos.
  - Listagem de produtos filtrados por categoria.
- Endpoints com autenticação para:
  - CRUD completo das entidades

### 2.5. Regras de Negócio

- Não permitir preços ou estoques negativos.
- Categorias devem ser cadastradas previamente para associar produtos.

## 3. Requisitos Técnicos

- Linguagem de Programação: C# .NET 8 ou superior
- Frameworks:
  - ASP.NET Core MVC para a interface web.
  - ASP.NET Core Web API para expor Produtos/Categorias.
- Acesso a Dados:
  - SQL Server/SQLite – O projeto deve ser compatível com SQL Server, porém deve ser entregue configurado para SQLite em modo “Development” para que seja executado sem dependencias de infra. Use os environments do ASPNET.
  - EF Core para mapear o BD e realizar operações de CRUD
- Autenticação e Autorização:
  - Implementar autenticação usando ASP.NET Core Identity.
  - Associar o ID do AspNetUser com o Vendedor (não é necessário relacionamento) basta criá-los no mesmo momento e usar o ID do AspNetUser no ID do Vendedor.
- Front-end:
  - Views dentro do ASP.NET Core MVC.
  - Navegação e UX com HTML e CSS para estilização.
  - Use a criatividade ou templates prontos para desenvolver a interface
- API:
  - Implementar endpoints RESTful para CRUD (Create, Read, Update, Delete) de posts e comentários.
  - A API deve suportar autenticação/autorização via JWT.
- Versionamento:
  - Github para controle de versão, com o código sendo hospedado em
um repositório publico e dentro dos padrões especificados em:
<https://github.com/desenvolvedor-io/template-repositorio-mba>

## 4. Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

    src/
        DarOnix.Web/ - Projeto MVC
        DarOnix.Api/ - API RESTful
        DarOnix.Data/ - Modelos de Dados e Configuração do EF Core
    README.md - Arquivo de Documentação do Projeto
    FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
    .gitignore - Arquivo de Ignoração do Git

## 5. Como Executar o Projeto

Pré-requisitos

- .NET SDK 8.0 ou superior
- SQL Server
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

Passos para Execução

    Clone o Repositório:
        git clone https://github.com/aldinei-pgmais/darkonix.git
        cd darkonix

    Configuração do Banco de Dados:
        No arquivo appsettings.json, configure a string de conexão do SQL Server.
        Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos

    Executar a Aplicação MVC:
        cd src/DarkOnix.Mvc/
        dotnet run
        Acesse a aplicação em: https://localhost:5000

    Executar a API:
        cd src/DarkOnix.Api/
        dotnet run
        Acesse a documentação da API em: https://localhost:5000/swagger

## 6. Instruções de Configuração

- JWT para API: As chaves de configuração do JWT estão no appsettings.json.
- Migrações do Banco de Dados: As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

## 7. Documentação da API

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

<http://localhost:5001/swagger>

## 8. Avaliação

Este projeto é parte de um curso acadêmico e não aceita contribuições externas.
Para feedbacks ou dúvidas utilize o recurso de Issues
O arquivo FEEDBACK.md é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
