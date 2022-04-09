
namespace ATBM191_09_UI
{
    partial class EditRoleControl
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
            this.save_button = new System.Windows.Forms.Button();
            this.tabcontrols = new System.Windows.Forms.TabControl();
            this.role_tab = new System.Windows.Forms.TabPage();
            this.username_label = new System.Windows.Forms.Label();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.rolename_textbox = new System.Windows.Forms.TextBox();
            this.roles_tab = new System.Windows.Forms.TabPage();
            this.role_datagridview = new System.Windows.Forms.DataGridView();
            this.tables_tab = new System.Windows.Forms.TabPage();
            this.table_datagridview = new System.Windows.Forms.DataGridView();
            this.ViewDetailButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.privs_tab = new System.Windows.Forms.TabPage();
            this.privs_datagridview = new System.Windows.Forms.DataGridView();
            this.tabcontrols.SuspendLayout();
            this.role_tab.SuspendLayout();
            this.roles_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).BeginInit();
            this.tables_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_datagridview)).BeginInit();
            this.privs_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.privs_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_button.Location = new System.Drawing.Point(544, 531);
            this.save_button.Margin = new System.Windows.Forms.Padding(4);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(100, 28);
            this.save_button.TabIndex = 18;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // tabcontrols
            // 
            this.tabcontrols.Controls.Add(this.role_tab);
            this.tabcontrols.Controls.Add(this.roles_tab);
            this.tabcontrols.Controls.Add(this.tables_tab);
            this.tabcontrols.Controls.Add(this.privs_tab);
            this.tabcontrols.Location = new System.Drawing.Point(15, 16);
            this.tabcontrols.Margin = new System.Windows.Forms.Padding(4);
            this.tabcontrols.Name = "tabcontrols";
            this.tabcontrols.SelectedIndex = 0;
            this.tabcontrols.Size = new System.Drawing.Size(629, 507);
            this.tabcontrols.TabIndex = 17;
            // 
            // role_tab
            // 
            this.role_tab.Controls.Add(this.username_label);
            this.role_tab.Controls.Add(this.password_textbox);
            this.role_tab.Controls.Add(this.password_label);
            this.role_tab.Controls.Add(this.rolename_textbox);
            this.role_tab.Location = new System.Drawing.Point(4, 25);
            this.role_tab.Margin = new System.Windows.Forms.Padding(4);
            this.role_tab.Name = "role_tab";
            this.role_tab.Size = new System.Drawing.Size(621, 478);
            this.role_tab.TabIndex = 3;
            this.role_tab.Text = "Role";
            this.role_tab.UseVisualStyleBackColor = true;
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(15, 27);
            this.username_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(80, 17);
            this.username_label.TabIndex = 12;
            this.username_label.Text = "Rolename: ";
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(97, 70);
            this.password_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(259, 22);
            this.password_textbox.TabIndex = 15;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(15, 74);
            this.password_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(73, 17);
            this.password_label.TabIndex = 14;
            this.password_label.Text = "Password:";
            // 
            // rolename_textbox
            // 
            this.rolename_textbox.Location = new System.Drawing.Point(97, 23);
            this.rolename_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.rolename_textbox.Name = "rolename_textbox";
            this.rolename_textbox.Size = new System.Drawing.Size(259, 22);
            this.rolename_textbox.TabIndex = 13;
            // 
            // roles_tab
            // 
            this.roles_tab.Controls.Add(this.role_datagridview);
            this.roles_tab.Location = new System.Drawing.Point(4, 25);
            this.roles_tab.Margin = new System.Windows.Forms.Padding(4);
            this.roles_tab.Name = "roles_tab";
            this.roles_tab.Padding = new System.Windows.Forms.Padding(4);
            this.roles_tab.Size = new System.Drawing.Size(621, 478);
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
            this.role_datagridview.Location = new System.Drawing.Point(8, 7);
            this.role_datagridview.Margin = new System.Windows.Forms.Padding(4);
            this.role_datagridview.Name = "role_datagridview";
            this.role_datagridview.RowHeadersWidth = 51;
            this.role_datagridview.Size = new System.Drawing.Size(603, 460);
            this.role_datagridview.TabIndex = 7;
            // 
            // tables_tab
            // 
            this.tables_tab.Controls.Add(this.table_datagridview);
            this.tables_tab.Location = new System.Drawing.Point(4, 25);
            this.tables_tab.Margin = new System.Windows.Forms.Padding(4);
            this.tables_tab.Name = "tables_tab";
            this.tables_tab.Padding = new System.Windows.Forms.Padding(4);
            this.tables_tab.Size = new System.Drawing.Size(621, 478);
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
            this.table_datagridview.Location = new System.Drawing.Point(9, 9);
            this.table_datagridview.Margin = new System.Windows.Forms.Padding(4);
            this.table_datagridview.Name = "table_datagridview";
            this.table_datagridview.RowHeadersWidth = 51;
            this.table_datagridview.Size = new System.Drawing.Size(601, 459);
            this.table_datagridview.TabIndex = 0;
            // 
            // ViewDetailButton
            // 
            this.ViewDetailButton.FillWeight = 50F;
            this.ViewDetailButton.HeaderText = "";
            this.ViewDetailButton.MinimumWidth = 6;
            this.ViewDetailButton.Name = "ViewDetailButton";
            this.ViewDetailButton.Text = "Chi tiết";
            this.ViewDetailButton.UseColumnTextForButtonValue = true;
            // 
            // privs_tab
            // 
            this.privs_tab.Controls.Add(this.privs_datagridview);
            this.privs_tab.Location = new System.Drawing.Point(4, 25);
            this.privs_tab.Margin = new System.Windows.Forms.Padding(4);
            this.privs_tab.Name = "privs_tab";
            this.privs_tab.Padding = new System.Windows.Forms.Padding(4);
            this.privs_tab.Size = new System.Drawing.Size(621, 478);
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
            this.privs_datagridview.Location = new System.Drawing.Point(9, 9);
            this.privs_datagridview.Margin = new System.Windows.Forms.Padding(4);
            this.privs_datagridview.Name = "privs_datagridview";
            this.privs_datagridview.RowHeadersWidth = 51;
            this.privs_datagridview.Size = new System.Drawing.Size(601, 459);
            this.privs_datagridview.TabIndex = 0;
            // 
            // EditRoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 574);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.tabcontrols);
            this.Name = "EditRoleControl";
            this.Text = "EditRoleControl";
            this.tabcontrols.ResumeLayout(false);
            this.role_tab.ResumeLayout(false);
            this.role_tab.PerformLayout();
            this.roles_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).EndInit();
            this.tables_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table_datagridview)).EndInit();
            this.privs_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.privs_datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TabControl tabcontrols;
        private System.Windows.Forms.TabPage role_tab;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox rolename_textbox;
        private System.Windows.Forms.TabPage roles_tab;
        private System.Windows.Forms.DataGridView role_datagridview;
        private System.Windows.Forms.TabPage tables_tab;
        private System.Windows.Forms.DataGridView table_datagridview;
        private System.Windows.Forms.DataGridViewButtonColumn ViewDetailButton;
        private System.Windows.Forms.TabPage privs_tab;
        private System.Windows.Forms.DataGridView privs_datagridview;
    }
}