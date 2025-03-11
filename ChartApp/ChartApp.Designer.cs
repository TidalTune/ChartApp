namespace ChartApp
{
    partial class ChartApp
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
            btnOpenFile = new Button();
            lblDisplay = new Label();
            SuspendLayout();
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(18, 20);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(75, 23);
            btnOpenFile.TabIndex = 0;
            btnOpenFile.Text = "OpenFile";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // lblDisplay
            // 
            lblDisplay.AutoSize = true;
            lblDisplay.Location = new Point(18, 46);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(38, 15);
            lblDisplay.TabIndex = 1;
            lblDisplay.Text = "label1";
            // 
            // ChartApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDisplay);
            Controls.Add(btnOpenFile);
            Name = "ChartApp";
            Text = "Form1";
            Paint += ChartApp_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenFile;
        private Label lblDisplay;
    }
}
