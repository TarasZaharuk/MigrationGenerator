using SqlQuery.Abstractions;
using SqlQuery.MigrationStatementGenerators;
using SqlQuery.Models;

namespace SqlQuery
{
    public class SqlMigrationGenerator
    {
        private readonly IGitChangesProvider _gitChanges = new GitChangesProvider();

        public string GenerateMigration(string gitRepositoryPath)
        {
            StoredProcedureUpdatedMigration procedure = new();
            FunctionUpdateMigration function = new();
            NotSuportedType notSuportedType = new();

            List<string> filesPath = [];
            filesPath.AddRange(_gitChanges.GetCreatedFiles(gitRepositoryPath));
            filesPath.AddRange(_gitChanges.GetModifiedFiles(gitRepositoryPath));
            filesPath.AddRange(_gitChanges.GetUntrackedFiles(gitRepositoryPath));

            Dictionary<QueryTypes,SQLMigrationStatementGenerator> statementGenerator = new();
            statementGenerator.Add(QueryTypes.StoredProcedure,procedure);
            statementGenerator.Add(QueryTypes.Function, function);
            statementGenerator.Add(QueryTypes.NotRecognized, notSuportedType);

            string migration = null!;
            QueryTypeClasyficator queryTypeClasyficator = new();

            foreach (string file in filesPath)
            {
                migration += statementGenerator[queryTypeClasyficator.GetQueryType(file)].GenereteMigrationStatement(file);
            }
            return migration;
        }
    }
}
