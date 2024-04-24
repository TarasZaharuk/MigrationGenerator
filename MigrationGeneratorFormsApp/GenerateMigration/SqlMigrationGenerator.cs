using GenerateMigration.Abstractions;
using GenerateMigration.MigrationStatementGenerators;
using GenerateMigration.Models;

namespace GenerateMigration
{
    public class SqlMigrationGenerator
    {
        private readonly IGitChangesProvider _gitChangesProvider;
        private readonly IQueryTypeClasyficator _queryTypeClasyficator;
        private Dictionary<QueryType, SQLMigrationStatementGenerator> statementGenerators = [];

        public SqlMigrationGenerator(IGitChangesProvider gitChanges, IQueryTypeClasyficator queryTypeClasyficator)
        {
            _gitChangesProvider = gitChanges;
            _queryTypeClasyficator = queryTypeClasyficator;
            statementGenerators.Add(QueryType.StoredProcedure, new StoredProcedureModifiedMigrationGenerator());
            statementGenerators.Add(QueryType.Function, new FunctionModifiedMigrationGenerator());
            statementGenerators.Add(QueryType.NotRecognized, new NotSupportedQueryGenerator());
            statementGenerators.Add(QueryType.NewTable, new CreateNewTableMigrationGenerator());
        }

        public string GenerateMigration(string gitRepositoryPath)
        {
            List<FileMeta> filesMeta = [];
            filesMeta.AddRange(_gitChangesProvider.GetCreatedFiles(gitRepositoryPath).Select(t => new FileMeta(t, SqlFileMode.Created)));
            filesMeta.AddRange(_gitChangesProvider.GetModifiedFiles(gitRepositoryPath).Select(t => new FileMeta(t, SqlFileMode.Updated)));
            filesMeta.AddRange(_gitChangesProvider.GetDeletedFiles(gitRepositoryPath).Select(t => new FileMeta(t, SqlFileMode.Deleted)));

            var statementsForMigration = new List<SqlStatement>();
            foreach (var fileMeta in filesMeta)
            {
                QueryType queryType = _queryTypeClasyficator.GetQueryType(fileMeta.Path, fileMeta.Mode);
                string sqlCode = GetFileContent(fileMeta.Path); 
                statementsForMigration.Add(new SqlStatement(sqlCode, queryType));
            }

            string migration = string.Empty;
            foreach (var statementForMigration in statementsForMigration.OrderBy(t => t.QueryType))
            {
                SQLMigrationStatementGenerator? statementGenerator = statementGenerators.GetValueOrDefault(statementForMigration.QueryType) ?? new NotSupportedQueryGenerator();
                migration += statementGenerator.GenereteMigrationStatement(statementForMigration.Code);
            }

            return migration;
        }

        private string GetFileContent(string path)
        {
            using StreamReader streamReader = new StreamReader(path);
            return streamReader.ReadToEnd();
        }
    }
}
