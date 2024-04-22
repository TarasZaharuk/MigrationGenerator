using GenerateMigration.Abstractions;
using LibGit2Sharp;

namespace GenerateMigration
{
    public class GitChangesProvider : IGitChangesProvider
    {
        public List<string> GetCreatedFiles(string gitRepositoryPath)
        {
            return GetChanges(gitRepositoryPath, ChangeKind.Added);
        }

        public List<string> GetDeletedFiles(string gitRepositoryPath)
        {
            return GetChanges(gitRepositoryPath, ChangeKind.Deleted);
        }

        public List<string> GetModifiedFiles(string gitRepositoryPath)
        {
            return GetChanges(gitRepositoryPath, ChangeKind.Modified);
        }

        private List<string> GetChanges(string gitRepositoryPath, ChangeKind changeKind)
        {
            using (var repo = new Repository(gitRepositoryPath))
            {
                var changes = repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree, DiffTargets.Index | DiffTargets.WorkingDirectory);
                return changes
                    .Where(c => c.Path.EndsWith(".sql") && c.Status == changeKind)
                    .Select(c => Path.Combine(gitRepositoryPath, c.Path))
                    .ToList();
            }
        }
    }
}
