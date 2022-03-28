
namespace ATBM191_09_UI
{
    partial class ViewControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.vwNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.queryRTxt = new System.Windows.Forms.RichTextBox();
            this.resDataGVw = new System.Windows.Forms.DataGridView();
            this.vwCreateBtn = new System.Windows.Forms.Button();
            this.cancelVwCreateBtn = new System.Windows.Forms.Button();
            this.showResBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resDataGVw)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên:";
            // 
            // vwNameTxt
            // 
            this.vwNameTxt.Location = new System.Drawing.Point(69, 10);
            this.vwNameTxt.Name = "vwNameTxt";
            this.vwNameTxt.Size = new System.Drawing.Size(216, 22);
            this.vwNameTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Truy vấn SQL";
            // 
            // queryRTxt
            // 
            this.queryRTxt.Location = new System.Drawing.Point(29, 94);
            this.queryRTxt.Name = "queryRTxt";
            this.queryRTxt.Size = new System.Drawing.Size(736, 137);
            this.queryRTxt.TabIndex = 3;
            this.queryRTxt.Text = "";
            // 
            // resDataGVw
            // 
            this.resDataGVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resDataGVw.Location = new System.Drawing.Point(29, 272);
            this.resDataGVw.Name = "resDataGVw";
            this.resDataGVw.RowHeadersWidth = 51;
            this.resDataGVw.RowTemplate.Height = 24;
            this.resDataGVw.Size = new System.Drawing.Size(736, 104);
            this.resDataGVw.TabIndex = 4;
            // 
            // vwCreateBtn
            // 
            this.vwCreateBtn.Location = new System.Drawing.Point(586, 400);
            this.vwCreateBtn.Name = "vwCreateBtn";
            this.vwCreateBtn.Size = new System.Drawing.Size(75, 38);
            this.vwCreateBtn.TabIndex = 6;
            this.vwCreateBtn.Text = "Tạo";
            this.vwCreateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.vwCreateBtn.UseVisualStyleBackColor = true;
            this.vwCreateBtn.Click += new System.EventHandler(this.vwCreateBtn_Click);
            // 
            // cancelVwCreateBtn
            // 
            this.cancelVwCreateBtn.Location = new System.Drawing.Point(681, 400);
            this.cancelVwCreateBtn.Name = "cancelVwCreateBtn";
            this.cancelVwCreateBtn.Size = new System.Drawing.Size(75, 38);
            this.cancelVwCreateBtn.TabIndex = 7;
            this.cancelVwCreateBtn.Text = "Hủy";
            this.cancelVwCreateBtn.UseVisualStyleBackColor = true;
            this.cancelVwCreateBtn.Click += new System.EventHandler(this.cancelVwCreateBtn_Click);
            // 
            // showResBtn
            // 
            this.showResBtn.Location = new System.Drawing.Point(29, 238);
            this.showResBtn.Name = "showResBtn";
            this.showResBtn.Size = new System.Drawing.Size(105, 28);
            this.showResBtn.TabIndex = 8;
            this.showResBtn.Text = "Xem kết quả";
            this.showResBtn.UseVisualStyleBackColor = true;
            this.showResBtn.Click += new System.EventHandler(this.showResBtn_Click);
            // 
            // ViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showResBtn);
            this.Controls.Add(this.cancelVwCreateBtn);
            this.Controls.Add(this.vwCreateBtn);
            this.Controls.Add(this.resDataGVw);
            this.Controls.Add(this.queryRTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vwNameTxt);
            this.Controls.Add(this.label1);
            this.Name = "ViewControl";
            this.Text = "Tạo View";
            ((System.ComponentModel.ISupportInitialize)(this.resDataGVw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vwNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox queryRTxt;
        private System.Windows.Forms.DataGridView resDataGVw;
        private System.Windows.Forms.Button vwCreateBtn;
        private System.Windows.Forms.Button cancelVwCreateBtn;
        private System.Windows.Forms.Button showResBtn;
    }
}