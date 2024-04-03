using SqlQuery.Abstractions;
using SqlQuery.Models;
using System.Diagnostics;

namespace SqlQuery
{
    public class GitChangesProvider : IGitChangesProvider
    {
        public List<string> GetUntrackedFiles(string gitRepositoryPath)
        {
            return GetSqlFiles(gitRepositoryPath, GetGitFilesMode.UntrackedFiles);
        }

        public List<string> GetModifiedFiles(string gitRepositoryPath)
        {
            return GetSqlFiles(gitRepositoryPath, GetGitFilesMode.ModifiedFiles);
        }

        public List<string> GetCreatedFiles(string gitRepositoryPath)
        {
            return GetSqlFiles(gitRepositoryPath, GetGitFilesMode.AdedFiles);
        }

        public List<string> GetDeletedFiles(string gitRepositoryPath)
        {
            return GetSqlFiles(gitRepositoryPath, GetGitFilesMode.AdedFiles);
        }

        private List<string> GetGitChangesFilesPathes(string gitRepositoryPath)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WorkingDirectory = gitRepositoryPath,
                FileName = "git",
                Arguments = "status --porcelain",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                List<string> files = [];
                StringReader reader = new(output);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    files.Add(line);
                }
                return files;
            }
        }

        private List<string> GetSqlFiles(string gitRepositoryPath, string getGitFilesMode)
        {
            if (!Path.Exists(gitRepositoryPath))
                throw new Exception($"Git Repository path does not exist.");
            string sqlFile;
            List<string> files = GetGitChangesFilesPathes(gitRepositoryPath);
            List<string> sqlFiles = new List<string>();
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".sql" && file.StartsWith(getGitFilesMode))
                {
                    sqlFile = file.Substring(3).Trim();
                    while (!Path.Exists(Path.Combine(gitRepositoryPath, sqlFile)))
                    {
                        gitRepositoryPath = Directory.GetParent(gitRepositoryPath)?.FullName ?? throw new Exception("file not founded");
                    }
                    sqlFile = Path.Combine(gitRepositoryPath, sqlFile);
                    sqlFiles.Add(sqlFile);
                }
            }

            return sqlFiles;
        }
    }
}
