# Guia de Uso - Sistema de Comandas

## 🚀 Iniciando o Sistema

### 1. Pré-requisitos
- Certifique-se de que a API backend está rodando em `http://localhost:5163/`
- Tenha pelo menos um usuário cadastrado na API para fazer login

### 2. Iniciando a aplicação
```bash
cd ComandasBlazor
dotnet run
```

A aplicação será iniciada em: `http://localhost:5079`

## 🔐 Fazendo Login

1. Ao abrir a aplicação, você verá a tela de login
2. Digite seu email e senha cadastrados na API
3. Clique em "Entrar"
4. Se as credenciais estiverem corretas, você será redirecionado para o Menu Principal

## 📋 Menu Principal

O Menu Principal apresenta cards com acesso rápido a todos os módulos:
- **Cardápio**: Gerenciar itens do menu
- **Mesas**: Gerenciar mesas do restaurante
- **Usuários**: Gerenciar usuários do sistema
- **Comandas**: Abrir e gerenciar comandas
- **Pedidos da Cozinha**: Gerenciar status dos pedidos

## 📖 Fluxo de Trabalho Recomendado

### 1. Configuração Inicial

#### a) Cadastrar Itens do Cardápio
1. Clique em "Cardápio" no menu
2. Clique em "➕ Novo Item"
3. Preencha:
   - Título: nome do prato/bebida
   - Descrição: detalhes do item
   - Preço: valor em reais
   - Possui Preparo: marque se o item precisa ser preparado na cozinha
4. Clique em "💾 Salvar"

#### b) Cadastrar Mesas
1. Clique em "Mesas" no menu
2. Clique em "➕ Nova Mesa"
3. Preencha:
   - Número da Mesa: identificação da mesa
   - Situação: Livre ou Ocupada
4. Clique em "💾 Salvar"

#### c) Cadastrar Usuários (se necessário)
1. Clique em "Usuários" no menu
2. Clique em "➕ Novo Usuário"
3. Preencha:
   - Nome: nome completo
   - Email: email do usuário
   - Senha: senha de acesso
4. Clique em "💾 Salvar"

### 2. Operação Diária

#### a) Abrir uma Comanda
1. Clique em "Comandas" no menu
2. Clique em "➕ Nova Comanda"
3. Preencha:
   - Número da Mesa: selecione a mesa
   - Nome do Cliente: nome do cliente
   - Marque os itens do cardápio que o cliente pediu
4. Clique em "💾 Salvar"

#### b) Gerenciar Pedidos na Cozinha
1. Clique em "Pedidos da Cozinha" no menu
2. Você verá todos os pedidos que precisam de preparo
3. Para cada pedido, você pode:
   - **🔄 Preparo**: Marcar que o pedido está sendo preparado
   - **✅ Pronto**: Marcar que o pedido está pronto para entrega
   - **🚚 Entregue**: Marcar que o pedido foi entregue ao cliente
4. Use o filtro de situação para ver apenas pedidos em um status específico

#### c) Editar uma Comanda
1. Na lista de comandas, clique em "✏️ Editar"
2. Você pode:
   - Alterar o nome do cliente
   - Adicionar ou remover itens marcando/desmarcando os checkboxes
3. Clique em "💾 Salvar"

#### d) Fechar uma Comanda
1. Na lista de comandas, clique em "🔒 Fechar"
2. Isso fechará a comanda (alterará o status)

#### e) Excluir uma Comanda
1. Na lista de comandas, clique em "🗑️ Excluir"
2. A comanda será removida do sistema

## 🎨 Navegação

### Menu Lateral
O menu lateral à esquerda permite navegação rápida entre todas as seções:
- 🏠 Menu Principal
- 📋 Cardápio
- 🪑 Mesas
- 👥 Usuários
- 📝 Comandas
- 🍳 Pedidos

### Botões de Ação
- **Voltar**: Retorna à tela anterior
- **Menu**: Retorna ao menu principal
- **Novo**: Abre o formulário para criar um novo registro
- **Editar**: Abre o formulário para editar um registro existente
- **Excluir**: Remove um registro

## 🔒 Segurança

- Todas as requisições à API são feitas com autenticação Bearer Token
- O token é obtido automaticamente no login
- Se a sessão expirar, você será redirecionado para a tela de login
- Use o botão "Sair" no menu principal para fazer logout

## 💡 Dicas

1. **Atualize regularmente a tela de Pedidos**: Clique em "🔄 Atualizar" para ver novos pedidos
2. **Use os filtros**: Na tela de Pedidos, filtre por situação para focar no que precisa de atenção
3. **Organize o cardápio**: Cadastre todos os itens antes de começar a abrir comandas
4. **Mantenha as mesas atualizadas**: Atualize o status das mesas conforme são ocupadas ou liberadas

## ❓ Problemas Comuns

### "Erro ao conectar com a API"
- Verifique se a API está rodando em `http://localhost:5163/`
- Verifique sua conexão de rede

### "Email ou senha inválidos"
- Verifique se você digitou corretamente
- Certifique-se de que o usuário está cadastrado na API

### "Nenhum item cadastrado"
- Cadastre itens primeiro antes de usá-los em comandas
- Use o botão "➕ Novo" para adicionar registros

## 🛠️ Configuração Avançada

Para alterar a URL da API, edite o arquivo `Program.cs` e modifique a linha:

```csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5163/") });
```

Substitua `http://localhost:5163/` pela URL da sua API.
