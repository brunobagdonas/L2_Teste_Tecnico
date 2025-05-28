# 📦 L2 - Teste Técnico

Projeto de API para otimização de empacotamento de pedidos em caixas, desenvolvido com **.NET 8**, **Dapper** e **SQL Server**, com suporte a **Docker**.

---

## 🔧 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 🚀 Executando com Docker

### 1. Clone o projeto

```bash
git clone https://github.com/brunobagdonas/L2_Teste_Tecnico.git
cd seu-repositorio
```

### 2. Suba os containers

```bash
docker-compose up --build
```

Esse comando irá:

- Buildar a API com base no `Dockerfile`
- Subir um container SQL Server 2022
- Conectar os dois serviços via rede Docker

### 3. Acesse

- **API**: [http://localhost:8080](http://localhost:8080)  
- **Banco de Dados**: `localhost:1433`  
  - **Usuário**: `sa`  
  - **Senha**: `YourStrong!Passw0rd`

---

## 🗂 Estrutura do Projeto

```
L2_Teste_Tecnico/
├── Controllers/
├── Models/
├── DTOs/
├── Repositories/
├── Services/
├── Program.cs
├── appsettings.json
└── Dockerfile
```

---

## 🔌 Conexão com o Banco

A string de conexão está definida no `appsettings.json` e no `docker-compose.yml`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=sqlserver;Database=PackingDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
}
```

---

## 🧪 Testando a API

Você pode testar os endpoints via Swagger  ou usando ferramentas como:

- [Postman](https://www.postman.com/)
- [Insomnia](https://insomnia.rest/)

---

## 📄 Licença

Este projeto é apenas para fins educacionais e técnicos.

## DETALHES IMPORTANTES

Passei tudo para inglês as nomenclaturas de variaveis e de banco. Então utiizar o seguinte JSO 

```json
{
  "orders": [
    {
      "orderId": 1,
      "products": [
        {
          "productId": "PS5",
          "dimensions": { "height": 40, "width": 10, "length": 25 }
        },
        {
          "productId": "Volante",
          "dimensions": { "height": 40, "width": 30, "length": 30 }
        }
      ]
    },
    {
      "orderId": 2,
      "products": [
        {
          "productId": "Joystick",
          "dimensions": { "height": 15, "width": 20, "length": 10 }
        },
        {
          "productId": "Fifa 24",
          "dimensions": { "height": 10, "width": 30, "length": 10 }
        },
        {
          "productId": "Call of Duty",
          "dimensions": { "height": 30, "width": 15, "length": 10 }
        }
      ]
    },
    {
      "orderId": 3,
      "products": [
        {
          "productId": "Headset",
          "dimensions": { "height": 25, "width": 15, "length": 20 }
        }
      ]
    },
    {
      "orderId": 4,
      "products": [
        {
          "productId": "Mouse Gamer",
          "dimensions": { "height": 5, "width": 8, "length": 12 }
        },
        {
          "productId": "Teclado Mecânico",
          "dimensions": { "height": 4, "width": 45, "length": 15 }
        }
      ]
    },
    {
      "orderId": 5,
      "products": [
        {
          "productId": "Cadeira Gamer",
          "dimensions": { "height": 120, "width": 60, "length": 70 }
        }
      ]
    },
    {
      "orderId": 6,
      "products": [
        {
          "productId": "Webcam",
          "dimensions": { "height": 7, "width": 10, "length": 5 }
        },
        {
          "productId": "Microphone",
          "dimensions": { "height": 25, "width": 10, "length": 10 }
        },
        {
          "productId": "Monitor",
          "dimensions": { "height": 50, "width": 60, "length": 20 }
        },
        {
          "productId": "Notebook",
          "dimensions": { "height": 2, "width": 35, "length": 25 }
        }
      ]
    },
    {
      "orderId": 7,
      "products": [
        {
          "productId": "Jogo de Cabos",
          "dimensions": { "height": 5, "width": 15, "length": 10 }
        }
      ]
    },
    {
      "orderId": 8,
      "products": [
        {
          "productId": "Controle Xbox",
          "dimensions": { "height": 10, "width": 15, "length": 10 }
        },
        {
          "productId": "Carregador",
          "dimensions": { "height": 3, "width": 8, "length": 8 }
        }
      ]
    },
    {
      "orderId": 9,
      "products": [
        {
          "productId": "Tablet",
          "dimensions": { "height": 1, "width": 25, "length": 17 }
        }
      ]
    },
    {
      "orderId": 10,
      "products": [
        {
          "productId": "HD Externo",
          "dimensions": { "height": 2, "width": 8, "length": 12 }
        },
        {
          "productId": "Pendrive",
          "dimensions": { "height": 1, "width": 2, "length": 5 }
        }
      ]
    }
  ]
}

```