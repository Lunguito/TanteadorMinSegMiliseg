using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanteadorTiempo
{
    public partial class Form1 : Form
    {
        private int minutos = 0;
        private int segundos = 0;
        private int milisegundos = 0;
        private bool corriendo = false;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            corriendo = true;
            timer1.Start();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            corriendo = false;
            timer1.Stop();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            corriendo = false;
            minutos = 0;
            segundos = 0;
            milisegundos = 0;
            ActualizarEtiquetas();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            milisegundos += 10;

            if (milisegundos >= 1000)
            {
                segundos++;
                milisegundos = 0;
            }

            if (segundos >= 60)
            {
                minutos++;
                segundos = 0;
            }

            ActualizarEtiquetas();
        }

        private void ActualizarEtiquetas()
        {
            lblMinutos.Text = minutos.ToString("00");
            lblSegundos.Text = segundos.ToString("00");
            lblMilisegundos.Text = milisegundos.ToString("000");
        }
    }
}
