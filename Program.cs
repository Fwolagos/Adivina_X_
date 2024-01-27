using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Tuve que importar esta bibloteca para poder usar path entre otras cosas 
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using Adivina_X_;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;






namespace Adivina_X_
{
  
    internal static class Program
    {
        #region Variables Globales

        /// <summary>
        /// Lista de intentos del usuario en la ram o temporal
        /// </summary>
        public static List<int> tempList = new List<int>();

        /// <summary>
        /// Lista con los  usuarios en la ram
        /// </summary>
        public static List<ClaseUsuarios> usersList = new List<ClaseUsuarios>();

        /// <summary>
        /// Estado del juego (stopped,start,)
        /// </summary>
        public static string stateGame = "stoppped";
        #endregion

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        #region Funciones del juego

        /// <summary>
        /// Funcion encargada de generar un numero secreto sin que se repita 
        /// Esta solo se reinicia si el programa es reiniciado
        /// </summary>
        /// <returns>Retorna el numero Secreto</returns>
        public static int  SecretNumber()
        {
            Random rnd = new Random();
            int numRandom = 0;
            do
            {
                 numRandom = rnd.Next();
            } while (tempList.Contains(numRandom));
            return numRandom;
        }

        /// <summary>
        /// Lee y carga los usuarios guardados en un documento .json
        /// </summary>
        /// <returns>Retorna una lista con los usuarios econtrados en el usuarios.json</returns>
        public static List<ClaseUsuarios> ImportUsers()
        {
            //Ruta del archivo 
            string path = @"C:/Programacion/Dates/Usuarios.json";
            //Lista temporal para cargar usuarios
            List<ClaseUsuarios> temp = new List<ClaseUsuarios>();
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string json = sr.ReadToEnd();
                    temp = JsonConvert.DeserializeObject<List<ClaseUsuarios>>(json);
                }
            }
            else
            {
                MessageBox.Show("El archivo de usuarios no existe.");
            }

            return temp;



        }


        #endregion
    }
}
