using GenerateMigration.Abstractions;
using GenerateMigration;
using MigrationGeneratorFormsApp.Properties;
using System.Windows.Forms;
using System.Drawing;

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
            var sqlMigration = new SqlMigrationGenerator(_gitChangesProvider, queryTypeClasyficator);
            richFileTextBox.Text = sqlMigration.GenerateMigration(_gitRepositoryPath);
        }
        private void listBoxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelectSourceRepository_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            _gitRepositoryPath = folderBrowserDialog.SelectedPath;
            textBoxSourceRepositoryPath.Text = _gitRepositoryPath;

            Settings.Default.SourceRepositoryPath = _gitRepositoryPath;
            Settings.Default.Save();
        }

        private void MigrationGenerator_Load(object sender, EventArgs e)
        {
            textBoxSourceRepositoryPath.Text = Settings.Default.SourceRepositoryPath;
            _gitRepositoryPath = Settings.Default.SourceRepositoryPath;
        }
    }
}
