using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Text.Json;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.Json.Serialization;

namespace Library
{
    public partial class QUANLYNGUOIDUNG : Form
    {
        String filePath = "user.txt";
        public QUANLYNGUOIDUNG()
        {
            InitializeComponent();
            dataMuonSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void QUANLYNGUOIDUNG_Load(object sender, EventArgs e)
        {
            LoadData(filePath);

        }
        //Hàm load data
        private void LoadData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File " + Path.GetFileName(filePath) + " không tồn tại!");
                return;
            }
            try
            {
                dataUser.Rows.Clear();
                dataMuonSach.Rows.Clear();
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    var userInfo = lines[i].Split(',');
                    string name = userInfo[0].Trim();
                    int id = int.Parse(userInfo[2].Trim());
                    string email = userInfo[3].Trim();

                    string borrowedTong = lines[i + 1].Substring("Sách đã mượn:".Length).Trim();
                    string[] books = borrowedTong.Split('|');
                    foreach (var book in books)
                    {
                        String[] parts = book.Split(',');
                        dataMuonSach.Rows.Add(name, parts[0].Trim(), parts[1].Trim(), parts[4].Trim(), parts[7].Trim(), parts[8].Trim());
                    }
                    dataUser.Rows.Add(name, id, email);
                }
                dataUser.ClearSelection();
                dataMuonSach.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hàm lọc theo tên
        private void FilterBorrowedBooks(int memberId, string memberName)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File " + Path.GetFileName(filePath) + " không tồn tại!");
                return;
            }
            try
            {
                dataMuonSach.Rows.Clear();
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    var userInfo = lines[i].Split(',');
                    string name = userInfo[0].Trim();
                    int id = int.Parse(userInfo[2].Trim());
                    if (id == memberId)
                    {
                        string borrowedTong = lines[i + 1].Substring("Sách đã mượn:".Length).Trim();
                        string[] books = borrowedTong.Split('|');
                        foreach (var book in books)
                        {
                            string[] parts = book.Split(',');
                            dataMuonSach.Rows.Add(name, parts[0].Trim(), parts[1].Trim(), parts[4].Trim(), parts[7].Trim(), parts[8].Trim());
                        }
                        break;
                    }
                }
                dataMuonSach.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendEmail(string toEmail, String memberName, String bookTitle)
        {
            string fromMail = "ngocvahung24@gmail.com";
            string passMail = "qfkw nckn wbvt zpjr";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromMail);
            mail.To.Add(toEmail);
            mail.Subject = "Nhắc nhở trả sách";
            mail.Body = "Xin chào " + memberName +
                "!\nHệ thống nhận thấy bạn đã mượn quyển sách " + bookTitle + " và đã hết hạn trả sách." +
                "\nMong rằng bạn hãy mang sách đến thư viện của chúng tôi để hoàn tất thủ tục trả sách." +
                "\nCám ơn bạn đã hợp tác!";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromMail, passMail);
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btBorrowed_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataUser.SelectedRows.Count > 0)
                {
                    var selectedRow = dataUser.SelectedRows[0];
                    if (selectedRow.Cells[1].Value != null && selectedRow.Cells[0].Value != null)
                    {
                        int selectedMemberId = Convert.ToInt32(selectedRow.Cells[1].Value);
                        string selectedMemberName = selectedRow.Cells[0].Value.ToString();
                        FilterBorrowedBooks(selectedMemberId, selectedMemberName);
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn người dùng để thao tác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click_1(object sender, EventArgs e)
        {
            LoadData(filePath);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dataMuonSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataMuonSach.SelectedRows[0];

                string memberName = row.Cells[0].Value.ToString();
                string bookTitle = row.Cells[1].Value.ToString();
                string author = row.Cells[2].Value.ToString();
                string issueDate = row.Cells[3].Value.ToString();
                string returnDate = row.Cells[4].Value.ToString();
                string status = row.Cells[5].Value.ToString();

                Books selectedBook = new Books
                {
                    Title = bookTitle,
                    Author = author,
                    Year = issueDate,
                    ReturnDate = returnDate,
                    Status = status
                };
                EDITSACHMUON editForm = new EDITSACHMUON(memberName, selectedBook, status);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSendReminder_Click_1(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int successMail = 0;
            int errorMail = 0;
            List<String> tmpMail = new List<String>();
            try
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    var userInfo = lines[i].Split(',');
                    string name = userInfo[0].Trim();
                    string email = userInfo[3].Trim();
                    string borrowedTong = lines[i + 1].Substring("Sách đã mượn:".Length).Trim();
                    string[] books = borrowedTong.Split('|');
                    foreach (var book in books)
                    {
                        var parts = book.Split(',');
                        string title = parts[0].Trim();
                        string returnDateStr = parts[7].Trim();
                        string status = parts[8].Trim().ToLower();
                        if (DateTime.TryParse(returnDateStr, out DateTime returnDate))
                        {
                            if (status == "borrowed" && returnDate < DateTime.Now)
                            {
                                if (isTrueEmail(email))
                                {
                                    SendEmail(email, name, title);
                                    successMail++;
                                }
                                else
                                {
                                    errorMail++;
                                    tmpMail.Add(email);
                                }
                            }
                        }
                    }
                }
                if (successMail > 0)
                {
                    MessageBox.Show($"Đã gửi thành công {successMail} mail thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (errorMail > 0)
                {
                    string message = "Định dạng các email sau không hợp lệ:\n";
                    foreach (var mail in tmpMail)
                    {
                        message += $"Mail: {mail}\n";
                    }
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có sách nào đến hạn trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isTrueEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private QUANLYTHUVIEN quanLyThuVienForm = null;
        private void manageLibrary_Click(object sender, EventArgs e)
        {

            if (quanLyThuVienForm == null || quanLyThuVienForm.IsDisposed)
            {
                quanLyThuVienForm = new QUANLYTHUVIEN();
                this.Hide();
                quanLyThuVienForm.ShowDialog();
                this.Show();
            }
            else
            {
                quanLyThuVienForm.Focus();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            this.Hide();
            users.ShowDialog();
            Application.Exit();
        }
    }
}
