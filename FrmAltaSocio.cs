using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLabPL2
{
    public partial class FrmAltaSocio : Form
    {
        public FrmAltaSocio()
        {
            InitializeComponent();
        }

        clsSocio ObjSocio = new clsSocio();

        private void FrmAltaSocio_Load(object sender, EventArgs e)
        {
            clsActividades ObjActividades = new clsActividades();
            clsBarrio ObjBarrio = new clsBarrio();
            ObjActividades.ListarActividades(cmbActividades);
            ObjBarrio.ListarBarrios(cmbBarrio);
        }

        private void btnCrearSocio_Click(object sender, EventArgs e)
        {

            if (ValidarCamposVacios())
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            ObjSocio.idSocio = txtDNI.Text;
            ObjSocio.Nombre = txtNombre.Text;
            ObjSocio.Direccion = txtDireccion.Text;
            ObjSocio.idBarrio = Convert.ToInt32(cmbBarrio.SelectedValue); 
            ObjSocio.idActividad = Convert.ToInt32(cmbActividades.SelectedValue);
            ObjSocio.CrarSocio();
            MessageBox.Show("Socio creado");
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            cmbBarrio.SelectedIndex = 0;
            cmbActividades.SelectedIndex = 0;
        }


        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtDireccion.Text))
            {
                return true;
            }
            return false; 
        }
    }
}
