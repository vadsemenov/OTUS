namespace Database
{
    public static class DBConnectionString
    {
        public static string GetConnectionString()
        {
            Npgsql.NpgsqlConnectionStringBuilder csb = new Npgsql.NpgsqlConnectionStringBuilder();
            csb.Host = "localHost";//"127.0.0.1";
            //csb.Port = 5432;
            csb.Database = "otus_school";

            // csb.IntegratedSecurity = false;
            csb.Username = "postgres";
            csb.Password = "12345";
            csb.CommandTimeout = 300;
            //csb.ApplicationName = "ODataTest";

            return csb.ConnectionString;
        }
    }
}