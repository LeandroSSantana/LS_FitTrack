using Microsoft.Data.SqlClient;

public class TreinoExercicioRepository : Database, ITreinoExercicioRepository
{
    public void Create(TreinoExercicio treinoExercicio)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO Aluno VALUES(@treino_id, @exercicio_id)";
        
        cmd.Parameters.AddWithValue("@treino_id", treinoExercicio.TreinoId);
        cmd.Parameters.AddWithValue("@exercicio_id", treinoExercicio.ExercicioId );
        
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Aluno WHERE treinoExercicio_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<TreinoExercicio> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM TreinoExercio";

        SqlDataReader reader = cmd.ExecuteReader();

        List<TreinoExercicio> treinoExercicios = new List<TreinoExercicio>();

        while (reader.Read())
        {
            TreinoExercicio te = new TreinoExercicio();
            te.TreinoExercicioId = reader.GetInt32(0);
            te.TreinoId = reader.GetInt32(1);
            te.ExercicioId = reader.GetInt32(2);

            treinoExercicios.Add(te);
        }

        return treinoExercicios;
    }

    public TreinoExercicio Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM TreinoExercicio WHERE treinoExercicio_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            TreinoExercicio treinoExercicio = new TreinoExercicio();
            treinoExercicio.TreinoExercicioId = reader.GetInt32(0);
            treinoExercicio.TreinoId = reader.GetInt32(1);
            treinoExercicio.ExercicioId = reader.GetInt32(2);     
                     
            return treinoExercicio;
        }

        return null;
    }

    public void Update(int id, TreinoExercicio treinoExercicio)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE TreinoExercicio SET treino_id = @treino_id, exercicio_id = @exercicio_id, WHERE treinExercicioId = @id";

        cmd.Parameters.AddWithValue("@treino_id", treinoExercicio.TreinoId);
        cmd.Parameters.AddWithValue("@exercicio_id", treinoExercicio.ExercicioId);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

}
