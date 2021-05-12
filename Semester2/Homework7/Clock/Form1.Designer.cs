
namespace Clock
{
    partial class ClockForm
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
            this.ClockBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ClockBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ClockBox
            // 
            this.ClockBox.BackColor = System.Drawing.SystemColors.Window;
            this.ClockBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClockBox.Location = new System.Drawing.Point(0, 0);
            this.ClockBox.Name = "ClockBox";
            this.ClockBox.Size = new System.Drawing.Size(582, 553);
            this.ClockBox.TabIndex = 0;
            this.ClockBox.TabStop = false;
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.ClockBox);
            this.Name = "ClockForm";
            this.Text = "ClockForm";
            this.Load += new System.EventHandler(this.ClockFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ClockBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ClockBox;
    }
}

