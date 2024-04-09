using GenerateMigration.Abstractions;
using GenerateMigration;
namespace MigrationGeneratorFormsApp
{
    public partial class MigrationGenerator : Form
    {
        private readonly IGitChangesProvider _gitChangesProvider = new GitChangesProvider();
        private readonly IQueryTypeClasyficator queryTypeClasyficator = new QueryTypeClasyficator();
        private string _gitRepositoryPath = null!;
        public MigrationGenerator()
        {
            InitializeComponent(); 
        }

        private void GenerateMigration_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            _gitRepositoryPath = folderBrowserDialog.SelectedPath;
            SqlMigrationGenerator sqlMigration = new(_gitChangesProvider,queryTypeClasyficator);
            richFileTextBox.Text = sqlMigration.GenerateMigration(_gitRepositoryPath);
            if (!string.IsNullOrEmpty(richFileTextBox.Text))
                Clipboard.SetText(richFileTextBox.Text);
            else
                MessageBox.Show("There is no queries");
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
            listBoxQueries.Items.Clear();
            List<string> newFiles = _gitChangesProvider.GetCreatedFiles(_gitRepositoryPath);
            List<string> modifiedFiles = _gitChangesProvider.GetModifiedFiles(_gitRepositoryPath);
            List<string> deletedFiles = _gitChangesProvider.GetDeletedFiles(_gitRepositoryPath);

            foreach (string file in newFiles)
                listBoxQueries.Items.Add("A  " + file);
            foreach (string modifiedFile in modifiedFiles)
                listBoxQueries.Items.Add("M  " + modifiedFile);
            foreach (string deletedFile in deletedFiles)
                listBoxQueries.Items.Add("D??" + deletedFile);
        }
    }
}
