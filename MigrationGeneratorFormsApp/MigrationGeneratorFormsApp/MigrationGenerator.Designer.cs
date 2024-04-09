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
            listBoxQueries = new ListBox();
            GenerateMigration = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // richFileTextBox
            // 
            richFileTextBox.Location = new Point(12, 278);
            richFileTextBox.Name = "richFileTextBox";
            richFileTextBox.Size = new Size(1950, 729);
            richFileTextBox.TabIndex = 0;
            richFileTextBox.Text = "";
            // 
            // listBoxQueries
            // 
            listBoxQueries.FormattingEnabled = true;
            listBoxQueries.Location = new Point(12, 12);
            listBoxQueries.Name = "listBoxQueries";
            listBoxQueries.Size = new Size(1950, 260);
            listBoxQueries.TabIndex = 1;
            // 
            // GenerateMigration
            // 
            GenerateMigration.Location = new Point(824, 1023);
            GenerateMigration.Name = "GenerateMigration";
            GenerateMigration.Size = new Size(261, 93);
            GenerateMigration.TabIndex = 2;
            GenerateMigration.Text = "GenerateMigration";
            GenerateMigration.UseVisualStyleBackColor = true;
            GenerateMigration.Click += GenerateMigration_Click;
            // 
            // 
            // MigrationGenerator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1129);
            Controls.Add(GenerateMigration);
            Controls.Add(listBoxQueries);
            Controls.Add(richFileTextBox);
            MaximumSize = new Size(2000, 1200);
            MinimumSize = new Size(2000, 1200);
            Name = "MigrationGenerator";
            Text = "MigrationGenerator";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richFileTextBox;
        private ListBox listBoxQueries;
        private Button GenerateMigration;
        private FolderBrowserDialog folderBrowserDialog;
    }
}
