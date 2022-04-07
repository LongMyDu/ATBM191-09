namespace ATBM191_09_UI
{
    partial class ObjectPrivs
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TableLevel = new System.Windows.Forms.TabPage();
            this.tablelevel_datagridview = new System.Windows.Forms.DataGridView();
            this.ColumnLevel = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.update_tab = new System.Windows.Forms.TabPage();
            this.update_datagridview = new System.Windows.Forms.DataGridView();
            this.insert_tab = new System.Windows.Forms.TabPage();
            this.insert_datagridview = new System.Windows.Forms.DataGridView();
            this.Insert_PrivilegeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Insert_Granted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Insert_Grantable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.save_button = new System.Windows.Forms.Button();
            this.Update_PrivilegeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_Granted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Update_Grantable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrivilegeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Granted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Grantable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.TableLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablelevel_datagridview)).BeginInit();
            this.ColumnLevel.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.update_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.update_datagridview)).BeginInit();
            this.insert_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insert_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TableLevel);
            this.tabControl1.Controls.Add(this.ColumnLevel);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 390);
            this.tabControl1.TabIndex = 0;
            // 
            // TableLevel
            // 
            this.TableLevel.Controls.Add(this.tablelevel_datagridview);
            this.TableLevel.Location = new System.Drawing.Point(4, 22);
            this.TableLevel.Name = "TableLevel";
            this.TableLevel.Padding = new System.Windows.Forms.Padding(3);
            this.TableLevel.Size = new System.Drawing.Size(456, 364);
            this.TableLevel.TabIndex = 0;
            this.TableLevel.Text = "Table level";
            this.TableLevel.UseVisualStyleBackColor = true;
            // 
            // tablelevel_datagridview
            // 
            this.tablelevel_datagridview.AllowUserToAddRows = false;
            this.tablelevel_datagridview.AllowUserToDeleteRows = false;
            this.tablelevel_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablelevel_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablelevel_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablelevel_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrivilegeName,
            this.Granted,
            this.Grantable});
            this.tablelevel_datagridview.Location = new System.Drawing.Point(6, 6);
            this.tablelevel_datagridview.Name = "tablelevel_datagridview";
            this.tablelevel_datagridview.Size = new System.Drawing.Size(444, 352);
            this.tablelevel_datagridview.TabIndex = 10;
            // 
            // ColumnLevel
            // 
            this.ColumnLevel.Controls.Add(this.tabControl2);
            this.ColumnLevel.Location = new System.Drawing.Point(4, 22);
            this.ColumnLevel.Name = "ColumnLevel";
            this.ColumnLevel.Padding = new System.Windows.Forms.Padding(3);
            this.ColumnLevel.Size = new System.Drawing.Size(456, 364);
            this.ColumnLevel.TabIndex = 1;
            this.ColumnLevel.Text = "Column level";
            this.ColumnLevel.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.update_tab);
            this.tabControl2.Controls.Add(this.insert_tab);
            this.tabControl2.Location = new System.Drawing.Point(7, 7);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(443, 351);
            this.tabControl2.TabIndex = 12;
            // 
            // update_tab
            // 
            this.update_tab.Controls.Add(this.update_datagridview);
            this.update_tab.Location = new System.Drawing.Point(4, 22);
            this.update_tab.Name = "update_tab";
            this.update_tab.Padding = new System.Windows.Forms.Padding(3);
            this.update_tab.Size = new System.Drawing.Size(435, 325);
            this.update_tab.TabIndex = 0;
            this.update_tab.Text = "Update";
            this.update_tab.UseVisualStyleBackColor = true;
            // 
            // update_datagridview
            // 
            this.update_datagridview.AllowUserToAddRows = false;
            this.update_datagridview.AllowUserToDeleteRows = false;
            this.update_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.update_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.update_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.update_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Update_PrivilegeName,
            this.Update_Granted,
            this.Update_Grantable});
            this.update_datagridview.Location = new System.Drawing.Point(6, 6);
            this.update_datagridview.Name = "update_datagridview";
            this.update_datagridview.Size = new System.Drawing.Size(423, 313);
            this.update_datagridview.TabIndex = 11;
            // 
            // insert_tab
            // 
            this.insert_tab.Controls.Add(this.insert_datagridview);
            this.insert_tab.Location = new System.Drawing.Point(4, 22);
            this.insert_tab.Name = "insert_tab";
            this.insert_tab.Padding = new System.Windows.Forms.Padding(3);
            this.insert_tab.Size = new System.Drawing.Size(435, 325);
            this.insert_tab.TabIndex = 1;
            this.insert_tab.Text = "Insert";
            this.insert_tab.UseVisualStyleBackColor = true;
            // 
            // insert_datagridview
            // 
            this.insert_datagridview.AllowUserToAddRows = false;
            this.insert_datagridview.AllowUserToDeleteRows = false;
            this.insert_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insert_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.insert_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insert_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Insert_PrivilegeName,
            this.Insert_Granted,
            this.Insert_Grantable});
            this.insert_datagridview.Location = new System.Drawing.Point(6, 6);
            this.insert_datagridview.Name = "insert_datagridview";
            this.insert_datagridview.Size = new System.Drawing.Size(423, 313);
            this.insert_datagridview.TabIndex = 12;
            // 
            // Insert_PrivilegeName
            // 
            this.Insert_PrivilegeName.HeaderText = "Privilege";
            this.Insert_PrivilegeName.Name = "Insert_PrivilegeName";
            this.Insert_PrivilegeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Insert_PrivilegeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Insert_Granted
            // 
            this.Insert_Granted.FillWeight = 80F;
            this.Insert_Granted.HeaderText = "Granted";
            this.Insert_Granted.Name = "Insert_Granted";
            // 
            // Insert_Grantable
            // 
            this.Insert_Grantable.FillWeight = 80F;
            this.Insert_Grantable.HeaderText = "Grantable";
            this.Insert_Grantable.Name = "Insert_Grantable";
            // 
            // save_button
            // 
            this.save_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_button.Location = new System.Drawing.Point(402, 415);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 17;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // Update_PrivilegeName
            // 
            this.Update_PrivilegeName.HeaderText = "Privilege";
            this.Update_PrivilegeName.Name = "Update_PrivilegeName";
            this.Update_PrivilegeName.ReadOnly = true;
            this.Update_PrivilegeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Update_PrivilegeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Update_Granted
            // 
            this.Update_Granted.FillWeight = 80F;
            this.Update_Granted.HeaderText = "Granted";
            this.Update_Granted.Name = "Update_Granted";
            // 
            // Update_Grantable
            // 
            this.Update_Grantable.FillWeight = 80F;
            this.Update_Grantable.HeaderText = "Grantable";
            this.Update_Grantable.Name = "Update_Grantable";
            // 
            // PrivilegeName
            // 
            this.PrivilegeName.HeaderText = "Privilege";
            this.PrivilegeName.Name = "PrivilegeName";
            this.PrivilegeName.ReadOnly = true;
            this.PrivilegeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PrivilegeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Granted
            // 
            this.Granted.FillWeight = 80F;
            this.Granted.HeaderText = "Granted";
            this.Granted.Name = "Granted";
            // 
            // Grantable
            // 
            this.Grantable.FillWeight = 80F;
            this.Grantable.HeaderText = "Grantable";
            this.Grantable.Name = "Grantable";
            // 
            // ObjectPrivs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 450);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.tabControl1);
            this.Name = "ObjectPrivs";
            this.Text = "ObjectPrivs";
            this.tabControl1.ResumeLayout(false);
            this.TableLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablelevel_datagridview)).EndInit();
            this.ColumnLevel.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.update_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.update_datagridview)).EndInit();
            this.insert_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.insert_datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TableLevel;
        private System.Windows.Forms.TabPage ColumnLevel;
        private System.Windows.Forms.DataGridView tablelevel_datagridview;
        private System.Windows.Forms.DataGridView update_datagridview;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage update_tab;
        private System.Windows.Forms.TabPage insert_tab;
        private System.Windows.Forms.DataGridView insert_datagridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insert_PrivilegeName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Insert_Granted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Insert_Grantable;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_PrivilegeName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Update_Granted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Update_Grantable;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivilegeName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Granted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Grantable;
    }
}