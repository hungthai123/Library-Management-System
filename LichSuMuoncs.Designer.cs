namespace Library
{
    partial class LichSuMuoncs
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
            this.lbLS = new System.Windows.Forms.Label();
            this.DTG = new System.Windows.Forms.DataGridView();
            this.NameBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DTG)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLS
            // 
            this.lbLS.AutoSize = true;
            this.lbLS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLS.Location = new System.Drawing.Point(477, 20);
            this.lbLS.Name = "lbLS";
            this.lbLS.Size = new System.Drawing.Size(147, 48);
            this.lbLS.TabIndex = 0;
            this.lbLS.Text = "History";
            // 
            // DTG
            // 
            this.DTG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DTG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameBook,
            this.Author,
            this.category,
            this.Year});
            this.DTG.Location = new System.Drawing.Point(57, 134);
            this.DTG.Name = "DTG";
            this.DTG.RowHeadersWidth = 51;
            this.DTG.RowTemplate.Height = 24;
            this.DTG.Size = new System.Drawing.Size(953, 436);
            this.DTG.TabIndex = 1;
            // 
            // NameBook
            // 
            this.NameBook.HeaderText = "Tên Sách";
            this.NameBook.MinimumWidth = 6;
            this.NameBook.Name = "NameBook";
            // 
            // Author
            // 
            this.Author.HeaderText = "Tác Giả";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            // 
            // category
            // 
            this.category.HeaderText = "Thể loại";
            this.category.MinimumWidth = 6;
            this.category.Name = "category";
            // 
            // Year
            // 
            this.Year.HeaderText = "Năm";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            // 
            // LichSuMuoncs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 568);
            this.Controls.Add(this.DTG);
            this.Controls.Add(this.lbLS);
            this.Name = "LichSuMuoncs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LichSuMuoncs";
            ((System.ComponentModel.ISupportInitialize)(this.DTG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLS;
        private System.Windows.Forms.DataGridView DTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
    }
}