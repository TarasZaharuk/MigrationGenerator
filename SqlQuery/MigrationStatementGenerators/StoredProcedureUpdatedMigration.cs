using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlQuery.MigrationStatementGenerators
{
    public class StoredProcedureUpdatedMigration : SQLMigrationStatementGenerator
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
