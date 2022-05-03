namespace ATBM191_09_UI
{
    partial class UserControl
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
            this.create_button = new System.Windows.Forms.Button();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.username_label = new System.Windows.Forms.Label();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.privs_tab = new System.Windows.Forms.TabPage();
            this.privs_datagridview = new System.Windows.Forms.DataGridView();
            this.tables_tab = new System.Windows.Forms.TabPage();
            this.table_datagridview = new System.Windows.Forms.DataGridView();
            this.roles_tab = new System.Windows.Forms.TabPage();
            this.role_datagridview = new System.Windows.Forms.DataGridView();
            this.tabcontrols = new System.Windows.Forms.TabControl();
            this.privs_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.privs_datagridview)).BeginInit();
            this.tables_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_datagridview)).BeginInit();
            this.roles_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).BeginInit();
            this.tabcontrols.SuspendLayout();
            this.SuspendLayout();
            // 
            // create_button
            // 
            this.create_button.Location = new System.Drawing.Point(397, 53);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(75, 23);
            this.create_button.TabIndex = 6;
            this.create_button.Text = "Create";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(84, 20);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(307, 20);
            this.username_textbox.TabIndex = 5;
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(12, 23);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(61, 13);
            this.username_label.TabIndex = 4;
            this.username_label.Text = "Username: ";
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(84, 56);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(307, 20);
            this.password_textbox.TabIndex = 9;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(12, 59);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(56, 13);
            this.password_label.TabIndex = 8;
            this.password_label.Text = "Password:";
            // 
            // privs_tab
            // 
            this.privs_tab.Controls.Add(this.privs_datagridview);
            this.privs_tab.Location = new System.Drawing.Point(4, 22);
            this.privs_tab.Name = "privs_tab";
            this.privs_tab.Padding = new System.Windows.Forms.Padding(3);
            this.privs_tab.Size = new System.Drawing.Size(765, 318);
            this.privs_tab.TabIndex = 2;
            this.privs_tab.Text = "System Privileges";
            this.privs_tab.UseVisualStyleBackColor = true;
            // 
            // privs_datagridview
            // 
            this.privs_datagridview.AllowUserToAddRows = false;
            this.privs_datagridview.AllowUserToDeleteRows = false;
            this.privs_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.privs_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.privs_datagridview.Location = new System.Drawing.Point(7, 7);
            this.privs_datagridview.Name = "privs_datagridview";
            this.privs_datagridview.Size = new System.Drawing.Size(752, 305);
            this.privs_datagridview.TabIndex = 0;
            // 
            // tables_tab
            // 
            this.tables_tab.Controls.Add(this.table_datagridview);
            this.tables_tab.Location = new System.Drawing.Point(4, 22);
            this.tables_tab.Name = "tables_tab";
            this.tables_tab.Padding = new System.Windows.Forms.Padding(3);
            this.tables_tab.Size = new System.Drawing.Size(765, 318);
            this.tables_tab.TabIndex = 1;
            this.tables_tab.Text = "Tables & Views";
            this.tables_tab.UseVisualStyleBackColor = true;
            // 
            // table_datagridview
            // 
            this.table_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_datagridview.Location = new System.Drawing.Point(7, 7);
            this.table_datagridview.Name = "table_datagridview";
            this.table_datagridview.Size = new System.Drawing.Size(752, 305);
            this.table_datagridview.TabIndex = 0;
            // 
            // roles_tab
            // 
            this.roles_tab.Controls.Add(this.role_datagridview);
            this.roles_tab.Location = new System.Drawing.Point(4, 22);
            this.roles_tab.Name = "roles_tab";
            this.roles_tab.Padding = new System.Windows.Forms.Padding(3);
            this.roles_tab.Size = new System.Drawing.Size(765, 318);
            this.roles_tab.TabIndex = 0;
            this.roles_tab.Text = "Roles";
            this.roles_tab.UseVisualStyleBackColor = true;
            // 
            // role_datagridview
            // 
            this.role_datagridview.AllowUserToAddRows = false;
            this.role_datagridview.AllowUserToDeleteRows = false;
            this.role_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.role_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.role_datagridview.Location = new System.Drawing.Point(6, 6);
            this.role_datagridview.Name = "role_datagridview";
            this.role_datagridview.Size = new System.Drawing.Size(753, 306);
            this.role_datagridview.TabIndex = 7;
            // 
            // tabcontrols
            // 
            this.tabcontrols.Controls.Add(this.roles_tab);
            this.tabcontrols.Controls.Add(this.tables_tab);
            this.tabcontrols.Controls.Add(this.privs_tab);
            this.tabcontrols.Location = new System.Drawing.Point(15, 94);
            this.tabcontrols.Name = "tabcontrols";
            this.tabcontrols.SelectedIndex = 0;
            this.tabcontrols.Size = new System.Drawing.Size(773, 344);
            this.tabcontrols.TabIndex = 10;
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabcontrols);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.username_label);
            this.Name = "UserControl";
            this.Text = "UserControl";
            this.privs_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.privs_datagridview)).EndInit();
            this.tables_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table_datagridview)).EndInit();
            this.roles_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).EndInit();
            this.tabcontrols.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TabPage privs_tab;
        private System.Windows.Forms.DataGridView privs_datagridview;
        private System.Windows.Forms.TabPage tables_tab;
        private System.Windows.Forms.DataGridView table_datagridview;
        private System.Windows.Forms.TabPage roles_tab;
        private System.Windows.Forms.DataGridView role_datagridview;
        private System.Windows.Forms.TabControl tabcontrols;
    }
}