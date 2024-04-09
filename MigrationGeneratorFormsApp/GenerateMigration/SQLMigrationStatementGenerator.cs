namespace GenerateMigration
{
    public abstract class SQLMigrationStatementGenerator
    {
        public abstract string GenereteMigrationStatement(string filePath);
        internal string GetFileContent(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }           
        }
    }
}
