namespace SqlQuery.Models
{
    public struct GetGitFilesMode
    {
        public const string AdedFiles = "A  ";
        public const string ModifiedFiles = " M";
        public const string DeletedFiles = "D??";
        public const string UntrackedFiles = "?? ";
    }
}
