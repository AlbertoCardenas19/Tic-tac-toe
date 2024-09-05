using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiktaktoe
{
    public class Tablero
    {
        public char[] casillas = new char[9];

        public Tablero()
        {
            for (int i = 0; i < casillas.Length; i++)
            {
                casillas[i] = ' ';
            }
        }
        public void ImprimirTablero()
        {
            Console.WriteLine($"Jugada (1-3)");
            Console.WriteLine($"Jugada (4-6)");
            Console.WriteLine($"Jugada (7-9)\n");
            for (int i = 0; i < casillas.Length; i += 3)
            {
                Console.WriteLine($" {casillas[i]} | {casillas[i + 1]} | {casillas[i + 2]} ");
                if (i < 6) Console.WriteLine("---|---|---");
            }
            //Console.WriteLine($" {casillas[0]} | {casillas[1]} | {casillas[2]} ");
            //Console.WriteLine("---|---|---");
            //Console.WriteLine($" {casillas[3]} | {casillas[4]} | {casillas[5]} ");
            //Console.WriteLine("---|---|---");
            //Console.WriteLine($" {casillas[6]} | {casillas[7]} | {casillas[8]} ");
        }

        public void ActualizarTablero(int posicion, char simbolo)
        {
            if (posicion >= 1 && posicion <= 9 && casillas[posicion - 1] == ' ')
            {
                casillas[posicion - 1] = simbolo;
            }

        }

        public (bool Ganador, string LineaGanadora) HayGanador()
        {
            int[][] combinacionesGanadoras = new int[][]
            {
                new int[] { 0, 1, 2 }, // fila superior
                new int[] { 3, 4, 5 }, // fila del medio
                new int[] { 6, 7, 8 }, // fila inferior
                new int[] { 0, 3, 6 }, // columna izquierda
                new int[] { 1, 4, 7 }, // columna del medio
                new int[] { 2, 5, 8 }, // columna derecha
                new int[] { 0, 4, 8 }, // diagonal principal
                new int[] { 2, 4, 6 }  // diagonal secundaria
            };

            string[] nombresGanadores = new string[]
            {
                "fila superior", "fila del medio", "fila inferior",
                "columna izquierda", "columna del medio", "columna derecha",
                "diagonal principal", "diagonal secundaria"
            };

            for (int i = 0; i < combinacionesGanadoras.Length; i++)
            {
                int[] combinacion = combinacionesGanadoras[i];
                if (casillas[combinacion[0]] == casillas[combinacion[1]] &&
                    casillas[combinacion[1]] == casillas[combinacion[2]] &&
                    casillas[combinacion[0]] != ' ')
                {
                    return (true, nombresGanadores[i]);
                }
            }

            return (false, "");
        }

        public bool HayEmpate()
        {
            for (int i = 0; i < casillas.Length; i++)
            {
                if (casillas[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }


    }
}
