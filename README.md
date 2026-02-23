# FinanceControl API
API REST desenvolvida em ASP.NET Core (.NET 8) para controle financeiro pessoal, permitindo que usuários registrem receitas, despesas, categorias, investimentos/rendimentos e acompanhem seu saldo mensal por meio de relatórios e previsões.

## 1. Domínio do Problema

Muitas pessoas possuem dificuldades para organizar suas finanças pessoais, controlar gastos mensais, planejar seus investimentos e visualizar seu saldo de forma estruturada.<br>
O projeto FinanceControl API propõe a implementação de um sistema backend responsável por:<br>
  Gerenciar usuários<br>
  Registrar receitas e despesas<br>
  Organizar transações por categorias<br>
  Calcular saldo financeiro<br>
  Gerar resumo mensal.<br>
A aplicação será consumida por um frontend desenvolvido em HTML, CSS e JavaScript (analisando utilização de ANGULAR), podendo utilizar CSHTML se necessário.

## 2. Requisitos Funcionais (RF)<br>
RF01 – O sistema deve permitir cadastro de usuário<br>
RF02 – O sistema deve permitir autenticação (login)<br>
RF03 – O sistema deve permitir cadastro de categorias<br>
RF04 – O sistema deve permitir registrar receitas<br>
RF05 – O sistema deve permitir registrar despesas<br>
RF06 – O sistema deve permitir listar transações<br>
RF07 – O sistema deve permitir calcular saldo automaticamente<br>
RF08 – O sistema deve permitir gerar resumo mensal

## 3. Requisitos Não Funcionais (RNF)<br>
RNF01 – A aplicação deve seguir o padrão REST<br>
RNF02 – Deve utilizar autenticação JWT<br>
RNF03 – Deve utilizar arquitetura em camadas<br>
RNF04 – Deve garantir integridade referencial no banco de dados<br>
RNF05 – Deve possuir documentação automática via Swagger<br>
RNF06 – Deve permitir escalabilidade futura

## 4. Objetivo do Projeto
Desenvolver uma API RESTful utilizando ASP.NET Core .NET 8, aplicando boas práticas de arquitetura em camadas, autenticação JWT(em analise) e persistência de dados em banco relacional MySQL.

## 5. Arquitetura do Sistema
O projeto segue arquitetura em camadas para garantir separação de responsabilidades:

Controller → Service → Repository → DbContext → MySQL
Camadas:<br>

API – Responsável por expor endpoints HTTP<br>
Application – Contém regras de negócio<br>
Domain – Contém entidades e enums<br>
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
 ASP.NET Core (.NET 8)  <br>
  Framework moderno, multiplataforma e de alta performance, amplamente utilizado no mercado. Atualmente utilizo no trabalho e estou estudando mais a fundo.

 Entity Framework Core<br>
  ORM oficial da Microsoft para .NET. Facilita o mapeamento objeto-relacional e reduz complexidade na manipulação do banco de dados. (até momento banco só foi malipulado via migrations)

 MySQL 8.0<br>
  Banco de dados relacional. Escolhido por ser leve, compatível com o Entity Framework via Pomelo(provedor).

JWT (Em analise ->)<br>
  Utilizado para autenticação, garantindo segurança nas requisições e controle de acesso por usuário.

Swagger (Swashbuckle)<br>
  Permite documentação automática da API, facilitando testes e validação dos endpoints.

HTML, CSS e JavaScript(padrão front-end) <br>->Analisando utilização de Angular.
  Serão utilizados para desenvolvimento do frontend que consumirá a API.

## 7. Organização Inicial de Tarefas

Estruturação da solução em camadas<br>
Configuração do banco de dados<br>
Implementação de autenticação JWT<br>
Implementação de CRUD de categorias<br>
Implementação de CRUD de transações<br>
Implementação de cálculo de saldo<br>
Documentação da API<br>

## 8. Justificativa Acadêmica<br>

O projeto foi estruturado visando os conceitos:<br>

Arquitetura em camadas<br>
Separação de responsabilidades<br>
Injeção de dependência<br>
Persistência de dados relacional<br>
Boas práticas de desenvolvimento backend
