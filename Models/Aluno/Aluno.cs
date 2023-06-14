public class Aluno{
    // propriedades
    private int alunoId;
    private string nome;    
    private int idade;    
    private decimal altura;    
    private decimal peso;    
    private string genero;    
    private string email;

    public List<Exercicio> exercicios;
    
    public int AlunoId{
        get {return this.alunoId;}
        set { this.alunoId = value;}
    }
    public string Nome{
        get { return this.nome; }
        set { this.nome = value; }
    }
    public int Idade{
        get { return this.idade; }
        set { this.idade = value; }
    }
    public decimal Altura{
        get { return this.altura; }
        set { this.altura = value; }
    }
    public decimal Peso{
        get { return this.peso; }
        set { this.peso = value; }
    }
    public string Genero{
        get { return this.genero; }
        set { this.genero = value; }
    }
    public string Email{
        get { return this.email; }
        set { this.email = value; }
    }
 
}
