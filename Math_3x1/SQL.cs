using System.Data;
using System.Data.SQLite;

namespace Math_3x1
{
    class SQL
    {
        private static string DBPath = AppContext.BaseDirectory + "db.db3";

        private static SQLiteConnection SQLiteConnection = new();
        private static SQLiteConnection DbConnection()
        {
            SQLiteConnection = new SQLiteConnection($"Data Source={DBPath}; Version=3;");
            SQLiteConnection.Open();
            return SQLiteConnection;
        }

        public static void CreateDBFileSQLite()
        {
            try 
            { 
                SQLiteConnection.CreateFile($"{DBPath}");
                try
                {
                    using var cmd = DbConnection().CreateCommand();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Number(id UINT UNIQUE, midvalues TEXT, steps INTEGER)";
                    cmd.ExecuteNonQuery();
                }
                catch { throw; }
            }
            catch { throw; }
        }

        public static ulong GetNextValue()
        {
            try
            {
                using var cmd = DbConnection().CreateCommand();
                cmd.CommandText = "SELECT MAX(id) FROM product;";
                SQLiteDataAdapter da = new(cmd.CommandText, DbConnection());
                ulong value = (ulong)cmd.ExecuteScalar();
                return value;
            }
            catch { throw; }
        }

        public static DataTable GetNumbers()
        {
            try
            {
                using var cmd = DbConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM Number";
                SQLiteDataAdapter da = new(cmd.CommandText, DbConnection());
                DataTable dt = new();
                da.Fill(dt);
                return dt;
            }
            catch { throw; }
        }

        public static DataTable GetNumbersId(ulong id)
        {
            try
            {
                using var cmd = DbConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM Number WHERE id=" + id;
                SQLiteDataAdapter da = new(cmd.CommandText, DbConnection());
                DataTable dt = new();
                da.Fill(dt);
                return dt;
            }
            catch { throw; }
        }

        public static void AddNumber(ulong id, string midvalues, int steps)
        {
            try
            {
                using var cmd = DbConnection().CreateCommand();
                cmd.CommandText = "INSERT INTO Number(id, midvalues, steps ) values (@id, @midvalues, @steps)";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@midvalues", midvalues);
                cmd.Parameters.AddWithValue("@steps", steps);
                cmd.ExecuteNonQuery();
            }
            catch { throw; }
        }

    }
}
