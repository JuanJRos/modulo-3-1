namespace Sintaxis_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Ingrese un número: ");
            int numero = Convert.ToInt32 (Console.ReadLine());

            List<int> numerosRandoms = new List<int>();

            for (int i = 0; i < numero; i++)
            {
                numerosRandoms.Add(random.Next(0,200));
            }

            Console.WriteLine("Numeros generados");

            foreach (int num in numerosRandoms)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();    
            
        }
    }
}
