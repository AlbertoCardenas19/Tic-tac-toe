using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiktaktoe
{
    public static class ManejoExcepciones
    {
        public static void ManejarExcepcion(Exception ex)
        {
            Console.WriteLine($"Se ha producido un error: {ex.Message}");
        }

        public static int ObtenerPosicionValida()
        {
            while (true)
            {
                string input = Console.ReadLine();

                // Usamos el método de extensión para validar si es un número válido
                if (input.EsNumeroValido())
                {
                    return Convert.ToInt32(input);
                }

                Console.WriteLine("Entrada no válida. Por favor, ingresa un número entre 1 y 9.");
            }
        }

        public static bool EsNumeroValido(this string input)
        {
            int numero;
            return int.TryParse(input, out numero) && numero >= 1 && numero <= 9;
        }

        public static bool EsPosicionVacia(this Tablero tablero, int posicion)
        {
            if (tablero.casillas[posicion - 1] == 'X' || tablero.casillas[posicion - 1] == 'O')
            {
                return false;
            }
            return true;
        }
    }
}
