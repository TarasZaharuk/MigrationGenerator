using System.Text.RegularExpressions;

namespace GenerateMigration.MigrationStatementGenerators
{
    public class FunctionModifiedMigrationGenerator : SQLMigrationStatementGenerator
    {
        public override string GenereteMigrationStatement(string statementCode)
        {
            string originalQuery = statementCode;

            string pattern = Regex.Escape("CREATE FUNCTION");
            string updatedQuery = Regex.Replace(originalQuery, pattern, "CREATE OR ALTER FUNCTION", RegexOptions.IgnoreCase);
            updatedQuery += Environment.NewLine + "GO" + Environment.NewLine + Environment.NewLine;
            return updatedQuery;
        }
    }
}
