namespace Tiktaktoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Juego nuevoJuego = new Juego();
            
            while (true)
            {
                nuevoJuego.SeleccionOpcion(nuevoJuego.ImprimirOpciones());

            }
        }
    }
}
