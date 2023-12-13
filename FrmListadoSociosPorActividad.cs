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
    public partial class FrmListadoSociosPorActividad : Form
    {
        public FrmListadoSociosPorActividad()
        {
            InitializeComponent();
        }
        clsSocio ObjSocio = new clsSocio();
        private void FrmListadoSociosPorActividad_Load(object sender, EventArgs e)
        {
            clsActividades ObjActividades = new clsActividades();
            ObjActividades.ListarActividades(cmbActividades);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Int32 cta = Convert.ToInt32(cmbActividades.SelectedValue);
            ObjSocio.ListarSociosPorActividad(dgvSocios, cta);
            lblTotal.Text = ObjSocio.Total.ToString("0.00");
            lblMayorDeuda.Text = ObjSocio.Mayor.ToString("0.00");
            lblMenorDeuda.Text = ObjSocio.Menor.ToString("0.00");
            lblPromedio.Text = ObjSocio.Promedio.ToString("0.00");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Int32 cta = Convert.ToInt32(cmbActividades.SelectedValue);
            ObjSocio.ExportarSociosPorActividad(cta);
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
