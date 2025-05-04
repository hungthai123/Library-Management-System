using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Library
{
    partial class EDITSACHMUON
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.txtReturnDate = new System.Windows.Forms.TextBox();
            this.txtIssueDate = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.Location = new System.Drawing.Point(400, 327);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(99, 45);
            this.btCancel.TabIndex = 27;
            this.btCancel.Text = "No";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOk.Location = new System.Drawing.Point(232, 327);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(99, 45);
            this.btOk.TabIndex = 13;
            this.btOk.Text = "Yes";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // txtReturnDate
            // 
            this.txtReturnDate.BackColor = System.Drawing.Color.LightYellow;
            this.txtReturnDate.Location = new System.Drawing.Point(221, 239);
            this.txtReturnDate.Name = "txtReturnDate";
            this.txtReturnDate.ReadOnly = true;
            this.txtReturnDate.Size = new System.Drawing.Size(409, 22);
            this.txtReturnDate.TabIndex = 25;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.BackColor = System.Drawing.Color.LightYellow;
            this.txtIssueDate.Location = new System.Drawing.Point(221, 199);
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.ReadOnly = true;
            this.txtIssueDate.Size = new System.Drawing.Size(409, 22);
            this.txtIssueDate.TabIndex = 26;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.Color.LightYellow;
            this.txtAuthor.Location = new System.Drawing.Point(221, 159);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(409, 22);
            this.txtAuthor.TabIndex = 23;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.Color.LightYellow;
            this.txtBookTitle.Location = new System.Drawing.Point(221, 119);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.ReadOnly = true;
            this.txtBookTitle.Size = new System.Drawing.Size(409, 22);
            this.txtBookTitle.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label7.Location = new System.Drawing.Point(38, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 31);
            this.label7.TabIndex = 16;
            this.label7.Text = "Status:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label6.Location = new System.Drawing.Point(38, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 31);
            this.label6.TabIndex = 17;
            this.label6.Text = "Return Date:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label5.Location = new System.Drawing.Point(38, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 31);
            this.label5.TabIndex = 18;
            this.label5.Text = "Issue Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label4.Location = new System.Drawing.Point(38, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 31);
            this.label4.TabIndex = 19;
            this.label4.Text = "Author:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.Location = new System.Drawing.Point(38, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 31);
            this.label3.TabIndex = 20;
            this.label3.Text = "Book Title:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(683, 65);
            this.label1.TabIndex = 21;
            this.label1.Text = "Edit Borrowed Books";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboStatus
            // 
            this.comboStatus.BackColor = System.Drawing.Color.LightYellow;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(221, 276);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(409, 24);
            this.comboStatus.TabIndex = 28;
            // 
            // EDITSACHMUON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(683, 385);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.txtReturnDate);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "EDITSACHMUON";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDITSACHMUON";
            this.Load += new System.EventHandler(this.EDITSACHMUON_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btCancel;
        private Button btOk;
        private TextBox txtReturnDate;
        private TextBox txtIssueDate;
        private TextBox txtAuthor;
        private TextBox txtBookTitle;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private ComboBox comboStatus;
    }
}