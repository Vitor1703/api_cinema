# Cinema API

## **Descrição**
A **Cinema API** é um sistema robusto e modular desenvolvido para gerenciar as operações de um cinema específico. O projeto cobre todas as áreas essenciais, como o gerenciamento de usuários, filmes, salas, sessões, ingressos e preços.

O sistema é construído em **.NET Core**, com **Entity Framework Core** como ORM e banco de dados **PostgreSQL**, garantindo escalabilidade e eficiência.

## **Funcionalidades Principais**
1. **Gerenciamento de Usuários**:
   - Cadastro de usuários.
   - Login e autenticação.
   - Consulta de usuários por ID.
2. **Gerenciamento de Filmes**:
   - Cadastro de novos filmes.
   - Atualização e desativação.
   - Listagem geral e de filmes em cartaz.
3. **Gerenciamento de Salas**:
   - Cadastro de salas de exibição.
   - Listagem das salas disponíveis.
4. **Sessões**:
   - Criação de sessões de filmes.
   - Atualização de horários e preços.
   - Listagem de sessões por filme ou sala.
   - Desativação de sessões.
5. **Ingressos**:
   - Compra de ingressos.
   - Validação de assentos disponíveis.
   - Cancelamento e listagem de ingressos por sessão ou usuário.
6. **Preços de Ingressos**:
   - Cadastro de preços.
   - Atualização e desativação.
   - Consulta de preços disponíveis.

## Requisitos necessários para testar o projeto

### Instalar o .NET
- **.NET**: Versão 8  
  Baixe o .NET na [página oficial](https://dotnet.microsoft.com/pt-br/).
  
### Instalar o PostgreSQL 
- **PostgreSQL**: Utilize a versão mais recente disponível.  
  Faça o download do PostgreSQL na [página oficial](https://www.postgresql.org/download/).

### Instalar o Docker
- **Docker**:  
  Faça o download do Docker na [página oficial](https://www.docker.com/).

## Passo a Passo para Configurar e Rodar o Projeto

### 1. Configuração do Docker
1. Instale o Docker conforme o link fornecido acima.
2. Certifique-se de que o Docker está em execução no seu sistema.
3. Vá até a raiz do projeto e execute o seguinte comando para inicializar os containers:
   ```bash
   docker-compose up -d

# Configuração do Banco de Dados

1. Certifique-se de que o PostgreSQL está em execução.
2. Utilize as seguintes configurações para conectar o banco de dados ao projeto:

   - **Nome do banco:** `cinema`
   - **Configuração de conexão:**
     ```plaintext
     Host=localhost;Database=cinema;Username=cinesystem;Password=bianca23
     ```
# Aplicando Migrations

## Diretório para Rodar as Migrations

- Navegue até o diretório:
  ```bash
  cd api_cinema/CinemaService/Infrastructure/Data

# Comandos para Aplicar as Migrations

1. Aplique todas as migrations em ordem, utilizando os seguintes comandos:
   ```bash
   dotnet ef migrations add 20241125233803_InitialMigration
   dotnet ef migrations add 20241126024358_AddMoviesTable
   dotnet ef migrations add 20241126032312_AddImageUrlToMovies
   dotnet ef migrations add 20241126035042_AddRoomsTable
   dotnet ef migrations add 20241126050339_AddSessionsTable
   dotnet ef migrations add 20241126055054_AddTicketsTable
   dotnet ef migrations add 20241126233753_AddTicketPricesTable
   dotnet ef migrations add 20241127002424_UpdateTicketForMultipleSeatsAndPriceRefactor

2. Após adicionar todas as migrations, aplique-as ao banco de dados com o comando:
   ```bash
   dotnet ef database update

# Rodando a Aplicação

1. Navegue até o diretório onde a API está localizada:
   ```bash
   cd api_cinema/CinemaService/Consumers/API

2. Execute o seguinte comando para iniciar a aplicação:
   ```bash
   dotnet run

3. Após rodar o comando, abra o navegador e acesse o Swagger para testar os endpoints da API:
   ```bash
   http://localhost:5035/swagger/index.html

# Rodando os Testes

1. Navegue até o diretório de testes do projeto:
   ```bash
   cd api_cinema/ApplicationTest

2. Execute os testes automatizados com o comando:
   ```bash
   dotnet test


Link da documentação e diagramas:
https://docs.google.com/document/d/1-zI7PFKvxIaQ973MHDikGujv2Q4kJOmvPlvjtfvRVo4/edit?tab=t.0#heading=h.jhyfgp1vwr0
