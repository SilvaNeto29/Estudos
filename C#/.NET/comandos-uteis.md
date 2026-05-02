# Comandos CLI do .NET mais úteis

## Criar projetos

```bash
dotnet new webapi -n MeuProjeto          # API com controllers
dotnet new web -n MeuProjeto             # Minimal API (mais enxuta)
dotnet new worker -n MeuWorker           # Worker Service
dotnet new console -n MinhaFerramenta   # Console app
dotnet new classlib -n MinhaLib         # Class library
dotnet new xunit -n MeusTestes          # Projeto de testes
dotnet new sln -n MinhaSolucao          # Solution file
```

## Gerenciar a solution

```bash
dotnet sln add Projetos/MeuProjeto      # adiciona projeto à solution
dotnet sln list                          # lista projetos na solution
```

## Dependências

```bash
dotnet add package Npgsql               # instala pacote NuGet
dotnet remove package Npgsql            # remove pacote
dotnet list package                     # lista pacotes instalados
dotnet restore                          # restaura dependências
```

## Referências entre projetos

```bash
dotnet add reference ../MinhaLib        # referencia outro projeto local
```

## Build e execução

```bash
dotnet run                              # compila e executa
dotnet run --project src/MeuProjeto    # especifica o projeto
dotnet watch run                        # hot reload (salva = recarrega)
dotnet build                            # só compila, sem executar
```

## Testes

```bash
dotnet test                             # roda todos os testes
dotnet test --filter NomeDoTeste       # roda teste específico
dotnet test -v normal                  # verbose, mostra detalhes
```

## Publicar e deploy

```bash
dotnet publish -c Release                              # publica em modo release
dotnet publish -c Release -r linux-x64 --self-contained  # binário que não precisa do runtime na VPS
```

## Informações e diagnóstico

```bash
dotnet --version                        # versão do SDK instalada
dotnet --list-sdks                      # SDKs disponíveis
dotnet --list-runtimes                  # runtimes disponíveis
dotnet new list                         # todos os templates disponíveis
```

## Ordem de uso no dia a dia

1. `dotnet new` — cria o projeto
2. `dotnet add package` — instala dependências
3. `dotnet watch run` — desenvolvimento com hot reload
4. `dotnet test` — valida antes de subir
5. `dotnet publish -c Release` — gera o artefato pra VPS
