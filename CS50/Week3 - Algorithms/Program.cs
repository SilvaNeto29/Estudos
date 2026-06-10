Console.WriteLine("Qual busca você deseja realizar?\n");
Console.WriteLine("Busca linear (1)\nBusca binária (2)\n");
int tipoBusca = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("Qual número deseja buscar?\n");
int numero = int.Parse(Console.ReadLine() ?? "0");


int[] array = { 47, 3, 91, 14, 68, 25, 83, 7, 56, 39, 72, 18, 44, 95, 11, 62, 30, 77, 5, 88, 21, 50 };

if (tipoBusca == 1)
{
    //Busca linear
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == numero)
        {
            System.Console.WriteLine($"Número encontrado na posição {i}");
            break;
        }

        if (i == array.Length - 1)
        {
            System.Console.WriteLine("Número não encontrado");
        }
    }
}
else if (tipoBusca == 2)
{
    //Busca binária
    array.Sort(); //Só funciona com arrays em ordem
    int inicio, fim, meio;
    bool encontrado = false;
    inicio = 0;
    fim = array.Length - 1;

    while (inicio <= fim)
    {
        meio = (inicio + fim) / 2;
        if (array[meio] == numero)
        {
            System.Console.WriteLine($"Número encontrado na posição {meio}");
            encontrado = true;
            break;
        }

        if (array[meio] < numero)
        {
            inicio = meio + 1;
        }
        else
        {
            fim = meio - 1;
        }
    }

    if (!encontrado)
    {
        System.Console.WriteLine($"Número {numero} não encontrado");
    }
}
