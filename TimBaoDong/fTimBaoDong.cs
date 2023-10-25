using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimBaoDong
{
    public partial class fTimBaoDong : Form
    {
        ThuatToanTBD tbd;
        List<string> Trai;
        List<string> Phai;

        public fTimBaoDong()
        {
            InitializeComponent();

            tbd = new ThuatToanTBD();
            Trai = new List<string>();
            Phai = new List<string>();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtPTHTrai.Text != "" && txtPTHPhai.Text != "")
            {
                Trai.Add(txtPTHTrai.Text);
                Phai.Add(txtPTHPhai.Text);

                listBox1.Items.Add(txtPTHTrai.Text.ToUpper() + " -> " + txtPTHPhai.Text.ToUpper());
                txtPTHTrai.Clear();
                txtPTHPhai.Clear();

                txtPTHTrai.Focus();
            }

            else MessageBox.Show("Bạn chưa nhập phụ thuộc hàm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtBaoDong.Text != "" && listBox1.Items.Count > 0)
                MessageBox.Show("Bao đóng của " + txtBaoDong.Text.ToUpper() + "+" + " là: " + tbd.timBaoDong(txtBaoDong.Text, Trai, Phai).ToUpper());
            else
                MessageBox.Show("Bạn chưa nhập bao đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            List<string> Khoa = new List<string>();
            Khoa = tbd.timKhoa(txtTapThuocTinh.Text, Trai, Phai);
            string mess = "";
            for (int i = 0; i < Khoa.Count; i++)
            {
                mess += Khoa[i];
                if (i != Khoa.Count - 1)
                    mess += ',';
            }
            MessageBox.Show("Khoá của tất cả tập thuộc tính trong X là: " + mess);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            Trai.RemoveAt(listBox1.SelectedIndex);
            Phai.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Trai = new List<string>();
            Phai = new List<string>();
        }

    }
}
