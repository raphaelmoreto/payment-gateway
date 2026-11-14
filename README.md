# 🚪 GatewayProject

## 📖 Sobre o Projeto

O **GatewayProject** é uma aplicação desenvolvida em **C# (.NET 8)** com o objetivo de demonstrar, na prática, o funcionamento de um **API Gateway** em uma arquitetura de software baseada em Clean Architecture.

O Gateway funciona como um ponto central de entrada para as requisições dos clientes, sendo responsável por intermediar a comunicação entre a aplicação e os diferentes serviços disponíveis.

O objetivo do projeto é compreender como centralizar e organizar a comunicação entre sistemas, evitando que os clientes precisem conhecer diretamente os endereços e detalhes de implementação de cada serviço.

A aplicação tem como finalidade demonstrar funcionalidades como:

* 🚪 Recebimento e encaminhamento de requisições HTTP
* 🔀 Roteamento de requisições para diferentes serviços
* ⚙️ Configuração e gerenciamento de rotas
* 🛡️ Tratamento de erros e respostas HTTP
* 📡 Comunicação com APIs externas e serviços internos

---

## 🏗️ Arquitetura do Projeto

O projeto segue os princípios da **Clean Architecture**, organizando as responsabilidades em camadas independentes.

```text
GatewayProject
│
├── GatewayProject.API              → Ponto de entrada da aplicação
│
├── GatewayProject.Application      → Casos de uso e regras de aplicação
│
├── GatewayProject.Domain           → Entidades e regras de domínio
│
└── GatewayProject.Infrastructure   → Implementações e integrações externas
```

### 🔹 Responsabilidade das Camadas

* **API:** responsável por receber as requisições HTTP, configurar os endpoints e disponibilizar os serviços do Gateway.
* **Application:** concentra os casos de uso e a orquestração das operações da aplicação.
* **Domain:** contém as entidades, abstrações e regras de negócio independentes de infraestrutura.
* **Infrastructure:** responsável pelas implementações técnicas, comunicação HTTP, integração com serviços externos e configurações necessárias.

A comunicação entre as camadas respeita o princípio da inversão de dependência, mantendo o domínio independente de detalhes externos.

---

## 📦 Tecnologias utilizadas

* **C#**
* **.NET 9**
* **ASP.NET Core Web API**
* **HttpClient / IHttpClientFactory**
* **Clean Architecture**

### 🔧 Bibliotecas e recursos

* `Microsoft.Extensions.Http` – gerenciamento de clientes HTTP.
* `Swashbuckle.AspNetCore` - gera automaticamente documentação interativa para APIs construídas em ASP.NET Core. Ele inspeciona suas rotas, controladores e modelos para criar um contrato no padrão OpenAPI (antigo Swagger) e disponibiliza uma página web onde você pode visualizar e testar cada endpoint diretamente pelo navegador.

---

## 🧠 Padrões e Conceitos

O projeto utiliza conceitos importantes da arquitetura de software:

* **API Gateway:** centralização da entrada e do encaminhamento de requisições.
* **Clean Architecture:** separação de responsabilidades e independência entre camadas.
* **Repository Pattern:** abstração do acesso a dados, quando necessário.
* **HTTP Client:** comunicação entre aplicações e serviços.
* **SOLID:** aplicação dos princípios de desenvolvimento orientado a objetos.

---

## 🔀 Funcionamento do Gateway

O Gateway atua como intermediário entre o cliente e os serviços disponíveis.

O fluxo básico de comunicação funciona da seguinte maneira:

```text
        CLIENTE
           |
           | HTTP Request
           v
     GATEWAY API
           |
           v
      APPLICATION
           |
           v
      INFRASTRUCTURE
           |
           | HTTP Request
           v
     SERVIÇO EXTERNO
           |
           | HTTP Response
           v
      INFRASTRUCTURE
           |
           v
      APPLICATION
           |
           v
      GATEWAY API
           |
           | HTTP Response
           v
        CLIENTE
```

### 📌 Exemplo prático

Imagine que uma aplicação precise consultar informações de usuários e produtos disponibilizadas por APIs diferentes.

Sem um Gateway, o cliente precisaria conhecer diretamente os endereços de cada API.

Com o Gateway, o cliente realiza suas requisições utilizando um único ponto de entrada.

Exemplo:

```http
GET /api/usuarios
GET /api/produtos
```

Internamente, o Gateway identifica a rota solicitada e encaminha a requisição para o serviço correspondente.

Dessa forma, o cliente não precisa conhecer os detalhes internos da comunicação entre os serviços.

---

## ⚙️ Como Executar

### ✅ Pré-requisitos

* .NET 8 SDK
* Visual Studio 2022+
* Git
* Editor de código de sua preferência

### ▶️ Passos

```bash
# Clonar o repositório
git clone https://github.com/seu-usuario/gateway-project.git

# Acessar a pasta
cd gateway-project

# Restaurar os pacotes
dotnet restore

# Compilar a solução
dotnet build

# Executar a API
dotnet run --project GatewayProject.API
```

Após iniciar a aplicação, utilize o Swagger para visualizar e testar os endpoints disponíveis.

---

## 📂 Estrutura dos Projetos

### 🔹 GatewayProject.API

Responsável pela camada de apresentação e entrada das requisições HTTP.

* Configuração da aplicação.
* Controllers e endpoints.
* Swagger.
* Registro das dependências.

### 🔹 GatewayProject.Application

Responsável pela lógica de aplicação e orquestração dos casos de uso (Services).

* Interfaces e contratos.
* Services e casos de uso.
* DTOs.
* Validações de entrada.
* Abstrações para comunicação com outros serviços.

### 🔹 GatewayProject.Domain

Responsável pelas regras e estruturas centrais do domínio.

* Entidades.
* Regras de negócio.

### 🔹 GatewayProject.Infrastructure

Responsável pelas implementações técnicas e integrações.

* Clientes HTTP.
* Comunicação com APIs externas.
* Implementação das interfaces da Application.
* Configurações de serviços externos.
* Gerenciamento de conexões e integrações.

---

## 🚀 Possíveis Melhorias

* 🔐 Implementação de autenticação centralizada com JWT.
* 🔄 Implementação de políticas de Retry e Circuit Breaker.
* ⏱️ Configuração de Timeout para chamadas HTTP.
* 🚦 Rate Limiting para controle de requisições.
* 📊 Monitoramento e logging das requisições.
* 🔀 Balanceamento de carga entre serviços.
* 📦 Implementação de cache para respostas frequentes.
* 🐳 Containerização utilizando Docker.
* 🧪 Testes unitários e de integração.

---

## 📚 Objetivos de Aprendizado

Ao desenvolver este projeto, os principais objetivos são:

* Compreender o conceito e a finalidade de um API Gateway.
* Entender como funciona a comunicação entre diferentes aplicações.
* Aprender a encaminhar requisições HTTP para serviços externos.
* Aplicar Injeção de Dependência e Inversão de Controle.
* Compreender como um Gateway pode simplificar a comunicação em arquiteturas distribuídas.

---

## 📄 Licença

Este projeto é destinado a fins educacionais e de estudo.

---

## 👨‍💻 Autor

Desenvolvido por **Raphael**.