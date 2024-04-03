namespace SQLProject
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
            GenerateMigrations = new Button();
            richFileTextBox = new RichTextBox();
            folderBrowserDialog = new FolderBrowserDialog();
            listBoxQueries = new ListBox();
            SuspendLayout();
            // 
            // GenerateMigrations
            // 
            GenerateMigrations.Location = new Point(824, 1023);
            GenerateMigrations.Name = "GenerateMigrations";
            GenerateMigrations.Size = new Size(261, 93);
            GenerateMigrations.TabIndex = 0;
            GenerateMigrations.Text = "GenerateMigrations";
            GenerateMigrations.UseVisualStyleBackColor = true;
            GenerateMigrations.Click += GenerateMigration_Click;
            // 
            // richFileTextBox
            // 
            richFileTextBox.Location = new Point(12, 278);
            richFileTextBox.Name = "richFileTextBox";
            richFileTextBox.Size = new Size(1950, 729);
            richFileTextBox.TabIndex = 2;
            richFileTextBox.Text = "";
            // 
            // listBoxQueries
            // 
            listBoxQueries.FormattingEnabled = true;
            listBoxQueries.Location = new Point(12, 12);
            listBoxQueries.Name = "listBoxQueries";
            listBoxQueries.Size = new Size(1950, 260);
            listBoxQueries.TabIndex = 3;
            listBoxQueries.SelectedIndexChanged += listBoxQueries_SelectedIndexChanged;
            // 
            // MigrationGenerator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1129);
            Controls.Add(listBoxQueries);
            Controls.Add(richFileTextBox);
            Controls.Add(GenerateMigrations);
            MaximumSize = new Size(2000, 1200);
            MinimumSize = new Size(2000, 1200);
            Name = "MigrationGenerator";
            Text = "MigrationGenerator";
            ResumeLayout(false);
        }

        #endregion

        private Button GenerateMigrations;
        private RichTextBox richFileTextBox;
        private FolderBrowserDialog folderBrowserDialog;
        private ListBox listBoxQueries;
        private Label label1;
        private Label label2;
    }
}
