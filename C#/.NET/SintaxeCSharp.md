# C# / .NET - Sintaxe objetiva

## 1. `using System`

- `using System;` traz classes como `Console`, `Math`, `String`, `DateTime`, `TimeSpan`, `System.IO`, `System.Net`, `System.Collections`, etc.
- `using System.IO;` traz classes para manipulação de arquivos e diretórios como `File`, `Directory`, `Path`, `FileInfo` e `DirectoryInfo`.

## 1.1 `using System.IO` e manipulação de arquivos

```csharp
using System;
using System.IO;

string caminho = "arquivo.txt";

// Gravar texto em um arquivo (cria se não existir e substitui se existir)
File.WriteAllText(caminho, "Olá, arquivo!\n");

// Ler todo o conteúdo de um arquivo
string conteudo = File.ReadAllText(caminho);
Console.WriteLine(conteudo);

// Acrescentar texto a um arquivo existente
File.AppendAllText(caminho, "Mais uma linha.\n");

// Ler linhas do arquivo em uma coleção
string[] linhas = File.ReadAllLines(caminho);
foreach (string linha in linhas)
    Console.WriteLine(linha);

// Verificar se o arquivo existe
if (File.Exists(caminho))
{
    Console.WriteLine("Arquivo encontrado");
}

// Excluir o arquivo
File.Delete(caminho);
```

- `File.WriteAllText(path, text)` escreve todo o texto em um arquivo.
- `File.ReadAllText(path)` lê todo o conteúdo como string.
- `File.AppendAllText(path, text)` adiciona texto no final do arquivo.
- `File.ReadAllLines(path)` lê todas as linhas em um array.
- `File.Exists(path)` verifica existência do arquivo.
- `File.Delete(path)` exclui um arquivo.

### Operações com diretórios

```csharp
string pasta = "dados";
Directory.CreateDirectory(pasta);
string caminhoArquivo = Path.Combine(pasta, "dados.txt");
File.WriteAllText(caminhoArquivo, "Dados importantes");

if (Directory.Exists(pasta))
{
    Console.WriteLine("Diretório existe: " + pasta);
}

// Copiar ou mover arquivo
File.Copy(caminhoArquivo, Path.Combine(pasta, "dados_backup.txt"));
File.Move(caminhoArquivo, Path.Combine(pasta, "dados_movidos.txt"));
```

- `Directory.CreateDirectory(path)` cria diretório se não existir.
- `Directory.Exists(path)` verifica existência de diretório.
- `Path.Combine(...)` monta caminhos de forma segura.
- `File.Copy(source, destination)` copia um arquivo.
- `File.Move(source, destination)` move/renomeia um arquivo.

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

### Comparação de strings

- Comparação básica (case-sensitive):

```csharp
string str1 = "Olá";
string str2 = "olá";

if (str1 == str2)
    Console.WriteLine("Strings iguais");
else
    Console.WriteLine("Strings diferentes");
```

- Método `Equals` (case-sensitive por padrão):

```csharp
if (str1.Equals(str2))
    Console.WriteLine("Iguais");
```

- Comparação case-insensitive:

```csharp
if (str1.Equals(str2, StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("Iguais ignorando maiúsculas/minúsculas");
```

- Método `Compare` (retorna 0 se igual, <0 se str1 < str2, >0 se str1 > str2):

```csharp
int resultado = string.Compare(str1, str2);
if (resultado == 0)
    Console.WriteLine("Strings iguais");
else if (resultado < 0)
    Console.WriteLine("str1 vem antes de str2");
else
    Console.WriteLine("str1 vem depois de str2");
```

- `Compare` case-insensitive:

```csharp
int resultado = string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase);
```

- Método `CompareTo` (similar ao Compare, mas método de instância):

```csharp
int resultado = str1.CompareTo(str2);
```

### Interpolação avançada

- Formatação em interpolação:

```csharp
double preco = 19.99;
Console.WriteLine($"Preço: {preco:C}"); // Formato moeda
Console.WriteLine($"Número: {num1:D5}"); // Preenche com zeros à esquerda
Console.WriteLine($"Percentual: {0.85:P}"); // Formato porcentagem
```

- Expressões em interpolação:

```csharp
Console.WriteLine($"Soma: {2 + 3}");
Console.WriteLine($"Maiúsculo: {nome.ToUpper()}");
```

### Verificação de prefixo e sufixo

- `StartsWith` (verifica se a string começa com uma substring, case-sensitive):

```csharp
string frase = "Olá mundo";
if (frase.StartsWith("Olá"))
    Console.WriteLine("Começa com 'Olá'");
```

- `StartsWith` case-insensitive:

```csharp
if (frase.StartsWith("olá", StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("Começa com 'olá' (ignorando maiúsculas)");
```

- `EndsWith` (verifica se a string termina com uma substring, case-sensitive):

```csharp
if (frase.EndsWith("mundo"))
    Console.WriteLine("Termina com 'mundo'");
```

- `EndsWith` case-insensitive:

```csharp
if (frase.EndsWith("MUNDO", StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("Termina com 'MUNDO' (ignorando maiúsculas)");
```

### Outros métodos de string

- `IndexOf` (retorna a posição da primeira ocorrência de uma substring, -1 se não encontrar):

```csharp
string texto = "Olá mundo, olá universo";
int posicao = texto.IndexOf("olá"); // Retorna 11 (posição da segunda "olá")
Console.WriteLine($"Posição: {posicao}");
```

- `IndexOf` case-insensitive:

```csharp
int posicao = texto.IndexOf("OLÁ", StringComparison.OrdinalIgnoreCase); // Retorna 0
```

- `LastIndexOf` (retorna a posição da última ocorrência):

```csharp
int ultimaPosicao = texto.LastIndexOf("olá"); // Retorna 11
```

- `Substring` (extrai parte da string):

```csharp
string parte = texto.Substring(4, 5); // "mundo" (posição 4, 5 caracteres)
string ateFim = texto.Substring(4); // "mundo, olá universo" (da posição 4 até o fim)
```

- `Replace` (substitui ocorrências):

```csharp
string novoTexto = texto.Replace("olá", "oi"); // "Oi mundo, oi universo"
```

- `ToUpper` e `ToLower` (converte maiúsculas/minúsculas):

```csharp
string maiusculo = texto.ToUpper(); // "OLÁ MUNDO, OLÁ UNIVERSO"
string minusculo = texto.ToLower(); // "olá mundo, olá universo"
```

- `Trim` (remove espaços em branco do início e fim):

```csharp
string comEspacos = "  texto com espaços  ";
string semEspacos = comEspacos.Trim(); // "texto com espaços"
string trimInicio = comEspacos.TrimStart(); // "texto com espaços  "
string trimFim = comEspacos.TrimEnd(); // "  texto com espaços"
```

- `Split` (divide a string em array baseado em separador):

```csharp
string csv = "nome,idade,cidade";
string[] partes = csv.Split(','); // ["nome", "idade", "cidade"]
foreach (string p in partes)
    Console.WriteLine(p);
```

- `Length` (retorna o tamanho da string):

```csharp
int tamanho = texto.Length; // 23
Console.WriteLine($"Tamanho: {tamanho}");
```

- `Contains` (verifica se contém uma substring):

```csharp
if (texto.Contains("mundo"))
    Console.WriteLine("Contém 'mundo'");
```

- `IsNullOrEmpty` e `IsNullOrWhiteSpace` (verifica se é nula, vazia ou só espaços):

```csharp
string vazia = "";
if (string.IsNullOrEmpty(vazia))
    Console.WriteLine("String vazia");

string soEspacos = "   ";
if (string.IsNullOrWhiteSpace(soEspacos))
    Console.WriteLine("String só com espaços");
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

## 117. Structs

- `struct` é um tipo de valor leve, útil para representar dados pequenos e imutáveis.
- Ao contrário de classes, structs são alocados na stack quando usados como variáveis locais.

```csharp
struct Produto
{
    // Campos do struct
    public int Id;
    public float Preco;

    // Construtor obrigando inicialização
    public Produto(int id, float preco)
    {
        Id = id;
        Preco = preco;
    }

    // Método para cálculo simples
    public float PrecoEmDolar(float cotacaoDolar)
    {
        return Preco * cotacaoDolar;
    }
}

// Uso do struct
Produto p = new Produto(1, 19.90f);
Console.WriteLine(p.Id); // 1
Console.WriteLine(p.PrecoEmDolar(5.20f));
```

## 118. Enums

```csharp
enum EDiasDaSemana
{
    Domingo,
    Segunda,
    Terca,
    Quarta,
    Quinta,
    Sexta,
    Sabado
}

// Uso do enum
EDiasDaSemana hoje = DiasDaSemana.Segunda;
Console.WriteLine(hoje); // Segunda
Console.WriteLine((int)hoje); // 1
```

## 119. Trabalhando com Datas (DateTime)

- `DateTime.Now` (data e hora atual):

```csharp
DateTime agora = DateTime.Now;
Console.WriteLine(agora); // Ex: 03/05/2026 14:30:45
Console.WriteLine(agora.Date); // 03/05/2026
Console.WriteLine(agora.TimeOfDay); // 14:30:45
```

- `DateTime.Today` (somente a data de hoje):

```csharp
DateTime hoje = DateTime.Today; // 03/05/2026 00:00:00
```

- `DateTime.UtcNow` (data e hora em UTC):

```csharp
DateTime utc = DateTime.UtcNow;
Console.WriteLine(utc);
```

- Criando uma data específica:

```csharp
DateTime data = new DateTime(2026, 5, 3); // 03/05/2026 00:00:00
DateTime dataCompleta = new DateTime(2026, 5, 3, 14, 30, 45); // Com hora
Console.WriteLine(data);
```

- Acessando propriedades da data:

```csharp
DateTime agora = DateTime.Now;
Console.WriteLine($"Ano: {agora.Year}");
Console.WriteLine($"Mês: {agora.Month}");
Console.WriteLine($"Dia: {agora.Day}");
Console.WriteLine($"Dia da semana: {agora.DayOfWeek}");
Console.WriteLine($"Hora: {agora.Hour}");
Console.WriteLine($"Minuto: {agora.Minute}");
Console.WriteLine($"Segundo: {agora.Second}");
```

- Operações com datas (AddDays, AddMonths, AddYears):

```csharp
DateTime data = DateTime.Now;
DateTime amanha = data.AddDays(1);
DateTime proximoMes = data.AddMonths(1);
DateTime proximoAno = data.AddYears(1);
DateTime meiaHoraDepois = data.AddMinutes(30);

Console.WriteLine($"Hoje: {data}");
Console.WriteLine($"Amanhã: {amanha}");
Console.WriteLine($"Próximo mês: {proximoMes}");
```

- Comparação de datas:

```csharp
DateTime data1 = new DateTime(2026, 5, 1);
DateTime data2 = new DateTime(2026, 5, 3);

if (data1 < data2)
    Console.WriteLine("data1 é anterior a data2");

if (data1 == data2)
    Console.WriteLine("As datas são iguais");

if (data1 != data2)
    Console.WriteLine("As datas são diferentes");
```

- Diferença entre datas (TimeSpan):

```csharp
DateTime data1 = new DateTime(2026, 5, 1);
DateTime data2 = new DateTime(2026, 5, 3);
TimeSpan diferenca = data2 - data1;

Console.WriteLine($"Dias de diferença: {diferenca.Days}"); // 2
Console.WriteLine($"Total de horas: {diferenca.TotalHours}"); // 48
Console.WriteLine($"Total de minutos: {diferenca.TotalMinutes}"); // 2880
```

- Parsing (convertendo string para DateTime):

```csharp
string dataString = "03/05/2026";
DateTime data = DateTime.Parse(dataString);
Console.WriteLine(data);

// Com formato específico
string dataFormatada = "2026-05-03";
DateTime data2 = DateTime.ParseExact(dataFormatada, "yyyy-MM-dd", null);
Console.WriteLine(data2);
```

- Formatando datas (ToString com padrões):

```csharp
DateTime agora = DateTime.Now;

Console.WriteLine(agora.ToString()); // Formato padrão
Console.WriteLine(agora.ToString("dd/MM/yyyy")); // 03/05/2026
Console.WriteLine(agora.ToString("dd/MM/yyyy HH:mm:ss")); // 03/05/2026 14:30:45
Console.WriteLine(agora.ToString("yyyy-MM-dd")); // 2026-05-03 (ISO)
Console.WriteLine(agora.ToString("dddd, dd de MMMM de yyyy")); // Saturday, 03 de May of 2026
Console.WriteLine(agora.ToString("HH:mm:ss")); // 14:30:45
```

- `TimeSpan` (intervalo de tempo):

```csharp
TimeSpan intervalo = new TimeSpan(2, 3, 30); // 2 horas, 3 minutos, 30 segundos
Console.WriteLine(intervalo); // 02:03:30
Console.WriteLine($"Total de segundos: {intervalo.TotalSeconds}");

TimeSpan dias = TimeSpan.FromDays(5);
TimeSpan horas = TimeSpan.FromHours(12);
```

- Verificando se uma data é válida:

```csharp
bool valida = DateTime.TryParse("03/05/2026", out DateTime data);
if (valida)
    Console.WriteLine($"Data válida: {data}");
else
    Console.WriteLine("Data inválida");
```

### CultureInfo (Informações de Cultura/Localização)

- CultureInfo afeta formatação de datas, números, moedas e símbolos.

```csharp
using System.Globalization;

// Obter a cultura atual
CultureInfo culturaBR = new CultureInfo("pt-BR");
CultureInfo culturaUS = new CultureInfo("en-US");

// Formatar data em diferentes culturas
DateTime agora = DateTime.Now;
Console.WriteLine(agora.ToString(culturaBR)); // 03/05/2026 14:30:45
Console.WriteLine(agora.ToString(culturaUS)); // 5/3/2026 2:30:45 PM
```

- Formatando números em diferentes culturas:

```csharp
double valor = 1234.56;
Console.WriteLine(valor.ToString("C", culturaBR)); // R$ 1.234,56
Console.WriteLine(valor.ToString("C", culturaUS)); // $1,234.56
Console.WriteLine(valor.ToString("N", culturaBR)); // 1.234,56
Console.WriteLine(valor.ToString("N", culturaUS)); // 1,234.56
```

- Listando culturas disponíveis:

```csharp
CultureInfo[] culturas = CultureInfo.GetCultures(CultureTypes.AllCultures);
foreach (CultureInfo c in culturas.Take(5))
    Console.WriteLine($"{c.Name} - {c.DisplayName}");
```

- Definir cultura padrão da thread:

```csharp
Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

DateTime data = DateTime.Now;
Console.WriteLine(data.ToString("D")); // Sexta-feira, 3 de maio de 2026
```

### TimeZone (Fuso Horário)

- Obter informações de fuso horário:

```csharp
TimeZoneInfo fusoLocal = TimeZoneInfo.Local;
Console.WriteLine($"ID: {fusoLocal.Id}");
Console.WriteLine($"Nome: {fusoLocal.StandardName}");
Console.WriteLine($"Offset: {fusoLocal.BaseUtcOffset}");
Console.WriteLine($"Está em horário de verão: {fusoLocal.IsDaylightSavingTime(DateTime.Now)}");
```

- Convertendo entre fusos horários:

```csharp
DateTime dataLocal = DateTime.Now;
TimeZoneInfo fusoUS = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
TimeZoneInfo fusoBR = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

DateTime emUS = TimeZoneInfo.ConvertTime(dataLocal, fusoBR, fusoUS);
DateTime emBR = TimeZoneInfo.ConvertTime(dataLocal, fusoUS, fusoBR);

Console.WriteLine($"Hora local: {dataLocal}");
Console.WriteLine($"Hora em NY: {emUS}");
Console.WriteLine($"Hora em BR: {emBR}");
```

- Listando fusos horários disponíveis:

```csharp
ReadOnlyCollection<TimeZoneInfo> fusos = TimeZoneInfo.GetSystemTimeZoneIds();
foreach (string id in fusos.Take(5))
{
    TimeZoneInfo fuso = TimeZoneInfo.FindSystemTimeZoneById(id);
    Console.WriteLine($"{fuso.Id}: {fuso.StandardName}");
}
```

- Criando um TimeZoneInfo customizado:

```csharp
TimeSpan offset = new TimeSpan(3, 0, 0); // UTC+3
TimeZoneInfo customFuso = TimeZoneInfo.CreateCustomTimeZone("CustomZone", offset, "Custom Timezone", "Custom");
Console.WriteLine(customFuso.Id);
```

### TimeSpan (Intervalo de Tempo)

- Criando TimeSpan:

```csharp
// Diferentes formas de criar
TimeSpan intervalo1 = new TimeSpan(2, 30, 45); // 2 horas, 30 minutos, 45 segundos
TimeSpan intervalo2 = TimeSpan.FromDays(5);
TimeSpan intervalo3 = TimeSpan.FromHours(12);
TimeSpan intervalo4 = TimeSpan.FromMinutes(90);
TimeSpan intervalo5 = TimeSpan.FromSeconds(3600);

Console.WriteLine(intervalo1); // 02:30:45
Console.WriteLine(intervalo2); // 5.00:00:00
```

- Propriedades de TimeSpan:

```csharp
TimeSpan intervalo = new TimeSpan(5, 12, 30, 45, 500); // 5 dias, 12 horas, 30 min, 45 seg, 500 ms
Console.WriteLine($"Dias: {intervalo.Days}"); // 5
Console.WriteLine($"Horas: {intervalo.Hours}"); // 12
Console.WriteLine($"Minutos: {intervalo.Minutes}"); // 30
Console.WriteLine($"Segundos: {intervalo.Seconds}"); // 45
Console.WriteLine($"Milissegundos: {intervalo.Milliseconds}"); // 500

// Totais
Console.WriteLine($"Total de horas: {intervalo.TotalHours}"); // 132.5125
Console.WriteLine($"Total de minutos: {intervalo.TotalMinutes}"); // 7950.75
Console.WriteLine($"Total de segundos: {intervalo.TotalSeconds}"); // 477045.5
```

- Operações com TimeSpan:

```csharp
TimeSpan ts1 = TimeSpan.FromHours(5);
TimeSpan ts2 = TimeSpan.FromHours(3);

TimeSpan soma = ts1 + ts2; // 8 horas
TimeSpan diferenca = ts1 - ts2; // 2 horas
TimeSpan multiplo = ts1 * 2; // 10 horas

Console.WriteLine($"Soma: {soma}");
Console.WriteLine($"Diferença: {diferenca}");
Console.WriteLine($"Múltiplo: {multiplo}");
```

- Comparando TimeSpan:

```csharp
TimeSpan ts1 = TimeSpan.FromHours(5);
TimeSpan ts2 = TimeSpan.FromHours(3);

if (ts1 > ts2)
    Console.WriteLine("ts1 é maior");

if (ts1 == ts2)
    Console.WriteLine("São iguais");
```

- Usando TimeSpan com DateTime:

```csharp
DateTime agora = DateTime.Now;
TimeSpan intervalo = TimeSpan.FromDays(7);
DateTime proximaSemana = agora + intervalo;

Console.WriteLine($"Hoje: {agora}");
Console.WriteLine($"Próxima semana: {proximaSemana}");
```
