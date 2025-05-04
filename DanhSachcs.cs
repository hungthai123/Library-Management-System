using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class DanhSachcs : Form
    {
        public DanhSachcs()
        {
            InitializeComponent();
            addBooks("");
        }

        public void addBooks(string keywords) {
            Panel panel = this.Controls.OfType<Panel>().FirstOrDefault(p=>p.Name == "booksContainer");
            
            string photosDirectory = Path.Combine(Application.StartupPath, "Photos");
            string booksDirectory = Path.Combine(Application.StartupPath, "Books.txt");
            string [] existingJson = File.ReadAllLines(booksDirectory);
            List<Books> books = new List<Books>();
            foreach (string line in existingJson)
            {
                var bookData = line.Split(',');
                if (bookData.Length >= 8)
                {
                    books.Add(new Books
                    {
                        Title = bookData[0].Trim(),
                        Author = bookData[1].Trim(),
                        Category = bookData[2].Trim() + ',' + bookData[3].Trim(),
                        Year = bookData[4].Trim(),
                        Url = bookData[5].Trim(),
                        Description = bookData[6].Trim(),
                        ReturnDate = DateTime.Now.ToString(),
                        Status = bookData[7].Trim()
                    });

                }
            }
            panel.Controls.Clear();
            var booksearch = books.Where(b=> b.Title.ToLower().Contains(keywords)).ToList();
            int x = 10, y = 10;
            if (booksearch.Count == 0)
            {
                Label noResult = new Label
                {
                    Text = "Không tìm thấy sách nào!",
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Red
                };
                booksContainer.Controls.Add(noResult);
            }
            foreach (var book in booksearch)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(100, 150),
                    Location = new Point(x, y),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = book, 
                };

                string imagePath = Path.Combine(photosDirectory, book.Url);
                if (File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                pictureBox.Click += pictureBox_Click;
                Label label = new Label
                {
                    Text = book.Title,
                    Location = new Point(x, y + 160),
                    AutoSize = true
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(label);
                x += 120;
                if (x + 120 > panel.Width)
                {
                    x = 10;
                    y += 200;
                }
            }

        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Tag is Books book)
            {
                BookForm bookForm = new BookForm(book);
                bookForm.Show();
            }
        }
        public void search() {
            Panel panel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "booksContainer");
            txtSearch.TextChanged += SearchBooks;
        }
        public void SearchBooks(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            addBooks(keyword);
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
            this.Close();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            this.Close();
        }
    }
}
