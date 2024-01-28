using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivina_X_
{
    public partial class ListaIntentos : Form
    {
        public ListaIntentos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra el form 1 al salir o cerrar el program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaIntentos_Load(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
           // form1.Show();
        }

        /// <summary>
        /// Boton para volver a la pagina Principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Form1 form1 = new Form1();
            //form1.Show();
        }

        /// <summary>
        /// Carga la lista de los numero probados por el jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = Program.tempListNumUsers;
            //listBox1.Items.Add(Program.tempListNumUsert.Cast<object>().ToArray());
        }
    }
    
}
