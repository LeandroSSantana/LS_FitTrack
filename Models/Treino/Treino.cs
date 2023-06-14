public class Treino{
    
    private int treinoId;
    private string diaSemana;    
    private string descricao;    
    private int alunoId;

    public int selectedExcercicio {get; set;}   

    public List<Exercicio> exercicios = new List<Exercicio>();

    public List<Exercicio> selectedExercicios = new List<Exercicio>();
    
    public int TreinoId{
        get {return this.treinoId;}
        set { this.treinoId = value;}
    }
    public string DiaSemana{
        get { return this.diaSemana; }
        set { this.diaSemana = value; }
    
    }

    public string Descricao{
        get { return this.descricao; }
        set { this.descricao = value; }
    }
    public int AlunoId{
        get { return this.alunoId; }
        set { this.alunoId = value; }
    }
   
}
