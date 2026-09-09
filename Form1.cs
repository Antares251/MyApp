using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        bool save = false;
        string path;

        int temporizador = 15;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofpAbrir.ShowDialog() == DialogResult.OK)
            {
                path = ofpAbrir.FileName;
                save = true;
                rctTexto.LoadFile(ofpAbrir.FileName, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled = false;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rctTexto.Clear();
            rctTexto.Focus();
            path = "";
            save = false;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrReloj.Stop();
            ssLabel.Text = "Guardado ✔";
            guardarFunc();
            rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
            guardarToolStripMenuItem.Enabled = false;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdGuardar.ShowDialog() == DialogResult.OK)
            {
                path = sfdGuardar.FileName;
                rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled = true;
                save = true;
                tmrReloj.Stop();
                ssLabel.Text = "Guardado ✔";
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rctTexto_TextChanged(object sender, EventArgs e)
        {
            guardarToolStripMenuItem.Enabled = true;
            if(autoGuardadoToolStripMenuItem.Checked)
            {
                tmrReloj.Stop();
                ssLabel.Text = "⟳";
                temporizador = 15;
                tmrReloj.Start();
            }
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            temporizador--;

            if (temporizador == 0)
            {
                tmrReloj.Stop();
                ssLabel.Text = "Guardado ✔";
                guardarFunc();
            }

            
        }

        public void guardarFunc()
        {
                path = ofpAbrir.FileName;
                save = true;
                rctTexto.SaveFile(path, RichTextBoxStreamType.PlainText);
                guardarToolStripMenuItem.Enabled = false;
   
        }

        private void autoGuardadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autoGuardadoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            autoGuardadoToolStripMenuItem.Checked = !autoGuardadoToolStripMenuItem.Checked;

            if (autoGuardadoToolStripMenuItem.Checked)
            {
                tmrReloj.Start();
                ssLabel.Text = "⟳";
            }
            else
            {
                tmrReloj.Stop();
                ssLabel.Text = "Auto-guardado desactivado";
            }
        }
    }

}
