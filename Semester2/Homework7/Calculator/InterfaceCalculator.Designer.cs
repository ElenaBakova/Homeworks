
namespace Calculator
{
    /// <summary>
    /// Win forms calculator
    /// </summary>
    partial class InterfaceCalculator
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
            this.additionButton = new System.Windows.Forms.Button();
            this.number0 = new System.Windows.Forms.Button();
            this.subtractionButton = new System.Windows.Forms.Button();
            this.number9 = new System.Windows.Forms.Button();
            this.number8 = new System.Windows.Forms.Button();
            this.number7 = new System.Windows.Forms.Button();
            this.multiplicationButton = new System.Windows.Forms.Button();
            this.number6 = new System.Windows.Forms.Button();
            this.number5 = new System.Windows.Forms.Button();
            this.number4 = new System.Windows.Forms.Button();
            this.divisionButton = new System.Windows.Forms.Button();
            this.number3 = new System.Windows.Forms.Button();
            this.number2 = new System.Windows.Forms.Button();
            this.number1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.equalButton = new System.Windows.Forms.Button();
            this.ClearEntryButton = new System.Windows.Forms.Button();
            this.calculatorEntryBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // additionButton
            // 
            this.additionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.additionButton.Location = new System.Drawing.Point(420, 489);
            this.additionButton.Name = "additionButton";
            this.additionButton.Size = new System.Drawing.Size(183, 105);
            this.additionButton.TabIndex = 15;
            this.additionButton.Text = "+";
            this.additionButton.UseVisualStyleBackColor = true;
            this.additionButton.Click += new System.EventHandler(this.OperationButtonClick);
            // 
            // number0
            // 
            this.number0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number0.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number0.Location = new System.Drawing.Point(3, 489);
            this.number0.Name = "number0";
            this.number0.Size = new System.Drawing.Size(133, 105);
            this.number0.TabIndex = 12;
            this.number0.Text = "0";
            this.number0.UseVisualStyleBackColor = true;
            this.number0.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // subtractionButton
            // 
            this.subtractionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtractionButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subtractionButton.Location = new System.Drawing.Point(420, 381);
            this.subtractionButton.Name = "subtractionButton";
            this.subtractionButton.Size = new System.Drawing.Size(183, 102);
            this.subtractionButton.TabIndex = 11;
            this.subtractionButton.Text = "-";
            this.subtractionButton.UseVisualStyleBackColor = true;
            this.subtractionButton.Click += new System.EventHandler(this.OperationButtonClick);
            // 
            // number9
            // 
            this.number9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number9.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number9.Location = new System.Drawing.Point(281, 381);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(133, 102);
            this.number9.TabIndex = 10;
            this.number9.Text = "9";
            this.number9.UseVisualStyleBackColor = true;
            this.number9.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // number8
            // 
            this.number8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number8.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number8.Location = new System.Drawing.Point(142, 381);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(133, 102);
            this.number8.TabIndex = 9;
            this.number8.Text = "8";
            this.number8.UseVisualStyleBackColor = true;
            this.number8.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // number7
            // 
            this.number7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number7.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number7.Location = new System.Drawing.Point(3, 381);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(133, 102);
            this.number7.TabIndex = 8;
            this.number7.Text = "7";
            this.number7.UseVisualStyleBackColor = true;
            this.number7.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // multiplicationButton
            // 
            this.multiplicationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplicationButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.multiplicationButton.Location = new System.Drawing.Point(420, 273);
            this.multiplicationButton.Name = "multiplicationButton";
            this.multiplicationButton.Size = new System.Drawing.Size(183, 102);
            this.multiplicationButton.TabIndex = 7;
            this.multiplicationButton.Text = "*";
            this.multiplicationButton.UseVisualStyleBackColor = true;
            this.multiplicationButton.Click += new System.EventHandler(this.OperationButtonClick);
            // 
            // number6
            // 
            this.number6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number6.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number6.Location = new System.Drawing.Point(281, 273);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(133, 102);
            this.number6.TabIndex = 6;
            this.number6.Text = "6";
            this.number6.UseVisualStyleBackColor = true;
            this.number6.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // number5
            // 
            this.number5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number5.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number5.Location = new System.Drawing.Point(142, 273);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(133, 102);
            this.number5.TabIndex = 5;
            this.number5.Text = "5";
            this.number5.UseVisualStyleBackColor = true;
            this.number5.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // number4
            // 
            this.number4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number4.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number4.Location = new System.Drawing.Point(3, 273);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(133, 102);
            this.number4.TabIndex = 4;
            this.number4.Text = "4";
            this.number4.UseVisualStyleBackColor = true;
            this.number4.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // divisionButton
            // 
            this.divisionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.divisionButton.Location = new System.Drawing.Point(420, 165);
            this.divisionButton.Name = "divisionButton";
            this.divisionButton.Size = new System.Drawing.Size(183, 102);
            this.divisionButton.TabIndex = 3;
            this.divisionButton.Text = "/";
            this.divisionButton.UseVisualStyleBackColor = true;
            this.divisionButton.Click += new System.EventHandler(this.OperationButtonClick);
            // 
            // number3
            // 
            this.number3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number3.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number3.Location = new System.Drawing.Point(281, 165);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(133, 102);
            this.number3.TabIndex = 2;
            this.number3.Text = "3";
            this.number3.UseVisualStyleBackColor = true;
            this.number3.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // number2
            // 
            this.number2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number2.Location = new System.Drawing.Point(142, 165);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(133, 102);
            this.number2.TabIndex = 1;
            this.number2.Text = "2";
            this.number2.UseVisualStyleBackColor = true;
            this.number2.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // number1
            // 
            this.number1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number1.Location = new System.Drawing.Point(3, 165);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(133, 102);
            this.number1.TabIndex = 0;
            this.number1.Text = "1";
            this.number1.UseVisualStyleBackColor = true;
            this.number1.Click += new System.EventHandler(this.NumberButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(80, 80);
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.02026F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.02026F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.02026F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.93923F));
            this.tableLayoutPanel1.Controls.Add(this.number1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.number2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.number3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.divisionButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.number4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.number5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.number6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.multiplicationButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.number7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.number8, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.number9, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.subtractionButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.number0, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.additionButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.equalButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ClearEntryButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.calculatorEntryBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // equalButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.equalButton, 2);
            this.equalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.equalButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.equalButton.Location = new System.Drawing.Point(142, 489);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(272, 105);
            this.equalButton.TabIndex = 16;
            this.equalButton.Text = "=";
            this.equalButton.UseVisualStyleBackColor = true;
            this.equalButton.Click += new System.EventHandler(this.EqualButtonClick);
            // 
            // ClearEntryButton
            // 
            this.ClearEntryButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClearEntryButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClearEntryButton.Location = new System.Drawing.Point(420, 99);
            this.ClearEntryButton.Name = "ClearEntryButton";
            this.ClearEntryButton.Size = new System.Drawing.Size(183, 60);
            this.ClearEntryButton.TabIndex = 17;
            this.ClearEntryButton.Text = "CE";
            this.ClearEntryButton.UseVisualStyleBackColor = true;
            this.ClearEntryButton.Click += new System.EventHandler(this.ClearEntryButtonClick);
            // 
            // calculatorEntryBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.calculatorEntryBox, 3);
            this.calculatorEntryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculatorEntryBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calculatorEntryBox.Location = new System.Drawing.Point(3, 3);
            this.calculatorEntryBox.Name = "calculatorEntryBox";
            this.calculatorEntryBox.Size = new System.Drawing.Size(411, 156);
            this.calculatorEntryBox.TabIndex = 18;
            this.calculatorEntryBox.Text = "";
            // 
            // InterfaceCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(606, 597);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(230, 495);
            this.Name = "InterfaceCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button additionButton;
        private System.Windows.Forms.Button number0;
        private System.Windows.Forms.Button subtractionButton;
        private System.Windows.Forms.Button number9;
        private System.Windows.Forms.Button number8;
        private System.Windows.Forms.Button number7;
        private System.Windows.Forms.Button multiplicationButton;
        private System.Windows.Forms.Button number6;
        private System.Windows.Forms.Button number5;
        private System.Windows.Forms.Button number4;
        private System.Windows.Forms.Button divisionButton;
        private System.Windows.Forms.Button number3;
        private System.Windows.Forms.Button number2;
        private System.Windows.Forms.Button number1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button equalButton;
        private System.Windows.Forms.Button ClearEntryButton;
        private System.Windows.Forms.RichTextBox calculatorEntryBox;
    }
}

