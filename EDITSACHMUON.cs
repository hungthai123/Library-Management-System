using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library.QUANLYNGUOIDUNG;

namespace Library
{
    public partial class EDITSACHMUON : Form
    {

        public Books sachCanSua;
        private string memberName;
        string filePath = "user.txt";

        public EDITSACHMUON(String memberName, Books book, String status) 
        {
            InitializeComponent();
            sachCanSua = book;

            this.memberName = memberName;
            txtBookTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtIssueDate.Text = book.Year;
            txtReturnDate.Text = book.ReturnDate;
            comboStatus.Text = status; 
        }

        private void SaveUpdatedBook(string memberName, string bookTitle)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File dữ liệu không tồn tại!");
                return;
            }
            try
            {
                var lines = File.ReadAllLines(filePath).ToList();
                for (int i = 0; i < lines.Count; i += 3)
                {
                    var userInfo = lines[i].Split(',');
                    string name = userInfo[0].Trim();
                    if (name == memberName)
                    {
                        string borrowedLine = lines[i + 1];
                        string borrowedData = borrowedLine.Substring("Sách đã mượn:".Length).Trim();
                        var books = borrowedData.Split('|');

                        for (int j = 0; j < books.Length; j++)
                        {
                            var parts = books[j].Split(',');
                            if (parts[0].Trim() == bookTitle)
                            {
                                parts[8] = comboStatus.Text.Trim();
                                books[j] = string.Join(",", parts);
                                break;
                            }
                        }
                        lines[i + 1] = "Sách đã mượn: " + string.Join(" | ", books);
                        break;
                    }
                }
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Cập nhật trạng thái thành công!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EDITSACHMUON_Load_1(object sender, EventArgs e)
        {
            comboStatus.Items.Add("Borrowed");
            comboStatus.Items.Add("Returned");
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SaveUpdatedBook(memberName, sachCanSua.Title);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
