# CS50 — Semana 4: Memória

## 1. Hexadecimal

O sistema hexadecimal usa base 16: dígitos de `0` a `9` e letras de `A` a `F`.

| Decimal | Hexadecimal | Binário  |
|---------|-------------|----------|
| 0       | 0x00        | 00000000 |
| 10      | 0x0A        | 00001010 |
| 15      | 0x0F        | 00001111 |
| 255     | 0xFF        | 11111111 |

**Por que 255 é o máximo de uma cor RGB?**  
Um byte tem 8 bits → pode representar 2⁸ = 256 valores (0 a 255).  
Em hex, 1 byte = 2 dígitos hexadecimais → `0xFF` = 255.  
Por isso cores como `#FF0000` (vermelho puro) usam exatamente 2 hex por canal.

**Prefixo `0x`**: por convenção, valores hex são escritos com `0x` na frente para não confundir com decimal. Ex: `0x1A`, `0xFF`.

---

## 2. Memória e Endereços

A memória RAM do computador é como uma sequência gigante de bytes, cada um com um **endereço único**.

```
Endereço   Valor (byte)
0x100      42
0x101      0
0x102      17
0x103      255
```

Quando você declara uma variável em C, o compilador reserva espaço na memória e associa um endereço a ela.

```c
int n = 50;
// 'n' ocupa 4 bytes na memória, ex: endereços 0x100 a 0x103
```

---

## 3. Ponteiros

Um **ponteiro** é uma variável que armazena um **endereço de memória**.

### Operadores essenciais

| Operador | Nome           | O que faz                                    |
|----------|----------------|----------------------------------------------|
| `&`      | "endereço de"  | Retorna o endereço de memória de uma variável |
| `*`      | "valor em"     | Acessa o valor no endereço guardado pelo ponteiro |

```c
#include <stdio.h>

int main(void)
{
    int n = 50;
    int *p = &n;     // p guarda o endereço de n

    printf("%i\n", n);   // imprime: 50
    printf("%p\n", p);   // imprime: 0x... (endereço de n)
    printf("%i\n", *p);  // imprime: 50  (valor NO endereço)

    *p = 100;            // muda o valor de n via ponteiro
    printf("%i\n", n);   // imprime: 100
}
```

### Declaração de ponteiro

```c
int *p;       // ponteiro para int
char *s;      // ponteiro para char
float *f;     // ponteiro para float
```

O tipo antes do `*` diz **como interpretar** os bytes no endereço apontado.

### Ponteiro nulo

```c
int *p = NULL;   // ponteiro que não aponta para nada
// Nunca desreferencie um ponteiro NULL — causa segmentation fault
if (p != NULL) { printf("%i\n", *p); }
```

---

## 4. Strings como Ponteiros

Em C, uma **string** é apenas um ponteiro para o primeiro caractere. Não existe tipo `string` — existe `char *`.

```c
char *s = "HI!";
// Na memória:
// s → 0x100
// 0x100: 'H'
// 0x101: 'I'
// 0x102: '!'
// 0x103: '\0'  ← terminador nulo obrigatório
```

O caractere `'\0'` (null terminator, valor 0) marca o fim da string. Funções como `printf` e `strlen` dependem dele para saber onde a string termina.

### Comparação de strings

```c
// ERRADO — compara endereços, não conteúdo:
if (s1 == s2) { ... }

// CERTO — usa strcmp:
#include <string.h>
if (strcmp(s1, s2) == 0) { ... }
```

### Cópia de strings

```c
// ERRADO — só copia o ponteiro (ambos apontam para o mesmo lugar):
char *t = s;

// CERTO — copia o conteúdo:
char *t = malloc(strlen(s) + 1);  // +1 para o '\0'
strcpy(t, s);
```

---

## 5. Aritmética de Ponteiros

Ponteiros podem ser incrementados. Incrementar um `int*` avança 4 bytes; um `char*` avança 1 byte.

```c
int nums[] = {10, 20, 30};
int *p = nums;   // aponta para nums[0]

printf("%i\n", *p);       // 10
printf("%i\n", *(p + 1)); // 20
printf("%i\n", *(p + 2)); // 30

// Equivalentemente:
printf("%i\n", nums[0]);  // 10
printf("%i\n", nums[1]);  // 20
// nums[i] é sintaxe sugar para *(nums + i)
```

---

## 6. Arrays e Ponteiros

Um array **é** um ponteiro para seu primeiro elemento.

```c
int arr[3] = {1, 2, 3};
int *p = arr;   // válido — arr decai para &arr[0]

// As três formas são equivalentes:
arr[1]     == *(arr + 1) == *(p + 1)
```

**Diferença importante**: `arr` é um ponteiro constante (não pode ser reatribuído), enquanto `p` pode ser movido.

---

## 7. Memória Dinâmica: malloc e free

O **heap** é a região da memória usada para alocação dinâmica — memória solicitada em tempo de execução, de tamanho desconhecido em compile-time.

```c
#include <stdlib.h>

// Aloca espaço para 3 ints (3 * 4 = 12 bytes)
int *arr = malloc(3 * sizeof(int));

if (arr == NULL) { return 1; }  // sempre checar falha de alocação

arr[0] = 10;
arr[1] = 20;
arr[2] = 30;

free(arr);   // libera a memória — OBRIGATÓRIO
arr = NULL;  // boa prática: evita dangling pointer
```

### calloc — aloca e zera

```c
// calloc(quantidade, tamanho) — inicializa tudo com 0
int *arr = calloc(3, sizeof(int));  // {0, 0, 0}
```

### realloc — redimensiona

```c
int *arr = malloc(3 * sizeof(int));
arr = realloc(arr, 6 * sizeof(int));  // expande para 6 ints
// Os primeiros 3 elementos são preservados
```

---

## 8. Layout da Memória de um Processo

```
┌─────────────────────┐  ← endereço alto
│       STACK         │  ← variáveis locais, parâmetros de função
│         ↓           │
│                     │
│         ↑           │
│        HEAP         │  ← malloc/calloc/realloc
├─────────────────────┤
│    Dados globais    │  ← variáveis globais e estáticas
├─────────────────────┤
│    Código (text)    │  ← instruções do programa
└─────────────────────┘  ← endereço baixo (0x0)
```

- **Stack**: gerenciada automaticamente, cresce para baixo. Rápida mas limitada.
- **Heap**: gerenciada manualmente com `malloc`/`free`. Flexível mas risco de bugs.
- **Stack overflow**: quando a stack cresce demais (ex: recursão infinita).

---

## 9. Bugs de Memória

### 9.1 Memory Leak — vazamento de memória
Alocar memória e nunca liberar. O programa fica consumindo RAM progressivamente.

```c
// BUG: never free
for (int i = 0; i < 1000; i++)
{
    int *p = malloc(sizeof(int));
    // esqueceu o free(p)!
}
```

### 9.2 Buffer Overflow — escrita além dos limites

```c
char buffer[5];
strcpy(buffer, "Hello, World!");  // escreve 14 bytes em 5 → corrompe memória
```

### 9.3 Use After Free — usar memória liberada

```c
int *p = malloc(sizeof(int));
free(p);
*p = 42;   // comportamento indefinido — memória já foi liberada
```

### 9.4 Double Free — liberar duas vezes

```c
int *p = malloc(sizeof(int));
free(p);
free(p);   // comportamento indefinido — pode corromper o heap
```

### 9.5 Dangling Pointer — ponteiro "solto"

```c
int *p = malloc(sizeof(int));
free(p);
// p ainda contém o endereço antigo, mas a memória não é mais sua
// Boa prática: p = NULL logo após o free
```

---

## 10. Valgrind

Ferramenta de linha de comando que detecta vazamentos e erros de memória em C/C++.

```bash
valgrind --leak-check=full ./programa
```

Saída típica de vazamento:
```
LEAK SUMMARY:
   definitely lost: 40 bytes in 1 blocks
```

---

## 11. Arquivo: I/O com Ponteiros de Arquivo

Arquivos em C são acessados através de `FILE *`.

```c
#include <stdio.h>

int main(void)
{
    // Abre para escrita ("w"), leitura ("r") ou append ("a")
    FILE *f = fopen("dados.txt", "w");
    if (f == NULL) { return 1; }

    fprintf(f, "Nome: %s\n", "Alice");
    fprintf(f, "Idade: %i\n", 30);

    fclose(f);  // SEMPRE fechar o arquivo

    // Leitura
    FILE *r = fopen("dados.txt", "r");
    char linha[100];
    while (fgets(linha, sizeof(linha), r) != NULL)
    {
        printf("%s", linha);
    }
    fclose(r);
}
```

### Leitura/escrita binária

```c
// fread(destino, tamanho_item, qtd_itens, arquivo)
// fwrite(origem, tamanho_item, qtd_itens, arquivo)

int nums[3] = {1, 2, 3};
FILE *f = fopen("bin.dat", "wb");
fwrite(nums, sizeof(int), 3, f);
fclose(f);
```

---

## 12. Imagens BMP (bônus da aula)

Arquivos de imagem têm um **cabeçalho** (header) com metadados seguido dos pixels.  
BMP armazena pixels como bytes de cor (BGR, não RGB!), linha por linha.

```c
// Estrutura simplificada de um pixel BMP:
typedef struct {
    uint8_t blue;
    uint8_t green;
    uint8_t red;
} RGBTRIPLE;
```

O CS50 usa isso nos problemas de filtros de imagem: ler cada pixel, aplicar transformação (escala de cinza, blur, etc.) e salvar.

---

## Resumo Rápido

| Conceito          | C                              | Equivalente C#                     |
|-------------------|--------------------------------|------------------------------------|
| Endereço de `n`   | `&n`                           | `ref n` / `unsafe: &n`             |
| Ponteiro          | `int *p`                       | `ref int` / `unsafe: int*`         |
| Desreferenciar    | `*p`                           | `*p` (unsafe) / valor de ref       |
| Alloc dinâmica    | `malloc` / `free`              | `new` / GC automático              |
| String            | `char *` (null-terminated)     | `string` (objeto gerenciado)       |
| Array             | ponteiro para 1º elemento      | objeto com `.Length`               |
| File I/O          | `FILE *`, `fopen`/`fclose`     | `FileStream`, `StreamReader`       |
| Checar memória    | Valgrind                       | dotMemory, BenchmarkDotNet         |
