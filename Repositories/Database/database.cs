using Microsoft.Data.SqlClient;

public abstract class Database : IDisposable
{
    protected SqlConnection conn;

    public Database() {

        string connectionString =  @"data source =LAPTOP-5G0C242E; 
        Initial Catalog=LSFitTrack; Integrated Security=true; TrustServerCertificate=True; MultipleActiveResultSets=True";

        conn = new SqlConnection(connectionString);
        conn.Open();
    }
    
    public void Dispose() {
        conn.Close();
    }
}
