namespace ProgressIndicator
{
    partial class ProgressIndicatorForm
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
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.controlButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.progressBar.Location = new System.Drawing.Point(24, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(592, 61);
            this.progressBar.TabIndex = 0;
            // 
            // controlButton
            // 
            this.controlButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton.Location = new System.Drawing.Point(24, 79);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(148, 48);
            this.controlButton.TabIndex = 1;
            this.controlButton.Text = "start";
            this.controlButton.UseVisualStyleBackColor = true;
            this.controlButton.Click += new System.EventHandler(this.ButtonClick);
            // 
            // textBox
            // 
            this.textBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox.BackColor = System.Drawing.SystemColors.Control;
            this.textBox.Location = new System.Drawing.Point(24, 79);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(148, 27);
            this.textBox.TabIndex = 2;
            // 
            // ProgressIndicatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 464);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.controlButton);
            this.Controls.Add(this.progressBar);
            this.MinimumSize = new System.Drawing.Size(650, 170);
            this.Name = "ProgressIndicatorForm";
            this.Text = "ProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button controlButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBox;
    }
}

