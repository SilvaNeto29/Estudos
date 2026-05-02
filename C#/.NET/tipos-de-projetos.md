# Tipos de projeto em .NET

## Aplicações web e API

- **ASP.NET Core Web API** — API REST clássica com controllers. O padrão para sistemas maiores.
- **Minimal API** — API sem controllers, tudo definido direto no `Program.cs`. Mais enxuta, ideal para microsserviços e projetos menores.
- **ASP.NET Core MVC** — web app server-side com Model-View-Controller. Renderiza HTML no servidor.
- **Razor Pages** — alternativa ao MVC, mais simples, cada página tem seu próprio arquivo de lógica.
- **Blazor** — UI interativa em C# rodando no browser via WebAssembly, ou no servidor via SignalR.
- **gRPC** — API baseada em contratos Protobuf, alta performance, comum em comunicação entre serviços internos.
- **SignalR** — comunicação em tempo real via WebSocket (chats, dashboards ao vivo).

## Workers e processamento em background

- **Worker Service** — processo de longa duração sem interface, ideal para consumir filas e processar jobs. É o que você vai usar no seu pipeline de IA.
- **Hosted Service / BackgroundService** — versão embutida do Worker, roda dentro do mesmo processo da API.

## Console e ferramentas

- **Console Application** — executável simples de linha de comando. Útil para scripts, ferramentas internas e CLIs.
- **Worker como CLI** — console app que roda uma vez e termina, diferente do Worker que fica em loop contínuo.

## Bibliotecas e pacotes

- **Class Library** — DLL reutilizável sem ponto de entrada. Você extrai lógica comum aqui para compartilhar entre projetos.
- **NuGet Package** — class library empacotada para distribuição pública ou privada.
- **Source Generator** — biblioteca especial que gera código C# em tempo de compilação.

## Desktop

- **WPF** (Windows Presentation Foundation) — apps desktop Windows com XAML, legado mas ainda muito usado em sistemas corporativos.
- **WinForms** — o mais antigo, formulários drag-and-drop, ainda vivo em sistemas legados (parecido com PowerBuilder no conceito).
- **MAUI** — multiplataforma moderno: Windows, macOS, iOS e Android com uma base de código só.

## Testes

- **xUnit / NUnit / MSTest** — projetos de teste unitário e de integração. xUnit é o padrão atual da comunidade.

## Outros

- **Azure Functions / AWS Lambda** — funções serverless em .NET, deploy sem gerenciar servidor.
- **Aspire** — orquestrador de microsserviços locais da Microsoft, relativamente novo, facilita rodar API + Worker + banco juntos em desenvolvimento.

---

## Para o seu contexto

Os que você vai usar no projeto com IA:

| Projeto                | Tipo                   |
| ---------------------- | ---------------------- |
| Recebe requisição HTTP | Minimal API ou Web API |
| Processa em background | Worker Service         |
| Lógica compartilhada   | Class Library          |
| Testes                 | xUnit                  |
