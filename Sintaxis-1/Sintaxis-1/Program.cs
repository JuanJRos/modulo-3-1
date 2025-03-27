namespace Sintaxis_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce tu nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce tu edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce tu ciudad: ");
            string ciudad = Console.ReadLine();
            Console.WriteLine($"Te llamas {nombre} tienes {edad} años. Bienvenido a {ciudad}");
            Console.ReadLine();
        }
    }
}
