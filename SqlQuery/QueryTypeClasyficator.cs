using SqlQuery.Models;
namespace SqlQuery
{
    internal class QueryTypeClasyficator
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
            if (query.StartsWith("CREATE PROCEDURE") || query.StartsWith("CREATE OR ALTER"))
                return QueryTypes.StoredProcedure;

            return QueryTypes.NotRecognized;
        }
    }
}
