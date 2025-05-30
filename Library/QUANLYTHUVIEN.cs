﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
namespace Library
{
    public partial class QUANLYTHUVIEN : Form
    {
        public List<Books> bookList = new List<Books>();
        public QUANLYTHUVIEN()
        {
            InitializeComponent();
            dataSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataSach.AllowUserToAddRows = false;
            LoadBooks();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text) &&
               !string.IsNullOrWhiteSpace(txtAuthor.Text) &&
               !string.IsNullOrWhiteSpace(txtCategory.Text) &&
               !string.IsNullOrWhiteSpace(txtYear.Text) &&
               !string.IsNullOrWhiteSpace(txtURL.Text) &&
               !string.IsNullOrWhiteSpace(txtDescript.Text))
            {
                Books newBook = new Books(txtTitle.Text, txtAuthor.Text, txtCategory.Text, txtYear.Text, txtURL.Text, txtDescript.Text,null,"borrowed");

                bookList.Add(newBook);
                dataSach.Rows.Add(newBook.Title, newBook.Author, newBook.Category, newBook.Year, newBook.URL, newBook.Description);
                SaveBooks();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ClearFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtYear.Clear();
            txtDescript.Clear();
            txtURL.Clear();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dataSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataSach.SelectedRows[0];
                int index = row.Index;
                Books sachDaChon = bookList[index];

                CHINHSUASACH editForm = new CHINHSUASACH(sachDaChon);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    bookList[index] = editForm.sachCanSua;

                    row.Cells[0].Value = editForm.sachCanSua.Title;
                    row.Cells[1].Value = editForm.sachCanSua.Author;
                    row.Cells[2].Value = editForm.sachCanSua.Category;
                    row.Cells[3].Value = editForm.sachCanSua.Year;

                    SaveBooks();
                    MessageBox.Show("Cập nhật sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookTitle = dataSach.SelectedRows[0].Cells[0].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có muốn xóa cuốn sách '{bookTitle}' không?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataSach.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        bookList.RemoveAt(row.Index);
                        dataSach.Rows.Remove(row);
                    }
                }
                SaveBooks();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (DataGridViewRow row in dataSach.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            bool found = false;

            foreach (DataGridViewRow row in dataSach.Rows)
            {
                bool match = false;
                if (!row.IsNewRow)
                {
                    

                    string cellValue = row.Cells[0].Value?.ToString();
                    
                        if (cellValue.ToLower().Contains(searchText))
                        {
                            match = true;
                            
                        }
                    }
                    row.Visible = match;
                    if (match) found = true;
                }
            

            if (!found)
            {
                MessageBox.Show("Không tìm thấy sách phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveBooks()
        {
            try
            {
                File.WriteAllText("Books.json", JsonSerializer.Serialize(bookList, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGrid()
        {
            dataSach.Rows.Clear();
            foreach (var book in bookList)
            {
                dataSach.Rows.Add(book.Title, book.Author, book.Category, book.Year);
            }
        }

        private void LoadBooks()
        {
            if (File.Exists("Books.json"))
            {
                string json = File.ReadAllText("Books.json");
                bookList = JsonSerializer.Deserialize<List<Books>>(json) ?? new List<Books>();
                UpdateDataGrid();
            }
        }

        private QUANLYNGUOIDUNG? formMember = null;
        private void manageMemberToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        internal void Focus()
        {
            throw new NotImplementedException();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            this.Hide();
            users.ShowDialog();
            Application.Exit();
        }

        private void manageMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formMember == null || formMember.IsDisposed)
            {
                formMember = new QUANLYNGUOIDUNG();
                //formMember.Show();
                //this.Hide();
                // Có sửa miếng ở đây
                this.Hide();
                formMember.ShowDialog();
                this.Show();
            }
            else
            {
                formMember.Focus();
            }
        }


    }
}
