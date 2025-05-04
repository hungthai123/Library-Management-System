using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Library
{
    public partial class UI : Form
    {
       
        private int currentIndex = 1; // Ảnh đầu tiên sẽ ở giữa
        private Timer timer;
        private List<string> images;
        List<Books> books ;
        public static int a = 0;

        public UI(User user)
        {
            InitializeComponent();
            getImages();
            setTimer();
            addAnhPanel1();
            addAnhPanel2();
            DK.Text= user.Name;
        }
        private void getImages()
        {
            string folderpath = Path.Combine(Application.StartupPath, "Photos");
            images = Directory.GetFiles(folderpath, "*.jpg").ToList();
            if (images.Count > 1)
            {
                images.Insert(0, images[images.Count - 1]);
                images.Add(images[1]);
            }


            if (images.Count == 0) return;

            panelContainer.Controls.Clear();


            DisplayImages();
        }

        private void DisplayImages()
        {
            panelContainer.Controls.Clear();

            int panelWidth = panelContainer.Width;
            int centerX = panelWidth / 2;
            PictureBox centerPic = null;

            for (int i = 0; i < images.Count; i++)
            {
                PictureBox pic = new PictureBox
                {
                    Image = Image.FromFile(images[i]),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(250, 180),
                };


                if (i == currentIndex)
                {
                    pic.Size = new Size(350, 250);
                    pic.Location = new Point(panelContainer.Width / 2 - 175, 10);
                    centerPic = pic;

                }
                else if (i == (currentIndex - 1 + images.Count) % images.Count)
                {
                    pic.Location = new Point(centerX - 400, 50);
                }
                else if (i == (currentIndex + 1) % images.Count)
                {
                    pic.Location = new Point(centerX + 100, 50);
                }
                else
                {
                    pic.Size = new Size(0, 0);
                }

                panelContainer.Controls.Add(pic);
            }
            if (centerPic != null && panelContainer.Controls.Contains(centerPic))
            {
                panelContainer.Controls.SetChildIndex(centerPic, 0);
            }
        }

        private void setTimer()
        {
            timer = new Timer();
            timer.Interval = 3000; // 3 giây tự chuyển ảnh
            timer.Tick += (s, e) => moveNextImage();
            timer.Start();
        }

        private void moveNextImage()
        {
            if (images.Count == 0) return;

            if (currentIndex < images.Count - 2)
            {
                currentIndex++;
            }
            else
            {

                currentIndex = 1;
            }

            DisplayImages();
        }
        private void DN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UI_Load(object sender, EventArgs e)
        {

        }
        private void addAnhPanel1()
        {
            Panel panel1 = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "pictureContainer1");
            var pictureBoxes = panel1.Controls.OfType<PictureBox>().ToList();
            var labels = panel1.Controls.OfType<Label>().ToList();
            string photosDirectory = Path.Combine(Application.StartupPath, "Photos");
            string booksDirectory = Path.Combine(Application.StartupPath, "Books.json");
            string existingJson = File.ReadAllText(booksDirectory);
            if (!string.IsNullOrWhiteSpace(existingJson) && panel1 != null)
            {
                books = JsonConvert.DeserializeObject<List<Books>>(existingJson) ?? new List<Books>();
                for (int i = 0; i < labels.Count; i++)
                {
                    try
                    {
                        labels[i].Text = books[i].Title;
                        pictureBoxes[i].Image = Image.FromFile(Path.Combine(photosDirectory, books[i].URL));
                        pictureBoxes[i].Tag = books[i];
                    }
                    catch (Exception ex)
                    {

                    }
                    a++;
                }


            }

        }

        private void addAnhPanel2()
        {
            Panel panel1 = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "pictureContainer2");
            var pictureBoxes = panel1.Controls.OfType<PictureBox>().ToList();
            var labels = panel1.Controls.OfType<Label>().ToList();
            string photosDirectory = Path.Combine(Application.StartupPath, "Photos");
            string booksDirectory = Path.Combine(Application.StartupPath, "Books.json");
            string existingJson = File.ReadAllText(booksDirectory);
            if (!string.IsNullOrWhiteSpace(existingJson) && panel1 != null)
            {
                books = JsonConvert.DeserializeObject<List<Books>>(existingJson) ?? new List<Books>();
                for (int i = 0; i < labels.Count; i++)
                {
                    try
                    {
                        labels[i].Text = books[a].Title;
                        pictureBoxes[i].Image = Image.FromFile(Path.Combine(photosDirectory, books[a].URL));
                        pictureBoxes[i].Tag = books[a];
                    }
                    catch (Exception ex)
                    {

                    }
                    a++;
                }

            }

        }

        private void DS_Click(object sender, EventArgs e)
        {
            DanhSachUI danhSachcs = new DanhSachUI();
            this.Hide();
            danhSachcs.Show();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Tag is Books book)
            {
                this.Hide();
                BookForm bookForm = new BookForm(book);
                bookForm.Show();
                bookForm.FormClosed += (s, arg) =>
                {
                    this.Show();
                };
            }
        }

        private void DN_Click_1(object sender, EventArgs e)
        {
            TrangThai.currentUser = null;
            Users users = new Users();
            users.Show();
            this.Close();
        }

        private void LSM_Click(object sender, EventArgs e)
        {
            this.Hide();
            LichSuMuoncs lsm = new LichSuMuoncs();
            lsm.ShowDialog();
            this.Show();
        }

        private void YT_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeuThichcs yu = new YeuThichcs();
            yu.ShowDialog();
            this.Show();
        }
    }
}
