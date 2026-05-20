# 1 - Paradigma deorientação a objetos

- Existem várias, como estruturada, funcional e OOP
- Espelhada em coisas do mundo real para representar coisas na programação.
- Quebrar em pedaços menores para tratar de assuntos grandes

# 2 - Propriedades, métodos e eventos

- Essas coisas compoe o objeto
- Propriedades são as variáveis do objeto.
- Funcções se tornam os métodos dentro do objeto

### Diferença entre objetos e structs

- Classe só copia o endereço, os dados ficam na memória HEAP. Dados de referencia
- Struct armazena o próprio valor. Ficam na stack que são muito mais rápidas.

# 3 - Encapsulamento

- É literalmente encapsular as propriedades, métodos e eventos dentro do objeto

# 4 - Abstração

- Abstraídos é limitar os detalhes. Quando uma função public é chamada ela pode chamar várias funções internas, mas não irá expor. Abstrair os dados internos pra externo só ter as informações necessárias.

# 5 - Herança

- Capacidade de herdar metodos e propriedades de outros objetos
- Classe base é a classe que foi utilizada para outra receber a herança

```csharp
class Pix : Pagamento
{

}
```

# 6 - Polimorfismo

- Capacidade de um mesmo membro (método/propriedade) apresentar comportamentos diferentes conforme o tipo concreto do objeto.
- Polimorfismo em tempo de execução (dispatch dinâmico): declarar método `virtual` ou `abstract` na classe base e usar `override` nas classes derivadas.
- Sobrecarga (compile-time): métodos com mesmo nome e assinaturas diferentes — polimorfismo estático.
- Interfaces: várias classes podem implementar a mesma `interface`, permitindo tratar objetos diferentes por um contrato comum.
- Exemplo:

```csharp
abstract class Pagamento
{
	public abstract void Processar();
}

class Pix : Pagamento
{
	public override void Processar() => Console.WriteLine("Processando Pix");
}

class Cartao : Pagamento
{
	public override void Processar() => Console.WriteLine("Processando Cartão");
}
```

- Boas práticas: prefira `interface`/`abstract` para contratos; use `virtual`/`override` quando necessário; evite `new` para ocultar membros; respeite o princípio de substituição de Liskov (LSP).

# 7 - Modificadores de Acesso

- `public`: acessível de qualquer lugar (dentro e fora da classe).
- `private`: acessível apenas dentro da própria classe (padrão para membros de classe).
- `protected`: acessível dentro da classe e por classes derivadas (herança).
- `internal`: acessível apenas dentro do mesmo assembly/projeto.
- `protected internal`: acessível dentro do mesmo assembly OU por classes derivadas em qualquer lugar.
- `private protected`: acessível apenas dentro da classe e por classes derivadas no mesmo assembly.
- Exemplo:

```csharp
public class ContaBancaria
{
    private decimal saldo; // só a classe acessa
    public string Titular { get; set; } // público
    protected virtual void ValidarSaque(decimal valor) { } // classes filhas acessam
    internal void AuditarOperacao() { } // só dentro do assembly
}
```

- Boa prática: use o nível mais restritivo possível; evite expor dados internos desnecessariamente.

# 8 - Tipos Complexos

- **Tipos de referência (reference types):** armazenam endereço de memória na stack, dados na heap. Classes, arrays, strings, delegates, interfaces.
- **Tipos de valor (value types):** armazenam o valor diretamente na stack. Structs, enums, tipos primitivos (int, double, bool).
- **Nullable types:** permite valores `null` em tipos de valor. Sintaxe: `int?`, `DateTime?`, etc.
- **Tuplas:** agrupam múltiplos valores de tipos diferentes. Exemplo: `(string nome, int idade) pessoa = ("João", 30);`
- **Records:** tipo imutável (C# 9+) para modelar dados. Comparação automática por valor.
- Exemplo:

```csharp
// Struct (value type)
public struct Ponto
{
    public int X, Y;
}

// Record (reference type, imutável)
public record Pessoa(string Nome, int Idade);

// Nullable
int? numero = null;
if (numero.HasValue) { }

// Tupla
(string, int) tupla = ("Ana", 25);
var (nome, idade) = tupla; // desempacotamento
```

- Diferença chave: structs são copiadas por valor, classes por referência — escolha baseada em tamanho e comportamento esperado.

# 9 - Using e Dispose

- `Dispose()` é um método que libera recursos (arquivos, conexões, memória) que **não são automaticamente coletados pelo garbage collector**.
- `IDisposable`: interface que garante que a classe tem um método `Dispose()` para limpeza.
- `using` statement: garante que `Dispose()` é chamado **automaticamente** ao sair do bloco, mesmo em caso de exceção.
- Exemplo SEM using (problema):

```csharp
FileStream fs = new FileStream("arquivo.txt", FileMode.Open);
fs.Write(dados, 0, dados.Length);
// ❌ Se houver exceção, arquivo nunca fecha
```

- Exemplo COM using (seguro):

```csharp
using (FileStream fs = new FileStream("arquivo.txt", FileMode.Open))
{
    fs.Write(dados, 0, dados.Length);
} // ✅ Dispose() é chamado automaticamente aqui
```

- Using declaration (C# 8+) — mais conciso:

```csharp
using FileStream fs = new FileStream("arquivo.txt", FileMode.Open);
fs.Write(dados, 0, dados.Length);
// ✅ Dispose() chamado ao final do escopo
```

- Implementar `IDisposable`:

```csharp
public class MinhaClasse : IDisposable
{
    private FileStream _arquivo;

    public void Dispose()
    {
        _arquivo?.Dispose(); // libera recurso
        GC.SuppressFinalize(this); // evita finalizador
    }
}
```

- Boa prática: sempre use `using` com recursos (arquivos, conexões, streams); implemente `IDisposable` em classes que gerenciam recursos não-gerenciados.

# 10 - Sealed class

- Classes que proíbem de serem usada como extended

# 11 - Partial class

- Uma classe dividida em dois arquivos. Ambas as declarações tem que ter partial class

# 12 - Interfaces

## O que são Interfaces?

- São contratos que definem um conjunto de métodos, propriedades e eventos que uma classe **deve implementar**.
- Não contêm implementação (exceto C# 8+ com métodos padrão).
- Uma classe pode implementar **múltiplas interfaces** (herança múltipla de contrato).
- Interface serve para garantir que diferentes classes tenham os mesmos membros públicos.

## Sintaxe Básica

```csharp
public interface IPagavel
{
    void Pagar(decimal valor);
    string ObterDescricao();
}
```

- Convenção: interfaces começam com "I" maiúsculo.
- Não têm modificadores de acesso nos membros (implicitamente `public`).

## Implementando uma Interface

```csharp
public class Fatura : IPagavel
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagando fatura de R$ {valor}");
    }

    public string ObterDescricao()
    {
        return "Fatura de serviços";
    }
}

public class Boleto : IPagavel
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagando boleto de R$ {valor}");
    }

    public string ObterDescricao()
    {
        return "Boleto bancário";
    }
}
```

- A classe **deve implementar todos os membros** da interface.
- Usa-se `:` para herdar da interface (assim como classes).

## Usando Interfaces (Polimorfismo)

```csharp
IPagavel fatura = new Fatura();
IPagavel boleto = new Boleto();

List<IPagavel> pagamentos = new List<IPagavel> { fatura, boleto };

foreach (var pagamento in pagamentos)
{
    pagamento.Pagar(100); // Chamará o método correto de cada classe
    Console.WriteLine(pagamento.ObterDescricao());
}
```

- Isso permite **tratar objetos diferentes através de um contrato comum**.
- Facilita adicionar novos tipos sem alterar o código existente (Open/Closed Principle).

## Múltiplas Interfaces

```csharp
public interface ISerializavel
{
    string Serializar();
}

public interface IPersistivel
{
    void Salvar();
}

public class Documento : IPagavel, ISerializavel, IPersistivel
{
    public void Pagar(decimal valor) { }
    public string ObterDescricao() { }
    public string Serializar() { }
    public void Salvar() { }
}
```

- Uma classe pode implementar quantas interfaces desejar (separadas por vírgula).

## Propriedades em Interfaces (C# 6+)

```csharp
public interface IVeiculo
{
    string Marca { get; set; }
    int Velocidade { get; }
    void Acelerar();
}

public class Carro : IVeiculo
{
    public string Marca { get; set; }
    public int Velocidade { get; private set; }

    public void Acelerar()
    {
        Velocidade += 10;
    }
}
```

- Propriedades definem get/set que a classe implementadora deve fornecer.

## Membros Padrão em Interfaces (C# 8+)

```csharp
public interface ILogger
{
    void Log(string mensagem);

    // Implementação padrão
    void LogComData(string mensagem)
    {
        Console.WriteLine($"[{DateTime.Now}] {mensagem}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
    // LogComData já tem implementação padrão
}
```

- Permite adicionar novos membros sem quebrar implementações antigas.

## Interface vs Classe Abstrata

| Aspecto          | Interface     | Classe Abstrata   |
| ---------------- | ------------- | ----------------- |
| Herança Múltipla | ✅ Sim        | ❌ Não (apenas 1) |
| Implementação    | ❌ Não (C# 7) | ✅ Sim            |
| Membros Privados | ❌ Não        | ✅ Sim            |
| Construtores     | ❌ Não        | ✅ Sim            |
| Contratos        | ✅ Pura       | ⚠️ Parcial        |

**Quando usar:**

- **Interface**: define um contrato genérico (ex: `IDisposable`, `IComparable`).
- **Classe Abstrata**: quando há código comum entre classes relacionadas.

## Exemplo Prático Completo

```csharp
public interface INotificacao
{
    void Enviar(string mensagem);
}

public class EmailNotificacao : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Email enviado: {mensagem}");
    }
}

public class SMSNotificacao : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"SMS enviado: {mensagem}");
    }
}

public class NotificadorSistema
{
    private List<INotificacao> notificadores = new();

    public void AdicionarNotificador(INotificacao notificador)
    {
        notificadores.Add(notificador);
    }

    public void NotificarTodos(string mensagem)
    {
        foreach (var notificador in notificadores)
        {
            notificador.Enviar(mensagem);
        }
    }
}

// Uso
var sistema = new NotificadorSistema();
sistema.AdicionarNotificador(new EmailNotificacao());
sistema.AdicionarNotificador(new SMSNotificacao());
sistema.NotificarTodos("Bem-vindo!");
```

## Boas Práticas

✅ Use interfaces para **contratos entre componentes**
✅ Nomeie com **prefixo "I"** (ex: `IRepository`, `IService`)
✅ Mantenha interfaces **pequenas e focadas** (Interface Segregation Principle)
✅ Implemente interfaces para **inverter dependências** (Dependency Injection)
✅ Use `typeof(T).GetInterfaces()` para inspecionar interfaces em runtime

❌ Não crie interfaces com todos os métodos públicos de uma classe
❌ Não misture responsabilidades em uma interface
❌ Não use interface só porque foi "dito que deve"

# 13 - Upcast e Downcast

- C# é tipado, mas se eu atribuo a classe B para uma variável que estava declarada com a classe A, se a classe B tiver herdado as propriedades de A, é possível reatribuir a variável.

# 14 - Events

- Eventos que irão acontecer quando x acontecer, mesmo tipo de evento do windows forms mas não igual, pode ser utilizado sem front.
- Validar casos de uso depois .

# 15 - Generics

- Permitem criar classes, métodos, interfaces e delegates que trabalham com tipos especificados posteriormente
- Eliminam conversões (casting) e boxing/unboxing
- Aumentam a reutilização de código com type safety
- Muito usados em coleções (`List<T>`, `Dictionary<TKey, TValue>`)

## Classes Genéricas

```csharp
public class Repositorio<T>
{
    private List<T> itens = new();

    public void Adicionar(T item)
    {
        itens.Add(item);
    }

    public T Obter(int indice)
    {
        return itens[indice];
    }

    public IEnumerable<T> Listar()
    {
        return itens;
    }
}

// Uso
var repoStrings = new Repositorio<string>();
repoStrings.Adicionar("Item 1");
string item = repoStrings.Obter(0);

var repoInts = new Repositorio<int>();
repoInts.Adicionar(42);
int numero = repoInts.Obter(0);
```

## Métodos Genéricos

- Métodos que aceitam tipos genéricos, mesmo em classes não genéricas

```csharp
public class Utils
{
    public T Identidade<T>(T valor)
    {
        return valor;
    }

    public TResult Processar<TInput, TResult>(TInput input, Func<TInput, TResult> transformador)
    {
        return transformador(input);
    }
}

// Uso
var utils = new Utils();
int mesmo = utils.Identidade(42);
string texto = utils.Processar(10, x => x.ToString());
```

## Interfaces Genéricas

```csharp
public interface IRepositorio<T>
{
    void Adicionar(T entidade);
    T ObterPorId(int id);
    IEnumerable<T> ListarTodos();
    void Remover(int id);
}

public class ProdutoRepositorio : IRepositorio<Produto>
{
    private List<Produto> produtos = new();

    public void Adicionar(Produto entidade) => produtos.Add(entidade);
    public Produto ObterPorId(int id) => produtos.FirstOrDefault(p => p.Id == id);
    public IEnumerable<Produto> ListarTodos() => produtos;
    public void Remover(int id) => produtos.RemoveAll(p => p.Id == id);
}
```

## Restrições (Constraints)

- Limitam os tipos que podem ser usados como argumento genérico

```csharp
// T deve ser um tipo de referência
public class Servico<T> where T : class

// T deve ser um tipo de valor
public class Calculadora<T> where T : struct

// T deve ter um construtor sem parâmetros
public class Fabrica<T> where T : new()

// T deve herdar de uma classe específica
public class RepositorioAnimais<T> where T : Animal

// T deve implementar uma interface específica
public class Comparador<T> where T : IComparable<T>

// Múltiplas restrições
public class Servico<T> where T : class, IComparable<T>, new()
```

### Exemplo com restrições

```csharp
public class Repositorio<T> where T : class, IEntidade, new()
{
    private List<T> itens = new();

    public T CriarNovo()
    {
        return new T();
    }

    public T BuscarPorId(int id)
    {
        return itens.FirstOrDefault(x => x.Id == id);
    }
}

public interface IEntidade
{
    int Id { get; set; }
}

public class Cliente : IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
```

## Tipos Genéricos Múltiplos

```csharp
public class Par<TPrimeiro, TSegundo>
{
    public TPrimeiro Primeiro { get; set; }
    public TSegundo Segundo { get; set; }

    public Par(TPrimeiro primeiro, TSegundo segundo)
    {
        Primeiro = primeiro;
        Segundo = segundo;
    }
}

// Uso
var par = new Par<string, int>("Idade", 30);
Console.WriteLine($"{par.Primeiro}: {par.Segundo}");
```

## Covariância e Contravariância

### Covariância (out)

- Permite usar um tipo mais derivado como retorno
- Usado apenas para saída

```csharp
public interface IProducer<out T>
{
    T Get();
}

public class AnimalProducer : IProducer<Animal>
{
    public Animal Get() => new Animal();
}

IProducer<Animal> producer = new AnimalProducer();
```

### Contravariância (in)

- Permite usar um tipo mais derivado como parâmetro
- Usado apenas para entrada

```csharp
public interface IConsumer<in T>
{
    void Process(T item);
}

public class AnimalConsumer : IConsumer<Animal>
{
    public void Process(Animal item) => Console.WriteLine("Processando animal");
}

IConsumer<Cachorro> consumer = new AnimalConsumer();
```

## Genéricos vs object

| Aspecto          | Generics                  | object                |
| ---------------- | ------------------------- | --------------------- |
| Type safety      | ✅ Em tempo de compilação | ❌ Em tempo de execução |
| Performance      | ✅ Sem boxing/unboxing    | ❌ Boxing para valores |
| Legibilidade     | ✅ Tipo explícito         | ❌ Requer casting     |
| IntelliSense     | ✅ Funciona               | ❌ Limitado           |

### Exemplo comparativo

```csharp
// ❌ Com object - sem type safety
public class RepositorioObject
{
    private List<object> itens = new();
    
    public void Adicionar(object item) => itens.Add(item);
    public object Obter(int indice) => itens[indice];
}

var repo = new RepositorioObject();
repo.Adicionar("texto");
string texto = (string)repo.Obter(0); // Casting necessário

// ✅ Com generics - type safety
public class RepositorioGenerico<T>
{
    private List<T> itens = new();
    
    public void Adicionar(T item) => itens.Add(item);
    public T Obter(int indice) => itens[indice];
}

var repoGenerico = new RepositorioGenerico<string>();
repoGenerico.Adicionar("texto");
string textoGenerico = repoGenerico.Obter(0); // Sem casting
```

## Default em Generics

- `default(T)` retorna o valor padrão do tipo T
- Para referências: `null`
- Para valores: `0`, `false`, etc.

```csharp
public class Exemplo<T>
{
    public T ObterPadrao()
    {
        return default(T);
    }
}

var exInt = new Exemplo<int>();
var exString = new Exemplo<string>();

Console.WriteLine(exInt.ObterPadrao());     // 0
Console.WriteLine(exString.ObterPadrao());  // (null/vazio)
```

## Boas Práticas

✅ Use nomes descritivos para tipos genéricos: `T`, `TKey`, `TValue`, `TEntity`
✅ Prefira generics sobre `object` para coleções e algoritmos
✅ Use restrições para garantir type safety em tempo de compilação
✅ Aproveite `List<T>`, `Dictionary<TKey, TValue>`, `IEnumerable<T>` do .NET
✅ Use `default(T)` quando precisar de valor padrão
❌ Não abuse de múltiplos parâmetros genéricos (máximo 3-4)
❌ Não use generics quando o tipo é sempre conhecido
❌ Não esqueça de documentar restrições quando não óbvias

# 16 - Listas e Coleções

- `List<T>` é uma coleção tipada que cresce dinamicamente
- Parte do namespace `System.Collections.Generic`
- Mais usada que arrays por ser flexível e ter métodos prontos

## Criação e Inicialização

```csharp
// Lista vazia
List<string> nomes = new List<string>();
List<int> numeros = new(); // C# 9+

// Com capacidade inicial (performance)
List<int> lista = new List<int>(100);

// Inicializador de coleção
List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };

// A partir de outra coleção
int[] array = { 1, 2, 3 };
List<int> listaFromArray = new List<int>(array);
```

## Métodos Principais

```csharp
List<int> numeros = new List<int> { 1, 2, 3 };

// Adicionar
numeros.Add(4);                    // Adiciona um item
numeros.AddRange(new[] { 5, 6 });  // Adiciona múltiplos
numeros.Insert(0, 0);              // Insere na posição específica

// Remover
numeros.Remove(3);                 // Remove primeira ocorrência do valor
numeros.RemoveAt(0);               // Remove por índice
numeros.RemoveRange(1, 2);         // Remove a partir do índice, quantidade
numeros.Clear();                   // Remove todos

// Buscar
int primeiro = numeros[0];         // Por índice
bool existe = numeros.Contains(2); // Verifica se existe
int indice = numeros.IndexOf(2);   // Retorna índice (-1 se não encontrar)
int ultimo = numeros[^1];          // Último elemento (C# 8+)

// Encontrar com predicado
int par = numeros.Find(x => x % 2 == 0);           // Primeiro que satisfaz
List<int> pares = numeros.FindAll(x => x % 2 == 0); // Todos que satisfazem
int indicePar = numeros.FindIndex(x => x % 2 == 0); // Índice do primeiro

// Ordenar
numeros.Sort();                    // Ordena in-place
numeros.Reverse();                 // Inverte a ordem
var ordenada = numeros.OrderBy(x => x).ToList();   // LINQ (nova lista)

// Outros
int count = numeros.Count;         // Quantidade de itens
numeros.ForEach(x => Console.WriteLine(x)); // Ação em cada item
numeros.TrimExcess();              // Libera memória não usada
```

## Iteração

```csharp
List<string> nomes = new() { "Ana", "Bruno", "Carol" };

// foreach
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}

// for (quando precisa do índice)
for (int i = 0; i < nomes.Count; i++)
{
    Console.WriteLine($"{i}: {nomes[i]}");
}

// ForEach (método da lista)
nomes.ForEach(nome => Console.WriteLine(nome));

// Com índice (C# 8+)
foreach (var (nome, indice) in nomes.Select((n, i) => (n, i)))
{
    Console.WriteLine($"{indice}: {nome}");
}
```

## List vs Array

| Aspecto        | List<T>                    | T[] (Array)           |
| -------------- | -------------------------- | --------------------- |
| Tamanho        | Dinâmico                   | Fixo                  |
| Performance    | Leve overhead              | Mais rápido           |
| Métodos        | Rico (Add, Remove, Find)   | Básico (Length, Copy) |
| Redimensionar  | Automático                 | Não é possível        |
| Uso típico     | Dados que mudam           | Dados fixos/constantes|

```csharp
// Array - tamanho fixo
int[] array = new int[5];
array[0] = 1;
// array.Add(6); // ❌ Erro - não existe

// List - tamanho dinâmico
List<int> lista = new List<int>();
lista.Add(1);
lista.Add(2);
lista.Add(3); // ✅ Cresce automaticamente
```

## Outras Coleções

### Dictionary<TKey, TValue>

- Pares chave-valor, busca O(1)

```csharp
Dictionary<string, int> idades = new()
{
    ["Ana"] = 25,
    ["Bruno"] = 30
};

idades.Add("Carol", 28);
int idade = idades["Ana"]; // 25
bool existe = idades.ContainsKey("Ana");
idades.TryGetValue("Ana", out int valor);
```

### HashSet<T>

- Elementos únicos, sem duplicatas, busca O(1)

```csharp
HashSet<int> unicos = new() { 1, 2, 3 };
unicos.Add(2); // Ignora, já existe
unicos.Add(4); // Adiciona
// Resultado: { 1, 2, 3, 4 }
```

### LinkedList<T>

- Inserção/remoção eficiente no meio, sem índice

```csharp
LinkedList<string> linked = new();
linked.AddLast("A");
linked.AddFirst("B"); // "B" -> "A"
```

### Queue<T> e Stack<T>

```csharp
// Queue - FIFO (First In, First Out)
Queue<int> fila = new();
fila.Enqueue(1);
fila.Enqueue(2);
int proximo = fila.Dequeue(); // 1

// Stack - LIFO (Last In, First Out)
Stack<int> pilha = new();
pilha.Push(1);
pilha.Push(2);
int topo = pilha.Pop(); // 2
```

## LINQ com Listas

```csharp
List<int> numeros = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Filtrar
var pares = numeros.Where(x => x % 2 == 0).ToList();

// Projetar
var dobros = numeros.Select(x => x * 2).ToList();

// Ordenar
var ordenado = numeros.OrderBy(x => x).ToList();
var descendente = numeros.OrderByDescending(x => x).ToList();

// Agregar
int soma = numeros.Sum();
double media = numeros.Average();
int max = numeros.Max();
int min = numeros.Min();
int contagem = numeros.Count();

// Primeiro/Último
int primeiro = numeros.First();
int primeiroPar = numeros.First(x => x % 2 == 0);
int ouPadrao = numeros.FirstOrDefault(x => x > 100); // 0 se não encontrar

// Verificar
bool algumPar = numeros.Any(x => x % 2 == 0);
bool todosPares = numeros.All(x => x % 2 == 0);

// Agrupar
var grupos = numeros.GroupBy(x => x % 2 == 0 ? "Par" : "Ímpar");

// Múltiplas operações
var resultado = numeros
    .Where(x => x > 3)
    .Select(x => x * 2)
    .OrderBy(x => x)
    .ToList();
```

## Conversões

```csharp
List<int> lista = new() { 1, 2, 3 };

// Para Array
int[] array = lista.ToArray();

// Para IEnumerable (readonly)
IEnumerable<int> enumerable = lista.AsEnumerable();

// Para IReadOnlyList (não pode adicionar/remover)
IReadOnlyList<int> readOnly = lista.AsReadOnly();

// De Array para List
int[] arr = { 1, 2, 3 };
List<int> list = arr.ToList();
```

## ReadOnlyCollection

- Lista que não pode ser modificada após criação

```csharp
List<int> original = new() { 1, 2, 3 };
IReadOnlyList<int> readOnly = original.AsReadOnly();

// readOnly.Add(4); // ❌ Erro de compilação

// Ou criar diretamente
IReadOnlyList<int> imutavel = new List<int> { 1, 2, 3 }.AsReadOnly();
```

## Boas Práticas

✅ Use `List<T>` para coleções que mudam de tamanho
✅ Use `IReadOnlyList<T>` em parâmetros quando não deve modificar
✅ Prefira `Count` sobre `Count()` (LINQ) quando disponível
✅ Especifique capacidade inicial quando souber o tamanho aproximado
✅ Use `Contains`, `Find`, `Exists` ao invés de loops manuais
✅ Retorne `IEnumerable<T>` para expor coleções sem permitir modificações

❌ Não use `List<T>` quando `IEnumerable<T>` basta no parâmetro
❌ Não chame `.ToList()` desnecessariamente em LINQ
❌ Não use `ArrayList` (não genérico, legado)
❌ Não exponha `List<T>` pública diretamente (use interfaces ou readonly)
