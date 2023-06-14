public interface ITreinoExercicioRepository
{
    List<TreinoExercicio> Read();     
    TreinoExercicio Read(int id);
    void Create (TreinoExercicio treinoExercicio);
    void Delete (int id);
    void Update (int id, TreinoExercicio treinoExercicio);
    
    
}