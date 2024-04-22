namespace GenerateMigration.Models
{
    public class FileMeta
    {
        public FileMeta(string path, SqlFileMode mode)
        {
            Path = path;
            Mode = mode;
        }
        public string Path { get; set; }
        public SqlFileMode Mode { get; set; }
    }
}
