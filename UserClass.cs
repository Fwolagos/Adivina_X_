using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivina_X_
{
    public class UserClass
    {
        #region Atributos
        public  string Name { get; set; }
        public  int Score { get; set; }

        #endregion
        //Constructor de la clase 

        /// <summary>
        /// Clase usuarios 
        /// </summary>
        /// <param name="getName">Nombre del usuario</param>
        /// <param name="getScore">Recort del usuario</param>
        public UserClass(string getName, int getScore)
        {
            Name = getName;
            Score = getScore;
        }

        /// <summary>
        ///  Metodo que Cambia el record de la clase
        /// </summary>
        /// <param name="newScore">Nuevo Recort para actualizar</param>
        public  void UpdateScore(int newScore)
        {
            Score = newScore;
        }

        /// <summary>
        /// Reinicia el recort del usuario a cero
        /// </summary>
        public void RessetScore() 
        {
            Score = 0;
        }
    }
}
