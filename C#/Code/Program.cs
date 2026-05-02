using System; //A base pra quase tudo, tem a classe Console, tem a classe Math, tem a classe String, tem a classe DateTime, 
// tem a classe TimeSpan... Tem muita coisa dentro do System. Tem o System.IO pra trabalhar com arquivos, tem o System.Net pra 
//trabalhar com rede, tem o System.Collections pra trabalhar com coleções... Tem muita coisa dentro do System.
//Não precisa ficar declarando system, ele já está implicitamente declarado, mas se quiser usar algo específico, pode usar o using System.XYZ; para facilitar a vida.

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Variáveis
            int num1;
            num1 = 10;

            string nome = "João";
            // 1. Concatenação simples
            Console.WriteLine("String " + nome + " E idade = " + num1);

            // 2. String.Format
            Console.WriteLine(string.Format("String {0} E idade = {1}", nome, num1));

            // 3. String interpolation (recomendado)
            Console.WriteLine($"String {nome} E idade = {num1}");

            //Var vai sempre pegar o tipo que tá sendo atribuído a ele. 
            //É boa prática quando é claro que tipo ele está recebendo ou não faz diferença o tipo da tipagem. Se int, bigint...

            //Constantes
            //Igual a variável, com tipo e var, mas com cont na frente. Não atribui valor depois 
            const int IDADE = 0; //const int IDADE; inicia com zero

            // TIPOS DO C#
            // Tipos de Valor (Value Types)
            bool ativo = true;                      // Booleano
            byte valor_byte = 255;                  // 0 a 255
            sbyte valor_sbyte = -128;               // -128 a 127
            short valor_short = 32767;              // -32,768 a 32,767
            ushort valor_ushort = 65535;            // 0 a 65,535
            int valor_int = 2147483647;             // -2,147,483,648 a 2,147,483,647
            uint valor_uint = 4294967295;           // 0 a 4,294,967,295
            long valor_long = 9223372036854775807;  // Grande intervalo
            ulong valor_ulong = 18446744073709551615; // Muito grande
            float valor_float = 3.14f;              // 32 bits, menor precisão
            double valor_double = 3.14159265;       // 64 bits, maior precisão
            decimal valor_decimal = 99.99m;         // Para valores monetários
            char caractere = 'A';                   // Um caractere
            
            // Tipos de Referência (Reference Types)
            string texto = "Olá";                   // Cadeia de caracteres
            object obj = 42;                        // Tipo base de todos

            //----------------------------------------------------------//
            object obj1 = "Olá, mundo!";
            string str1 = (string)obj1; // Casting explícito
            //O Object pode ser alterado pra uma penca de coisas, é um tipo qualquer 

            int? idade = null; // Nullable int, pode ser null ou um valor inteiro

            //Alias 
            //int é um alias para System.Int32
            //string é um alias para System.String

            //Conversão implicita
            int num2 = 100;
            long num3 = num2; // int para long, sem necessidade de cast

            float valor = 25.8f;
            double valor2 = valor; // float para double, sem necessidade de cast

            //Somente funciona se os tipos de dados forem compatíveis.

            //Conversão explicita 
            double valor3 = 9.99;
            float valor4 = (float)valor3; // double para float, requer cast explícito

            int inteiro = int.Parse("123"); // Converte string para int, pode lançar exceção se a string não for um número válido
            string text2 = Convert.ToString(inteiro); // Converte int para string

            // CONDICIONAIS
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

            // LAÇOS
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"for: {i}");

            int j = 0;
            while (j < 3)
            {
                Console.WriteLine($"while: {j}");
                j++;
            }

            int k = 0;
            do
            {
                Console.WriteLine($"do while: {k}");
                k++;
            } while (k < 3);

            string[] nomes = { "Ana", "Bruno", "Carla" };
            foreach (string item in nomes)
                Console.WriteLine($"foreach: {item}");

            // COLEÇÕES SIMPLES
            var lista = new System.Collections.Generic.List<int> { 1, 2, 3 };
            var mapa = new System.Collections.Generic.Dictionary<string, int> { ["um"] = 1, ["dois"] = 2 };
            Console.WriteLine(lista.Count);
            Console.WriteLine(mapa["um"]);

            // MÉTODO SIMPLES
            static int Soma(int a, int b) => a + b;
            Console.WriteLine(Soma(2, 3));

            // TRY / CATCH
            try
            {
                int x = int.Parse("abc");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro de formato");
            }

            // EXPRESSÃO LAMBDA
            Func<int, int> dobro = n => n * 2;
            Console.WriteLine(dobro(5));

        }
    }
}