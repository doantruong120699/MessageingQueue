using System.Windows.Forms;

namespace TienTrinh2
{
    partial class TienTrinh2_Matrix
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
            this.panel3_Matrix = new System.Windows.Forms.Panel();
            this.panel4_Matrix = new System.Windows.Forms.Panel();
            this.label4_Matrix = new System.Windows.Forms.Label();
            this.panel1_Matrix = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_Reset_Matrix = new System.Windows.Forms.Button();
            this.panel5_Matrix = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label_ViewR_Matrix = new System.Windows.Forms.Label();
            this.label_file_Matrix = new System.Windows.Forms.Label();
            this.tb_para2_Matrix = new System.Windows.Forms.TextBox();
            this.label3_Matrix = new System.Windows.Forms.Label();
            this.btn_Calculator_Matrix = new System.Windows.Forms.Button();
            this.btn_Close_Matrix = new System.Windows.Forms.Button();
            this.panel3_Matrix.SuspendLayout();
            this.panel4_Matrix.SuspendLayout();
            this.panel1_Matrix.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5_Matrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3_Matrix
            // 
            this.panel3_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3_Matrix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3_Matrix.Controls.Add(this.panel4_Matrix);
            this.panel3_Matrix.Controls.Add(this.panel1_Matrix);
            this.panel3_Matrix.Location = new System.Drawing.Point(1, -1);
            this.panel3_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3_Matrix.Name = "panel3_Matrix";
            this.panel3_Matrix.Size = new System.Drawing.Size(551, 624);
            this.panel3_Matrix.TabIndex = 25;
            // 
            // panel4_Matrix
            // 
            this.panel4_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4_Matrix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4_Matrix.BackColor = System.Drawing.Color.Silver;
            this.panel4_Matrix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4_Matrix.Controls.Add(this.label4_Matrix);
            this.panel4_Matrix.Location = new System.Drawing.Point(13, 4);
            this.panel4_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4_Matrix.Name = "panel4_Matrix";
            this.panel4_Matrix.Size = new System.Drawing.Size(520, 67);
            this.panel4_Matrix.TabIndex = 24;
            // 
            // label4_Matrix
            // 
            this.label4_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4_Matrix.AutoSize = true;
            this.label4_Matrix.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label4_Matrix.Location = new System.Drawing.Point(-3, 14);
            this.label4_Matrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4_Matrix.Name = "label4_Matrix";
            this.label4_Matrix.Size = new System.Drawing.Size(513, 31);
            this.label4_Matrix.TabIndex = 6;
            this.label4_Matrix.Text = "INTER - PROCESS COMMUNUCATION";
            this.label4_Matrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4_Matrix.Click += new System.EventHandler(this.label4_Matrix_Click);
            // 
            // panel1_Matrix
            // 
            this.panel1_Matrix.AllowDrop = true;
            this.panel1_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1_Matrix.AutoScroll = true;
            this.panel1_Matrix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1_Matrix.BackColor = System.Drawing.Color.Silver;
            this.panel1_Matrix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1_Matrix.Controls.Add(this.panel2);
            this.panel1_Matrix.Controls.Add(this.btn_Reset_Matrix);
            this.panel1_Matrix.Controls.Add(this.panel5_Matrix);
            this.panel1_Matrix.Controls.Add(this.label3_Matrix);
            this.panel1_Matrix.Controls.Add(this.btn_Calculator_Matrix);
            this.panel1_Matrix.Controls.Add(this.btn_Close_Matrix);
            this.panel1_Matrix.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1_Matrix.ForeColor = System.Drawing.Color.Black;
            this.panel1_Matrix.Location = new System.Drawing.Point(13, 79);
            this.panel1_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1_Matrix.Name = "panel1_Matrix";
            this.panel1_Matrix.Size = new System.Drawing.Size(520, 537);
            this.panel1_Matrix.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(23, 57);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 46);
            this.panel2.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select task";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 11);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(312, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_Reset_Matrix
            // 
            this.btn_Reset_Matrix.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Reset_Matrix.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Reset_Matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset_Matrix.Location = new System.Drawing.Point(184, 487);
            this.btn_Reset_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Reset_Matrix.Name = "btn_Reset_Matrix";
            this.btn_Reset_Matrix.Size = new System.Drawing.Size(133, 34);
            this.btn_Reset_Matrix.TabIndex = 25;
            this.btn_Reset_Matrix.Text = "Reset";
            this.btn_Reset_Matrix.UseVisualStyleBackColor = false;
            this.btn_Reset_Matrix.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // panel5_Matrix
            // 
            this.panel5_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5_Matrix.AutoScroll = true;
            this.panel5_Matrix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5_Matrix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5_Matrix.Controls.Add(this.richTextBox1);
            this.panel5_Matrix.Controls.Add(this.label_ViewR_Matrix);
            this.panel5_Matrix.Controls.Add(this.label_file_Matrix);
            this.panel5_Matrix.Controls.Add(this.tb_para2_Matrix);
            this.panel5_Matrix.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel5_Matrix.ForeColor = System.Drawing.Color.Black;
            this.panel5_Matrix.Location = new System.Drawing.Point(24, 123);
            this.panel5_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5_Matrix.Name = "panel5_Matrix";
            this.panel5_Matrix.Size = new System.Drawing.Size(470, 351);
            this.panel5_Matrix.TabIndex = 24;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(25, 103);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(417, 233);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // label_ViewR_Matrix
            // 
            this.label_ViewR_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ViewR_Matrix.AutoSize = true;
            this.label_ViewR_Matrix.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ViewR_Matrix.Location = new System.Drawing.Point(171, 62);
            this.label_ViewR_Matrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ViewR_Matrix.Name = "label_ViewR_Matrix";
            this.label_ViewR_Matrix.Size = new System.Drawing.Size(109, 38);
            this.label_ViewR_Matrix.TabIndex = 22;
            this.label_ViewR_Matrix.Text = "Result";
            this.label_ViewR_Matrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ViewR_Matrix.Click += new System.EventHandler(this.label_ViewR_Matrix_Click);
            // 
            // label_file_Matrix
            // 
            this.label_file_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_file_Matrix.AutoSize = true;
            this.label_file_Matrix.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_file_Matrix.Location = new System.Drawing.Point(57, 5);
            this.label_file_Matrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_file_Matrix.Name = "label_file_Matrix";
            this.label_file_Matrix.Size = new System.Drawing.Size(354, 20);
            this.label_file_Matrix.TabIndex = 17;
            this.label_file_Matrix.Text = "Enter the path to the excel file to save the results";
            this.label_file_Matrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_para2_Matrix
            // 
            this.tb_para2_Matrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_para2_Matrix.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_para2_Matrix.Location = new System.Drawing.Point(25, 32);
            this.tb_para2_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_para2_Matrix.Name = "tb_para2_Matrix";
            this.tb_para2_Matrix.Size = new System.Drawing.Size(417, 26);
            this.tb_para2_Matrix.TabIndex = 16;
            // 
            // label3_Matrix
            // 
            this.label3_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3_Matrix.AutoSize = true;
            this.label3_Matrix.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_Matrix.Location = new System.Drawing.Point(161, 9);
            this.label3_Matrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3_Matrix.Name = "label3_Matrix";
            this.label3_Matrix.Size = new System.Drawing.Size(178, 35);
            this.label3_Matrix.TabIndex = 6;
            this.label3_Matrix.Text = "PROCESS 2";
            this.label3_Matrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Calculator_Matrix
            // 
            this.btn_Calculator_Matrix.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Calculator_Matrix.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Calculator_Matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Calculator_Matrix.ForeColor = System.Drawing.Color.Black;
            this.btn_Calculator_Matrix.Location = new System.Drawing.Point(24, 487);
            this.btn_Calculator_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Calculator_Matrix.Name = "btn_Calculator_Matrix";
            this.btn_Calculator_Matrix.Size = new System.Drawing.Size(133, 34);
            this.btn_Calculator_Matrix.TabIndex = 21;
            this.btn_Calculator_Matrix.Text = "Handle";
            this.btn_Calculator_Matrix.UseVisualStyleBackColor = false;
            this.btn_Calculator_Matrix.Click += new System.EventHandler(this.btn_Calculator_Click);
            // 
            // btn_Close_Matrix
            // 
            this.btn_Close_Matrix.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Close_Matrix.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close_Matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close_Matrix.Location = new System.Drawing.Point(344, 487);
            this.btn_Close_Matrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Close_Matrix.Name = "btn_Close_Matrix";
            this.btn_Close_Matrix.Size = new System.Drawing.Size(133, 34);
            this.btn_Close_Matrix.TabIndex = 20;
            this.btn_Close_Matrix.Text = "Exit";
            this.btn_Close_Matrix.UseVisualStyleBackColor = false;
            this.btn_Close_Matrix.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // TienTrinh2_Matrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 623);
            this.Controls.Add(this.panel3_Matrix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TienTrinh2_Matrix";
            this.Text = "TIẾN TRÌNH 2";
            this.Load += new System.EventHandler(this.TienTrinh2_Load);
            this.panel3_Matrix.ResumeLayout(false);
            this.panel4_Matrix.ResumeLayout(false);
            this.panel4_Matrix.PerformLayout();
            this.panel1_Matrix.ResumeLayout(false);
            this.panel1_Matrix.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5_Matrix.ResumeLayout(false);
            this.panel5_Matrix.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3_Matrix;
        private System.Windows.Forms.Panel panel4_Matrix;
        private System.Windows.Forms.Label label4_Matrix;
        private System.Windows.Forms.Panel panel1_Matrix;
        private System.Windows.Forms.Panel panel5_Matrix;
        private System.Windows.Forms.Label label3_Matrix;
        private System.Windows.Forms.Button btn_Calculator_Matrix;
        private System.Windows.Forms.Button btn_Close_Matrix;
        public System.Windows.Forms.Label label_ViewR_Matrix;
        private System.Windows.Forms.Label label_file_Matrix;
        private System.Windows.Forms.TextBox tb_para2_Matrix;
        private System.Windows.Forms.Button btn_Reset_Matrix;
        private Panel panel2;
        private Label label1;
        private ComboBox comboBox1;
        private RichTextBox richTextBox1;
    }
}