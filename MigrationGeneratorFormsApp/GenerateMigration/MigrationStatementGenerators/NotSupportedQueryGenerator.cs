namespace GenerateMigration.MigrationStatementGenerators
{
    internal class NotSupportedQueryGenerator : SQLMigrationStatementGenerator
    {
        public override string GenereteMigrationStatement(string statementCode)
        {
            string updatedQuery = "/*" + "NOT SUPORTED QUERY TYPE" + Environment.NewLine + statementCode + Environment.NewLine + "*/";
            return updatedQuery;
        }
    }
}
