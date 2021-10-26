using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public partial class Form1 : Form
    {
        int i = 0;
        private persona[] vector;
        public Form1()
        {
            InitializeComponent();
            limpiar();
        }

        private void limpiar()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Nombre", 200);
            listView1.Columns.Add("Apellido Paterno", 200);
            listView1.Columns.Add("Apellido Materno", 200);
        }

        private void btnabrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            if (dialogo.ShowDialog()==DialogResult.OK)
            {
                limpiar();  
                i = 0;
                string linea = "";
                StreamReader sr = new StreamReader(dialogo.FileName);
                vector = new persona[File.ReadAllLines(dialogo.FileName).Length];
                while (!sr.EndOfStream)
                {
                    linea = sr.ReadLine();
                    vector[i] = new persona(linea);
                    i++;
                }
                sr.Close();
            }
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                ListViewItem renglon = new ListViewItem(vector[i].Nombre);
                renglon.SubItems.Add(vector[i].ApellidoPaterno);
                renglon.SubItems.Add(vector[i].ApellidoMaterno);
                listView1.Items.Add(renglon);
                //vector[i] = null;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog guardar = new SaveFileDialog();
            if (guardar.ShowDialog()==DialogResult.OK)
            {
               
                StreamWriter sw = new StreamWriter(guardar.FileName);
                for (int i = 0; i < vector.Length; i++)
                {
                    sw.WriteLine(vector[i].Nombre + "," + vector[i].ApellidoPaterno + "," + vector[i].ApellidoMaterno);
                }

                sw.Close();
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
