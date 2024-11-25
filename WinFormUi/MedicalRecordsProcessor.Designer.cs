namespace WinFormUi
{
    partial class MedicalRecordsProcessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            processFileButton = new Button();
            inputFIlePath = new TextBox();
            selectInputFIleButton = new Button();
            outputFolderPath = new TextBox();
            selectOutputFolderPath = new Button();
            outputLogTextBox = new TextBox();
            outputFolderBrowserDialog = new FolderBrowserDialog();
            openInputFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // processFileButton
            // 
            processFileButton.Location = new Point(704, 415);
            processFileButton.Name = "processFileButton";
            processFileButton.Size = new Size(75, 23);
            processFileButton.TabIndex = 0;
            processFileButton.Text = "Process";
            processFileButton.UseVisualStyleBackColor = true;
            processFileButton.Click += processFileButton_Click;
            // 
            // inputFIlePath
            // 
            inputFIlePath.Location = new Point(176, 35);
            inputFIlePath.Name = "inputFIlePath";
            inputFIlePath.Size = new Size(381, 23);
            inputFIlePath.TabIndex = 1;
            // 
            // selectInputFIleButton
            // 
            selectInputFIleButton.Location = new Point(563, 35);
            selectInputFIleButton.Name = "selectInputFIleButton";
            selectInputFIleButton.Size = new Size(75, 23);
            selectInputFIleButton.TabIndex = 2;
            selectInputFIleButton.Text = "Select";
            selectInputFIleButton.UseVisualStyleBackColor = true;
            selectInputFIleButton.Click += selectInputFIleButton_Click;
            // 
            // outputFolderPath
            // 
            outputFolderPath.Location = new Point(176, 73);
            outputFolderPath.Name = "outputFolderPath";
            outputFolderPath.Size = new Size(381, 23);
            outputFolderPath.TabIndex = 3;
            // 
            // selectOutputFolderPath
            // 
            selectOutputFolderPath.Location = new Point(563, 73);
            selectOutputFolderPath.Name = "selectOutputFolderPath";
            selectOutputFolderPath.Size = new Size(75, 23);
            selectOutputFolderPath.TabIndex = 4;
            selectOutputFolderPath.Text = "Select";
            selectOutputFolderPath.UseVisualStyleBackColor = true;
            selectOutputFolderPath.Click += selectOutputFolderPath_Click;
            // 
            // outputLogTextBox
            // 
            outputLogTextBox.Location = new Point(178, 114);
            outputLogTextBox.Multiline = true;
            outputLogTextBox.Name = "outputLogTextBox";
            outputLogTextBox.ScrollBars = ScrollBars.Both;
            outputLogTextBox.Size = new Size(460, 289);
            outputLogTextBox.TabIndex = 5;
            // 
            // outputFolderBrowserDialog
            // 
            outputFolderBrowserDialog.AddToRecent = false;
            // 
            // MedicalRecordsProcessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(outputLogTextBox);
            Controls.Add(selectOutputFolderPath);
            Controls.Add(outputFolderPath);
            Controls.Add(selectInputFIleButton);
            Controls.Add(inputFIlePath);
            Controls.Add(processFileButton);
            Name = "MedicalRecordsProcessor";
            Text = "MedicalRecordsProcessor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button processFileButton;
        private TextBox inputFIlePath;
        private Button selectInputFIleButton;
        private TextBox outputFolderPath;
        private Button selectOutputFolderPath;
        private TextBox outputLogTextBox;
        private FolderBrowserDialog outputFolderBrowserDialog;
        private OpenFileDialog openInputFileDialog;
    }
}