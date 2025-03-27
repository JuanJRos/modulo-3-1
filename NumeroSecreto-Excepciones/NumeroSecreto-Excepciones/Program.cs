namespace NumeroSecreto_Excepciones
{
    public class ComprobarNumeroException : Exception
    {
        public ComprobarNumeroException(string message) : base(message)
        {
            //Console.WriteLine(message);
        }
    }

    internal class Program
    {
        private static int obtenerNumero()
        {
            string valorUsuario = Console.ReadLine();
            int valorNumero = 0;
            try
            {
                if (valorUsuario is not null)
                {
                    valorNumero = Convert.ToInt32(valorUsuario);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine("Por favor ingrese un número");
            }
            return valorNumero;
        }

        private static void comprobarNumero(int numUsuario, int numAleatorio)
        {
            if (numUsuario < numAleatorio && numUsuario != 0)
            {
                throw new ComprobarNumeroException("El número introducido es menor. Vuelve a intentarlo!");
            }
            else if (numUsuario > numAleatorio && numUsuario != 0)
            {
                throw new ComprobarNumeroException("El número introducido es mayor. Vuelve a intentarlo!");
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 51);
            int turnos = 10;
            int numeroUsuario;

            Console.WriteLine("Descubre el número secreto entre 1 y 50.");

            int intentos = 0;

            do
            {
                Console.WriteLine($"Intento {intentos+1}/{turnos}");
                Console.WriteLine("Introduce un número: ");
                numeroUsuario = obtenerNumero();
                try
                {
                    comprobarNumero(numeroUsuario, numeroAleatorio);
                }
                catch (ComprobarNumeroException e)
                {
                    Console.WriteLine(e.Message);  
                }
                intentos++;
            }
            while (intentos < turnos && numeroUsuario != numeroAleatorio);
            
            if(intentos == turnos)
            {
                Console.WriteLine($"Has llegado al límite de intentos!! El número era {numeroAleatorio}");
            }
            else if(numeroUsuario == numeroAleatorio)
            {
                Console.WriteLine($"Felicidades has acertado el número {numeroAleatorio}");
            }

        }
    }
}
