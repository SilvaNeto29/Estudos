// CS50 Semana 4 — Memória: exemplos em C#
// Cada seção ilustra um conceito da aula com o equivalente em C#.
// Para rodar um exemplo específico, chame o método no final do arquivo.

using System.Runtime.InteropServices;
using System.Text;

ExemplosHexadecimal();
ExemplosPonteirosEEnderecos();
ExemplosStrings();
ExemplosMemoriaDinamica();
ExemplosArquivos();
ExemplosMemoriaAvancada();

// ─────────────────────────────────────────────────────────────────────────────
// 1. HEXADECIMAL
// Em C:  printf("%x\n", 255);  →  ff
// ─────────────────────────────────────────────────────────────────────────────
static void ExemplosHexadecimal()
{
    Console.WriteLine("=== 1. HEXADECIMAL ===");

    int n = 255;
    Console.WriteLine($"Decimal:     {n}");
    Console.WriteLine($"Hexadecimal: {n:X2}");   // X2 = maiúsculo, 2 dígitos
    Console.WriteLine($"Binário:     {Convert.ToString(n, 2).PadLeft(8, '0')}");

    // Literal hex em C# (igual ao 0xFF do C)
    int vermelho = 0xFF0000;
    int verde    = 0x00FF00;
    int azul     = 0x0000FF;

    Console.WriteLine($"\nCor HTML vermelho: #{vermelho:X6}");
    Console.WriteLine($"Cor HTML verde:    #{verde:X6}");
    Console.WriteLine($"Cor HTML azul:     #{azul:X6}");

    // Decompondo canal RGB de uma cor hex
    int cor = 0x1A2B3C;
    byte r = (byte)((cor >> 16) & 0xFF);
    byte g = (byte)((cor >> 8)  & 0xFF);
    byte b = (byte)((cor)       & 0xFF);
    Console.WriteLine($"\n#1A2B3C → R={r} G={g} B={b}");
    Console.WriteLine();
}

// ─────────────────────────────────────────────────────────────────────────────
// 2. PONTEIROS E ENDEREÇOS
// Em C:  int *p = &n;  printf("%p", p);  printf("%i", *p);
// C# tem ponteiros no modo "unsafe" — aqui usamos referências para a analogia.
// ─────────────────────────────────────────────────────────────────────────────
static void ExemplosPonteirosEEnderecos()
{
    Console.WriteLine("=== 2. PONTEIROS E ENDEREÇOS ===");

    // Tipos de valor (int, double, struct) ficam na STACK — como variáveis locais em C
    int n = 50;
    Console.WriteLine($"Valor de n: {n}");

    // Em C# gerenciado, não acessamos endereços diretamente.
    // Com unsafe + fixed conseguimos o mesmo que &n em C:
    unsafe
    {
        // Variável local está na stack — endereço fixo, não precisa de fixed
        int* p = &n;
        Console.WriteLine($"Endereço de n (unsafe): 0x{(long)p:X}");
        Console.WriteLine($"Valor via ponteiro *p: {*p}");

        *p = 100;   // modifica n via ponteiro — igual a *p = 100 em C
        Console.WriteLine($"n depois de *p = 100: {n}");
    }

    // Analogia segura: ref passa o endereço implicitamente
    int x = 10;
    Dobrar(ref x);  // equivale a passar &x em C e receber int*
    Console.WriteLine($"\nref: x após Dobrar(ref x) = {x}");
    Console.WriteLine();
}

static void Dobrar(ref int valor)
{
    valor *= 2;   // modifica o original, como *p *= 2 faria em C
}

// ─────────────────────────────────────────────────────────────────────────────
// 3. STRINGS
// Em C:  char *s = "Oi";  strcmp, strcpy, strlen
// Em C#: string é um objeto imutável; compare com == ou .Equals()
// ─────────────────────────────────────────────────────────────────────────────
static void ExemplosStrings()
{
    Console.WriteLine("=== 3. STRINGS ===");

    string s1 = "Oi";
    string s2 = "Oi";
    string s3 = "Tchau";

    // Em C, == compara PONTEIROS (endereços). Em C#, == compara CONTEÚDO para string.
    // Isso é uma diferença importante em relação ao C!
    Console.WriteLine($"s1 == s2: {s1 == s2}");     // true  — compara conteúdo
    Console.WriteLine($"s1 == s3: {s1 == s3}");     // false

    // Equivalente ao strcmp do C:
    int resultado = string.Compare(s1, s3, StringComparison.Ordinal);
    Console.WriteLine($"Compare(s1, s3): {resultado}");  // < 0 porque 'O' < 'T'

    // Strings em C# são IMUTÁVEIS — uma cópia cria um novo objeto
    string t = s1;     // em C seria apenas copiar o ponteiro (BUG se você free(s1) depois)
    t = "Novo valor";  // em C# isso cria um novo objeto; s1 não muda
    Console.WriteLine($"s1 após t = 'Novo valor': {s1}");   // ainda "Oi"

    // Acessando caracteres individualmente — como char* em C
    string palavra = "CS50";
    for (int i = 0; i < palavra.Length; i++)
    {
        Console.Write($"[{i}]='{palavra[i]}'  ");
    }
    Console.WriteLine();

    // StringBuilder = alocação manual de char[] — eficiente para concatenação
    var sb = new StringBuilder();
    sb.Append("Hello");
    sb.Append(", ");
    sb.Append("World!");
    Console.WriteLine(sb.ToString());
    Console.WriteLine();
}

// ─────────────────────────────────────────────────────────────────────────────
// 4. MEMÓRIA DINÂMICA
// Em C:  malloc / calloc / realloc / free
// Em C#: new / GC (Garbage Collector faz o free automaticamente)
// ─────────────────────────────────────────────────────────────────────────────
static void ExemplosMemoriaDinamica()
{
    Console.WriteLine("=== 4. MEMÓRIA DINÂMICA ===");

    // malloc(3 * sizeof(int)) → new int[3]
    int[] arr = new int[3];       // alocado no HEAP, como malloc
    arr[0] = 10;
    arr[1] = 20;
    arr[2] = 30;
    Console.WriteLine($"arr[0]={arr[0]}, arr[1]={arr[1]}, arr[2]={arr[2]}");

    // calloc → new int[3] já inicializa com 0 em C# (garantido pelo runtime)
    int[] zerado = new int[5];
    Console.Write("Zerado: ");
    foreach (var v in zerado) Console.Write($"{v} ");
    Console.WriteLine();

    // realloc → Array.Resize
    Array.Resize(ref arr, 6);   // expande; primeiros 3 elementos preservados
    Console.WriteLine($"Após resize: comprimento={arr.Length}, arr[2]={arr[2]}");

    // Em C# não existe free() — o GC libera automaticamente quando não há referências.
    // Para recursos não-gerenciados (arquivos, conexões, handles), use IDisposable + using:
    using (var ms = new MemoryStream())
    {
        ms.Write([1, 2, 3, 4]);
        Console.WriteLine($"MemoryStream length: {ms.Length} bytes (liberada ao sair do using)");
    }
    // ms é liberada aqui — análogo ao free()

    // Demonstração do GC: forçar coleta (raramente necessário na prática)
    arr = null!;   // remove referência → objeto elegível para coleta
    GC.Collect();
    Console.WriteLine("GC.Collect() chamado — equivalente ao free() automático do C#");
    Console.WriteLine();
}

// ─────────────────────────────────────────────────────────────────────────────
// 5. ARQUIVOS
// Em C:  FILE *f = fopen("x.txt","w");  fprintf(f,...);  fclose(f);
// Em C#: StreamWriter / StreamReader / FileStream
// ─────────────────────────────────────────────────────────────────────────────
static void ExemplosArquivos()
{
    Console.WriteLine("=== 5. ARQUIVOS ===");

    string caminho = "exemplo_cs50.txt";

    // fopen("w") + fprintf + fclose
    using (var writer = new StreamWriter(caminho))
    {
        writer.WriteLine("Nome: Alice");
        writer.WriteLine("Idade: 30");
        writer.WriteLine("Curso: CS50");
    }   // fclose automático ao sair do using

    // fopen("r") + fgets + fclose
    using (var reader = new StreamReader(caminho))
    {
        string? linha;
        while ((linha = reader.ReadLine()) != null)
        {
            Console.WriteLine($"  Lido: {linha}");
        }
    }

    // Leitura/escrita BINÁRIA — equivalente a fread/fwrite
    string caminhobin = "exemplo_cs50.bin";
    int[] nums = [100, 200, 300];

    using (var fs = new FileStream(caminhobin, FileMode.Create))
    {
        foreach (var num in nums)
        {
            fs.Write(BitConverter.GetBytes(num));   // grava 4 bytes por int
        }
    }

    using (var fs = new FileStream(caminhobin, FileMode.Open))
    {
        byte[] buf = new byte[4];
        Console.Write("  Binário lido: ");
        while (fs.Read(buf, 0, 4) == 4)
        {
            Console.Write($"{BitConverter.ToInt32(buf)} ");
        }
        Console.WriteLine();
    }

    // Limpeza
    File.Delete(caminho);
    File.Delete(caminhobin);
    Console.WriteLine();
}

// ─────────────────────────────────────────────────────────────────────────────
// 6. CONCEITOS AVANÇADOS: Span<T> e Memory<T>
// Equivalente moderno ao ponteiro C — acesso direto a regiões de memória
// sem alocação extra e sem unsafe. Muito usado em código de alta performance.
// ─────────────────────────────────────────────────────────────────────────────
static void ExemplosMemoriaAvancada()
{
    Console.WriteLine("=== 6. SPAN<T> — PONTEIRO SEGURO DO C# ===");

    int[] dados = [10, 20, 30, 40, 50];

    // Span é uma "janela" sobre a memória — como ponteiro + tamanho em C
    Span<int> span = dados;
    Span<int> fatia = span.Slice(1, 3);   // equivale a: int *p = dados + 1; (tamanho 3)

    Console.Write("Fatia [1..3]: ");
    foreach (var v in fatia) Console.Write($"{v} ");
    Console.WriteLine();

    // Modificar via Span modifica o array original — como ponteiro em C
    fatia[0] = 999;
    Console.WriteLine($"dados[1] após fatia[0] = 999: {dados[1]}");

    // stackalloc — aloca na STACK como array local em C (rápido, sem GC)
    Span<int> local = stackalloc int[4] { 1, 2, 3, 4 };
    Console.Write("stackalloc na stack: ");
    foreach (var v in local) Console.Write($"{v} ");
    Console.WriteLine();

    // Marshal.AllocHGlobal — equivalente direto ao malloc do C
    nint ptr = Marshal.AllocHGlobal(4 * sizeof(int));
    unsafe
    {
        int* p = (int*)ptr;
        p[0] = 7; p[1] = 14; p[2] = 21; p[3] = 28;
        Console.Write("Marshal (malloc manual): ");
        for (int i = 0; i < 4; i++) Console.Write($"{p[i]} ");
        Console.WriteLine();
    }
    Marshal.FreeHGlobal(ptr);   // free() explícito — vazamento se esquecer!
    Console.WriteLine("Marshal.FreeHGlobal chamado — equivalente ao free() do C");
}
