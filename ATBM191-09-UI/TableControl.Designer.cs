namespace ATBM191_09_UI
{
    partial class TableControl
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
            this.table_name_label = new System.Windows.Forms.Label();
            this.table_name_textbox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // table_name_label
            // 
            this.table_name_label.AutoSize = true;
            this.table_name_label.Location = new System.Drawing.Point(13, 22);
            this.table_name_label.Name = "table_name_label";
            this.table_name_label.Size = new System.Drawing.Size(66, 13);
            this.table_name_label.TabIndex = 0;
            this.table_name_label.Text = "Table name:";
            // 
            // table_name_textbox
            // 
            this.table_name_textbox.Location = new System.Drawing.Point(85, 19);
            this.table_name_textbox.Name = "table_name_textbox";
            this.table_name_textbox.Size = new System.Drawing.Size(307, 20);
            this.table_name_textbox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PK,
            this.ColName,
            this.DataType,
            this.ColSize,
            this.NotNull});
            this.dataGridView1.Location = new System.Drawing.Point(16, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(772, 385);
            this.dataGridView1.TabIndex = 2;
            // 
            // PK
            // 
            this.PK.HeaderText = "PK";
            this.PK.Name = "PK";
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            // 
            // DataType
            // 
            this.DataType.HeaderText = "Data Type";
            this.DataType.Name = "DataType";
            // 
            // ColSize
            // 
            this.ColSize.HeaderText = "Size";
            this.ColSize.Name = "ColSize";
            // 
            // NotNull
            // 
            this.NotNull.HeaderText = "Not null";
            this.NotNull.Name = "NotNull";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.table_name_textbox);
            this.Controls.Add(this.table_name_label);
            this.Name = "TableControl";
            this.Text = "TableControl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label table_name_label;
        private System.Windows.Forms.TextBox table_name_textbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNull;
        private System.Windows.Forms.Button button1;
    }
}