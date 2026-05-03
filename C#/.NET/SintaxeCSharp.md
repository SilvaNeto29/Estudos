# C# / .NET - Sintaxe objetiva

## 1. `using System`

- `using System;` traz classes como `Console`, `Math`, `String`, `DateTime`, `TimeSpan`, `System.IO`, `System.Net`, `System.Collections`, etc.

## 2. Console

- `Console.Write("texto")` → escreve sem pular linha.
- `Console.WriteLine("texto")` → escreve e pula linha.
- `Console.Read()` → lê um só caractere (retorna `int` com código Unicode).
- `Console.ReadLine()` → lê uma linha inteira (retorna `string`).

```csharp
Console.Write("sem quebra");
Console.Write(" continua");
Console.WriteLine(" com quebra");
string entrada = Console.ReadLine();
int codigo = Console.Read();
```

## 3. Variáveis e constantes

- Declaração de variável:

```csharp
int num1 = 10;
string nome = "João";
```

- Constante:

```csharp
const int IDADE = 0;
```

## 4. Strings

- Concatenação:

```csharp
Console.WriteLine("String " + nome + " E idade = " + num1);
```

- `String.Format`:

```csharp
Console.WriteLine(string.Format("String {0} E idade = {1}", nome, num1));
```

- Interpolação (recomendado):

```csharp
Console.WriteLine($"String {nome} E idade = {num1}");
```

## 5. Tipos de valor (Value Types)

```csharp
bool ativo = true;
byte valorByte = 255;
sbyte valorSbyte = -128;
short valorShort = 32767;
ushort valorUshort = 65535;
int valorInt = 2147483647;
uint valorUint = 4294967295;
long valorLong = 9223372036854775807;
ulong valorUlong = 18446744073709551615;
float valorFloat = 3.14f;
double valorDouble = 3.14159265;
decimal valorDecimal = 99.99m;
char caractere = 'A';
```

## 6. Tipos de referência (Reference Types)

```csharp
string texto = "Olá";
object obj = 42;
```

- `object` é o tipo base de todos os outros.

## 7. Nullable

```csharp
int? idade = null;
```

- Usado quando um tipo de valor precisa aceitar `null`.

## 8. Alias de tipos

- `int` é alias para `System.Int32`.
- `string` é alias para `System.String`.

## 9. Conversão de tipos

- Conversão implícita:

```csharp
int num2 = 100;
long num3 = num2;
float valor = 25.8f;
double valor2 = valor;
```

- Conversão explícita:

```csharp
double valor3 = 9.99;
float valor4 = (float)valor3;
```

- Converter string para número e número para string:

```csharp
int inteiro = int.Parse("123");
string text2 = Convert.ToString(inteiro);
```

## 10. Condicionais

```csharp
if (num1 > 5)
    Console.WriteLine("num1 é maior que 5");
else
    Console.WriteLine("num1 é 5 ou menor");

switch (nome)
{
    case "João":
        Console.WriteLine("Nome é João");
        break;
    default:
        Console.WriteLine("Nome diferente");
        break;
}
```

## 11. Laços

- `for`:

```csharp
for (int i = 0; i < 3; i++)
    Console.WriteLine($"for: {i}");
```

- `while`:

```csharp
int j = 0;
while (j < 3)
{
    Console.WriteLine($"while: {j}");
    j++;
}
```

- `do while`:

```csharp
int k = 0;
do
{
    Console.WriteLine($"do while: {k}");
    k++;
} while (k < 3);
```

- `foreach`:

```csharp
string[] nomes = { "Ana", "Bruno", "Carla" };
foreach (string item in nomes)
    Console.WriteLine($"foreach: {item}");
```

## 12. Coleções simples

```csharp
var lista = new System.Collections.Generic.List<int> { 1, 2, 3 };
var mapa = new System.Collections.Generic.Dictionary<string, int> { ["um"] = 1, ["dois"] = 2 };
Console.WriteLine(lista.Count);
Console.WriteLine(mapa["um"]);
```

## 13. Método simples

```csharp
static int Soma(int a, int b) => a + b;
Console.WriteLine(Soma(2, 3));
```

## 14. Try / Catch

```csharp
try
{
    int x = int.Parse("abc");
}
catch (FormatException)
{
    Console.WriteLine("Erro de formato");
}
```

## 15. Expressão lambda

```csharp
Func<int, int> dobro = n => n * 2;
Console.WriteLine(dobro(5));
```

## 16. Snippets VS Code

- `Ctrl+Shift+P` > `Preferences: Configure User Snippets` > C#
- Adicione no `csharp.json`:

```json
{
  "Console WriteLine": {
    "prefix": "cw",
    "body": ["Console.WriteLine(\"${1}\");"],
    "description": "Escreve Console.WriteLine com interpolação"
  },
  "Console Write": {
    "prefix": "cwr",
    "body": ["Console.Write(\"${1}\");"],
    "description": "Escreve Console.Write com interpolação"
  },
  "Console ReadLine": {
    "prefix": "cr",
    "body": ["string ${1} = Console.ReadLine();"],
    "description": "Lê uma linha de entrada"
  }
}
```

- Uso:
  - `cw` + `Tab`
  - `cwr` + `Tab`
  - `cr` + `Tab`
