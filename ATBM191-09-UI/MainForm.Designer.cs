namespace ATBM191_09_UI
{
    partial class MainForm
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
            this.main_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.view_button = new System.Windows.Forms.Button();
            this.table_button = new System.Windows.Forms.Button();
            this.role_button = new System.Windows.Forms.Button();
            this.user_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.header_panel = new System.Windows.Forms.Panel();
            this.new_button = new System.Windows.Forms.Button();
            this.header_label = new System.Windows.Forms.Label();
            this.main_datagridview = new System.Windows.Forms.DataGridView();
            this.main_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.header_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.AutoSize = true;
            this.main_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.main_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.main_panel.Controls.Add(this.panel1);
            this.main_panel.Controls.Add(this.header_panel);
            this.main_panel.Controls.Add(this.main_datagridview);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Margin = new System.Windows.Forms.Padding(4);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1067, 554);
            this.main_panel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.view_button);
            this.panel1.Controls.Add(this.table_button);
            this.panel1.Controls.Add(this.role_button);
            this.panel1.Controls.Add(this.user_button);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 554);
            this.panel1.TabIndex = 3;
            // 
            // view_button
            // 
            this.view_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.view_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.view_button.FlatAppearance.BorderSize = 0;
            this.view_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_button.ForeColor = System.Drawing.Color.Gainsboro;
            this.view_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.view_button.Location = new System.Drawing.Point(0, 320);
            this.view_button.Margin = new System.Windows.Forms.Padding(4);
            this.view_button.Name = "view_button";
            this.view_button.Size = new System.Drawing.Size(267, 74);
            this.view_button.TabIndex = 4;
            this.view_button.Text = "Views";
            this.view_button.UseVisualStyleBackColor = true;
            this.view_button.Click += new System.EventHandler(this.view_button_Click);
            // 
            // table_button
            // 
            this.table_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.table_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_button.FlatAppearance.BorderSize = 0;
            this.table_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.table_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_button.ForeColor = System.Drawing.Color.Gainsboro;
            this.table_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.table_button.Location = new System.Drawing.Point(0, 246);
            this.table_button.Margin = new System.Windows.Forms.Padding(4);
            this.table_button.Name = "table_button";
            this.table_button.Size = new System.Drawing.Size(267, 74);
            this.table_button.TabIndex = 3;
            this.table_button.Text = "Tables";
            this.table_button.UseVisualStyleBackColor = true;
            this.table_button.Click += new System.EventHandler(this.Table_Button_Click);
            // 
            // role_button
            // 
            this.role_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.role_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.role_button.FlatAppearance.BorderSize = 0;
            this.role_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.role_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_button.ForeColor = System.Drawing.Color.Gainsboro;
            this.role_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.role_button.Location = new System.Drawing.Point(0, 172);
            this.role_button.Margin = new System.Windows.Forms.Padding(4);
            this.role_button.Name = "role_button";
            this.role_button.Size = new System.Drawing.Size(267, 74);
            this.role_button.TabIndex = 2;
            this.role_button.Text = "Roles";
            this.role_button.UseVisualStyleBackColor = true;
            this.role_button.Click += new System.EventHandler(this.role_button_Click);
            // 
            // user_button
            // 
            this.user_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.user_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.user_button.FlatAppearance.BorderSize = 0;
            this.user_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_button.ForeColor = System.Drawing.Color.Gainsboro;
            this.user_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.user_button.Location = new System.Drawing.Point(0, 98);
            this.user_button.Margin = new System.Windows.Forms.Padding(4);
            this.user_button.Name = "user_button";
            this.user_button.Size = new System.Drawing.Size(267, 74);
            this.user_button.TabIndex = 1;
            this.user_button.Text = "Users";
            this.user_button.UseVisualStyleBackColor = true;
            this.user_button.Click += new System.EventHandler(this.User_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 98);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(66, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrator";
            // 
            // header_panel
            // 
            this.header_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.header_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(75)))));
            this.header_panel.Controls.Add(this.new_button);
            this.header_panel.Controls.Add(this.header_label);
            this.header_panel.Location = new System.Drawing.Point(265, 0);
            this.header_panel.Margin = new System.Windows.Forms.Padding(4);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(801, 98);
            this.header_panel.TabIndex = 2;
            // 
            // new_button
            // 
            this.new_button.AutoEllipsis = true;
            this.new_button.Location = new System.Drawing.Point(689, 62);
            this.new_button.Margin = new System.Windows.Forms.Padding(4);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(100, 28);
            this.new_button.TabIndex = 1;
            this.new_button.Text = "New";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.New_button_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.ForeColor = System.Drawing.Color.White;
            this.header_label.Location = new System.Drawing.Point(21, 34);
            this.header_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(99, 31);
            this.header_label.TabIndex = 0;
            this.header_label.Text = "HOME";
            // 
            // main_datagridview
            // 
            this.main_datagridview.AllowUserToAddRows = false;
            this.main_datagridview.AllowUserToDeleteRows = false;
            this.main_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.main_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.main_datagridview.Location = new System.Drawing.Point(265, 98);
            this.main_datagridview.Margin = new System.Windows.Forms.Padding(4);
            this.main_datagridview.Name = "main_datagridview";
            this.main_datagridview.RowHeadersWidth = 51;
            this.main_datagridview.Size = new System.Drawing.Size(805, 460);
            this.main_datagridview.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.main_panel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.main_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.header_panel.ResumeLayout(false);
            this.header_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Panel header_panel;
        private System.Windows.Forms.DataGridView main_datagridview;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button user_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button view_button;
        private System.Windows.Forms.Button table_button;
        private System.Windows.Forms.Button role_button;
        private System.Windows.Forms.Label label1;
    }
}

