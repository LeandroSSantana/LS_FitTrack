public class Exercicio
{
    private int exercicioId;
    private int aluno_id;
    private string dia;
    private string nome;
    private string musculo;
    private string repeticao;

    public int ExercicioId
    {
        get { return exercicioId; }
        set { exercicioId = value; }
    }

    public int Aluno_id
    {
        get { return aluno_id; }
        set { aluno_id = value; }
    }

    public string Dia
    {
        get { return dia; }
        set { dia = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Musculo
    {
        get { return musculo; }
        set { musculo = value; }
    }

    public string Repeticao
    {
        get { return repeticao; }
        set { repeticao = value; }
    }
}
