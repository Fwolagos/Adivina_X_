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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cuando el formulario se cierra este vueleve al origianal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Usuarios_Load(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
            //form1.Show();
        }

        /// <summary>
        /// Boton para importar los usuarios 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Program.usersList = Program.ImportUsers();

            //DataSource propiedad de la lista
            cbx1.DataSource = Program.usersList;
            cbx1.DisplayMember = "Name";
            cbx2.DataSource = Program.usersList;
            cbx2.DisplayMember = "Name";

        }

        /// <summary>
        /// Boton para Seleccionar el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbx1.SelectedItem != null)
            {
                // Obtener el objeto seleccionado
                Program.player = (UserClass)cbx1.SelectedItem;
                MessageBox.Show("Jugador Seleccionado");
                this.Close();
            }
        }

        /// <summary>
        /// Boton que Crea los usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (txbName.Text != null)
            {
                Program.MakeUsers(txbName.Text.ToString());
                cbx1.DataSource = Program.usersList;
                cbx2.DataSource = Program.usersList;

            }
            else
            {
                MessageBox.Show("Ingrese un nombre valido por favor");
            }

        }

        /// <summary>
        /// Boton para eliminar un usuario seleccionado 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (cbx2.SelectedItem != null)
            {
                Program.DeleteUsers(((UserClass)cbx2.SelectedItem).Name);
            }
            else
            {
                MessageBox.Show("Selecciones un jugador valido");
            }
        }
    }
}
