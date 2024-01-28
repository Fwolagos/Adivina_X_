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
        public static List<int> tempListNumSecret = new List<int>();

        /// <summary>
        /// Lista de numeros que el jugador probo
        /// </summary>
        public static List<int> tempListNumUsert = new List<int>();

        /// <summary>
        /// Lista con los  usuarios en la ram
        /// </summary>
        public static List<UserClass> usersList = new List<UserClass>();

        /// <summary>
        /// Estado del juego (stopped,start,)
        /// </summary>
        public static string stateGame = "stoppped";

        /// <summary>
        /// Es la instancia para almacenar el jugador que fue seleccionado
        /// </summary>
        public static UserClass player = null;

        /// <summary>
        /// Variable para almacenar el numero secreto
        /// </summary>
        public static int temNumSecret = 0;
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
        public static void SecretNumber()
        {
            Random rnd = new Random();
            int numRandom = 0;
            do
            {
                numRandom = rnd.Next();
            } while (tempListNumSecret.Contains(numRandom));
            tempListNumSecret.Add(numRandom);
            
        }

        /// <summary>
        /// Lee y carga los usuarios guardados en un documento .json
        /// </summary>
        /// <returns>Retorna una lista con los usuarios econtrados en el usuarios.json</returns>
        public static List<UserClass> ImportUsers()
        {
            //Ruta del archivo 
            string path = @"C:/Programacion/Dates/Usuarios.json";
            //Lista temporal para cargar usuarios
            List<UserClass> temp = new List<UserClass>();
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string json = sr.ReadToEnd();
                    temp = JsonConvert.DeserializeObject<List<UserClass>>(json);
                }
            }
            else
            {
                MessageBox.Show("El archivo de usuarios no existe.");
            }

            return temp;



        }

        /// <summary>
        /// Exporta los usuarios al .Json
        /// </summary>
        /// <param name="temp">Necesita una lista para guardar</param>
        public static void ExportUsers(List<UserClass> temp)
        {
            string json = string.Empty;

            if (temp != null && temp.Count > 0)
            {
                json = JsonConvert.SerializeObject(temp);
                WriteFile(json);
                MessageBox.Show("Datos de usuarios exportados con éxito.");
            }
            else
            {
                MessageBox.Show("Favor agregar al menos un usuario para poder exportar.");
            }
        }

        /// <summary>
        /// Escribe el Documento .Jason
        /// </summary>
        /// <param name="content">El valor a esciribir y guardar</param>
        public static void WriteFile(string content)
        {
            string path = @"C:/Programacion/Dates/Usuarios.json";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(content);
            }
        }

        /// <summary>
        /// Agrega un usuario por default al juego
        /// </summary>
        public static void DefaultUser()
        {
            UserClass user = new UserClass("Default",0);
            usersList.Add(user);
        }

        /// <summary>
        /// Crea usuario 
        /// </summary>
        /// <param name="name">Ocupa el parametro de nombre para crear un usuario</param>
        public static void MakeUsers(string name)
        {
            UserClass user = new UserClass(name, 0);
            usersList.Add(user);
            ExportUsers(usersList);
        }

        /// <summary>
        /// Borra usuarios dandole un nombre
        /// </summary>
        /// <param name="name">Nombre del usuario</param>
        public static void DeleteUsers(string name)
        {
            usersList.RemoveAll(user => user.Name == name);
            ExportUsers(usersList);
        }
        #endregion
    }
}
    
