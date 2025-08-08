namespace AlunoNota;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine("*********************************************************");
        Console.WriteLine("*************** Sistema de alunos e notas ***************");
        Console.WriteLine("*********************************************************");

        List<Aluno> alunos = new();
        Aluno aluno;
        do
        {
            aluno = new Aluno();

            Console.WriteLine("");
            Console.Write("Informe o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            foreach (Disciplinas disciplina in (Disciplinas[])Enum.GetValues(typeof(Disciplinas)))
            {
                Console.WriteLine("");

                Console.Write($"Informe a nota do(a) aluno(a) {aluno.Nome} para a disciplina {disciplina}: ");
                string? notaTemp = Console.ReadLine();

                while (string.IsNullOrEmpty(notaTemp) || !float.TryParse(notaTemp, out float nota) || nota < 0 || nota > 10)
                {
                    Console.WriteLine("Nota inválida. Por favor, insira uma nova nota.\n");
                    Console.Write($"Informe a nota do(a) aluno(a) {aluno.Nome} para a disciplina {disciplina}: ");
                    notaTemp = Console.ReadLine();
                }

                aluno.NotaPorDisciplina.Add(disciplina, float.Parse(notaTemp));
            }

            alunos.Add(aluno);

        } while (ValidarSimNao());

        Console.WriteLine("");
        Console.WriteLine("*************** REPORT ***************");

        AprovarReprovarAlunos(alunos);
        CalculoMediaPorAluno(alunos);
        EscreveListaAlunos(alunos);
        CalculoMenorCR(alunos);
    }
    private static bool ValidarSimNao()
    {
        char resposta;

        do
        {
            Console.WriteLine("");
            Console.Write("Deseja cadastrar outro aluno(a)? (S/N) ");
            char entrada = Console.ReadKey().KeyChar;
            resposta = Char.ToUpper(entrada);

            if (resposta == 'S')
            {
                return true;
            }
            else if (resposta == 'N')
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nEntrada inválida. Por favor, digite S ou N.");
            }

        } while (true);

    }
    private static void AprovarReprovarAlunos(List<Aluno> alunos)
    {
        foreach (var aluno in alunos)
        {
            var itemRecuperado = aluno.NotaPorDisciplina.Sum(i => i.Value) / Enum.GetValues(typeof(Disciplinas)).Length;

            if (itemRecuperado >= 7)
            {
                aluno.status = Status.Aprovado;
            }
            else
            {
                aluno.status = Status.Reprovado;
            }
        }
    }
    private static void CalculoMediaPorAluno(List<Aluno> alunos)
    {
        foreach (var aluno in alunos)
        {
            float notas = 0f;

            foreach (KeyValuePair<Disciplinas, float> nota in aluno.NotaPorDisciplina)
            {
                notas += nota.Value;
            }

            aluno.MediaGeral = notas / Enum.GetValues(typeof(Disciplinas)).Length;
        }
    }
    private static void EscreveListaAlunos(List<Aluno> alunos)
    {
        Console.WriteLine("");
        string mensagem = string.Empty;

        foreach (var aluno in alunos)
        {
            mensagem = $"Aluno(a): {aluno.Nome} \nMédia Geral: {aluno.MediaGeral.ToString("F2")} \nStatus: {aluno.status}";
            mensagem += "\nNotas por disciplina: ";

            foreach (KeyValuePair<Disciplinas, float> nota in aluno.NotaPorDisciplina)
            {
                mensagem += $"\n{nota.Key}: {nota.Value.ToString("F2")}";
            }

            Console.WriteLine("\n" + mensagem);
        }
    }
    private static void CalculoMenorCR(List<Aluno> alunos)
    {
        Aluno? aluno = alunos.MinBy(a => a.MediaGeral);

        if (aluno != null)
        {
            Console.WriteLine($"\nO aluno com a menor média é: {aluno.Nome} com média {aluno.MediaGeral.ToString("F2")}");
        }
        else
        {
            Console.WriteLine("\nNenhum aluno cadastrado.");
        }
    }
}

public class Aluno
{
    public string Nome { get; set; }

    public char PrimeiraLetra { get; set; }

    private float _mediaGeral { get; set; }

    public float MediaGeral
    {
        get { return _mediaGeral; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("A nota não pode ser negativa.");
            }
            _mediaGeral = value;
        }
    }

    public Status status;

    public Dictionary<Disciplinas, float> NotaPorDisciplina { get; set; } = new();

    public bool Ativo { get; set; }

    public DateTime Avaliacao { get; set; }

}

public enum Status
{
    None = 0,
    Aprovado = 1,
    Reprovado = 2
}

public enum Disciplinas
{
    Historia,
    Matematica,
    Fisica,
    Geografia
}