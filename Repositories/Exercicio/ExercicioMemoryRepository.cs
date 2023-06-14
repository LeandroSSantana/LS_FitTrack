using System.Linq;
public class ExercicioMemoryRepository : IExercicioRepository
{
    List<Exercicio> exercicios = new List<Exercicio>();
    public void Create(Exercicio exercicio)
    {
        exercicios.Add(exercicio);
    }

    public void Delete(int id)
    {
        var exercicio = (from e in exercicios 
                        where e.ExercicioId == id 
                        select e)
                        .FirstOrDefault();      
        exercicios.Remove(exercicio);
    }

    public List<Exercicio> Read()
    {
        return exercicios;
    }

    public Exercicio Read(int id)
    {
            return exercicios.FirstOrDefault( p=> p.ExercicioId == id);
    }

    public void Update(int id, Exercicio exercicio)
    {
        var e = Read(exercicio.ExercicioId);

        e.Nome = exercicio.Nome;
        e.Musculo = exercicio.Musculo;
        
    }
}
