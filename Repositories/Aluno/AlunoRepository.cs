using Microsoft.Data.SqlClient;

public class AlunoRepository : Database, IAlunoRepository
{
    public void Create(Aluno aluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO Aluno VALUES(@nome, @idade, @altura, @peso, @genero, @email)";

        cmd.Parameters.AddWithValue("@nome", aluno.Nome);
        cmd.Parameters.AddWithValue("@idade", aluno.Idade);
        cmd.Parameters.AddWithValue("@altura", aluno.Altura);
        cmd.Parameters.AddWithValue("@peso", aluno.Peso);
        cmd.Parameters.AddWithValue("@genero", aluno.Genero);
        cmd.Parameters.AddWithValue("@email", aluno.Email);

        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Aluno WHERE aluno_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Aluno> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Aluno";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Aluno> alunos = new List<Aluno>();

        while (reader.Read())
        {
            Aluno a = new Aluno();
            a.AlunoId = reader.GetInt32(0);
            a.Nome = reader.GetString(1);
            a.Idade = reader.GetInt32(2);
            a.Altura = reader.GetDecimal(3);
            a.Peso = reader.GetDecimal(4);
            a.Genero = reader.GetString(5);
            a.Email = reader.GetString(6);

            alunos.Add(a);
        }

        return alunos;
    }

    public Aluno Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Aluno WHERE aluno_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Aluno aluno = new Aluno();
            aluno.AlunoId = reader.GetInt32(0);
            aluno.Nome = reader.GetString(1);
            aluno.Idade = reader.GetInt32(2);
            aluno.Altura = reader.GetDecimal(3);
            aluno.Peso = reader.GetDecimal(4);
            aluno.Genero = reader.GetString(5);
            aluno.Email = reader.GetString(6);          
                     
            return aluno;
        }

        return null;
    }

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



    public List<Exercicio> ReadExercicios(int id) 
    {
        List<Exercicio> exercicios = new List<Exercicio>();
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"
            SELECT *
            FROM Exercicio            
            WHERE aluno_id = @id"
        ;
        
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Exercicio exercicio = new Exercicio();
            exercicio.ExercicioId = reader.GetInt32(0);
            exercicio.Aluno_id = reader.GetInt32(1);
            exercicio.Dia = reader.GetString(2);
            exercicio.Musculo = reader.GetString(3);
            exercicio.Nome = reader.GetString(4);
            exercicio.Repeticao = reader.GetString(5);        
            exercicios.Add(exercicio);
        } 

        reader.Close();            

        return exercicios;
    }


    public void Update(int id, Aluno aluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"
            UPDATE Aluno 
            SET nome = @nome, idade = @idade, 
            altura = @altura, peso = @peso, genero 
            = @genero, email = @email WHERE aluno_id = @id";

        cmd.Parameters.AddWithValue("@nome", aluno.Nome);
        cmd.Parameters.AddWithValue("@idade", aluno.Idade);
        cmd.Parameters.AddWithValue("@altura", aluno.Altura);
        cmd.Parameters.AddWithValue("@peso", aluno.Peso);
        cmd.Parameters.AddWithValue("@genero", aluno.Genero);
        cmd.Parameters.AddWithValue("@email", aluno.Email);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Aluno> Search(string keyword)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Aluno WHERE Nome LIKE @keyword";

        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

        SqlDataReader reader = cmd.ExecuteReader();

        List<Aluno> alunos = new List<Aluno>();

        while (reader.Read())
        {
            Aluno a = new Aluno();
            a.AlunoId = reader.GetInt32(0);
            a.Nome = reader.GetString(1);
            a.Idade = reader.GetInt32(2);
            a.Altura = reader.GetDecimal(3);
            a.Peso = reader.GetDecimal(4);
            a.Genero = reader.GetString(5);
            a.Email = reader.GetString(6);

            alunos.Add(a);
        }

        return alunos;
    }
}
