using System;
using System.Windows.Forms;

namespace Library

{
    public partial class CHINHSUASACH : Form
    {
        public Books sachCanSua { get; private set; }

        public CHINHSUASACH(Books book)
        {
            InitializeComponent();
            sachCanSua = book;

            
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtCategory.Text = book.Category;
            txtYear.Text = book.Year;
            txtURL.Text = book.Url;
            txtDescript.Text = book.Description;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text) ||
                string.IsNullOrWhiteSpace(txtURL.Text) ||
                string.IsNullOrWhiteSpace(txtDescript.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            sachCanSua.Title = txtTitle.Text;
            sachCanSua.Author = txtAuthor.Text;
            sachCanSua.Category = txtCategory.Text;
            sachCanSua.Year = txtYear.Text;
            sachCanSua.Url = txtURL.Text;
            sachCanSua.Description = txtDescript.Text;

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
