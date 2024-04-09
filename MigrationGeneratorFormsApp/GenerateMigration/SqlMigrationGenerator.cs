using GenerateMigration.Abstractions;
using GenerateMigration.MigrationStatementGenerators;
using GenerateMigration.Models;

namespace GenerateMigration
{
    public class SqlMigrationGenerator
    {
        private readonly IGitChangesProvider _gitChanges;
        private readonly IQueryTypeClasyficator _queryTypeClasyficator;
        private Dictionary<QueryTypes, SQLMigrationStatementGenerator> statementGenerator = [];
        StoredProcedureModifiedMigrationGenerator _procedureMigrationGenerator = new();
        FunctionModifiedMigrationGenerator _functionMigrationGenerator = new();
        NotSuportedQueryGenerator _notSuportedQueryGenerator = new();

        public SqlMigrationGenerator(IGitChangesProvider gitChanges,IQueryTypeClasyficator queryTypeClasyficator) 
        {
            _gitChanges = gitChanges;
            _queryTypeClasyficator = queryTypeClasyficator;
            statementGenerator.Add(QueryTypes.StoredProcedure, _procedureMigrationGenerator);
            statementGenerator.Add(QueryTypes.Function, _functionMigrationGenerator);
            statementGenerator.Add(QueryTypes.NotRecognized, _notSuportedQueryGenerator);
        }  
        
        public string GenerateMigration(string gitRepositoryPath)
        {
            List<string> filesPath = [];
            filesPath.AddRange(_gitChanges.GetCreatedFiles(gitRepositoryPath));
            filesPath.AddRange(_gitChanges.GetModifiedFiles(gitRepositoryPath));

            string migration = null!;

            foreach (string file in filesPath)
            {
                migration += statementGenerator[_queryTypeClasyficator.GetQueryType(file)].GenereteMigrationStatement(file);
            }

            return migration;
        }
    }
}
