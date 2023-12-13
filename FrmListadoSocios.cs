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
    public partial class prt : Form
    {
        public prt()
        {
            InitializeComponent();
        }

        clsSocio ObjSocio = new clsSocio();

        private void FrmListadoSocios_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ObjSocio.ListadoGeneralSocios(dgvSocios);
            lblTotal.Text = ObjSocio.Total.ToString("0.00");
            lblMayorDeuda.Text = ObjSocio.Mayor.ToString("0.00");
            lblMenorDeuda.Text = ObjSocio.Menor.ToString("0.00");
            lblPromedio.Text = ObjSocio.Promedio.ToString("0.00");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ObjSocio.Exportar();
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
