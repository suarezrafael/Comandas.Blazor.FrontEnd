# 🚀 Quick Start Guide

## Início Rápido em 3 Passos

### 1️⃣ Pré-requisitos
Antes de começar, certifique-se de que você tem:
- ✅ .NET 9 SDK instalado
- ✅ A API rodando em `http://localhost:5163/`
- ✅ Pelo menos um usuário cadastrado na API

### 2️⃣ Executar a Aplicação

```bash
# Clone o repositório (se ainda não clonou)
git clone https://github.com/suarezrafael/Comandas.Blazor.FrontEnd.git
cd Comandas.Blazor.FrontEnd

# Execute a aplicação
dotnet run
```

A aplicação será iniciada em: **http://localhost:5079**

### 3️⃣ Fazer Login

1. Abra seu navegador e acesse: http://localhost:5079
2. Digite seu email e senha (cadastrados na API)
3. Clique em "Entrar"
4. Pronto! Você está no Menu Principal 🎉

## 📋 Fluxo Básico de Uso

### Configuração Inicial (Primeira Vez)

1. **Cadastrar Itens do Cardápio**
   - Menu Principal → Cardápio → ➕ Novo Item
   - Preencha: Título, Descrição, Preço, Possui Preparo
   - Salvar

2. **Cadastrar Mesas**
   - Menu Principal → Mesas → ➕ Nova Mesa
   - Preencha: Número da Mesa, Situação
   - Salvar

### Uso Diário

1. **Abrir uma Comanda**
   - Menu Principal → Comandas → ➕ Nova Comanda
   - Selecione a mesa, nome do cliente, e itens
   - Salvar

2. **Gerenciar Pedidos na Cozinha**
   - Menu Principal → Pedidos
   - Atualize o status: 🔄 Preparo → ✅ Pronto → 🚚 Entregue

3. **Fechar uma Comanda**
   - Comandas → 🔒 Fechar na comanda desejada

## 🎨 Interface

### Cores do Tema Restaurante
- 🟤 **Marrom Terracota**: Botões e destaques
- 🟫 **Marrom Madeira**: Cabeçalhos de tabela
- 🟡 **Âmbar Dourado**: Elementos de ênfase
- ⬜ **Creme Claro**: Background

### Navegação Rápida
- **Sidebar**: Menu lateral com todos os módulos
- **Botão Menu** (🏠): Volta ao menu principal
- **Botão Voltar** (←): Volta à página anterior

## 🆘 Resolução Rápida de Problemas

| Problema | Solução |
|----------|---------|
| Erro ao conectar | Verifique se a API está rodando em http://localhost:5163/ |
| Login inválido | Verifique suas credenciais ou cadastre um usuário na API |
| Página em branco | Limpe o cache do navegador (Ctrl+Shift+Delete) |
| Erro 401 | Sua sessão expirou, faça login novamente |

## 📱 Módulos Disponíveis

| Módulo | Ícone | Função |
|--------|-------|--------|
| Cardápio | 📋 | Gerenciar itens do menu |
| Mesas | 🪑 | Gerenciar mesas do restaurante |
| Usuários | 👥 | Gerenciar usuários do sistema |
| Comandas | 📝 | Abrir e gerenciar pedidos |
| Pedidos | 🍳 | Acompanhar status na cozinha |

## 🔧 Configuração Avançada

### Alterar URL da API

Edite o arquivo `Program.cs` na linha 11:

```csharp
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5163/") 
});
```

Substitua a URL pela da sua API.

### Alterar Porta da Aplicação

Edite o arquivo `Properties/launchSettings.json`:

```json
"applicationUrl": "http://localhost:5079"
```

## 📚 Documentação Completa

Para mais detalhes, consulte:
- **README.md**: Visão geral e instruções de setup
- **USAGE.md**: Guia detalhado de uso com todas as funcionalidades

## 💡 Dicas Importantes

1. ✅ Cadastre itens do cardápio ANTES de criar comandas
2. ✅ Mantenha as mesas atualizadas conforme são ocupadas/liberadas
3. ✅ Use o filtro de situação nos Pedidos para focar no que precisa atenção
4. ✅ Clique em "🔄 Atualizar" nos Pedidos para ver novos pedidos
5. ✅ Use o botão "Sair" para fazer logout com segurança

## 🎯 Próximos Passos

Depois de configurar tudo:
1. Cadastre seu cardápio completo
2. Configure todas as mesas do restaurante
3. Adicione os usuários que vão operar o sistema
4. Comece a receber clientes e abrir comandas!

---

**Dúvidas?** Consulte o arquivo USAGE.md para instruções detalhadas.

**Problemas?** Verifique se a API está rodando e acessível.
