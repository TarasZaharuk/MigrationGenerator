namespace GenerateMigration.Abstractions
{
    public interface IGitChangesProvider
    {
        List<string> GetCreatedFiles(string gitRepositoryPath);

        List<string> GetDeletedFiles(string gitRepositoryPath);

        List<string> GetModifiedFiles(string gitRepositoryPath);  
    }
}
