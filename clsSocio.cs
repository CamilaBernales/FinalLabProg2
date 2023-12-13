using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.Drawing.Printing;
using System.Drawing;

namespace FinalLabPL2
{
    class clsSocio
    {
        private String CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BD_Clientes.mdb";
        private String tabla = "Socio";

        public Decimal Total = 0;
        public Decimal Promedio = 0;
        public Decimal Mayor = 0;
        public Decimal Menor = 0;
        public Int32 Cantidad = 0;
        private string dni = "";
        private string nomb = "";
        private string direcc = "";
        private Int32 barrio = 0;
        private Int32 codigo = 0;
        private Int32 actividad = 0;
        private decimal deuda = 0;


        public Int32 idSoc
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string idSocio {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nomb; }
            set { nomb = value; }
        }

        public string Direccion
        {
            get { return direcc; }
            set { direcc = value; }
        }

        public Int32 idBarrio
        {
            get { return barrio; }
            set { barrio = value; }
        }

        public Int32 idActividad
        {
            get { return actividad; }
            set { actividad = value; }
        }

        public decimal Deuda
        {
            get { return deuda; }
            set { deuda = value; }
        }

        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter adaptador;

        public void Listar(System.Windows.Forms.ComboBox combo)
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
                combo.ValueMember = "IdSocio";
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ListadoDeSocio(DataGridView grilla, Int32 Cta)
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

                adaptador.SelectCommand.CommandText = "SELECT * FROM Barrio";
                adaptador.Fill(datos, "Barrio");

                adaptador.SelectCommand.CommandText = "SELECT * FROM Actividad";
                adaptador.Fill(datos, "Actividad");

                grilla.Rows.Clear();

                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    if (Cta == Convert.ToInt32(fila["idSocio"]))
                    {
                        string nombreBarrio = ObtenerNombreBarrio(Convert.ToInt32(fila["idBarrio"]), datos.Tables["Barrio"]);
                        string nombreActividad = ObtenerNombreActividad(Convert.ToInt32(fila["idActividad"]), datos.Tables["Actividad"]);

                        grilla.Rows.Add(fila["Nombre"], fila["Direccion"], nombreBarrio, nombreActividad, fila["Deuda"]);
                    }
                }

                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private string ObtenerNombreBarrio(int idBarrio, DataTable tablaBarrios)
        {
            DataRow[] filas = tablaBarrios.Select($"idBarrio = {idBarrio}");
            if (filas.Length > 0)
            {
                return filas[0]["Nombre"].ToString();
            }
            return string.Empty;
        }

        private string ObtenerNombreActividad(int idActividad, DataTable tablaActividades)
        {
            DataRow[] filas = tablaActividades.Select($"idActividad = {idActividad}");
            if (filas.Length > 0)
            {
                return filas[0]["Nombre"].ToString();
            }
            return string.Empty;
        }

        public void ListadoGeneralSocios(DataGridView grilla)
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
                grilla.Rows.Clear();

                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    grilla.Rows.Add(fila["idSocio"], fila["Nombre"], fila["Deuda"]);
                    Total = Total + Convert.ToInt32(fila["Deuda"]);
                    int deudaActual = Convert.ToInt32(fila["Deuda"]);
                    if (deudaActual > Mayor)
                    {
                        Mayor = deudaActual;
                    }

                    if (deudaActual < Menor)
                    {
                        Menor = deudaActual;
                    }
                }

                if (datos.Tables[tabla].Rows.Count > 0)
                {
                    Promedio = Total / datos.Tables[tabla].Rows.Count;
                }

                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Exportar()
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

                StreamWriter Archivo = new StreamWriter("Reporte.csv", false, Encoding.UTF8);
                Archivo.WriteLine("Listado de Socios");
                Archivo.WriteLine("");
                Archivo.WriteLine("Número de Documento;Nombre;Deuda");
                Total = 0;
                Cantidad = 0;
                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {

                    Archivo.Write(fila["IdSocio"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["Nombre"]);
                    Archivo.Write(";");
                    Archivo.WriteLine(fila["Deuda"]);
                    Total = Total + Convert.ToInt32(fila["Deuda"]);
                    Cantidad++;


                }
                Archivo.Write("Deuda mayor en el listado:;");
                Archivo.WriteLine(Mayor);
                Archivo.Write("Deuda menor en el listado:;");
                Archivo.WriteLine(Menor);
                Archivo.Write("Total de deuda:;");
                Archivo.WriteLine(Total);
                if (Cantidad > 0)
                {
                    Archivo.Write("Promedio:;");
                    Archivo.WriteLine(Total / Cantidad);
                }
                Archivo.Close();
                Conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void ListarDeudores(DataGridView grilla)
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
                grilla.Rows.Clear();
                int cantidadDeudores = 0;

                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    decimal deuda = Convert.ToDecimal(fila["Deuda"]);

                    if (deuda > 0)
                    {


                        grilla.Rows.Add(fila["idSocio"], fila["Nombre"], deuda);

                        // Suma la deuda para calcular el total
                        Total += deuda;

                        // Actualiza el mayor y el menor
                        if (deuda > Mayor)
                        {
                            Mayor = deuda;
                        }

                        if (deuda < Menor)
                        {
                            Menor = deuda;
                        }

                        cantidadDeudores++;

                    }
                }

                if (cantidadDeudores > 0)
                {
                    Promedio = Total / cantidadDeudores;
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ExportarSociosPorActividad(Int32 Cta)
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
                adaptador.SelectCommand.CommandText = "SELECT * FROM Actividad";
                adaptador.Fill(datos, "Actividad");

                string nombreActividad = ObtenerNombreActividad(Cta, datos.Tables["Actividad"]);
                StreamWriter Archivo = new StreamWriter("ReportePorActividad.csv", false, Encoding.UTF8);
                Archivo.WriteLine("Listado de Socios Por Actividad");
                Archivo.WriteLine("");
                Archivo.Write("Actividad:");
                Archivo.WriteLine(nombreActividad);
                Archivo.WriteLine("Número de Documento;Nombre;Deuda");
                Total = 0;
                Cantidad = 0;
                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    if (Cta == Convert.ToInt32(fila["idActividad"]))
                    {
                        Archivo.Write(fila["IdSocio"]);
                        Archivo.Write(";");
                        Archivo.Write(fila["Nombre"]);
                        Archivo.Write(";");
                        Archivo.WriteLine(fila["Deuda"]);
                        Total = Total + Convert.ToInt32(fila["Deuda"]);
                        Cantidad++;
                    }
                }
                Archivo.Write("Deuda mayor en el listado:;");
                Archivo.WriteLine(Mayor);
                Archivo.Write("Deuda menor en el listado:;");
                Archivo.WriteLine(Menor);
                Archivo.Write("Total de deuda:;");
                Archivo.WriteLine(Total);
                if (Cantidad > 0)
                {
                    Archivo.Write("Promedio:;");
                    Archivo.WriteLine(Total / Cantidad);
                }
                Archivo.Close();
                Conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ListarSociosPorActividad(DataGridView grilla, Int32 Cta)
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
                grilla.Rows.Clear();

                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    decimal deuda = Convert.ToDecimal(fila["Deuda"]);

                    if (Cta == Convert.ToInt32(fila["idActividad"]))
                    {
                        grilla.Rows.Add(fila["Nombre"], fila["Direccion"], fila["Deuda"]);

                        Total += deuda;

                        if (deuda > Mayor)
                        {
                            Mayor = deuda;
                        }

                        if (deuda < Menor)
                        {
                            Menor = deuda;
                        }

                        Cantidad++;
                    }
                }

                if (Cantidad > 0)
                {
                    Promedio = Total / Cantidad;
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ListarSocioPorBarrio(DataGridView grilla, Int32 Cta)
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
                grilla.Rows.Clear();

                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    decimal deuda = Convert.ToDecimal(fila["Deuda"]);

                    if (Cta == Convert.ToInt32(fila["idBarrio"]))
                    {
                        grilla.Rows.Add(fila["Nombre"], fila["Direccion"], fila["Deuda"]);

                        Total += deuda;

                        if (deuda > Mayor)
                        {
                            Mayor = deuda;
                        }

                        if (deuda < Menor)
                        {
                            Menor = deuda;
                        }

                        Cantidad++;
                    }
                }

                if (Cantidad > 0)
                {
                    Promedio = Total / Cantidad;
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ExportarSociosPorBarrio(Int32 Cta)
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
                adaptador.SelectCommand.CommandText = "SELECT * FROM Barrio";
                adaptador.Fill(datos, "Barrio");

                string nombreBarrio = ObtenerNombreBarrio(Cta, datos.Tables["Barrio"]);
                StreamWriter Archivo = new StreamWriter("ReportePorBarrio.csv", false, Encoding.UTF8);
                Archivo.WriteLine("Listado de Socios Por Barrio");
                Archivo.WriteLine("");
                Archivo.Write("Barrio:");
                Archivo.WriteLine(nombreBarrio);
                Archivo.WriteLine("Número de Documento;Nombre;Deuda");
                Total = 0;
                Cantidad = 0;
                foreach (DataRow fila in datos.Tables[tabla].Rows)
                {
                    if (Cta == Convert.ToInt32(fila["idBarrio"]))
                    {
                        Archivo.Write(fila["IdSocio"]);
                        Archivo.Write(";");
                        Archivo.Write(fila["Nombre"]);
                        Archivo.Write(";");
                        Archivo.WriteLine(fila["Deuda"]);
                        Total = Total + Convert.ToInt32(fila["Deuda"]);
                        Cantidad++;
                    }
                }
                Archivo.Write("Deuda mayor en el listado:;");
                Archivo.WriteLine(Mayor);
                Archivo.Write("Deuda menor en el listado:;");
                Archivo.WriteLine(Menor);
                Archivo.Write("Total de deuda:;");
                Archivo.WriteLine(Total);
                if (Cantidad > 0)
                {
                    Archivo.Write("Promedio:;");
                    Archivo.WriteLine(Total / Cantidad);
                }
                Archivo.Close();
                Conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void CrarSocio()
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

                DataTable dt = datos.Tables[tabla];
                DataRow dr = dt.NewRow();
                dr["idSocio"] = dni;
                dr["Nombre"] = nomb;
                dr["Direccion"] = direcc;
                dr["idBarrio"] = barrio;
                dr["idActividad"] = actividad;
                dr["Deuda"] = deuda;

                dt.Rows.Add(dr);
                OleDbCommandBuilder conciliarCambios = new OleDbCommandBuilder(adaptador);
                adaptador.Update(datos, tabla);
                Conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Buscar(Int32 IdCliente)
        {
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = tabla;
                OleDbDataReader DR = Comando.ExecuteReader();
                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        if (DR.GetInt32(0) == IdCliente)
                        {
                            idSoc = DR.GetInt32(0);
                            nomb = DR.GetString(1);
                            direcc = DR.GetString(2);
                            barrio = DR.GetInt32(3);
                            actividad = DR.GetInt32(4);
                            deuda = DR.GetDecimal(5);
                        }
                    }
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Eliminar(string IdSocio)
        {
            try
            {
                String sql = "";
                sql = "DELETE * FROM Socio WHERE IdSocio = ";
                sql = sql + IdSocio;
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = sql;
                Comando.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Modificar(string dni, string deuda)
        {
            try
            {
                String sql = "";
                sql = "UPDATE Socio SET Deuda = ";
                sql = sql + deuda.ToString();
                sql = sql + " WHERE IdSocio = ";
                sql = sql + dni;
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = sql;
                Comando.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show("Error in Modificar: " + ex.Message);
            }
        }

        public void Imprimir(PrintPageEventArgs reporte)
        {
            try
            {
                Font LetraTitulo1 = new Font("Arial", 20);
                Font LetraTitulo2 = new Font("Arial", 12);
                Font LetraTexto = new Font("Arial", 8);
                Int32 f = 200;
                reporte.Graphics.DrawString("Listado de Socios",LetraTitulo1,Brushes.Red,100, 100);
               
                reporte.Graphics.DrawString("DNI", LetraTitulo2,
               Brushes.Blue, 100, 180);
                reporte.Graphics.DrawString("Nombre del Clientes",
               LetraTitulo2, Brushes.Blue, 150, 180);
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = tabla;
                DataSet DS = new DataSet();
                adaptador = new OleDbDataAdapter(Comando);
                adaptador.Fill(DS, tabla);
                if (DS.Tables[tabla].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[tabla].Rows)
                    {
                        reporte.Graphics.DrawString(fila["IdSocio"].ToString
                       (), LetraTexto, Brushes.Black, 100, f);
                        reporte.Graphics.DrawString(fila["Nombre"].ToString(),
                       LetraTexto, Brushes.Black, 150, f);
                        f = f + 12;
                    }
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}
