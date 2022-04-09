
namespace ATBM191_09_UI
{
    partial class CreateRoleControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.textRoleName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(460, 154);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(90, 35);
            this.btnCreateRole.TabIndex = 2;
            this.btnCreateRole.Text = "Create";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.button1_Click);
            // 
            // textRoleName
            // 
            this.textRoleName.Location = new System.Drawing.Point(163, 59);
            this.textRoleName.Name = "textRoleName";
            this.textRoleName.Size = new System.Drawing.Size(387, 26);
            this.textRoleName.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(163, 97);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(387, 26);
            this.textPassword.TabIndex = 4;
            // 
            // CreateRoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 219);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textRoleName);
            this.Controls.Add(this.btnCreateRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateRoleControl";
            this.Text = "Create Role ";
            this.Load += new System.EventHandler(this.CreateRoleControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.TextBox textRoleName;
        private System.Windows.Forms.TextBox textPassword;
    }
}