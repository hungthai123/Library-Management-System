using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class LichSuMuoncs : Form
    {
        public LichSuMuoncs()
        {
            InitializeComponent();
            hienThi();
        }
        public void hienThi(){
            DataGridView DTG = this.Controls.OfType<DataGridView>().FirstOrDefault(Dtg => Dtg.Name == "DTG");
            if (DTG != null)
            {
                DTG.Rows.Clear();
                foreach (var sach in TrangThai.currentUser.sachMuon) { 
                   DTG.Rows.Add(sach.Title,sach.Author,sach.Category,sach.Year);
                }
            }
            else { 
                return;
            }
        }

    }
}
