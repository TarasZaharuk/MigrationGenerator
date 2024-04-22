using System.Text.RegularExpressions;
namespace GenerateMigration.MigrationStatementGenerators
{
    public class StoredProcedureModifiedMigrationGenerator : SQLMigrationStatementGenerator
    {
        public override string GenereteMigrationStatement(string statementCode)
        {
            string originalQuery = statementCode;

            string pattern = Regex.Escape("CREATE PROCEDURE");
            string updatedQuery = Regex.Replace(originalQuery, pattern, "CREATE OR ALTER PROCEDURE ", RegexOptions.IgnoreCase);
            updatedQuery += Environment.NewLine + "GO" + Environment.NewLine + Environment.NewLine;
            return updatedQuery;
        }
    }
}
