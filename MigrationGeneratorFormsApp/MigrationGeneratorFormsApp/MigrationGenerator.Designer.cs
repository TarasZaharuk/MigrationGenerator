namespace MigrationGeneratorFormsApp
{
    partial class MigrationGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richFileTextBox = new RichTextBox();
            GenerateMigration = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            label1 = new Label();
            textBoxSourceRepositoryPath = new TextBox();
            buttonSelectSourceRepository = new Button();
            SuspendLayout();
            // 
            // richFileTextBox
            // 
            richFileTextBox.Dock = DockStyle.Fill;
            richFileTextBox.Location = new Point(0, 0);
            richFileTextBox.Margin = new Padding(2, 2, 2, 10);
            richFileTextBox.Name = "richFileTextBox";
            richFileTextBox.Size = new Size(1522, 894);
            richFileTextBox.TabIndex = 0;
            richFileTextBox.Text = "";
            // 
            // GenerateMigration
            // 
            GenerateMigration.Dock = DockStyle.Bottom;
            GenerateMigration.Location = new Point(0, 821);
            GenerateMigration.Margin = new Padding(2);
            GenerateMigration.Name = "GenerateMigration";
            GenerateMigration.Size = new Size(1522, 73);
            GenerateMigration.TabIndex = 2;
            GenerateMigration.Text = "GenerateMigration";
            GenerateMigration.UseVisualStyleBackColor = true;
            GenerateMigration.Click += GenerateMigration_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 3;
            label1.Text = "Source repositories:";
            // 
            // textBoxSourceRepositoryPath
            // 
            textBoxSourceRepositoryPath.Location = new Point(186, 22);
            textBoxSourceRepositoryPath.Name = "textBoxSourceRepositoryPath";
            textBoxSourceRepositoryPath.ReadOnly = true;
            textBoxSourceRepositoryPath.Size = new Size(952, 31);
            textBoxSourceRepositoryPath.TabIndex = 4;
            // 
            // buttonSelectSourceRepository
            // 
            buttonSelectSourceRepository.Location = new Point(1169, 22);
            buttonSelectSourceRepository.Name = "buttonSelectSourceRepository";
            buttonSelectSourceRepository.Size = new Size(219, 34);
            buttonSelectSourceRepository.TabIndex = 5;
            buttonSelectSourceRepository.Text = "Select source repository";
            buttonSelectSourceRepository.UseVisualStyleBackColor = true;
            buttonSelectSourceRepository.Click += buttonSelectSourceRepository_Click;
            // 
            // MigrationGenerator
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 894);
            Controls.Add(buttonSelectSourceRepository);
            Controls.Add(textBoxSourceRepositoryPath);
            Controls.Add(label1);
            Controls.Add(GenerateMigration);
            Controls.Add(richFileTextBox);
            Margin = new Padding(2);
            Name = "MigrationGenerator";
            Text = "MigrationGenerator";
            Load += MigrationGenerator_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richFileTextBox;
        private Button GenerateMigration;
        private FolderBrowserDialog folderBrowserDialog;
        private Label label1;
        private TextBox textBoxSourceRepositoryPath;
        private Button buttonSelectSourceRepository;
    }
}
