using Microsoft.Data.SqlClient;

public class TreinoRepository : Database, ITreinoRepository
{
    public void Create(Treino treino)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"INSERT INTO Treino (aluno_id, dia_semana, descricao) 
                          VALUES (@aluno_id, @dia_semana, @descricao)"
        ;
    
        cmd.Parameters.AddWithValue("@aluno_id", treino.AlunoId);
        cmd.Parameters.AddWithValue("@dia_semana", treino.DiaSemana);
        cmd.Parameters.AddWithValue("@descricao", treino.Descricao);

        cmd.ExecuteNonQuery();
    }


    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Treino WHERE treino_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Treino> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Treino";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Treino> treinos = new List<Treino>();

        while (reader.Read())
        {
            Treino t = new Treino();
            t.TreinoId = reader.GetInt32(0);
            t.DiaSemana = reader.GetString(1);
            t.Descricao = reader.GetString(2);
            t.AlunoId = reader.GetInt32(3);

            treinos.Add(t);
        }

        return treinos;
    }

    public Treino Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Treino WHERE treino_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Treino treino = new Treino();
            treino.TreinoId = reader.GetInt32(0);
            treino.DiaSemana = reader.GetString(1);
            treino.Descricao = reader.GetString(2);
            treino.AlunoId = reader.GetInt32(3);

            return treino;
        }

        return null;
    }

    public List<Treino> ReadTreinos(int id)
    {
        List<Treino> treinos = new List<Treino>();
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"SELECT * FROM Exercicio 
        JOIN aluno_exercicio 
        on aluno_exercicio.exercicio_id = 
        Exercicios.exercicio_id 
        where aluno_exercicio.aluno_id = @alunoId";
        
        cmd.Parameters.AddWithValue("@alunoId", id);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Treino treino = new Treino();
            treino.TreinoId = reader.GetInt32(0);
            treino.DiaSemana = reader.GetString(1);
            treino.Descricao = reader.GetString(2);
            treino.AlunoId = reader.GetInt32(3);
            treinos.Add(treino);
        }

        return treinos;
    }

    public void Update(int id, Treino treino)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"UPDATE treino SET 
            treino_id = @treino_id, 
            dia_semana = @dia_semana, 
            descricao = @descricao, 
            aluno_id = @aluno_id WHERE 
            treino_id = @id";

        cmd.Parameters.AddWithValue("@treino_id", treino.TreinoId);
        cmd.Parameters.AddWithValue("@dia_semana", treino.DiaSemana);
        cmd.Parameters.AddWithValue("@descricao", treino.Descricao);
        cmd.Parameters.AddWithValue("@aluno_id", treino.AlunoId);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Treino> Search(string keyword)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Treino WHERE Nome LIKE @keyword";

        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

        SqlDataReader reader = cmd.ExecuteReader();

        List<Treino> treinos = new List<Treino>();

        while (reader.Read())
        {
            Treino treino = new Treino();
            treino.TreinoId = reader.GetInt32(0);
            treino.DiaSemana = reader.GetString(1);
            treino.Descricao = reader.GetString(2);
            treino.AlunoId = reader.GetInt32(3);

            treinos.Add(treino);
        }

        return treinos;
    }

    public List<Exercicio> ReadExercicios()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Exercicio";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Exercicio> exercicios = new List<Exercicio>();

        while(reader.Read())
        {
            Exercicio e = new Exercicio();
            e.ExercicioId = reader.GetInt32(0);
            e.Nome = reader.GetString(1);
            
            exercicios.Add(e);
        }
        return exercicios;
    }
}