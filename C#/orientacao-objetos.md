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
