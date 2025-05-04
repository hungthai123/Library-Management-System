using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Library
{
    partial class CHINHSUASACH
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
            txtYear = new TextBox();
            txtCategory = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btOk = new Button();
            btCancel = new Button();
            label6 = new Label();
            txtURL = new TextBox();
            label7 = new Label();
            txtDescript = new TextBox();
            SuspendLayout();
            // 
            // txtYear
            // 
            txtYear.BackColor = Color.LightYellow;
            txtYear.Location = new Point(150, 192);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(393, 23);
            txtYear.TabIndex = 11;
            // 
            // txtCategory
            // 
            txtCategory.BackColor = Color.LightYellow;
            txtCategory.Location = new Point(150, 158);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(393, 23);
            txtCategory.TabIndex = 10;
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.LightYellow;
            txtAuthor.Location = new Point(150, 124);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(393, 23);
            txtAuthor.TabIndex = 5;
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.LightYellow;
            txtTitle.Location = new Point(150, 90);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(393, 23);
            txtTitle.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 15.75F);
            label5.Location = new Point(12, 188);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 6;
            label5.Text = "Year:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15.75F);
            label4.Location = new Point(12, 153);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 7;
            label4.Text = "Categrory:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F);
            label3.Location = new Point(12, 118);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 8;
            label3.Text = "Author:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F);
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 9;
            label2.Text = "Title:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(199, 9);
            label1.Name = "label1";
            label1.Size = new Size(178, 42);
            label1.TabIndex = 9;
            label1.Text = "Edit Book";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btOk
            // 
            btOk.Location = new Point(182, 328);
            btOk.Name = "btOk";
            btOk.Size = new Size(87, 42);
            btOk.TabIndex = 0;
            btOk.Text = "Yes";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += btOk_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(329, 328);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(87, 42);
            btCancel.TabIndex = 12;
            btCancel.Text = "No";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15.75F);
            label6.Location = new Point(12, 227);
            label6.Name = "label6";
            label6.Size = new Size(60, 25);
            label6.TabIndex = 6;
            label6.Text = "URL:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtURL
            // 
            txtURL.BackColor = Color.LightYellow;
            txtURL.Location = new Point(150, 232);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(393, 23);
            txtURL.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 15.75F);
            label7.Location = new Point(12, 269);
            label7.Name = "label7";
            label7.Size = new Size(119, 25);
            label7.TabIndex = 6;
            label7.Text = "Discription:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDescript
            // 
            txtDescript.BackColor = Color.LightYellow;
            txtDescript.Location = new Point(150, 274);
            txtDescript.Name = "txtDescript";
            txtDescript.Size = new Size(393, 23);
            txtDescript.TabIndex = 11;
            // 
            // CHINHSUASACH
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(598, 398);
            Controls.Add(btCancel);
            Controls.Add(btOk);
            Controls.Add(txtDescript);
            Controls.Add(txtURL);
            Controls.Add(txtYear);
            Controls.Add(txtCategory);
            Controls.Add(txtAuthor);
            Controls.Add(label7);
            Controls.Add(txtTitle);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CHINHSUASACH";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CHINHSUASACH";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtYear;
        private TextBox txtCategory;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btOk;
        private Button btCancel;
        private Label label6;
        private TextBox txtURL;
        private Label label7;
        private TextBox txtDescript;
    }
}