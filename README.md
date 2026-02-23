# FinanceControl API
API REST desenvolvida em ASP.NET Core (.NET 8) para controle financeiro pessoal, permitindo que usuários registrem receitas, despesas, categorias, investimentos/rendimentos e acompanhem seu saldo mensal por meio de relatórios e previsões.

## 1. Domínio do Problema

Muitas pessoas possuem dificuldades para organizar suas finanças pessoais, controlar gastos mensais, planejar seus investimentos e visualizar seu saldo de forma estruturada.
O projeto FinanceControl API propõe a implementação de um sistema backend responsável por:
  Gerenciar usuários
  Registrar receitas e despesas
  Organizar transações por categorias
  Calcular saldo financeiro
  Gerar resumo mensal.
A aplicação será consumida por um frontend desenvolvido em HTML, CSS e JavaScript (analisando utilização de ANGULAR), podendo utilizar CSHTML se necessário.

## 2. Requisitos Funcionais (RF)
RF01 – O sistema deve permitir cadastro de usuário
RF02 – O sistema deve permitir autenticação (login)
RF03 – O sistema deve permitir cadastro de categorias
RF04 – O sistema deve permitir registrar receitas
RF05 – O sistema deve permitir registrar despesas
RF06 – O sistema deve permitir listar transações
RF07 – O sistema deve permitir calcular saldo automaticamente
RF08 – O sistema deve permitir gerar resumo mensal

## 3. Requisitos Não Funcionais (RNF)
RNF01 – A aplicação deve seguir o padrão REST
RNF02 – Deve utilizar autenticação JWT
RNF03 – Deve utilizar arquitetura em camadas
RNF04 – Deve garantir integridade referencial no banco de dados
RNF05 – Deve possuir documentação automática via Swagger
RNF06 – Deve permitir escalabilidade futura

## 4. Objetivo do Projeto
Desenvolver uma API RESTful utilizando ASP.NET Core .NET 8, aplicando boas práticas de arquitetura em camadas, autenticação JWT(em analise) e persistência de dados em banco relacional MySQL.

## 5. Arquitetura do Sistema
O projeto segue arquitetura em camadas para garantir separação de responsabilidades:

Controller → Service → Repository → DbContext → MySQL
Camadas:

API – Responsável por expor endpoints HTTP
Application – Contém regras de negócio
Domain – Contém entidades e enums
Infrastructure – Responsável pela persistência de dados

        FinanceControl/
        │
        ├── FinanceControl.API/
        │   ├── Controllers/
        │   ├── Middlewares/
        │   ├── Program.cs
        │   └── appsettings.json
        │
        ├── FinanceControl.Application/
        │   ├── DTOs/
        │   ├── Interfaces/
        │   ├── Services/
        │
        ├── FinanceControl.Domain/
        │   ├── Entities/
        │   ├── Enums/
        │
        ├── FinanceControl.Infrastructure/
        │   ├── Data/
        │   │   ├── AppDbContext.cs
        │   ├── Repositories/
        │
        └── FinanceControl.sln

## 6. Tecnologias Utilizadas e Justificativas
 ASP.NET Core (.NET 8)  
  Framework moderno, multiplataforma e de alta performance, amplamente utilizado no mercado. Atualmente utilizo no trabalho e estou estudando mais a fundo.

 Entity Framework Core
  ORM oficial da Microsoft para .NET. Facilita o mapeamento objeto-relacional e reduz complexidade na manipulação do banco de dados. (até momento banco só foi malipulado via migrations)

 MySQL 8.0
  Banco de dados relacional. Escolhido por ser leve, compatível com o Entity Framework via Pomelo(provedor).

JWT (Em analise ->)
  Utilizado para autenticação, garantindo segurança nas requisições e controle de acesso por usuário.

Swagger (Swashbuckle)
  Permite documentação automática da API, facilitando testes e validação dos endpoints.

HTML, CSS e JavaScript(padrão front-end) ->Analisando utilização de Angular.
  Serão utilizados para desenvolvimento do frontend que consumirá a API.

## 7. Organização Inicial de Tarefas

Estruturação da solução em camadas
Configuração do banco de dados
Implementação de autenticação JWT
Implementação de CRUD de categorias
Implementação de CRUD de transações
Implementação de cálculo de saldo
Documentação da API

## 8. Justificativa Acadêmica

O projeto foi estruturado visando os conceitos:

Arquitetura em camadas
Separação de responsabilidades
Injeção de dependência
Persistência de dados relacional
Boas práticas de desenvolvimento backend
