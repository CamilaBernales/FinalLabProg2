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
    public partial class FrmBuscarSocio : Form
    {
        public FrmBuscarSocio()
        {
            InitializeComponent();
        }

        clsSocio ObjSocio = new clsSocio();
        clsActividades ObjActividades = new clsActividades();
        clsBarrio ObjBarrio = new clsBarrio();

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Int32 IdCliente = Convert.ToInt32(txtDNISocio.Text);
            ObjSocio.Buscar(IdCliente);
            if (ObjSocio.idSoc != 0)
            {
                lblNombre.Text = ObjSocio.Nombre;
                lblDireccion.Text = ObjSocio.Direccion;
                cmbActividades.SelectedIndex = ObjSocio.idActividad;
                cmbBarrio.SelectedIndex = ObjSocio.idBarrio;
                txtDeuda.Text = ObjSocio.Deuda.ToString();
            }
            else
            {
                lblNombre.Text = "";
                lblDireccion.Text = "";
                txtDeuda.Text = "";
                MessageBox.Show("Dato no encontrado!!!");
            }




        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ObjSocio.Modificar(txtDNISocio.Text, txtDeuda.Text);
            MessageBox.Show("Modificacion realizada con exito");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmBuscarSocio_Load(object sender, EventArgs e)
        {
           
            ObjBarrio.ListarBarrios(cmbBarrio);
            ObjActividades.ListarActividades(cmbActividades);


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ObjSocio.Eliminar(txtDNISocio.Text);
            MessageBox.Show("Socio eliminado con exito");

        }
    }
}
