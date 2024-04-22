using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using GenerateMigration;
using GenerateMigration.Abstractions;

namespace WpfAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _repositoryPath = string.Empty;
        private readonly IGitChangesProvider _gitChangesProvider = new GitChangesProvider();
        private readonly IQueryTypeClasyficator queryTypeClasyficator = new QueryTypeClasyficator();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                repositoryPathTextBlock.Text = dialog.FileName;
                Properties.Settings.Default.RepositoryPath = dialog.FileName;
                _repositoryPath = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _repositoryPath = Properties.Settings.Default.RepositoryPath;
            repositoryPathTextBlock.Text = _repositoryPath;
        }

        private void generateMigrationButton_Click(object sender, RoutedEventArgs e)
        {
            var sqlMigration = new SqlMigrationGenerator(_gitChangesProvider, queryTypeClasyficator);
            migrationTextBlock.Text = sqlMigration.GenerateMigration(_repositoryPath);
        }
    }
}