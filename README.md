
# 💊 FarmaciaSOFT API

A **FarmaciaSOFT** é uma API desenvolvida em ASP.NET Core com Entity Framework Core, organizada em camadas seguindo boas práticas de desenvolvimento.  
Seu objetivo é permitir o gerenciamento de vendas de medicamentos, aplicação de descontos para clientes, e envio de notificações por SMS com Twilio.

---

## 📌 Funcionalidades

- Cadastro de clientes e medicamentos
- Registro de vendas
- Aplicação de **10% de desconto** para clientes cadastrados
- Atualização de estoque
- Envio de confirmação de venda via **SMS (Twilio)**
- Autenticação JWT

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Twilio API (SMS)
- Visual Studio Code

---

## 📁 Estrutura em Camadas

O projeto é organizado nas seguintes camadas:

```
/FarmaciaSOFT
├── Controllers
├── Services
├── Repositories
├── Models
├── DTOs
├── Data (DbContext)
└── Program.cs / appsettings.json
```

---

## 💬 Exemplo de Funcionalidade: Venda com Desconto

Ao registrar uma venda:

- O sistema verifica se o cliente existe.
- Aplica **10% de desconto** no total da venda.
- Atualiza o estoque do medicamento vendido.
- Envia SMS de confirmação ao cliente com a API do Twilio.

---

## 🔧 Configuração do [Twilio](https://www.twilio.com/docs)

No `appsettings.json`:

```json
"Twilio": {
  "AccountSID": "SUA_ACCOUNT_SID",
  "AuthToken": "SEU_AUTH_TOKEN",
  "From": "+SEU_NUMERO_TWILIO"
}
```

## ▶️ Como Executar

1. Clone o repositório
2. Configure o banco no `appsettings.json`
3. Configure o Twilio
4. Execute com:

```bash
dotnet ef database update
dotnet run
```

---

## 🚧 Funcionalidades Futuras

- Integração com AutoMapper
- Testes unitários com xUnit e Moq
- Dashboard para vendas

---

## 👨‍💻 Autor

Desenvolvido por **Caio de Souza Nery**  
GitHub: [CaioSNery](https://github.com/CaioSNery)
