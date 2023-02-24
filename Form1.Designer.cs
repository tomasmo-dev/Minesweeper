namespace Minesweeper
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaximumMines = new System.Windows.Forms.NumericUpDown();
            this.messageBox = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldHeight = new System.Windows.Forms.NumericUpDown();
            this.fieldWidth = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(436, 86);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MaximumMines);
            this.groupBox1.Controls.Add(this.messageBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fieldHeight);
            this.groupBox1.Controls.Add(this.fieldWidth);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(1114, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 320);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 37);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max Mines";
            // 
            // MaximumMines
            // 
            this.MaximumMines.Location = new System.Drawing.Point(171, 175);
            this.MaximumMines.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MaximumMines.Name = "MaximumMines";
            this.MaximumMines.Size = new System.Drawing.Size(265, 43);
            this.MaximumMines.TabIndex = 10;
            // 
            // messageBox
            // 
            this.messageBox.AutoSize = true;
            this.messageBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageBox.ForeColor = System.Drawing.Color.Red;
            this.messageBox.Location = new System.Drawing.Point(146, 374);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(0, 61);
            this.messageBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width";
            // 
            // fieldHeight
            // 
            this.fieldHeight.Location = new System.Drawing.Point(171, 103);
            this.fieldHeight.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.fieldHeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.fieldHeight.Name = "fieldHeight";
            this.fieldHeight.Size = new System.Drawing.Size(265, 43);
            this.fieldHeight.TabIndex = 2;
            this.fieldHeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // fieldWidth
            // 
            this.fieldWidth.Location = new System.Drawing.Point(171, 55);
            this.fieldWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.fieldWidth.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.fieldWidth.Name = "fieldWidth";
            this.fieldWidth.Size = new System.Drawing.Size(265, 43);
            this.fieldWidth.TabIndex = 1;
            this.fieldWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 1107);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 1129);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label messageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown fieldHeight;
        private System.Windows.Forms.NumericUpDown fieldWidth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MaximumMines;
    }
}
