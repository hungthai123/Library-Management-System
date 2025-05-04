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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            allowClose = true;
            string filePath =  Path.Combine(Application.StartupPath, "User.json");
            string otherPath = Path.Combine(Application.StartupPath, "Admin.json");

            List<User> users = new List<User>();
            List<Admin> admins = new List<Admin>();

            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                string adminJson = File.ReadAllText(otherPath);
                if (!string.IsNullOrWhiteSpace(adminJson))
                {
                    admins = JsonConvert.DeserializeObject<List<Admin>>(adminJson) ?? new List<Admin>();
                    admintmp = admins.FirstOrDefault(a=>a.Name== txtName.Text.Trim() && a.PassWord == txtPass.Text.Trim());
                    if (admintmp != null)
                    {
                        QUANLYTHUVIEN ql = new QUANLYTHUVIEN();
                        ql.Show();
                        this.Close();
                    }
                }
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
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
