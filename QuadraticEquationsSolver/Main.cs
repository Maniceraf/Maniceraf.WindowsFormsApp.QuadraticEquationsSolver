using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadraticEquationsSolver
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        class TAM_THUC
        {
            private double a; //a<>0
            private double b;
            private double c;
            public double HeSoA
            {
                get
                {
                    return a;
                }
                set
                {
                    a = value;
                }
            }
            public double HeSoB
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }
            }
            public double HeSoC
            {
                get
                {
                    return c;
                }
                set
                {
                    c = value;
                }
            }
            public TAM_THUC()
            {
            }
            public bool NhapHeSo(string hesoa, string hesob, string hesoc)
            {
                try
                {
                    if (hesoa.Trim().Length == 0)
                    {
                        MessageBox.Show("Chưa nhập hệ số a", "Thong bao loi",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    else if (hesob.Trim().Length == 0)
                    {
                        MessageBox.Show("Chưa nhập hệ số b", "Thong bao loi",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    else if (hesoc.Trim().Length == 0)
                    {
                        MessageBox.Show("Chưa nhập hệ số c", "Thong bao loi",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    a = Double.Parse(hesoa);
                    b = Double.Parse(hesob);
                    c = Double.Parse(hesoc);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                    return false;
                }
            }
            public NGHIEM GiaiPT()
            {
                NGHIEM cNghiem = new NGHIEM();
                double delta;
                delta = b * b - 4 * a * c;
                if (delta < 0)
                    cNghiem.LoaiN = 0;
                else if (delta == 0)
                {
                    cNghiem.LoaiN = 1;
                    cNghiem.x1 = -b / 2 * a;
                }
                else
                {
                    cNghiem.LoaiN = 2;
                    cNghiem.x1 = -b - Math.Sqrt(delta) / 2 * a;
                    cNghiem.x2 = -b + Math.Sqrt(delta) / 2 * a;
                }
                return cNghiem;
            }
        }
        class NGHIEM
        {
            private double[] x = new double[2];
            private int LoaiNghiem;
            public NGHIEM()
            {
            }
            public int LoaiN
            {
                get
                {
                    return LoaiNghiem;
                }
                set
                {
                    LoaiNghiem = value;
                }
            }
            public double x1
            {
                get
                {
                    return x[0];
                }
                set
                {
                    x[0] = value;
                }
            }
            public double x2
            {
                get
                {
                    return x[1];
                }
                set
                {
                    x[1] = value;
                }
            }
            public void Xuat(TextBox txtNghiem)
            {
                if (LoaiNghiem == 0)
                    txtNghiem.Text = "Phương trình trên vô nghiệm.";
                else if (LoaiNghiem == 1)
                {
                    txtNghiem.Text = "Phương trình trên có nghiệm kép: ";
                    txtNghiem.Text += "x= " + x[0];
                }
                else
                {
                    txtNghiem.Text = "Phương trình trên có 2 nghiệm phân biệt: ";
                    txtNghiem.Text += " x1 = " + x[0];
                    txtNghiem.Text += " và x2 = " + x[1];
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TAM_THUC tt = new TAM_THUC();
            NGHIEM N;

            tt.NhapHeSo(txta.Text.Trim(), txtb.Text.Trim(), txtc.Text.Trim());
            N = tt.GiaiPT();
            N.Xuat(txtNghiem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txta.Text = "";
            txtb.Text = "";
            txtc.Text = "";
            txtNghiem.Text = "";
        }
    }
}
