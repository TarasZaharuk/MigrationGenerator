using System.Text;
using System.Text.RegularExpressions;

namespace GenerateMigration.MigrationStatementGenerators
{
    public class CreateNewTableMigrationGenerator : SQLMigrationStatementGenerator
    {
        public override string GenereteMigrationStatement(string statementCode)
        {
            string originalQuery = statementCode;

            Regex regex = new(@"(?<=\[[^\]]+\]\.\[)[^\]]+(?=\])");
            Match match = regex.Match(originalQuery);
            string tableName = match.Value;

            List<string> lines = originalQuery.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            StringBuilder stringBuilder = new();
            foreach (string line in lines)
            {
                stringBuilder.AppendLine('\t' + line);
            }
            originalQuery = stringBuilder.ToString();
            originalQuery = Environment.NewLine +
                    $"IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='{tableName}' and xtype='U')"
                    + Environment.NewLine +
                    "BEGIN"
                    + Environment.NewLine +
                    originalQuery
                    + Environment.NewLine +
                    "END"
                    + Environment.NewLine +
                    "GO" + Environment.NewLine;

            return originalQuery;
        }
    }
}
    