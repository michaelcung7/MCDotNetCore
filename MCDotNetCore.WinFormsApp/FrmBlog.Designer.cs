namespace MCDotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            txtContent = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(67, 160, 71);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(359, 278);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 36);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += this.btnSave_Click;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(192, 182);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(327, 66);
            txtContent.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(192, 115);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(327, 25);
            txtAuthor.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(192, 51);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(327, 25);
            txtTitle.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(185, 160);
            label1.Name = "label1";
            label1.Size = new Size(62, 19);
            label1.TabIndex = 4;
            label1.Text = "Content:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 93);
            label2.Name = "label2";
            label2.Size = new Size(55, 19);
            label2.TabIndex = 5;
            label2.Text = "Author:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 29);
            label3.Name = "label3";
            label3.Size = new Size(37, 19);
            label3.TabIndex = 6;
            label3.Text = "Title:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(84, 110, 122);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(245, 278);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 404);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Controls.Add(txtAuthor);
            Controls.Add(txtContent);
            Controls.Add(btnSave);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtContent;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
    }
}
