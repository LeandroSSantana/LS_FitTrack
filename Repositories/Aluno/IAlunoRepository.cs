public interface IAlunoRepository
{
    List<Aluno> Read();
    List<Exercicio> ReadExercicios(int id);    
    Aluno Read(int id);
    void Create (Aluno aluno);
    void Delete (int id);
    void Update (int id, Aluno aluno);
    
    
}