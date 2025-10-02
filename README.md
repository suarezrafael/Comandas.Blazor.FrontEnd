# Comandas.Blazor.FrontEnd
FrontEnd de modelo das comandas.api blazor server

## 🍽️ Sistema de Comandas - Restaurant Management System

Este é um sistema completo de gerenciamento de comandas de restaurante desenvolvido em Blazor Server (.NET 9).

## 📋 Características

- **Autenticação JWT**: Sistema de login com token Bearer
- **Design Customizado**: Interface com tema de restaurante (cores terrosas e âmbar)
- **Gerenciamento Completo**:
  - 📋 **Cardápio**: Cadastro de itens do menu com preços e descrições
  - 🪑 **Mesas**: Controle de mesas disponíveis e ocupadas
  - 👥 **Usuários**: Gerenciamento de usuários do sistema
  - 📝 **Comandas**: Abertura e gestão de comandas com itens do cardápio
  - 🍳 **Pedidos**: Gerenciamento de pedidos na cozinha com status

## 🚀 Como Executar

### Pré-requisitos
- .NET 9 SDK
- API backend rodando em `http://localhost:5163/`

### Executar a aplicação

```bash
dotnet run
```

A aplicação estará disponível em:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001 (se configurado)

## 🔐 Login

A tela de login é a página inicial. Use as credenciais configuradas na API backend para acessar o sistema.

## 📱 Funcionalidades por Módulo

### Cardápio
- Listar todos os itens do cardápio
- Adicionar novo item (título, descrição, preço, possui preparo)
- Editar item existente
- Excluir item

### Mesas
- Listar todas as mesas
- Adicionar nova mesa (número, situação)
- Editar mesa existente
- Excluir mesa

### Usuários
- Listar todos os usuários
- Adicionar novo usuário (nome, email, senha)
- Editar usuário existente
- Excluir usuário

### Comandas
- Listar todas as comandas
- Abrir nova comanda (mesa, cliente, itens do cardápio)
- Editar comanda (adicionar/remover itens)
- Fechar comanda (PATCH)
- Excluir comanda

### Pedidos da Cozinha
- Listar pedidos com filtro por situação
- Atualizar status dos pedidos (Em Preparo, Pronto, Entregue)
- Visualização por mesa e cliente

## 🎨 Design

O sistema utiliza um tema customizado com cores de restaurante:
- **Primária**: Marrom terracota (#D4691E)
- **Secundária**: Marrom madeira (#8B4513)
- **Accent**: Âmbar dourado (#FFB84D)
- **Background**: Creme claro (#FFF8E1)

## 🔧 Configuração da API

Para alterar o endpoint da API, edite o arquivo `Program.cs`:

```csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5163/") });
```

## 📦 Estrutura do Projeto

```
ComandasBlazor/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   └── Pages/
│       ├── Login.razor
│       ├── Menu.razor
│       ├── Cardapio/
│       ├── Mesas/
│       ├── Usuarios/
│       ├── Comandas/
│       └── Pedidos/
├── Models/
│   ├── CardapioItem.cs
│   ├── Mesa.cs
│   ├── Usuario.cs
│   ├── Comanda.cs
│   └── PedidoCozinha.cs
├── Services/
│   ├── AuthService.cs
│   └── ApiService.cs
└── wwwroot/
    └── app.css
```

## 📝 Licença

Este projeto é um sistema de exemplo para demonstração de Blazor Server com integração de API REST
