# 🚧 E-commerce API (Em desenvolvimento)
> 🚧 **Ainda em desenvolvimento.** Este projeto está em fase de construção e pode sofrer alterações.


API de E-commerce construída em .NET 9 utilizando Clean Architecture, CQRS com MediatR, PostgreSQL como base transacional e Elasticsearch como base de leitura.

## Tecnologias

- .NET 9
- PostgreSQL
- Entity Framework Core
- Elasticsearch
- MediatR (CQRS)
- FluentValidation
- AutoMapper
- Swagger/OpenAPI
- xUnit (Testes)

## Organização do Projeto

- **Domain:** Entidades e regras de negócio.
- **Application:** DTOs, comandos, queries, handlers e validações.
- **Infrastructure:** Persistência (PostgreSQL e Elasticsearch).
- **API:** Camada de exposição (Controllers e Program.cs).

## Executando o Projeto

### 1. Clonar o repositório:

```bash
git clone https://github.com/seuusuario/seurepositorio.git
