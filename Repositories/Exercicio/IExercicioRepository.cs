public interface IExercicioRepository
{
    List<Exercicio> Read();    
    Exercicio Read(int id);
    void Create (Exercicio exercicio);
    void Delete (int id);
    void Update (int id, Exercicio exercicio);
    
    
}
