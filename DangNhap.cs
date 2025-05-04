using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library
{
    public partial class DangNhap : Form
    {
        public User usertmp { get; set; }
        public Admin admintmp { get; set; }
        private bool allowClose = false;
        public DangNhap()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            allowClose = true;
            Users users = new Users();
            users.Show();
            this.Close();
        }
        public List<Books> ParseBooks(string raw)
        {
            List<Books> books = new List<Books>();
            if (string.IsNullOrWhiteSpace(raw)) return books;

            string[] items = raw.Split('|');
            foreach (var item in items)
            {
                string[] bookData = item.Split(',');

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

            return books;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            allowClose = true;
            string filePath = Path.Combine(Application.StartupPath, "User.txt");
            string otherPath = Path.Combine(Application.StartupPath, "Admin.txt");

            List<User> users = new List<User>();
            List<Admin> admins = new List<Admin>();

            if (File.Exists(filePath))
            {
                string[] adminJson = File.ReadAllLines(otherPath);
                foreach (var line in adminJson) 
                {
                    var adminData = line.Split(',');
                    if (adminData.Length == 2)
                    {
                        admins.Add(new Admin { Name = adminData[0], PassWord = adminData[1] });
                    }
                }
                admintmp = admins.FirstOrDefault(a => a.Name == txtName.Text.Trim() && a.PassWord == txtPass.Text.Trim());
                if (admintmp != null)
                {
                    QUANLYTHUVIEN ql = new QUANLYTHUVIEN();
                    ql.Show();
                    this.Close();
                }
            }
            if (!string.IsNullOrWhiteSpace(otherPath))
                {
                string[] userLines = File.ReadAllLines(filePath);
                for (int i = 0; i < userLines.Length; i += 3)
                {
                    if (i + 2 >= userLines.Length) break; // Đảm bảo đủ 3 dòng

                    // Dòng 1: Tài khoản
                    string[] userData = userLines[i].Split(',');
                    if (userData.Length < 2) continue;

                    string name = userData[0].Trim();
                    string password = userData[1].Trim();

                    // Dòng 2: Sách đã mượn
                    string lineMuon = userLines[i + 1];
                    string sachMuonRaw = lineMuon.Contains(":") ? lineMuon.Split(':')[1].Trim() : "";
                    List<Books> sachMuon = ParseBooks(sachMuonRaw);

                    // Dòng 3: Sách yêu thích
                    string lineYeuThich = userLines[i + 2];
                    string yeuThichRaw = lineYeuThich.Contains(":") ? lineYeuThich.Split(':')[1].Trim() : "";
                    List<Books> yeuThich = ParseBooks(yeuThichRaw);


                    // Thêm vào danh sách
                    users.Add(new User
                    {
                        Name = name,
                        PassWord = password,
                        sachMuon = sachMuon,
                        yeuThich = yeuThich
                    });
                }


                usertmp = users.FirstOrDefault(u => u.Name == txtName.Text.Trim() && u.PassWord == txtPass.Text.Trim());

                if (usertmp!=null)
                    {
                        TrangThai.currentUser = usertmp;
                        UI ui = new UI(TrangThai.currentUser);
                        ui.Show();
                        this.Close();


                    }
                    else
                    {
                        notification.Text = "Ban Da Nhap Sai Tai Khoan Hoac Mat Khau!";
                    }
            }
            
            else
            {
                notification.Text = "Ban Da Nhap Sai Tai Khoan Hoac Mat Khau!";
            }
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                e.Cancel = true;
            }
        }
    }
}
