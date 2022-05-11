
namespace ATBM191_09_UI
{
    partial class Control_HSBA_DV
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
            this.Ngay_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.HSBA_DV_Button = new System.Windows.Forms.Button();
            this.Ketqua_textBox = new System.Windows.Forms.TextBox();
            this.MaHSBA_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.header_panel = new System.Windows.Forms.Panel();
            this.header_label = new System.Windows.Forms.Label();
            this.Xoa_button = new System.Windows.Forms.Button();
            this.MaDV_comboBox = new System.Windows.Forms.ComboBox();
            this.MaKTV_comboBox = new System.Windows.Forms.ComboBox();
            this.header_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ngay_dateTimePicker
            // 
            this.Ngay_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Ngay_dateTimePicker.Location = new System.Drawing.Point(224, 315);
            this.Ngay_dateTimePicker.MaxDate = new System.DateTime(2022, 5, 12, 0, 0, 0, 0);
            this.Ngay_dateTimePicker.Name = "Ngay_dateTimePicker";
            this.Ngay_dateTimePicker.Size = new System.Drawing.Size(227, 26);
            this.Ngay_dateTimePicker.TabIndex = 93;
            this.Ngay_dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // HSBA_DV_Button
            // 
            this.HSBA_DV_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.HSBA_DV_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.HSBA_DV_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HSBA_DV_Button.ForeColor = System.Drawing.Color.Azure;
            this.HSBA_DV_Button.Location = new System.Drawing.Point(206, 436);
            this.HSBA_DV_Button.Name = "HSBA_DV_Button";
            this.HSBA_DV_Button.Size = new System.Drawing.Size(137, 42);
            this.HSBA_DV_Button.TabIndex = 92;
            this.HSBA_DV_Button.UseVisualStyleBackColor = false;
            this.HSBA_DV_Button.Click += new System.EventHandler(this.HSBA_DV_Button_Click);
            // 
            // Ketqua_textBox
            // 
            this.Ketqua_textBox.AllowDrop = true;
            this.Ketqua_textBox.Location = new System.Drawing.Point(224, 376);
            this.Ketqua_textBox.Name = "Ketqua_textBox";
            this.Ketqua_textBox.Size = new System.Drawing.Size(227, 26);
            this.Ketqua_textBox.TabIndex = 87;
            // 
            // MaHSBA_textBox
            // 
            this.MaHSBA_textBox.Location = new System.Drawing.Point(224, 140);
            this.MaHSBA_textBox.Name = "MaHSBA_textBox";
            this.MaHSBA_textBox.Size = new System.Drawing.Size(227, 26);
            this.MaHSBA_textBox.TabIndex = 85;
            this.MaHSBA_textBox.TextChanged += new System.EventHandler(this.MaHSBA_textBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 82;
            this.label6.Text = "Kết quả :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "Mã KTV : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "Ngày :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Mã DV :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Mã HSBA : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // header_panel
            // 
            this.header_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.header_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.header_panel.Controls.Add(this.header_label);
            this.header_panel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_panel.Location = new System.Drawing.Point(0, 0);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(615, 101);
            this.header_panel.TabIndex = 76;
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.ForeColor = System.Drawing.Color.White;
            this.header_label.Location = new System.Drawing.Point(56, 31);
            this.header_label.Margin = new System.Windows.Forms.Padding(70, 0, 3, 0);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(463, 37);
            this.header_label.TabIndex = 0;
            this.header_label.Text = "HỒ SƠ BỆNH ÁN _ DỊCH VỤ";
            this.header_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Xoa_button
            // 
            this.Xoa_button.BackColor = System.Drawing.SystemColors.Info;
            this.Xoa_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Xoa_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xoa_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.Xoa_button.Location = new System.Drawing.Point(206, 493);
            this.Xoa_button.Name = "Xoa_button";
            this.Xoa_button.Size = new System.Drawing.Size(137, 42);
            this.Xoa_button.TabIndex = 94;
            this.Xoa_button.Text = "Xóa";
            this.Xoa_button.UseVisualStyleBackColor = false;
            this.Xoa_button.Click += new System.EventHandler(this.Xoa_button_Click);
            // 
            // MaDV_comboBox
            // 
            this.MaDV_comboBox.FormattingEnabled = true;
            this.MaDV_comboBox.Items.AddRange(new object[] {
            "DV0001",
            "DV0002",
            "DV0003",
            "DV0004",
            "DV0005"});
            this.MaDV_comboBox.Location = new System.Drawing.Point(224, 199);
            this.MaDV_comboBox.Name = "MaDV_comboBox";
            this.MaDV_comboBox.Size = new System.Drawing.Size(227, 28);
            this.MaDV_comboBox.TabIndex = 95;
            // 
            // MaKTV_comboBox
            // 
            this.MaKTV_comboBox.FormattingEnabled = true;
            this.MaKTV_comboBox.Items.AddRange(new object[] {
            "NV0004",
            "NV0005",
            "NV0006",
            "NV0007",
            "NV0008",
            "NV0009",
            "NV0010",
            "NV0011",
            "NV0012",
            "NV0013",
            "NV0014",
            "NV0015",
            "NV0016",
            "NV0017",
            "NV0018",
            "NV0019",
            "NV0020",
            "NV0021",
            "NV0022",
            "NV0023",
            "NV0024",
            "NV0025",
            "NV0026",
            "NV0027",
            "NV0028",
            "NV0029",
            "NV0030",
            "NV0031",
            "NV0032",
            "NV0033",
            "NV0034",
            "NV0035",
            "NV0036",
            "NV0037",
            "NV0038",
            "NV0039",
            "NV0040",
            "NV0041",
            "NV0042",
            "NV0043",
            "NV0044",
            "NV0045",
            "NV0046",
            "NV0047",
            "NV0048",
            "NV0049",
            "NV0050",
            "NV0051",
            "NV0052",
            "NV0053",
            "NV0054",
            "NV0055"});
            this.MaKTV_comboBox.Location = new System.Drawing.Point(224, 258);
            this.MaKTV_comboBox.Name = "MaKTV_comboBox";
            this.MaKTV_comboBox.Size = new System.Drawing.Size(227, 28);
            this.MaKTV_comboBox.TabIndex = 96;
            // 
            // Control_HSBA_DV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 547);
            this.Controls.Add(this.MaKTV_comboBox);
            this.Controls.Add(this.MaDV_comboBox);
            this.Controls.Add(this.Xoa_button);
            this.Controls.Add(this.Ngay_dateTimePicker);
            this.Controls.Add(this.HSBA_DV_Button);
            this.Controls.Add(this.Ketqua_textBox);
            this.Controls.Add(this.MaHSBA_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.header_panel);
            this.Name = "Control_HSBA_DV";
            this.Text = "Control_HSBA_DV";
            this.Load += new System.EventHandler(this.Control_HSBA_DV_Load);
            this.header_panel.ResumeLayout(false);
            this.header_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Ngay_dateTimePicker;
        private System.Windows.Forms.Button HSBA_DV_Button;
        private System.Windows.Forms.TextBox Ketqua_textBox;
        private System.Windows.Forms.TextBox MaHSBA_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel header_panel;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Button Xoa_button;
        private System.Windows.Forms.ComboBox MaDV_comboBox;
        private System.Windows.Forms.ComboBox MaKTV_comboBox;
    }
}