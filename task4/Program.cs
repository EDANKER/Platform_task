using System.Runtime.CompilerServices;
using Task;

namespace Task
{
    class Programm
    {
        private static void Main()
        {
            var product = new Product();
            Console.WriteLine(product.Menu());
        }
    }

    class Product
    {
        public string Menu()
        {
            while (true)
            {
                Console.Write(
                    "\n1 прочитать/редактировать Platform:  \n2 прочитать/редактировать Type:  \n3 прочитать/редактировать Target:  \n4 выключить программу \nвыберите режим: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        var Platform = new PlatformBuild();
                        Console.WriteLine(Platform.Platformtext());
                        break;
                    case "2":
                        Console.Clear();
                        var type = new TypeMenu();
                        Console.WriteLine(type.Plat());
                        break;
                    case "3":
                        Console.Clear();
                        var Target = new TargetMenu();
                        Console.WriteLine(Target.Targertext());
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("неверный ответ");
                        break;
                }
            }
        }
    }
}
