using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Gra
{
    public partial class frmPrzeszkody : Form
    {
        Control.ControlCollection pola;
        int pozycja;
        Color kolorPrzeszkody = Color.DarkGray, kolorSterownika = Color.HotPink;
        Random losowe = new Random();
        bool kolej = true;

        Stopwatch czas;

        public frmPrzeszkody()
        {
            InitializeComponent();
        }

        private void frmPrzeszkody_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    TextBox pole = new TextBox
                    {
                        Width = 70,
                        Left = j * 75 + 10,
                        Top = i * 30 + 10,
                        Enabled = false
                    };
                    this.pnlPanel.Controls.Add(pole);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblCzas.Text = "00:00.0";

            pola = this.pnlPanel.Controls;

            czas = new Stopwatch();
            czas.Start();
            tmrStoper.Enabled = true;
            tmrCzas.Enabled = true;                       

            btnStart.Enabled = false;
            pozycja = 2;

            pola[50 + pozycja].BackColor = kolorSterownika;
        }

        private void tmrStoper_Tick(object sender, EventArgs e)
        {
            for (int i = 54; i > 4; i--)
                pola[i].BackColor = pola[i - 5].BackColor;

            for (int i = 0; i < 5; i++)
                pola[i].BackColor = SystemColors.Window;

            kolej = !kolej;

            if (kolej)
                for (int i = 0; i < 4; i++)
                    pola[losowe.Next(0, 5)].BackColor = kolorPrzeszkody;

            if (pola[50 + pozycja].BackColor == kolorPrzeszkody)
            {
                tmrStoper.Enabled = false;
                tmrCzas.Enabled = false;
                czas.Stop();
                string wynik = "Czas gry: " + czas.Elapsed.ToString("mm\\:ss\\.f");

                MessageBox.Show(wynik, "Koniec", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Control pole in pnlPanel.Controls)
                {
                    pole.BackColor = SystemColors.Window;
                }
                btnStart.Enabled = true;

            }
            else
            {
                pola[50 + pozycja].BackColor = kolorSterownika;
            }
            tmrStoper.Interval = (int)(tmrStoper.Interval * 0.99);


        }

        private void tmrCzas_Tick(object sender, EventArgs e)
        {
            lblCzas.Text = czas.Elapsed.ToString("mm\\:ss\\.f");
        }

        private void frmPrzeszkody_KeyDown(object sender, KeyEventArgs e)
        {
            pola[50 + pozycja].BackColor = SystemColors.Window;
            if (e.KeyCode == Keys.Right
                && pozycja < 4
                && pola[51 + pozycja].BackColor == SystemColors.Window)
            {
                pozycja++;
            }
                
            if (e.KeyCode == Keys.Left
                && pozycja > 0
                && pola[49 + pozycja].BackColor == SystemColors.Window)
            {
                pozycja--;
            }
            pola[50 + pozycja].BackColor = kolorSterownika;

        }
    }
}
