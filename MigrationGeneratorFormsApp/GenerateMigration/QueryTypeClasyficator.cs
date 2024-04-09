using GenerateMigration.Abstractions;
using GenerateMigration.Models;
namespace GenerateMigration
{
    public class QueryTypeClasyficator : IQueryTypeClasyficator
    {
        public QueryTypes GetQueryType(string filePath)
        {
            string query;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                query = streamReader.ReadToEnd();
            }
            
            if (query.StartsWith("CREATE FUNCTION") || query.StartsWith("CREATE OR ALTER FUNCTION"))
                return QueryTypes.Function;
            if (query.StartsWith("CREATE PROCEDURE") || query.StartsWith("CREATE OR ALTER PROCEDURE"))
                return QueryTypes.StoredProcedure;

            return QueryTypes.NotRecognized;
        }
    }
}
