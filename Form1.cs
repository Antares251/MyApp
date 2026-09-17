using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvInformacion.Rows.Add();

            dgvInformacion[0, dgvInformacion.Rows.Count - 1].Value = dgvInformacion.Rows.Count;
            dgvInformacion[1, dgvInformacion.Rows.Count - 1].Value = txtNombre.Text;
            dgvInformacion[2,dgvInformacion.Rows.Count - 1].Value = mtbTelefono.Text;
        }
    }
}
