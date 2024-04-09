using System.Text.RegularExpressions;
namespace GenerateMigration.MigrationStatementGenerators
{
    public class StoredProcedureModifiedMigrationGenerator : SQLMigrationStatementGenerator
    {

        public override string GenereteMigrationStatement(string filePath)
        {
            string originalQuery = GetFileContent(filePath);
            Regex regex = new(Regex.Escape("CREATE"));

            string updatedQuery = regex.Replace(originalQuery,"CREATE OR ALTER", 1);
            updatedQuery += Environment.NewLine + Environment.NewLine + "GO" + Environment.NewLine + Environment.NewLine;
            return updatedQuery;
        }
    }
}
