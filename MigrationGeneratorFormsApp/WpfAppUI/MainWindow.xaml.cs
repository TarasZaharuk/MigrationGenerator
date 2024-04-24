using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using GenerateMigration;
using GenerateMigration.Abstractions;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using System.IO;

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

        private readonly string _basePath = AppDomain.CurrentDomain.BaseDirectory;
        private const string _relativeSqlSyntaxHighlightingDefinitionPath = @"..\..\..\SqlHighlighting.xml";
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
            string sqlSyntaxHighlightingDefinitionFullPath = Path.GetFullPath(Path.Combine(_basePath, _relativeSqlSyntaxHighlightingDefinitionPath));
            using (StreamReader streamReader = new StreamReader(sqlSyntaxHighlightingDefinitionFullPath))
            {
                var xmlSQLSyntaxHighlightingDefinition = streamReader.ReadToEnd();

                using (MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlSQLSyntaxHighlightingDefinition)))
                {
                    using (XmlTextReader reader = new XmlTextReader(memoryStream))
                    {
                        var customSqlSyntaxDefinition = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                        sqlEditor.SyntaxHighlighting = customSqlSyntaxDefinition;
                    }
                }
            }
            
            _repositoryPath = Properties.Settings.Default.RepositoryPath;
            repositoryPathTextBlock.Text = _repositoryPath;
        }

        private void generateMigrationButton_Click(object sender, RoutedEventArgs e)
        {
            var sqlMigration = new SqlMigrationGenerator(_gitChangesProvider, queryTypeClasyficator);
            sqlEditor.Text = sqlMigration.GenerateMigration(_repositoryPath);
        }
    }
}