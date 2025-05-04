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

        public QUANLYNGUOIDUNG()
        {
            InitializeComponent();
        }
        private void QUANLYNGUOIDUNG_Load(object sender, EventArgs e)
        {
            LoadData("user.json");
            dataMuonSach.ClearSelection();
            dataUser.ClearSelection();
        }
        public class Member
        {
            [JsonPropertyName("Name")]
            public string MemberName { get; set; }
            [JsonPropertyName("id")]
            public int MemberID { get; set; }
            [JsonPropertyName("Email")]
            public string Email { get; set; }
            [JsonPropertyName("sachMuon")]
            public List<BorrowedBook> BorrowedBooks { get; set; }
            [JsonPropertyName("yeuThich")]
            public List<Books> YeuThich { get; set; }
            public string PassWord { get; set; }
        }

        public class BorrowedBook
        {
            [JsonPropertyName("Title")]
            public string BookTitle { get; set; } = string.Empty;
            [JsonPropertyName("Year")]
            public string IssueDate { get; set; } = string.Empty;
            [JsonPropertyName("Url")]
            public string Url { get; set; }
            [JsonPropertyName("Description")]
            public string Description { get; set; }
            public string Author { get; set; } = string.Empty;
            public string Category {  get; set; } = string.Empty;
            public string ReturnDate { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
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
                string data = File.ReadAllText(filePath);
                var members = JsonSerializer.Deserialize<List<Member>>(data) ?? new List<Member>();
                dataUser.Rows.Clear();
                dataMuonSach.Rows.Clear();
                foreach (var member in members)
                {
                    dataUser.Rows.Add(member.MemberName, member.MemberID, member.Email);
                    foreach (var book in member.BorrowedBooks)
                    {
                        dataMuonSach.Rows.Add(member.MemberName, book.BookTitle, book.Author, book.IssueDate, book.ReturnDate, book.Status);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file JSON: " + ex.Message);
            }
        }
        //Hàm lọc theo tên
        private void FilterBorrowedBooks(int memberId, string memberName)
        {
            string filePath = "user.json";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File dữ liệu không tồn tại!");
                return;
            }
            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Member> members = JsonSerializer.Deserialize<List<Member>>(jsonData) ?? new List<Member>();
                var selectedMember = members.FirstOrDefault(m => m.MemberID == memberId);

                if (selectedMember == null)
                {
                    MessageBox.Show("Không tìm thấy thành viên!");
                    return;
                }

                List<BorrowedBook> borrowedBooks = selectedMember.BorrowedBooks ?? new List<BorrowedBook>();

                dataMuonSach.Rows.Clear();
                foreach (var book in borrowedBooks)
                {
                    dataMuonSach.Rows.Add(memberName, book.BookTitle, book.Author, book.IssueDate, book.ReturnDate, book.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file JSON: " + ex.Message);
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
                MessageBox.Show("Đã gửi mail thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btBorrowed_Click_1(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dataUser.SelectedRows[0];
                if (selectedRow.Cells[1].Value != null && selectedRow.Cells[0].Value != null)
                {
                    int selectedMemberId = Convert.ToInt32(selectedRow.Cells[1].Value);
                    string selectedMemberName = selectedRow.Cells[0].Value.ToString() ?? string.Empty;
                    FilterBorrowedBooks(selectedMemberId, selectedMemberName);
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewAll_Click_1(object sender, EventArgs e)
        {
            LoadData("User.json");
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dataMuonSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataMuonSach.SelectedRows[0];

                string memberName = row.Cells[0].Value?.ToString() ?? string.Empty;
                string bookTitle = row.Cells[1].Value?.ToString() ?? string.Empty;
                string author = row.Cells[2].Value?.ToString() ?? string.Empty;
                string issueDate = row.Cells[3].Value?.ToString() ?? string.Empty;
                string returnDate = row.Cells[4].Value?.ToString() ?? string.Empty;
                string status = row.Cells[5].Value?.ToString() ?? string.Empty;

                BorrowedBook selectedBook = new BorrowedBook
                {
                    BookTitle = bookTitle,
                    Author = author,
                    IssueDate = issueDate,
                    ReturnDate = returnDate,
                    Status = status
                };
                EDITSACHMUON editForm = new EDITSACHMUON(memberName, selectedBook);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSendReminder_Click_1(object sender, EventArgs e)
        {
            String filePath = "user.json";
            string jsonData = File.ReadAllText(filePath);
            List<Member> members = JsonSerializer.Deserialize<List<Member>>(jsonData) ?? new List<Member>();
            DateTime today = DateTime.Today;
            foreach (var member in members)
            {
                foreach (var book in member.BorrowedBooks)
                {
                    String tmp = book.Status.Trim();
                    tmp = tmp.ToString().ToLower();
                    if (tmp == "borrowed" && DateTime.TryParse(book.ReturnDate, out DateTime returnDate) && returnDate < today)
                    {
                        SendEmail(member.Email.ToString(), member.MemberName, book.BookTitle);
                    }
                }
            }
        }

        private void QUANLYNGUOIDUNG_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private QUANLYTHUVIEN quanLyThuVienForm;
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

        
    }
}
