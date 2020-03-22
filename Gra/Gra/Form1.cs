using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra
{
    public partial class frmPrzeszkody : Form
    {
        Control.ControlCollection pola;
        Color kolorPrzeszkody = Color.DarkGray;
        Random losowe = new Random();
        bool kolej = true;


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
            pola = this.pnlPanel.Controls;

            for (int i = 54; i > 4; i--)
            {
                pola[i].BackColor = pola[i - 5].BackColor;
            }

            for (int i = 0; i < 5; i++)
            {
                pola[i].BackColor = SystemColors.Window;
            }

            if (kolej)
            {
                for (int i = 0; i < 4; i++)
                {
                    pola[losowe.Next(0, 5)].BackColor = kolorPrzeszkody;
                }
            }
            kolej = !kolej;
        }
    }
}
