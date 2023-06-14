using System.Linq;
public class AlunoMemoryRepository : IAlunoRepository
{
    List<Aluno> alunos = new List<Aluno>();
    public void Create(Aluno aluno)
    {
        alunos.Add(aluno);
    }

    public void Delete(int id)
    {
        var aluno = (from a in alunos 
                        where a.AlunoId == id 
                        select a)
                        .FirstOrDefault();      
        alunos.Remove(aluno);
    }

    public List<Aluno> Read()
    {
        return alunos;
    }

    public Aluno Read(int id)
    {
            return alunos.FirstOrDefault( p=> p.AlunoId == id);
    }

    public void Update(int id, Aluno aluno)
    {
        var p = Read(aluno.AlunoId);

        p.Nome = aluno.Nome;
        
    }

    public List<Exercicio> ReadExercicios(int id)
    {
        return null;
    }
}
