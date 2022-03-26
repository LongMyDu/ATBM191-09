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
            this.role_datagridview = new System.Windows.Forms.DataGridView();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            // role_datagridview
            // 
            this.role_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.role_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.role_datagridview.Location = new System.Drawing.Point(6, 6);
            this.role_datagridview.Name = "role_datagridview";
            this.role_datagridview.Size = new System.Drawing.Size(753, 306);
            this.role_datagridview.TabIndex = 7;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 344);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.role_datagridview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(765, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(765, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 7);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(752, 305);
            this.dataGridView2.TabIndex = 0;
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.username_label);
            this.Name = "UserControl";
            this.Text = "UserControl";
            ((System.ComponentModel.ISupportInitialize)(this.role_datagridview)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.DataGridView role_datagridview;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}