using SqlQuery;
using SqlQuery.Abstractions;
namespace SQLProject
{
    public partial class MigrationGenerator : Form
    {
        private readonly IGitChangesProvider _gitChangesProvider = new GitChangesProvider();
        private string _gitRepositoryPath = null!;
        public MigrationGenerator() => InitializeComponent();

        private void GenerateMigration_Click(object sender, EventArgs e)
        {

            folderBrowserDialog.ShowDialog();
            _gitRepositoryPath = folderBrowserDialog.SelectedPath;
            SqlMigrationGenerator sqlMigration = new SqlMigrationGenerator();
            richFileTextBox.Text = sqlMigration.GenerateMigration(_gitRepositoryPath);
            if (!string.IsNullOrEmpty(richFileTextBox.Text))
                Clipboard.SetText(richFileTextBox.Text);
            else
                MessageBox.Show("There is no queries repository");
            InitializelistBoxQueries();
        }

        private void listBoxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (StreamReader streamReader = new StreamReader(listBoxQueries.Text.Substring(3).Trim()))
            {
                richFileTextBox.Text = streamReader.ReadToEnd();
            }
        }

        private void InitializelistBoxQueries()
        {
            List<string> newFiles = _gitChangesProvider.GetCreatedFiles(_gitRepositoryPath);
            List<string> modifiedFiles = _gitChangesProvider.GetModifiedFiles(_gitRepositoryPath);
            List<string> deletedFiles = _gitChangesProvider.GetDeletedFiles(_gitRepositoryPath);
            List<string> untrackedFiles = _gitChangesProvider.GetUntrackedFiles(_gitRepositoryPath);

            foreach (string file in newFiles)
                listBoxQueries.Items.Add("A  " + file);
            foreach (string modifiedFile in modifiedFiles)
                listBoxQueries.Items.Add("AM " + modifiedFile);
            foreach (string deletedFile in deletedFiles)
                listBoxQueries.Items.Add("D??" + deletedFile);
            foreach (string untrackedFile in untrackedFiles)
                listBoxQueries.Items.Add("?? " + untrackedFile);
        }

    }
}
