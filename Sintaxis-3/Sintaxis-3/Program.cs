namespace Sintaxis_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce día de la semana: ");
            string dia = Console.ReadLine().ToLower();

            switch (dia)
            {
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                case "viernes":
                    Console.WriteLine("No es fin de semana");
                    break;
                case "sabado":
                case "domingo":
                    Console.WriteLine("Es fin de semana");
                    break;
                default:
                    Console.WriteLine("Introduce un día de la semana");
                    break;
            }

            Console.ReadLine();
        }
    }
}
