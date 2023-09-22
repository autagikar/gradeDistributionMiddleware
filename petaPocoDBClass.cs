using PetaPoco;
namespace gradeDistributionMiddleware;

    public class petaPocoDBClass
    {
        private readonly Database _database;

        public petaPocoDBClass(string connectionString)
        {
            _database = new Database(connectionString, "System.Data.SqlClient");
        }

        //Get 
        public List<dbo_classEntries> GetAllData(string table_name)
        {
            return _database.Fetch<dbo_classEntries>("SELECT * FROM " + table_name);
        }

        // POST
        public void InsertData(string table_name, string primary_key, dbo_classEntries data_entry)
    {
        _database.Insert(table_name, primary_key, data_entry);
    }

        // Get By Id



    }

