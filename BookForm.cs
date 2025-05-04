using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public partial class BookForm : Form
    {
        private string tmp;
        public DateTime currentDate = DateTime.Now.AddDays(7);
        public BookForm(Books b)
        {
            InitializeComponent();
            this.lbTitle.Text = b.Title;
            this.lbAuthor.Text = b.Author;
            this.lbCategory.Text = b.Category;
            this.lbYear.Text = b.Year;
            this.lbDescription.Text = b.Description;
            tmp = b.Url;
            string photosDirectory = Path.Combine(Application.StartupPath, "Photos");
            pbIMG.Image = Image.FromFile(Path.Combine(photosDirectory, b.Url));
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (TrangThai.currentUser != null)
            {
                Books book = new Books
                {
                    Title = lbTitle.Text,
                    Author = lbAuthor.Text,
                    Category = lbCategory.Text,
                    Year = lbYear.Text,
                    ReturnDate = currentDate.ToString(),
                    Description = lbDescription.Text,
                    Url = tmp,
                    Status = "Borrowed"
                };
                TrangThai.currentUser.sachMuon.Add(book);

                string filePath = Path.Combine(Application.StartupPath, "User.txt");

                if (File.Exists(filePath))
                {
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    for (int i = 0; i < lines.Count; i += 3)
                    {
                        string[] userData = lines[i].Split(',');
                        if (userData.Length >= 2 && userData[0].Trim() == TrangThai.currentUser.Name)
                        {
                            
                            List<string> borrowedBooks = new List<string>();
                            foreach (var b in TrangThai.currentUser.sachMuon)
                            {
                                borrowedBooks.Add($"{b.Title},{b.Author},{b.Category},{b.Year},{b.Url},{b.Description},{b.ReturnDate},Borrowed");
                            }
                            

                            
                            lines[i + 1] = "Sách đã mượn: " + string.Join(" | ", borrowedBooks);
                            break;
                        }
                    }

                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show("Mượn thành công!");
                    this.Close();
                }
            }
            else {

                MessageBox.Show("Bạn cần đăng nhập để mượn!!!");
            }

        }

        private void btnYT_Click(object sender, EventArgs e)
        {
            if (TrangThai.currentUser != null)
            {
                Books book = new Books
                {
                    Title = lbTitle.Text,
                    Author = lbAuthor.Text,
                    Category = lbCategory.Text,
                    Year = lbYear.Text,
                    ReturnDate = currentDate.ToString(),
                    Description = lbDescription.Text,
                    Url = tmp,
                    Status = "Borrowed"
                };
                TrangThai.currentUser.yeuThich.Add(book);

                string filePath = Path.Combine(Application.StartupPath, "User.txt");

                if (File.Exists(filePath))
                {
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    for (int i = 0; i < lines.Count; i += 3)
                    {
                        string[] userData = lines[i].Split(',');
                        if (userData.Length >= 2 && userData[0].Trim() == TrangThai.currentUser.Name)
                        {

                            List<string> favoriteBooks = new List<string>();
                            foreach (var b in TrangThai.currentUser.yeuThich)
                            {
                                favoriteBooks.Add($"{b.Title},{b.Author},{b.Category},{b.Year},{b.Url},{b.Description},{b.ReturnDate},{b.Status}");
                            }


                            lines[i + 2] = "Sách yêu thích:" + string.Join(" | ", favoriteBooks);
                            break;
                        }
                    }

                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show("Thích thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("da co trong danh sach yeu thich");

                }
            }
            else {
                MessageBox.Show("ban can dang nhap de yeu thich");
            }

            
        }
    }
}
