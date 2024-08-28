# API de Filmes

Uma API RESTful para gerenciar filmes, desenvolvida com .NET e ASP.NET Core. Esta API permite realizar operações CRUD (Criar, Ler, Atualizar e Excluir) em filmes.

## Endpoints

### 1. Adicionar um Filme

- **Endpoint:** `POST /filmes`
- **Descrição:** Adiciona um novo filme ao banco de dados.
- **Parâmetros:** 
  - `filmeDto` (Objeto JSON) - Dados necessários para criação do filme.
- **Resposta:** 
  - `201 Created` - Caso a inserção seja bem-sucedida.
  - `400 Bad Request` - Caso haja um erro na solicitação.
- **Exemplo de Requisição:**
  ```json
  {
    "titulo": "Inception",
    "ano": 2010,
    "genero": "Sci-Fi"
  }

### 2. Obter Todos os Filmes

**Endpoint:** `GET /filmes`

**Descrição:** Obtém uma lista de filmes.

### Parâmetros

- **skip** (opcional) - Número de registros a serem pulados (padrão: 0).
- **take** (opcional) - Número de registros a serem retornados (padrão: 50).

### Resposta

- **200 OK** - Lista de filmes.

### 3. Obter um Filme por ID

**Endpoint:** `GET /filmes/{id}`

**Descrição:** Obtém um filme específico pelo ID.

### Parâmetros

- **id** (int) - ID do filme.

### Resposta

- **200 OK** - Dados do filme.
- **404 Not Found** - Caso o filme não seja encontrado.

### Exemplo de Requisição

```http
GET /filmes/1


### Exemplo de Requisição

```http
GET /filmes?skip=0&take=10

