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
    public partial class YeuThichcs : Form
    {
        public YeuThichcs()
        {
            InitializeComponent();
            label1.Text = "\u2764 Yêu Thích";
            label1.Font = new Font("Arial", 24, System.Drawing.FontStyle.Regular);
            label1.ForeColor = Color.Red;
            AutoSize = true;
            YT();
        }
        public void YT(){
            Panel panel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "pictureContainer");
            var pictureBoxes = panel.Controls.OfType<PictureBox>().ToList();
            string photosDirectory = Path.Combine(Application.StartupPath, "Photos");
            int x = 10, y = 10;
            panel.Controls.Clear();
            if (panel != null && TrangThai.currentUser != null && TrangThai.currentUser.yeuThich != null) {
                foreach (var yt in TrangThai.currentUser.yeuThich) {
                    string imagePath = Path.Combine(photosDirectory, yt.Url);
                    PictureBox picture = new PictureBox
                    {
                        Image = Image.FromFile(imagePath),
                        SizeMode = PictureBoxSizeMode.StretchImage, 
                        Size = new Size(100, 160),
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(x, y)
                    };
                    panel.Controls.Add(picture);
                    Label label = new Label
                    {
                        Text = yt.Title.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Size = new Size(100, 20),
                        Location = new Point(x, y+170), 
                    };
                    panel.Controls.Add(label);
                    x += 150; 
                    if (x + 150 > panel.Width) 
                    {
                        x = 10;
                        y += 200;
                    }

                }
            }
            else {
                
                Label noResult = new Label
                {
                        Text = "Không tìm thấy sách nào!",
                        Location = new Point(10, 10),
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Red
                };
                panel.Controls.Add(noResult);

            }
        }


    }
}
