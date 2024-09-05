using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiktaktoe
{
    public class Jugador
    {
        public string Nombre { get; }
        public char Simbolo { get; }
        public int ContadorVictorias { get; set; }

        public Jugador(string jugador, char simbolo, int contadorVictorias)
        {
            this.Nombre = jugador;
            this.Simbolo = simbolo; 
            this.ContadorVictorias = contadorVictorias;
        }

        public void IncrementarContadorVictorias()
        {
            ContadorVictorias++;
        }

    }
}
