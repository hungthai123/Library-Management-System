using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;



namespace Library
{
    public partial class DangKy : Form
    {
        private bool allowClose = false;


        public DangKy()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
            txtRePass.UseSystemPasswordChar = true;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            allowClose = true;
            this.Close();
        }

        private void btnSigin_Click(object sender, EventArgs e)
        {
            allowClose = true;

            if (txtPass.Text.Trim() == txtRePass.Text.Trim() && txtPass.Text.Trim()  != "" && txtName.Text.Trim() != "")
            {
                
                    string filePath = Path.Combine(Application.StartupPath, "User.json");


                    List<User> users = new List<User>();
                    if (File.Exists(filePath))
                    {
                        string existingJson = File.ReadAllText(filePath);
                        if (!string.IsNullOrWhiteSpace(existingJson))
                        {
                            users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
                        }
                    }
                    
                    int newid = users.Count>0 ? users.Last().id + 1 : 1 ;

                    User user = new User
                    {
                        Name = txtName.Text.Trim(),
                        PassWord = txtPass.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        sachMuon = new List<Books>(),
                        yeuThich = new List<Books>(),

                    };
                    if (users.Any(u => u.Name == user.Name))
                    {
                        notification.Text = "ten da duoc su dung!";
                        return;
                    }
                    users.Add(user);

                    string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
                    File.WriteAllText(filePath, jsonString, Encoding.UTF8);

                    notification.Text = "Chúc mừng! Bạn đã đăng ký thành công!";
                    txtName.Text = "";
                    txtPass.Text = "";
                    txtRePass.Text = "";
                    txtEmail.Text = "";
                    MessageBox.Show("Ban Da Dang Ky Thanh Cong!");
                    Users users1 = new Users();
                    users1.Show();
                    this.Close();




                
            }
            else
            {
                notification.Text = "Ban Nhap Sai Xin Hay Nhap Lai!";
            }
            }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose) { 
                e.Cancel = true;
            }
        }
    }
    }

