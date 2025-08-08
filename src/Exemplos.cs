namespace AlunoNota;

enum Direcao
{
    Norte,
    Sul,
    Leste,
    Oeste
}

class Exemplos
{
    public static void Direcao(Direcao direcao)
    {
        switch (direcao)
        {
            case AlunoNota.Direcao.Norte:
                Console.WriteLine("Você está indo para cima.");
                break;
            case AlunoNota.Direcao.Sul:
                Console.WriteLine("Você está indo para baixo.");
                break;
            case AlunoNota.Direcao.Leste:
                Console.WriteLine("Você está indo para direita.");
                break;
            case AlunoNota.Direcao.Oeste:
                Console.WriteLine("Você está indo para esquerda.");
                break;
            default:
                Console.WriteLine("Direção inválida.");
                break;
        }
    }

    public void Principal()
    {
        //Program.Direcao(AlunoNota.Direcao.Norte);

        string[] Turma = new string[0];
        Turma = new string[] { "João", "Maria", "Pedro", "Ana" };

        List<string> TurmaEmLista = Turma.ToList();
        TurmaEmLista.Insert(0, "Lucas");
        TurmaEmLista.RemoveAt(TurmaEmLista.Count - 1);

        foreach (string Aluno in TurmaEmLista)
        {
            Console.WriteLine(Aluno);
        }

        int[] Notas = new[] { 5, 7, 9, 10 };
        int NumeroDeNotas = Notas.Length;

        for (int i = 0; i < NumeroDeNotas; i++)
        {
            Console.WriteLine($"Nota {i + 1}: {Notas[i]}");
        }

        //FIFO
        Queue<string> Fila = new Queue<string>();
        Fila.Enqueue("João");
        Fila.Enqueue("Maria");
        Fila.Enqueue("Pedro");

        string Nome = Fila.Dequeue(); // Remove o primeiro elemento da fila

        //LIFO
        Stack<int> Pilha = new Stack<int>();
        Pilha.Push(1);
        Pilha.Push(2);
        Pilha.Push(3);

        int Numero = Pilha.Pop(); // Remove o último elemento adicionado

        Console.Write("Digite o nome do aluno: ");
        string NomeCompleto = Console.ReadLine();

        Console.Write("Digite a nota do aluno: ");
        float Nota = float.Parse(Console.ReadLine());

        if (Nota > 0 && Nota < 3)
        {
            Console.Write("Nota Baixa!");
        }
        else if (Nota >= 3 && Nota < 8)
        {
            Console.Write("Nota Média!");
        }
        else if (Nota >= 8 && Nota < 9.9)
        {
            Console.Write("Nota Alta!");
        }
        else if (Nota == 10)
        {
            Console.Write("Nota Perfeita!");
        }
        else
        {
            Console.Write("Nota Inválida!");
        }
        
    }
}