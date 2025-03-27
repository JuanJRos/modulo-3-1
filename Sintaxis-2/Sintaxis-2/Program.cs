namespace Sintaxis_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el primer número: ");
            int numero1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduce el segundo número: ");
            int numero2 = Convert.ToInt32(Console.ReadLine());

            if (numero1 > numero2)
            {
                Console.WriteLine($"El número {numero1} es mayor a {numero2}.");
            }
            else if (numero2 > numero1)
            {
                Console.WriteLine($"El número {numero2} es mayor a {numero1}");
            }
            else
            {
                Console.WriteLine("Los dos número son iguales");
            }

                Console.ReadLine();
        }
    }
}
