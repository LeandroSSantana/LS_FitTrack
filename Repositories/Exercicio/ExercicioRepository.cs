using Microsoft.Data.SqlClient;

public class ExercicioRepository : Database, IExercicioRepository
{
   public void Create(Exercicio exercicio)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"INSERT INTO Exercicio (aluno_id, dia, musculo, nome, repeticao) 
                          VALUES (@aluno_id, @dia, @musculo, @nome, @repeticao)"
        ;

        cmd.Parameters.AddWithValue("@aluno_id", exercicio.Aluno_id);
        cmd.Parameters.AddWithValue("@dia", exercicio.Dia);
        cmd.Parameters.AddWithValue("@musculo", exercicio.Musculo);
        cmd.Parameters.AddWithValue("@nome", exercicio.Nome);
        cmd.Parameters.AddWithValue("@repeticao", exercicio.Repeticao);
        

        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Exercicio Where exercicio_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Exercicio> Read()
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
            e.Aluno_id = reader.GetInt32(1);
            e.Dia = reader.GetString(2);
            e.Musculo = reader.GetString(3);
            e.Nome = reader.GetString(4);
            e.Repeticao = reader.GetString(4);
               
            exercicios.Add(e);
        }
        return exercicios;
    }

    public Exercicio Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Exercicio WHERE exercicio_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        Exercicio e = null;

        if(reader.Read())
        {
            e = new Exercicio();
            e.ExercicioId = reader.GetInt32(0);
            e.Aluno_id = reader.GetInt32(1);
            e.Dia = reader.GetString(2);
            e.Musculo = reader.GetString(3);
            e.Nome = reader.GetString(4);
            e.Repeticao = reader.GetString(4);

        }
        return e;
    }

    public void Update(int id, Exercicio exercicio)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE Exercicio SET Nome = @nome WHERE exercicio_id = @id";

        cmd.Parameters.AddWithValue("@nome", exercicio.Nome);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Exercicio> Search(string keyword)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Exercicio WHERE Nome LIKE @keyword";
        
        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

        SqlDataReader reader = cmd.ExecuteReader();

        List<Exercicio> exercicios = new List<Exercicio>();

        while (reader.Read())
        {
            Exercicio e = new Exercicio();
            e.ExercicioId = reader.GetInt32(0);
            e.Nome = reader.GetString(0);
            e.Musculo = reader.GetString(1);
            
            exercicios.Add(e);
        }
        
        return exercicios;
    }
}


