# Estruturas de Dados

É como guardamos dados na memória do computador. Arrays são as estruturas mais simples — um bloco contíguo de memória com elementos do mesmo tipo. A partir deles, chegamos a estruturas mais complexas como listas ligadas, filas, pilhas, árvores e grafos.

## Struct

Uma `struct` permite agrupar múltiplos tipos de dados sob um único nome, funcionando como um molde para criar registros compostos. Em C, isso seria escrito assim:

```c
typedef struct
{
    string name;
    string phone;
} Person;

Person people[3];

people[0].name  = "Alice";
people[0].phone = "+55 21 99999-0000";

people[1].name  = "Bob";
people[1].phone = "+55 21 98888-1111";
```

Cada elemento do array `people` é uma `Person` completa, com seus próprios campos `.name` e `.phone`. Essa é uma forma de **encapsulamento**: os dados relacionados ficam juntos, em vez de espalhados em arrays separados (`names[0]`, `phones[0]`...). Isso torna o código mais legível e menos propenso a erros de indexação.

---

# Complexidade de Algoritmos

Os endereços de memória são opacos para quem escreve o código — você não sabe de antemão onde um valor está armazenado. Por isso, algoritmos de busca e ordenação são necessários, e entender **o quanto de tempo eles consomem** é essencial para escrever código eficiente.

## Metáfora dos Cofres

Imagine uma fileira de cofres numerados, cada um contendo (ou não) um prêmio. Você precisa encontrar o cofre com 50 reais dentro. Como você faz essa busca?

---

## Busca Linear

Você vai de cofre em cofre, da esquerda para a direita, abrindo um de cada vez até encontrar (ou esgotar todos).

**Pseudocódigo:**

```
for i = 0 to n - 1
    if 50 is behind doors[i]
        return true
return false
```

**Comportamento:**
- No **melhor caso**: o valor está no primeiro cofre → 1 operação.
- No **pior caso**: o valor está no último cofre (ou não existe) → *n* operações.

**Notação Big O:**
- Limite superior (pior caso): **O(n)** — cresce linearmente com o tamanho da entrada.
- Limite inferior (melhor caso): **Ω(1)** — símbolo ômega, representa o caso ótimo.

> A busca linear ganha da busca binária quando a lista **não está ordenada**, porque ordenar a lista para depois fazer busca binária pode custar mais do que simplesmente varrer tudo uma vez.

---

## Busca Binária

Só funciona em listas **já ordenadas**. Em vez de começar pelo início, você vai direto ao **meio** da lista e compara:

- Se o valor do meio é o que você quer → achou.
- Se o valor buscado é **menor** → descarta a metade direita e repete no meio da metade esquerda.
- Se o valor buscado é **maior** → descarta a metade esquerda e repete no meio da metade direita.

**Pseudocódigo:**

```
if no doors left
    return false
else if 50 is behind doors[middle]
    return true
else if 50 < doors[middle]
    search doors[0] through doors[middle - 1]
else if 50 > doors[middle]
    search doors[middle + 1] through doors[n - 1]
```

**Exemplo prático** (lista com 8 elementos, buscando o 7):

```
[1, 3, 5, 7, 9, 11, 13, 15]
         ^--- meio = 7? Não. 7 < 9, vai pra esquerda.
[1, 3, 5, 7]
      ^--- meio = 5? Não. 7 > 5, vai pra direita.
[7]
 ^--- meio = 7? Sim. Encontrado em 3 passos!
```

Uma busca linear teria levado 4 passos. Com 1 bilhão de elementos, a busca binária leva no máximo ~30 passos.

**Notação Big O:**
- Limite superior (pior caso): **O(log n)** — a cada passo, o problema é dividido pela metade.
- Limite inferior (melhor caso): **Ω(1)** — se o elemento está exatamente no meio.

---

## Big O Notation

É a linguagem padrão para descrever a **eficiência de um algoritmo** em termos de **ordem de grandeza**, ignorando constantes e fatores de baixa relevância.

| Notação     | Nome         | Exemplo                              |
|-------------|--------------|--------------------------------------|
| O(1)        | Constante    | Acessar `array[0]`                   |
| O(log n)    | Logarítmica  | Busca binária                        |
| O(n)        | Linear       | Busca linear                         |
| O(n log n)  | Linearítmica | Merge Sort                           |
| O(n²)       | Quadrática   | Selection Sort, Bubble Sort          |

Quanto menor a notação, mais eficiente o algoritmo para entradas grandes.

- **O(...)** → limite superior, descreve o **pior caso**.
- **Ω(...)** → limite inferior (ômega), descreve o **melhor caso**.
- **Θ(...)** → theta, quando pior e melhor caso são iguais (ex: sempre percorre tudo).

---

# Algoritmos de Ordenação

Antes de poder fazer busca binária, os dados precisam estar ordenados. Os algoritmos abaixo são formas de chegar lá — com custos diferentes.

---

## Selection Sort (Ordenação por Seleção)

A ideia é simples: **encontre o menor elemento** do array e coloque-o na primeira posição. Depois encontre o menor dos restantes e coloque na segunda. Repita até o fim.

**Exemplo:**

```
[5, 2, 8, 1, 4]
 ^menor = 1 → troca com posição 0
[1, 2, 8, 5, 4]
    ^menor dos restantes = 2 → já está no lugar
[1, 2, 8, 5, 4]
       ^menor dos restantes = 4 → troca com posição 2
[1, 2, 4, 5, 8]
          ^menor = 5 → já está no lugar
[1, 2, 4, 5, 8] ✓
```

**Custo:**
- Primeira passagem: *n - 1* comparações
- Segunda: *n - 2*
- ...
- Total: *(n-1) + (n-2) + ... + 1 = n(n-1)/2 ≈ n²/2*

**Notação Big O:**
- Pior caso: **O(n²)**
- Melhor caso: **Ω(n²)** — mesmo se o array já estiver ordenado, ele percorre tudo igualmente. Não tem como "pular" nada.

---

## Bubble Sort (Ordenação por Bolha)

A cada passagem, **compara pares adjacentes** e troca se estiverem fora de ordem. Os maiores valores "borbulham" para o final a cada rodada.

**Exemplo:**

```
[5, 2, 8, 1, 4]
 5>2? Troca → [2, 5, 8, 1, 4]
     5<8? OK  → [2, 5, 8, 1, 4]
        8>1? Troca → [2, 5, 1, 8, 4]
              8>4? Troca → [2, 5, 1, 4, 8]  ← 8 no lugar certo

Segunda passagem:
[2, 5, 1, 4, 8]
 2<5? OK
    5>1? Troca → [2, 1, 5, 4, 8]
         5>4? Troca → [2, 1, 4, 5, 8]

...continua até nenhuma troca acontecer numa passagem completa.
```

**Uma otimização importante:** se em uma passagem inteira nenhuma troca ocorrer, o array já está ordenado — pode parar.

**Notação Big O:**
- Pior caso: **O(n²)**
- Melhor caso (com a otimização de parada antecipada): **Ω(n)** — se já estiver ordenado, uma única passagem sem trocas confirma isso.

---

## Recursão

Recursão é quando uma **função chama a si mesma** para resolver uma versão menor do mesmo problema. É um padrão fundamental para algoritmos como o Merge Sort.

**Exemplo clássico — fatorial:**

```c
int factorial(int n)
{
    if (n <= 1)           // caso base: para a recursão
        return 1;
    return n * factorial(n - 1);  // chamada recursiva
}

// factorial(4)
// = 4 * factorial(3)
// = 4 * 3 * factorial(2)
// = 4 * 3 * 2 * factorial(1)
// = 4 * 3 * 2 * 1
// = 24
```

Todo algoritmo recursivo precisa de:
1. **Caso base** — condição de parada (evita loop infinito).
2. **Chamada recursiva** — resolve uma versão menor do problema.

---

## Merge Sort (Ordenação por Mesclagem)

Usa recursão para dividir o array ao meio repetidamente até ter arrays de 1 elemento (que estão, trivialmente, ordenados). Depois **mescla** os pares ordenados, dois a dois, até reconstituir o array completo — já ordenado.

**Exemplo:**

```
[5, 2, 8, 1]

Dividir:
[5, 2]      [8, 1]

Dividir de novo:
[5]  [2]    [8]  [1]

Mesclar (comparando e ordenando par a par):
[2, 5]      [1, 8]

Mesclar os dois:
Compara 2 e 1 → 1 primeiro
Compara 2 e 8 → 2 depois
Compara 5 e 8 → 5 depois
Sobra 8

[1, 2, 5, 8] ✓
```

**Notação Big O:**
- Pior caso: **O(n log n)** — log n níveis de divisão × n operações de mesclagem por nível.
- Melhor caso: **Ω(n log n)** — mesmo com dados já ordenados, ainda divide e mescla tudo.

**Comparação com os anteriores:**

| Algoritmo      | Melhor caso | Pior caso   |
|----------------|-------------|-------------|
| Selection Sort | Ω(n²)       | O(n²)       |
| Bubble Sort    | Ω(n)        | O(n²)       |
| Merge Sort     | Ω(n log n)  | O(n log n)  |

O Merge Sort é significativamente mais rápido para arrays grandes, mas tem um custo: precisa de **memória extra** para armazenar os subarrays temporários durante a mesclagem (espaço O(n)), enquanto os outros dois ordenam "in-place".
