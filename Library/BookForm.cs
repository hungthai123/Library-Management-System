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
            tmp = b.URL;
            string photosDirectory = Path.Combine(Application.StartupPath, "Photos");
            pbIMG.Image = Image.FromFile(Path.Combine(photosDirectory, b.URL));
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (TrangThai.currentUser != null) {
                Books book = new Books
                {
                    Title = lbTitle.Text,
                    Author = lbAuthor.Text,
                    Category = lbCategory.Text,
                    Year = lbYear.Text,
                    ReturnDate = currentDate.ToString(),
                    Description = lbDescription.Text,
                    URL = tmp,
                    Status = "Borrowed"
                    
                };
                TrangThai.currentUser.sachMuon.Add(book);
                string filePath = Path.Combine(Application.StartupPath, "User.json");
                if (File.Exists(filePath))
                {

                    string existingJson = File.ReadAllText(filePath);
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
                    User userupd = users.FirstOrDefault(u => u.Name == TrangThai.currentUser.Name);
                    if (userupd != null)
                    {
                        userupd.sachMuon = TrangThai.currentUser.sachMuon;
                    }
                    string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
                    File.WriteAllText(filePath, updatedJson);
                    MessageBox.Show("muon thanh cong!");
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
                    Description = lbDescription.Text,
                    URL = tmp,
                };
                if (!TrangThai.currentUser.yeuThich.Any(b => b.Title == book.Title))
                {
                    MessageBox.Show("Da them vao danh sach!!");
                    TrangThai.currentUser.yeuThich.Add(book);
                    string filePath = Path.Combine(Application.StartupPath, "User.json");
                    if (File.Exists(filePath))
                    {
                        string existingJson = File.ReadAllText(filePath);
                        List<User> users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
                        User userupd = users.FirstOrDefault(u => u.Name == TrangThai.currentUser.Name);
                        if (userupd != null)
                        {
                            userupd.yeuThich = TrangThai.currentUser.yeuThich;
                        }
                        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
                        File.WriteAllText(filePath, updatedJson);
                        this.Close();


                    }
                }
                else {
                    MessageBox.Show("da co trong danh sach yeu thich");
                }
            }
            else
            {

                MessageBox.Show("Bạn cần đăng nhập để yêu thích!!!");
            }
        }
    }
}
