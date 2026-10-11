
using System;
using System.Windows.Forms;

namespace xirdalama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Hadisələri qoş
            txtAmount.TextChanged += txtAmount_TextChanged;
            btnXirdala.Click += btnXirdala_Click;

            // Bütün əskinasları başlanğıcda göstər
            Temizle();

            picture1.Visible = true;
            picture5.Visible = true;
            picture10.Visible = true;
            picture20.Visible = true;
            picture50.Visible = true;
            picture100.Visible = true;
            picture200.Visible = true;
            picture500.Visible = true;
        }

        // Bütün əskinasların sayını 0 et
        private void Temizle()
        {
            lblCount1.Text = "0";
            lblCount5.Text = "0";
            lblCount10.Text = "0";
            lblCount20.Text = "0";
            lblCount50.Text = "0";
            lblCount100.Text = "0";
            lblCount200.Text = "0";
            lblCount500.Text = "0";
        }

        // Məbləğ daxil ediləndə boşluq xətasını yoxla
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtAmount, "");

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                errorProvider1.SetError(
                    txtAmount,
                    "Məbləğ daxil edin"
                );

                Temizle();
            }
        }

        // Xırdala düyməsi
        private void btnXirdala_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtAmount, "");

            int mebleg;

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                errorProvider1.SetError(
                    txtAmount,
                    "Məbləğ daxil edin"
                );

                txtAmount.Focus();
                Temizle();
                return;
            }

            if (!int.TryParse(txtAmount.Text, out mebleg))
            {
                MessageBox.Show(
                    "Düzgün tam ədəd daxil edin.",
                    "Diqqət",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Temizle();
                txtAmount.Focus();
                return;
            }

            if (mebleg <= 0)
            {
                MessageBox.Show(
                    "Mənfi və ya sıfır məbləğ xırdalanmaz",
                    "Diqqət",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Temizle();
                txtAmount.Focus();
                return;
            }

            Goster(mebleg);
        }

        // Əskinasların sayını hesabla
        private void Goster(int mebleg)
        {
            // Hər hesablamadan əvvəl bütün sayları 0 et
            Temizle();

            int[] eskinazlar = { 500, 200, 100, 50, 20, 10, 5, 1 };

            foreach (int eskinaz in eskinazlar)
            {
                int say = mebleg / eskinaz;
                mebleg = mebleg % eskinaz;

                switch (eskinaz)
                {
                    case 500:
                        lblCount500.Text = say.ToString();
                        break;

                    case 200:
                        lblCount200.Text = say.ToString();
                        break;

                    case 100:
                        lblCount100.Text = say.ToString();
                        break;

                    case 50:
                        lblCount50.Text = say.ToString();
                        break;

                    case 20:
                        lblCount20.Text = say.ToString();
                        break;

                    case 10:
                        lblCount10.Text = say.ToString();
                        break;

                    case 5:
                        lblCount5.Text = say.ToString();
                        break;

                    case 1:
                        lblCount1.Text = say.ToString();
                        break;
                }
            }
        }
    }
}
