using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace EMPRESA
{
    class Empleados
    {
        String cadena;
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        public Empleados()
        {
            cadena = "provider=microsoft.jet.oledb.4.0;data source=EMPRESA.mdb";
            conector = new OleDbConnection(cadena);
            comando = new OleDbCommand();
            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Empleados";
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

        }

        public void ver(DataGridView dgvEmpleados)
        {
            dgvEmpleados.DataSource = tabla;
        }
        public void ver(ComboBox combo)
        {
            combo.DisplayMember = "nombre";
            combo.ValueMember = "dni";
            combo.DataSource = tabla;
        }
        public void ver(ListBox lst)
        {
            lst.DisplayMember = "nombre";
            lst.ValueMember = "dni";
            lst.DataSource = tabla;
        }
        public void ver(DataGridView grilla, int Sector)
        {
            grilla.Rows.Clear();
            foreach(DataRow fila in tabla.Rows)
            {
                if (fila["sector"].ToString()== Sector.ToString())
                {
                    grilla.Rows.Add(fila["dni"], fila["nombre"], fila["sueldoo"]);
                }
                
            }
        }
    }
}
