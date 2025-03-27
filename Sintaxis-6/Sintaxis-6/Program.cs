namespace Sintaxis_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un número");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese un caracter");
            string caracter = Console.ReadLine();

            Console.WriteLine("----------");

            for (int i = 0; i < numero; i++)
            {
                int fila = 0;
                string filaCadena = "";

                while(fila <= i)
                {
                    if(i == numero-1 || fila == 0 || fila == i)
                    {
                        filaCadena += caracter;
                    }
                    else
                    {
                        filaCadena += " ";
                    }
                    fila++;
                }
                Console.WriteLine(filaCadena);
            }

        }
    }
}
