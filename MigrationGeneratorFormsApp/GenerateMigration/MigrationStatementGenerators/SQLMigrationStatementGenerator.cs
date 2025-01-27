﻿namespace GenerateMigration.MigrationStatementGenerators
{
    public abstract class SQLMigrationStatementGenerator
    {
        public abstract string GenereteMigrationStatement(string statementCode);
        internal string GetFileContent(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
