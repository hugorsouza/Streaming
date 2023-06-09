# Streaming - Gerencie e organizar suas listas

Este é um projeto de aplicativo web desenvolvido em .NET 5, com o objetivo de fornecer uma solução completa para gerenciar listas de conteúdo em um serviço de streaming. A aplicação utiliza uma arquitetura de camadas bem estruturada, promovendo uma separação clara de responsabilidades e facilitando a manutenção e extensibilidade do código.

## 🛠️ Recursos e Tecnologias Utilizadas:

### NET 5:
A plataforma .NET de última geração, fornecendo um ambiente robusto e eficiente para o desenvolvimento da aplicação.

### Entity Framework Migration: 
Utilizado para mapear e gerenciar o banco de dados SQL, permitindo a criação, atualização e migração do esquema de banco de dados de forma simples e automatizada.

### Token Authentication: 
Implementação de autenticação baseada em tokens para garantir a segurança e controle de acesso ao sistema, permitindo que os usuários autenticados gerenciem suas próprias listas de conteúdo.

### ASP.NET Core: 
Framework utilizado para o desenvolvimento da aplicação web, oferecendo uma base sólida e poderosa para a criação de APIs RESTful.

### Swagger: 
Ferramenta para documentação de APIs, fornecendo uma interface interativa para explorar e testar os endpoints disponíveis.

### Banco de Dados SQL: 
A aplicação se integra com um banco de dados SQL para armazenar informações sobre os usuários, listas de conteúdo e detalhes do conteúdo.

### Camadas: 
A arquitetura é dividida em camadas, incluindo a camada de apresentação (API), camada de serviços (regras de negócio), camada de acesso a dados (repositórios) e camada de modelos (entidades de domínio), garantindo um código organizado e modular.

## 🔩 Principais Funcionalidades:

Registro e autenticação de usuários.
Gerenciamento de listas de conteúdo, incluindo criação, edição e exclusão.
Adição e remoção de conteúdo nas listas dos usuários.
Pesquisa avançada de conteúdo por gênero, ator, diretor, etc.
Visualização de detalhes sobre cada conteúdo, como sinopse, classificação e duração.
Integração com um serviço externo de streaming para obter informações atualizadas sobre o catálogo de conteúdo.

