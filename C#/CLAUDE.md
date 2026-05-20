# Manual do Livro de Bolso C#

Este manual define como escrever e manter os arquivos de estudo de C# neste repositório.

## Estrutura de cada seção

```markdown
# N - Nome do tópico

- Definição concisa em bullet points
- Explicação direta sem introduções

## Subtópico (quando necessário)

- Mais detalhes sobre um aspecto específico

```csharp
// Código funcional e completo
public class Exemplo
{
    // Implementação
}
```

- Bullet points explicando o código quando necessário
```

## Estilo de escrita

- **Direto ao ponto**: sem introduções como "Nesta seção vamos ver..."
- **Código funcional**: exemplos que podem ser executados
- **Sem comentários óbvios**: comentários inline apenas para explicações importantes
- **Bullet points**: preferir bullets sobre parágrafos longos
- **Sem emojis**: exceto em seções de boas práticas (✅ ❌)

## Seções simples vs complexas

**Simples** (tópicos pequenos como sealed, partial):
- Título
- 1-2 bullets
- 1 bloco de código curto

**Complexas** (tópicos grandes como interfaces, generics):
- Título
- Subtítulos com `##`
- Múltiplos blocos de código
- Tabela comparativa quando relevante
- Seção de boas práticas com ✅ ❌

## Padrão de nomenclatura

- Títulos numerados: `# 1 -`, `# 2 -`, etc.
- Subtítulos: `## O que são X?`, `## Sintaxe`, `## Exemplo`
- Código: sempre com ` ```csharp `
- Tabelas: usar pipes `|` com alinhamento

## Boas práticas (seção opcional)

Usar apenas em tópicos complexos:

```markdown
## Boas Práticas

✅ Faça isso
❌ Não faça aquilo
```

## O que NÃO fazer

- Não repetir informações já ditos
- Não usar linguagem formal/didática demais
- Não explicar o óbvio
- Não criar seções de "Conclusão"
- Não adicionar exercícios ou quizzes
