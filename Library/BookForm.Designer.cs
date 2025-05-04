namespace Library
{
    partial class BookForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbIMG = new System.Windows.Forms.PictureBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.gbDescrip = new System.Windows.Forms.GroupBox();
            this.btnYT = new System.Windows.Forms.Button();
            this.btnMuon = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMG)).BeginInit();
            this.gbDescrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label5.Location = new System.Drawing.Point(310, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label4.Location = new System.Drawing.Point(310, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.Location = new System.Drawing.Point(310, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Author:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.Location = new System.Drawing.Point(310, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Title:";
            // 
            // pbIMG
            // 
            this.pbIMG.Location = new System.Drawing.Point(29, 38);
            this.pbIMG.Name = "pbIMG";
            this.pbIMG.Size = new System.Drawing.Size(255, 290);
            this.pbIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIMG.TabIndex = 5;
            this.pbIMG.TabStop = false;
            // 
            // lbDescription
            // 
            this.lbDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbDescription.Location = new System.Drawing.Point(7, 43);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(1034, 110);
            this.lbDescription.TabIndex = 0;
            // 
            // lbAuthor
            // 
            this.lbAuthor.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbAuthor.Location = new System.Drawing.Point(418, 122);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(540, 27);
            this.lbAuthor.TabIndex = 4;
            // 
            // lbCategory
            // 
            this.lbCategory.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbCategory.Location = new System.Drawing.Point(507, 204);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(561, 27);
            this.lbCategory.TabIndex = 2;
            // 
            // lbYear
            // 
            this.lbYear.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbYear.Location = new System.Drawing.Point(507, 286);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(561, 27);
            this.lbYear.TabIndex = 1;
            // 
            // gbDescrip
            // 
            this.gbDescrip.Controls.Add(this.btnYT);
            this.gbDescrip.Controls.Add(this.lbDescription);
            this.gbDescrip.Controls.Add(this.btnMuon);
            this.gbDescrip.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.gbDescrip.Location = new System.Drawing.Point(27, 366);
            this.gbDescrip.Name = "gbDescrip";
            this.gbDescrip.Size = new System.Drawing.Size(1073, 314);
            this.gbDescrip.TabIndex = 0;
            this.gbDescrip.TabStop = false;
            this.gbDescrip.Text = "Description";
            // 
            // btnYT
            // 
            this.btnYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYT.Location = new System.Drawing.Point(863, 200);
            this.btnYT.Name = "btnYT";
            this.btnYT.Size = new System.Drawing.Size(135, 35);
            this.btnYT.TabIndex = 11;
            this.btnYT.Text = "Yêu Thích";
            this.btnYT.UseVisualStyleBackColor = true;
            this.btnYT.Click += new System.EventHandler(this.btnYT_Click);
            // 
            // btnMuon
            // 
            this.btnMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuon.Location = new System.Drawing.Point(742, 200);
            this.btnMuon.Name = "btnMuon";
            this.btnMuon.Size = new System.Drawing.Size(115, 35);
            this.btnMuon.TabIndex = 10;
            this.btnMuon.Text = "Mượn";
            this.btnMuon.UseVisualStyleBackColor = true;
            this.btnMuon.Click += new System.EventHandler(this.btnMuon_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbTitle.Location = new System.Drawing.Point(390, 41);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(561, 27);
            this.lbTitle.TabIndex = 3;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1115, 693);
            this.Controls.Add(this.gbDescrip);
            this.Controls.Add(this.lbYear);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.pbIMG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbIMG)).EndInit();
            this.gbDescrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbIMG;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.GroupBox gbDescrip;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnMuon;
        private System.Windows.Forms.Button btnYT;
    }
}
