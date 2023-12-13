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
    public partial class FrmConsutarSocio : Form
    {
        public FrmConsutarSocio()
        {
            InitializeComponent();
        }


        clsSocio ObjSocio = new clsSocio();
        private void FrmConsutarSocio_Load(object sender, EventArgs e)
        {
            ObjSocio.Listar(cmbSocio);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Int32 cta = Convert.ToInt32(cmbSocio.SelectedValue);
            ObjSocio.ListadoDeSocio(dgvFactura, cta);

        }

        private void dgvFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
