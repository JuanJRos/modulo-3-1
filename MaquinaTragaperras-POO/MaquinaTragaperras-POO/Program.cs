namespace MaquinaTragaperras_POO
{
    public interface IRuleta
    {
        bool ObtenerResultado();
    }

    public class Maquina : IRuleta
    {
        public int Monedas { get; set; }

        public List<bool> Ruletas { get; set; }
        public Maquina()
        {
            Monedas = 0;
            Ruletas = new List<bool>();
            for (int i = 0; i < 3; i++)
            {
                Ruletas.Add(ObtenerResultado());
            }
        }

        public bool ObtenerResultado()
        {
            Random random = new Random();
            return random.Next(2) == 0;
        }

        public void ReiniciarResultado()
        {
            Ruletas.Clear();
            for (int i = 0; i < 3; i++)
            {
                Ruletas.Add(ObtenerResultado());
            }
        }
    }

    internal class Program
    {
        static Maquina IniciaPartida()
        {
            Maquina maquina = new Maquina();
            maquina.ReiniciarResultado();
            return maquina;
        }

        static void MostrarResultado(Maquina maquina)
        {
            int num = 1;
            Console.WriteLine($"Monedas: {maquina.Monedas}");
            foreach (var item in maquina.Ruletas)
            {
                Console.WriteLine($"{num}ª Ruleta {item}");
                num++; 
            }
            Console.WriteLine("-----");
        }

        static void MostrarMenuBienvenida()
        {
            Console.WriteLine("Bienvenido a la Máquina Tragaperras!!! Selecciona una opción:");
            Console.WriteLine("1 - Jugar");
            Console.WriteLine("2 - Salir");
        }

        static int ObtenerValorUsuario()
        {
            int num = 0;

            try
            {
                string valorUsuario = Console.ReadLine();
                if (valorUsuario is not null)
                    num = int.Parse(valorUsuario);
            }
            catch (Exception ex) 
            {
                Console.WriteLine ("Porfavor ingrese un número");
            }
            return num;
        }

        static void Main(string[] args)
        {
            int numeroUsuario;
            do
            {
                Maquina maquina = IniciaPartida();
                MostrarMenuBienvenida();
                numeroUsuario = ObtenerValorUsuario();

                while (numeroUsuario == 1)
                {
                    Console.WriteLine("Introduce cuantas monedas quieres apostar: ");
                    maquina.Monedas += ObtenerValorUsuario(); ;
                    if (!maquina.Ruletas.Contains(false))
                    {
                        MostrarResultado(maquina);
                        Console.WriteLine($"Enhorabuena!!!. Has ganado {maquina.Monedas} monedas!!");
                        maquina.Monedas = 0;
                        Console.WriteLine("Pulse 1 para volver a jugar o 2 para salir");
                        numeroUsuario = ObtenerValorUsuario();
                    }
                    else
                    {
                        MostrarResultado(maquina);
                        Console.WriteLine("Has perdido!! Pulsa 1 para volvera intentarlo o pulsa 2 para salir: ");
                        numeroUsuario = ObtenerValorUsuario();
                        maquina.ReiniciarResultado();
                    }
                }
            }
            while (numeroUsuario != 2);
        }
    }
}
