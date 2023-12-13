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
    public partial class FrmSistema : Form
    {
        public FrmSistema()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultaDeUnSocioToolStripMenuItem_Click(object sender, EventArgs e)
            
        {
            FrmConsutarSocio frmConsultarSocio = new FrmConsutarSocio();
            frmConsultarSocio.Show();
        }

        private void listadoDeTodosLosSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prt frmListadoSocios = new prt();
            frmListadoSocios.Show();
        }

        private void listadoDeSociosDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoSociosDeudoderes frmListadoDeudores = new FrmListadoSociosDeudoderes();
            frmListadoDeudores.Show();
        }

        private void listadoDeSociosDeUnaActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoSociosPorActividad frmListadoSociosPorActividad = new FrmListadoSociosPorActividad();
            frmListadoSociosPorActividad.Show();
        }

        private void listadoDeSociosDeUnBarrioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoSociosPorBarrio frmListadoDeSociosPorBarrio = new FrmListadoSociosPorBarrio();
            frmListadoDeSociosPorBarrio.Show();

        }

        private void agregarSocioNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaSocio frmAltaSocio = new FrmAltaSocio();
            frmAltaSocio.Show();
        }

        private void buscarSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarSocio frmBuscarSocio = new FrmBuscarSocio();
            frmBuscarSocio.Show();
        }

        private void FrmSistema_Load(object sender, EventArgs e)
        {

        }

        private void acercaDelProgramadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaProgramador frmAcercaProgramador = new FrmAcercaProgramador();
            frmAcercaProgramador.Show();
        }
    }
}
