namespace GenerateMigration.MigrationStatementGenerators
{
    internal class NotSuportedQueryGenerator : SQLMigrationStatementGenerator
    {
        public override string GenereteMigrationStatement(string filePath)
        {
            string originalQuery = GetFileContent(filePath);
            string updatedQuery = "/*" + "NOT SUPORTED QUERY TYPE" + Environment.NewLine + originalQuery + Environment.NewLine + "*/";
            return updatedQuery;
        }
    }
}
