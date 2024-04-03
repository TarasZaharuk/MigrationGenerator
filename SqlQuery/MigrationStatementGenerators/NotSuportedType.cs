using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQuery.MigrationStatementGenerators
{
    internal class NotSuportedType : SQLMigrationStatementGenerator
    {
        public override string GenereteMigrationStatement(string filePath)
        {
            string originalQuery = GetFileContent(filePath);
            string updatedQuery = "/*" + "NOT SUPORTED QUERY TYPE" + Environment.NewLine + originalQuery + Environment.NewLine + "*/";
            return updatedQuery;
        }
    }
}
