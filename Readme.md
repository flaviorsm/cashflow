
# Implementar Migration

dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate --project ../CFM.Infrastructure

dotnet ef database update

# Projeto CFM API

Este projeto implementa uma API para a consolidação de lançamentos financeiros, permitindo o acesso e a manipulação de dados por meio de endpoints RESTful.

## Estrutura do Projeto

A API é construída usando .NET Core e segue os princípios de Arquitetura Onion, Domain-Driven Design (DDD), Test-Driven Development (TDD) e Design Patterns.

### Tecnologias Utilizadas

- **.NET Core**: Framework para desenvolvimento de aplicações web.
- **AutoMapper**: Biblioteca para mapeamento de objetos.
- **ASP.NET Core MVC**: Estrutura para construção de APIs RESTful.

## Endpoints

### 1. Consolidar Por Dia

`GET api/consolidado/PorDia`

- **Descrição**: Consolida os lançamentos para uma data específica.
- **Parâmetros**:
  - `data` (query string): A data para a qual a consolidação será feita. Deve estar em formato `DateTime`.
- **Respostas**:
  - `200 OK`: Retorna o consolidado dos lançamentos para o dia solicitado.
  - `204 No Content`: Indica que não há lançamentos para a data fornecida.
  - `400 Bad Request`: Se ocorrer um erro de validação ou entrada inválida.
  - `500 Internal Server Error`: Se ocorrer um erro interno no servidor.

### 2. Consolidar Por Período

`GET api/consolidado/PorPeriodo`

- **Descrição**: Consolida os lançamentos em um intervalo de datas.
- **Parâmetros**:
  - `dataInicial` (query string): A data inicial do período para a consolidação. Deve estar em formato `DateTime`.
  - `dataFinal` (query string): A data final do período para a consolidação. Deve estar em formato `DateTime`.
- **Respostas**:
  - `200 OK`: Retorna dados consolidados, se encontrados.
  - `204 No Content`: Se não houver dados disponíveis para o período especificado.
  - `400 Bad Request`: Em caso de erro ao processar a solicitação.
  - `500 Internal Server Error`: Se ocorrer um erro interno no servidor.

### 3. Consolidar Por Categoria

`GET api/consolidado/PorCategoria`

- **Descrição**: Consolida os lançamentos de uma categoria específica em um intervalo de datas.
- **Parâmetros**:
  - `categoria` (query string): O identificador da categoria para a consolidação.
  - `dataInicial` (query string): A data inicial do período para a consolidação. Deve estar em formato `DateTime`.
  - `dataFinal` (query string): A data final do período para a consolidação. Deve estar em formato `DateTime`.
- **Respostas**:
  - `200 OK`: Retorna dados consolidados, se encontrados.
  - `204 No Content`: Se não houver dados disponíveis para o período e categoria especificados.
  - `400 Bad Request`: Em caso de erro ao processar a solicitação.
  - `500 Internal Server Error`: Se ocorrer um erro interno no servidor.

## Endpoints da API

### 4. Consolidar Por Dia

`GET api/consolidado/PorDia`

- **Descrição**: Consolida os lançamentos para uma data específica.
- **Parâmetros**:
  - `data`: A data para a qual a consolidação será feita (formato: `DateTime`).
- **Respostas**:
  - `200 OK`: Retorna o consolidado dos lançamentos do dia solicitado.
  - `204 No Content`: Não há lançamentos para a data fornecida.
  - `400 Bad Request`: Erro de validação ou entrada inválida.
  - `500 Internal Server Error`: Erro interno no servidor.

### 5. Consolidar Por Período

`GET api/consolidado/PorPeriodo`

- **Descrição**: Consolida os lançamentos em um intervalo de datas.
- **Parâmetros**:
  - `dataInicial`: A data inicial do período para a consolidação (formato: `DateTime`).
  - `dataFinal`: A data final do período para a consolidação (formato: `DateTime`).
- **Respostas**:
  - `200 OK`: Retorna dados consolidados, se encontrados.
  - `204 No Content`: Não há dados disponíveis para o período especificado.
  - `400 Bad Request`: Erro ao processar a solicitação.
  - `500 Internal Server Error`: Erro interno no servidor.

### 6. Consolidar Por Categoria

`GET api/consolidado/PorCategoria`

- **Descrição**: Consolida os lançamentos de uma categoria específica em um intervalo de datas.
- **Parâmetros**:
  - `categoria`: O identificador da categoria para a consolidação.
  - `dataInicial`: A data inicial do período para a consolidação (formato: `DateTime`).
  - `dataFinal`: A data final do período para a consolidação (formato: `DateTime`).
- **Respostas**:
  - `200 OK`: Retorna dados consolidados, se encontrados.
  - `204 No Content`: Não há dados disponíveis para o período e categoria especificados.
  - `400 Bad Request`: Erro ao processar a solicitação.
  - `500 Internal Server Error`: Erro interno no servidor.

## Configuração do Ambiente

Para executar este projeto localmente, você precisa ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado. 

### Executando o Projeto

1. Clone o repositório.
2. Navegue até o diretório do projeto.
3. Execute o comando:
   ```bash
   dotnet run
