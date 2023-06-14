public interface ITreinoRepository
{
    List<Treino> Read();
    List<Treino> ReadTreinos(int id); 
    Treino Read(int id);
    void Create (Treino treino);
    void Delete (int id);
    void Update (int id, Treino treino);
    List<Exercicio> ReadExercicios();      
}