
using GenerateMigration.Models;

namespace GenerateMigration.Abstractions
{
    public interface IQueryTypeClasyficator
    {
        QueryTypes GetQueryType(string filePath);
    }
}
