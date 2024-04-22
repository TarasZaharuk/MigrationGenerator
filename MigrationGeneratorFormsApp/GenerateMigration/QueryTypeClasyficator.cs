using GenerateMigration.Abstractions;
using GenerateMigration.Models;
namespace GenerateMigration
{
    public class QueryTypeClasyficator : IQueryTypeClasyficator
    {
        public QueryType GetQueryType(string filePath, SqlFileMode fileMode)
        {
            string query;
            using StreamReader streamReader = new StreamReader(filePath);
            query = streamReader.ReadToEnd();
            
            if ((fileMode == SqlFileMode.Created || fileMode == SqlFileMode.Updated)  && ContainsKeywordExactlyOnce(query, "CREATE FUNCTION"))
                return QueryType.Function;

            if ((fileMode == SqlFileMode.Created || fileMode == SqlFileMode.Updated) && ContainsKeywordExactlyOnce(query, "CREATE PROCEDURE"))
                return QueryType.StoredProcedure;
            
            if (fileMode == SqlFileMode.Created && ContainsKeywordExactlyOnce(query, "CREATE TABLE"))
                return QueryType.NewTable;

            return QueryType.NotRecognized;
        }

        private bool ContainsKeywordExactlyOnce(string query, string statementIdentifierKeyWord) {
            if (string.IsNullOrEmpty(query) || string.IsNullOrEmpty(statementIdentifierKeyWord))
                return false;

            query = query.ToLower();
            statementIdentifierKeyWord = statementIdentifierKeyWord.ToLower();

            int firstIndex = query.IndexOf(statementIdentifierKeyWord);
            if (firstIndex == -1)
                return false;

            int secondIndex = query.IndexOf(statementIdentifierKeyWord, firstIndex + statementIdentifierKeyWord.Length);

            return secondIndex == -1;
        }
    }
}
