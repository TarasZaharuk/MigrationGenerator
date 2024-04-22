using GenerateMigration.Models;

namespace GenerateMigration.Abstractions
{
    public interface IQueryTypeClasyficator
    {
        QueryType GetQueryType(string filePath, SqlFileMode fileMode);
    }
}
