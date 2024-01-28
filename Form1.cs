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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Boton que Cabia de formulario al formulario de lista de intentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (Program.stateGame == "stoppped")
            {
                MessageBox.Show("Aún el juego no inicia. Por favor presione el botón iniciar.");
            }
            else
            {                
                //Abrir el otro form
                ListaIntentos form2 = new ListaIntentos();
                form2.Show();
            }

        }

        /// <summary>
        /// Boto que cambia del formulario principal hacia el formulario de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            //Muestra el nuevo formulario
            Usuarios usuariosForm = new Usuarios();
            usuariosForm.Show();
        }

        /// <summary>
        /// Función que habla un poco sobre el juego 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Adivina 'x' es un juego de adivinar el número pensado por nuestro genio de la lampara." +
                " Puedes intentar las veces que quieras pero por cada ves que falles puedes perder un punto o por cada ves que " +
                "ganes obtendras un punto. ");
        }

        /// <summary>
        /// Boton Reiniciar puntaje, Inicia en cero el puntaje del usuario seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (Program.stateGame == "stoppped")
            {
                MessageBox.Show("Aún el juego no inicia. Por favor presione el botón iniciar");
            }
            else
            {
                Program.player.RessetScore();
                textBox3.Text = Program.player.Score.ToString();
            }
        }

        /// <summary>
        /// Botón que reinicia todo el juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// Botón que inicia el juego 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.player == null)
            {
                MessageBox.Show("Primero debe selecionar un usuario!!!!. Presione el botón de Usuarios");
                Usuarios usuariosForm = new Usuarios();
                usuariosForm.Show();
            }
            else if (Program.stateGame == "initiated")
            {
                MessageBox.Show("El juego ya inicio");
            }
            else
            {
                textBox2.Text = Program.player.Name.ToString();
                this.Hide();

                Game gameForm = new Game();
                gameForm.Show();
            }
        }

        /// <summary>
        /// Ejecuta instruciones al iniciar el form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Program.DefaultUser();
            
        }

        /// <summary>
        /// Boton para averiguar si el numero es correcto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.stateGame == "stoppped")
                MessageBox.Show("El juego aun no inicia, por favor presione el botón iniciar juego");
            else
            {
                try
                {
                    Program.tempListNumUsers.Add(Convert.ToInt32(txbNum.Text));
                    Program.GuestNumber(Convert.ToInt32(txbNum.Text));
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("No se permiten letras " + ex.Message);
                }
                
            }
            if (Program.stateGame == "initiated")
            {
                textBox2.Text = Program.player.Name.ToString();
                textBox3.Text = Program.player.Score.ToString();
                txbNum.Clear();
            }

        }

        /// <summary>
        /// Boton que permite a jugador rendirse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.stateGame == "initiated")
            {
                Program.Surrender();
                textBox3.Text = Program.player.Score.ToString();
            }

        }

        /// <summary>
        /// Para mostrar el nombre del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = Program.player.Name.ToString();
        }

        /// <summary>
        /// Para mostra el recort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Program.player.Score.ToString();
        }

        /// <summary>
        /// Boton para refrescar los cambios del puntaje y usuarios 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (Program.stateGame == "initiated")
            {
                textBox2.Text = Program.player.Name.ToString();
                textBox3.Text = Program.player.Score.ToString();
            }
            else
            {
                MessageBox.Show("El juego aun no inicia presione iniciar juego.");
            }
        }

        /// <summary>
        /// Boton para gurdar y salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if ( Program.stateGame == "initiated")
            {
                Program.ExportUsers(Program.usersList);
                MessageBox.Show("Su partida fue guardada");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Gracias por juegar nuestro juego");
                Application.Exit();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
