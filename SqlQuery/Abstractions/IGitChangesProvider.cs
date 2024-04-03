using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQuery.Abstractions
{
    public interface IGitChangesProvider
    {
        List<string> GetUntrackedFiles(string gitRepositoryPath);
        List<string> GetCreatedFiles(string gitRepositoryPath);

        List<string> GetDeletedFiles(string gitRepositoryPath);

        List<string> GetModifiedFiles(string gitRepositoryPath);  
    }
}
