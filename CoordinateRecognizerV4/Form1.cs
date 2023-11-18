namespace CoordinateRecognizerV4
{
    partial class Form1
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
            this.FolderPathTextBox = new System.Windows.Forms.TextBox();
            this.ProcessImagesButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FolderPathTextBox
            // 
            this.FolderPathTextBox.Location = new System.Drawing.Point(12, 12);
            this.FolderPathTextBox.Name = "FolderPathTextBox";
            this.FolderPathTextBox.Size = new System.Drawing.Size(300, 20);
            this.FolderPathTextBox.TabIndex = 0;
            // 
            // ProcessImagesButton
            // 
            this.ProcessImagesButton.Location = new System.Drawing.Point(12, 38);
            this.ProcessImagesButton.Name = "ProcessImagesButton";
            this.ProcessImagesButton.Size = new System.Drawing.Size(100, 23);
            this.ProcessImagesButton.TabIndex = 1;
            this.ProcessImagesButton.Text = "Process Images";
            this.ProcessImagesButton.UseVisualStyleBackColor = true;
            this.ProcessImagesButton.Click += new System.EventHandler(this.ProcessImagesButton_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(12, 67);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(400, 200);
            this.ResultTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 279);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ProcessImagesButton);
            this.Controls.Add(this.FolderPathTextBox);
            this.Name = "Form1";
            this.Text = "Coordinate Recognizer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox FolderPathTextBox;
        private System.Windows.Forms.Button ProcessImagesButton;
        private System.Windows.Forms.TextBox ResultTextBox;
    }
}
