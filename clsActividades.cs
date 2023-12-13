using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace FinalLabPL2
{
    internal class clsActividades
    {
        private String CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BD_Clientes.mdb";
        private String tabla = "Actividad";

        public Decimal Total = 0;
        public Decimal Promedio = 0;
        public Decimal Mayor = 0;
        public Decimal Menor = 0;
        public Int32 Cantidad = 0;

        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter adaptador;


        public void ListarActividades(ComboBox combo)
        {
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = tabla;
                adaptador = new OleDbDataAdapter(Comando);
                DataSet datos = new DataSet();
                adaptador.Fill(datos, tabla);
                combo.DataSource = datos.Tables[tabla];
                combo.DisplayMember = "Nombre";
                combo.ValueMember = "idActividad";
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
