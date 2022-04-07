namespace ATBM191_09_UI
{
    partial class EditUserControl
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
            this.tabcontrols = new System.Windows.Forms.TabControl();
            this.user_tab = new System.Windows.Forms.TabPage();
            this.username_label = new System.Windows.Forms.Label();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.roles_tab = new System.Windows.Forms.TabPage();
            this.role_datagridview = new System.Windows.Forms.DataGridView();
            this.tables_tab = new System.Windows.Forms.TabPage();
            this.table_datagridview = new System.Windows.Forms.DataGridView();
            this.ViewDetailButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.privs_tab = new System.Windows.Forms.TabPage();
            this.privs_datagridview = new System.Windows.Forms.DataGridView();
            this.save_button = new System.Windows.Forms.Button();
            this.tabcontrols.SuspendLayout();
            this.user_tab.SuspendLayout();
            this.roles_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).BeginInit();
            this.tables_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_datagridview)).BeginInit();
            this.privs_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.privs_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcontrols
            // 
            this.tabcontrols.Controls.Add(this.user_tab);
            this.tabcontrols.Controls.Add(this.roles_tab);
            this.tabcontrols.Controls.Add(this.tables_tab);
            this.tabcontrols.Controls.Add(this.privs_tab);
            this.tabcontrols.Location = new System.Drawing.Point(12, 12);
            this.tabcontrols.Name = "tabcontrols";
            this.tabcontrols.SelectedIndex = 0;
            this.tabcontrols.Size = new System.Drawing.Size(472, 412);
            this.tabcontrols.TabIndex = 11;
            // 
            // user_tab
            // 
            this.user_tab.Controls.Add(this.username_label);
            this.user_tab.Controls.Add(this.password_textbox);
            this.user_tab.Controls.Add(this.password_label);
            this.user_tab.Controls.Add(this.username_textbox);
            this.user_tab.Location = new System.Drawing.Point(4, 22);
            this.user_tab.Name = "user_tab";
            this.user_tab.Size = new System.Drawing.Size(464, 386);
            this.user_tab.TabIndex = 3;
            this.user_tab.Text = "User ";
            this.user_tab.UseVisualStyleBackColor = true;
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(11, 22);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(61, 13);
            this.username_label.TabIndex = 12;
            this.username_label.Text = "Username: ";
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(73, 57);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(195, 20);
            this.password_textbox.TabIndex = 15;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(11, 60);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(56, 13);
            this.password_label.TabIndex = 14;
            this.password_label.Text = "Password:";
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(73, 19);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(195, 20);
            this.username_textbox.TabIndex = 13;
            // 
            // roles_tab
            // 
            this.roles_tab.Controls.Add(this.role_datagridview);
            this.roles_tab.Location = new System.Drawing.Point(4, 22);
            this.roles_tab.Name = "roles_tab";
            this.roles_tab.Padding = new System.Windows.Forms.Padding(3);
            this.roles_tab.Size = new System.Drawing.Size(464, 386);
            this.roles_tab.TabIndex = 0;
            this.roles_tab.Text = "Roles";
            this.roles_tab.UseVisualStyleBackColor = true;
            // 
            // role_datagridview
            // 
            this.role_datagridview.AllowUserToAddRows = false;
            this.role_datagridview.AllowUserToDeleteRows = false;
            this.role_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.role_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.role_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.role_datagridview.Location = new System.Drawing.Point(6, 6);
            this.role_datagridview.Name = "role_datagridview";
            this.role_datagridview.RowHeadersWidth = 51;
            this.role_datagridview.Size = new System.Drawing.Size(452, 374);
            this.role_datagridview.TabIndex = 7;
            // 
            // tables_tab
            // 
            this.tables_tab.Controls.Add(this.table_datagridview);
            this.tables_tab.Location = new System.Drawing.Point(4, 22);
            this.tables_tab.Name = "tables_tab";
            this.tables_tab.Padding = new System.Windows.Forms.Padding(3);
            this.tables_tab.Size = new System.Drawing.Size(464, 386);
            this.tables_tab.TabIndex = 1;
            this.tables_tab.Text = "Tables & Views";
            this.tables_tab.UseVisualStyleBackColor = true;
            // 
            // table_datagridview
            // 
            this.table_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViewDetailButton});
            this.table_datagridview.Location = new System.Drawing.Point(7, 7);
            this.table_datagridview.Name = "table_datagridview";
            this.table_datagridview.RowHeadersWidth = 51;
            this.table_datagridview.Size = new System.Drawing.Size(451, 373);
            this.table_datagridview.TabIndex = 0;
            // 
            // ViewDetailButton
            // 
            this.ViewDetailButton.FillWeight = 50F;
            this.ViewDetailButton.HeaderText = "";
            this.ViewDetailButton.Name = "ViewDetailButton";
            this.ViewDetailButton.Text = "Chi tiết";
            this.ViewDetailButton.UseColumnTextForButtonValue = true;
            // 
            // privs_tab
            // 
            this.privs_tab.Controls.Add(this.privs_datagridview);
            this.privs_tab.Location = new System.Drawing.Point(4, 22);
            this.privs_tab.Name = "privs_tab";
            this.privs_tab.Padding = new System.Windows.Forms.Padding(3);
            this.privs_tab.Size = new System.Drawing.Size(464, 386);
            this.privs_tab.TabIndex = 2;
            this.privs_tab.Text = "System Privileges";
            this.privs_tab.UseVisualStyleBackColor = true;
            // 
            // privs_datagridview
            // 
            this.privs_datagridview.AllowUserToAddRows = false;
            this.privs_datagridview.AllowUserToDeleteRows = false;
            this.privs_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.privs_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.privs_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.privs_datagridview.Location = new System.Drawing.Point(7, 7);
            this.privs_datagridview.Name = "privs_datagridview";
            this.privs_datagridview.RowHeadersWidth = 51;
            this.privs_datagridview.Size = new System.Drawing.Size(451, 373);
            this.privs_datagridview.TabIndex = 0;
            // 
            // save_button
            // 
            this.save_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_button.Location = new System.Drawing.Point(409, 431);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 16;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // EditUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 466);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.tabcontrols);
            this.Name = "EditUserControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditUserControl";
            this.tabcontrols.ResumeLayout(false);
            this.user_tab.ResumeLayout(false);
            this.user_tab.PerformLayout();
            this.roles_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).EndInit();
            this.tables_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table_datagridview)).EndInit();
            this.privs_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.privs_datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontrols;
        private System.Windows.Forms.TabPage roles_tab;
        private System.Windows.Forms.DataGridView role_datagridview;
        private System.Windows.Forms.TabPage tables_tab;
        private System.Windows.Forms.DataGridView table_datagridview;
        private System.Windows.Forms.TabPage privs_tab;
        private System.Windows.Forms.DataGridView privs_datagridview;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.DataGridViewButtonColumn ViewDetailButton;
        private System.Windows.Forms.TabPage user_tab;
    }
}