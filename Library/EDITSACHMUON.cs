using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library.QUANLYNGUOIDUNG;

namespace Library
{
    public partial class EDITSACHMUON : Form
    {

        public BorrowedBook sachCanSua;
        private string memberName;

        public EDITSACHMUON(String memberName, BorrowedBook book)
        {
            InitializeComponent();
            sachCanSua = book;

            this.memberName = memberName;
            txtBookTitle.Text = book.BookTitle;
            txtAuthor.Text = book.Author;
            txtIssueDate.Text = book.IssueDate;
            txtReturnDate.Text = book.ReturnDate;
        }

        private void SaveUpdatedBook(string memberName, string bookTitle)
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
                var member = members.FirstOrDefault(m => m.MemberName == memberName);
                if (member != null)
                {
                    var book = member.BorrowedBooks.FirstOrDefault(b => b.BookTitle == bookTitle);
                    if (book != null)
                    {
                        book.Status = comboStatus.Text;
                    }
                }
                File.WriteAllText(filePath, JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật file JSON: " + ex.Message);
            }
        }

        private void EDITSACHMUON_Load_1(object sender, EventArgs e)
        {
            comboStatus.Items.Add("Borrowed");
            comboStatus.Items.Add("Returned");
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SaveUpdatedBook(memberName, sachCanSua.BookTitle);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
