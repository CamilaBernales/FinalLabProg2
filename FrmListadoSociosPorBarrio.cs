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
    public partial class FrmListadoSociosPorBarrio : Form
    {
        public FrmListadoSociosPorBarrio()
        {
            InitializeComponent();
        }

        clsSocio ObjSocio = new clsSocio();
        private void FrmListadoDeSociosPorBarrio_Load(object sender, EventArgs e)
        {
            clsBarrio ObjetoBarrio = new clsBarrio();
            ObjetoBarrio.ListarBarrios(cmbBarrio);

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Int32 cta = Convert.ToInt32(cmbBarrio.SelectedValue);
            ObjSocio.ListarSocioPorBarrio(dgvSocios, cta);
            lblTotal.Text = ObjSocio.Cantidad.ToString("0.00");
            lblTotalDeudas.Text = ObjSocio.Total.ToString("0.00");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Int32 cta = Convert.ToInt32(cmbBarrio.SelectedValue);
            ObjSocio.ExportarSociosPorBarrio(cta);
            MessageBox.Show("Datos exportados!!!");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            prtVentana.ShowDialog();
            prtDocumento.PrinterSettings = prtVentana.PrinterSettings;
            prtDocumento.Print();
            MessageBox.Show("Reporte impreso");
        }

        private void prtDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ObjSocio.Imprimir(e);
        }
    }
}
