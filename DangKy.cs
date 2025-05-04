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
        public int a = 0;


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
                
                string filePath = Path.Combine(Application.StartupPath, "User.txt");
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i += 3)
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts.Length > 0 && parts[0].Trim() == txtName.Text.Trim())
                        {
                            notification.Text = "Tên đã được sử dụng!";
                            return;
                        }
                        a++;
                    }
                }

                
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    writer.WriteLine($"{txtName.Text.Trim()},{txtPass.Text.Trim()},{a},{txtEmail.Text.Trim()}");
                    writer.WriteLine("Sách đã mượn:");
                    writer.WriteLine("Sách yêu thích:");
                }

                notification.Text = "Chúc mừng! Bạn đã đăng ký thành công!";
                MessageBox.Show("Bạn đã đăng ký thành công!");

                txtName.Text = "";
                txtPass.Text = "";
                txtRePass.Text = "";
                txtEmail.Text = "";

                Users usersForm = new Users();
                usersForm.Show();
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

