using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiktaktoe
{
    public class Juego
    {
        private Tablero tablero;
        private Jugador jugador1;
        private Jugador jugador2;
        private Jugador jugadorActual;
        public Juego() {
            
            jugador1 = new Jugador("Jugador 1", 'X', 0);
            jugador2 = new Jugador("Jugador 2", 'O', 0);
        }
        public string ImprimirOpciones()
        {
            Console.Clear();
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Puntuaciones");
            Console.WriteLine("3. Salir");
            string opcion = Console.ReadLine();
            return opcion;
        }

        public void SeleccionOpcion(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    IniciarJuego();
                    break;
                case "2":
                    MostrarPuntuaciones();
                    break;
                case "3":
                    SalirJuego();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
        public void IniciarJuego()
        {
            tablero = new Tablero();
            jugadorActual = jugador1;
            while (!tablero.HayGanador().Item1 && !tablero.HayEmpate())
            {
                JugarTurno();
            }
            MostrarResultado();

        }

        private void JugarTurno()
        {
            Console.Clear ();
            tablero.ImprimirTablero();
            Console.WriteLine();
            Console.WriteLine($"{jugadorActual.Nombre}, es tu turno...");
            int posicion = ManejoExcepciones.ObtenerPosicionValida();

            while (!tablero.EsPosicionVacia(posicion))
            {
                Console.WriteLine("La posición ya está ocupada. Intenta otra vez.");
                posicion = ManejoExcepciones.ObtenerPosicionValida();
            }

            tablero.ActualizarTablero(posicion, jugadorActual.Simbolo);
            CambiarTurno();
        }

        private void CambiarTurno()
        {
            jugadorActual = (jugadorActual == jugador1) ? jugador2 : jugador1;
        }

        private void MostrarResultado()
        {
            Console.Clear();
            tablero.ImprimirTablero();
            (bool hayGanador, string lineaGanadora) = tablero.HayGanador();
            if (hayGanador)
            {
                CambiarTurno();
                Console.WriteLine();
                Console.WriteLine($"¡Felicidades, {jugadorActual.Nombre} ha ganado!");
                Console.WriteLine($"Se formó un 3 en raya en la {lineaGanadora}.");
                jugadorActual.IncrementarContadorVictorias();  
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Es un empate!");
            }

            Console.WriteLine();
            Console.WriteLine("Pulse Enter para continuar...");
            Console.ReadLine();
        }

        private void MostrarPuntuaciones()
        {
            Console.Clear();
            Console.WriteLine($"{jugador1.Nombre}: {jugador1.ContadorVictorias}");
            Console.WriteLine($"{jugador2.Nombre}: {jugador2.ContadorVictorias}");
            Console.WriteLine();
            Console.WriteLine("Pulse Enter para continuar...");
            Console.ReadLine();

        }

        public void SalirJuego()
        {
            Environment.Exit(0);
        }
    }
}
