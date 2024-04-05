# Conceitos Aprendidos no Projeto

Neste projeto, incorporei uma variedade de práticas e padrões de design, fundamentais para a construção de aplicações robustas e escaláveis usando .NET 8. Abaixo estão os conceitos-chave que apliquei:

## DDD (Domain-Driven Design) e SOLID

- **DDD**: Implementei o Domain-Driven Design para estruturar meu projeto de maneira coesa, centrando o foco na complexidade do domínio do negócio. Isso envolveu a criação de um modelo de domínio rico, facilitando a implementação de funcionalidades complexas e a evolução do sistema.

- **SOLID**: Princípios SOLID foram aplicados para promover um código mais limpo, modular e fácil de manter. Isso ajudou a garantir que o design do software fosse resiliente às mudanças e fácil de entender.

## CQRS (Command Query Responsibility Segregation)

Adotei o padrão CQRS para separar claramente as operações de escrita (commands) das operações de leitura (queries). Isso não apenas simplificou a complexidade do design, mas também otimizou o desempenho e a escalabilidade da aplicação.
- **Commands**: Usei para operações de escrita, facilitando a validação e execução de alterações no domínio.
- **Handlers**: Responsáveis por processar commands e queries, conectando-se com todo o fluxo da aplicação.

## FailFast Validations

Implementei FailFast Validations nos Commands para assegurar que dados inválidos fossem rejeitados logo no início do processo. Isso reduziu o overhead de requisições desnecessárias, melhorando a eficiência da aplicação.

## Domínios Ricos

Um domínio rico é uma abordagem de modelagem onde as entidades e objetos de valor possuem não apenas dados, mas também comportamentos e lógicas de negócio que refletem as complexidades e regras do domínio real que estão representando. Isso contrasta com domínios anêmicos, que contêm apenas dados sem lógica de negócio. A aplicação dessa abordagem permite a criação de sistemas mais robustos, pois a lógica de negócio é encapsulada dentro do domínio, facilitando a manutenção e evolução do software.

## Separação por Contextos Delimitados

A separação por contextos delimitados é uma técnica chave do Domain-Driven Design que consiste em dividir o sistema em módulos ou subdomínios que são especializados em determinadas áreas do negócio. No caso deste projeto, ele está focado no contexto de pagamentos.

## Value Objects

Utilizei Value Objects para evitar a "obsessão por tipos primitivos" e centralizar validações e lógica relacionada a valores específicos do domínio. Isso aumentou a expressividade do modelo de domínio e reduziu a duplicação de código.

## Repository Pattern

Apliquei o Repository Pattern para desacoplar o domínio das fontes de dados, permitindo que minha lógica de negócio fosse independente da infraestrutura de dados. Isso me deu a flexibilidade de mudar as tecnologias de persistência sem afetar o núcleo do domínio.

## Testes Unitários

- Utilizei o MSTest para validar todas as camadas do projeto, assegurando que cada unidade de código funcionasse como esperado sob diversas condições. Isso foi crucial para manter a qualidade e a estabilidade do sistema ao longo do desenvolvimento.
