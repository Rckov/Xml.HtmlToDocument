namespace HtmlToDocument.Example
{
    partial class Form1
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
            this.txtPathHtml = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTypeDocument = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrientation = new System.Windows.Forms.ComboBox();
            this.btConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPathHtml
            // 
            this.txtPathHtml.Location = new System.Drawing.Point(10, 25);
            this.txtPathHtml.Name = "txtPathHtml";
            this.txtPathHtml.ReadOnly = true;
            this.txtPathHtml.Size = new System.Drawing.Size(283, 20);
            this.txtPathHtml.TabIndex = 0;
            // 
            // btBrowse
            // 
            this.btBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrowse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBrowse.Location = new System.Drawing.Point(292, 25);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(52, 20);
            this.btBrowse.TabIndex = 1;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.BtBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип документа:";
            // 
            // cmbTypeDocument
            // 
            this.cmbTypeDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDocument.FormattingEnabled = true;
            this.cmbTypeDocument.Location = new System.Drawing.Point(10, 71);
            this.cmbTypeDocument.Name = "cmbTypeDocument";
            this.cmbTypeDocument.Size = new System.Drawing.Size(104, 21);
            this.cmbTypeDocument.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ориентация страниц:";
            // 
            // cmbOrientation
            // 
            this.cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrientation.FormattingEnabled = true;
            this.cmbOrientation.Location = new System.Drawing.Point(119, 71);
            this.cmbOrientation.Name = "cmbOrientation";
            this.cmbOrientation.Size = new System.Drawing.Size(115, 21);
            this.cmbOrientation.TabIndex = 5;
            // 
            // btConvert
            // 
            this.btConvert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConvert.Location = new System.Drawing.Point(239, 70);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(105, 22);
            this.btConvert.TabIndex = 6;
            this.btConvert.Text = "Конвертировать";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.BtConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Путь к html файлу:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 102);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btConvert);
            this.Controls.Add(this.cmbOrientation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTypeDocument);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.txtPathHtml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPathHtml;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTypeDocument;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOrientation;
        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.Label label3;
    }
}
