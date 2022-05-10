
namespace ATBM191_09_UI
{
    partial class BenhNhanMenu
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
            this.header_panel = new System.Windows.Forms.Panel();
            this.header_label = new System.Windows.Forms.Label();
            this.main_datagridview = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HSBADV_Button = new System.Windows.Forms.Button();
            this.HSBA_Button = new System.Windows.Forms.Button();
            this.BenhNhan_Button = new System.Windows.Forms.Button();
            this.PersonalInfo_Button = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.header_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_datagridview)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // header_panel
            // 
            this.header_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.header_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.header_panel.Controls.Add(this.header_label);
            this.header_panel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_panel.Location = new System.Drawing.Point(289, 0);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(768, 123);
            this.header_panel.TabIndex = 3;
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.ForeColor = System.Drawing.Color.White;
            this.header_label.Location = new System.Drawing.Point(322, 46);
            this.header_label.Margin = new System.Windows.Forms.Padding(70, 0, 3, 0);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(116, 37);
            this.header_label.TabIndex = 0;
            this.header_label.Text = "HOME";
            this.header_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.header_label.Click += new System.EventHandler(this.header_label_Click);
            // 
            // main_datagridview
            // 
            this.main_datagridview.AllowUserToAddRows = false;
            this.main_datagridview.AllowUserToDeleteRows = false;
            this.main_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.main_datagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.main_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.main_datagridview.Location = new System.Drawing.Point(292, 123);
            this.main_datagridview.Name = "main_datagridview";
            this.main_datagridview.ReadOnly = true;
            this.main_datagridview.RowHeadersWidth = 51;
            this.main_datagridview.Size = new System.Drawing.Size(765, 454);
            this.main_datagridview.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.HSBADV_Button);
            this.panel2.Controls.Add(this.HSBA_Button);
            this.panel2.Controls.Add(this.BenhNhan_Button);
            this.panel2.Controls.Add(this.PersonalInfo_Button);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 580);
            this.panel2.TabIndex = 6;
            // 
            // HSBADV_Button
            // 
            this.HSBADV_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HSBADV_Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.HSBADV_Button.FlatAppearance.BorderSize = 0;
            this.HSBADV_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HSBADV_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HSBADV_Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.HSBADV_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HSBADV_Button.Location = new System.Drawing.Point(0, 399);
            this.HSBADV_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HSBADV_Button.Name = "HSBADV_Button";
            this.HSBADV_Button.Size = new System.Drawing.Size(296, 92);
            this.HSBADV_Button.TabIndex = 5;
            this.HSBADV_Button.Text = "Hồ sơ bệnh án - dịch vụ";
            this.HSBADV_Button.UseVisualStyleBackColor = true;
            // 
            // HSBA_Button
            // 
            this.HSBA_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HSBA_Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.HSBA_Button.FlatAppearance.BorderSize = 0;
            this.HSBA_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HSBA_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HSBA_Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.HSBA_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HSBA_Button.Location = new System.Drawing.Point(0, 307);
            this.HSBA_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HSBA_Button.Name = "HSBA_Button";
            this.HSBA_Button.Size = new System.Drawing.Size(296, 92);
            this.HSBA_Button.TabIndex = 4;
            this.HSBA_Button.Text = "Hồ sơ bệnh án";
            this.HSBA_Button.UseVisualStyleBackColor = true;
            // 
            // BenhNhan_Button
            // 
            this.BenhNhan_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BenhNhan_Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.BenhNhan_Button.FlatAppearance.BorderSize = 0;
            this.BenhNhan_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BenhNhan_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BenhNhan_Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.BenhNhan_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BenhNhan_Button.Location = new System.Drawing.Point(0, 215);
            this.BenhNhan_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BenhNhan_Button.Name = "BenhNhan_Button";
            this.BenhNhan_Button.Size = new System.Drawing.Size(296, 92);
            this.BenhNhan_Button.TabIndex = 3;
            this.BenhNhan_Button.Text = "Bệnh nhân";
            this.BenhNhan_Button.UseVisualStyleBackColor = true;
            // 
            // PersonalInfo_Button
            // 
            this.PersonalInfo_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PersonalInfo_Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.PersonalInfo_Button.FlatAppearance.BorderSize = 0;
            this.PersonalInfo_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PersonalInfo_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonalInfo_Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.PersonalInfo_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PersonalInfo_Button.Location = new System.Drawing.Point(0, 123);
            this.PersonalInfo_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PersonalInfo_Button.Name = "PersonalInfo_Button";
            this.PersonalInfo_Button.Size = new System.Drawing.Size(296, 92);
            this.PersonalInfo_Button.TabIndex = 1;
            this.PersonalInfo_Button.Text = "Thông tin cá nhân";
            this.PersonalInfo_Button.UseVisualStyleBackColor = true;
            this.PersonalInfo_Button.Click += new System.EventHandler(this.PersonalInfo_Button_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 123);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(-7, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 120);
            this.label1.TabIndex = 1;
            this.label1.Text = "BỆNH NHÂN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // BenhNhanMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 580);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.main_datagridview);
            this.Controls.Add(this.header_panel);
            this.Name = "BenhNhanMenu";
            this.Text = "BenhNhanMenu";
            this.header_panel.ResumeLayout(false);
            this.header_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_datagridview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header_panel;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.DataGridView main_datagridview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button HSBADV_Button;
        private System.Windows.Forms.Button HSBA_Button;
        private System.Windows.Forms.Button BenhNhan_Button;
        private System.Windows.Forms.Button PersonalInfo_Button;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}