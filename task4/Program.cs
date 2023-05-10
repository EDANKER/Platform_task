namespace Microsoft
{
    class Programm
    {
        private static void Main()
        {
            var product = new Product();
            Console.WriteLine(product.tasknumber());
        }
    }

    class Product
    {
        public string tasknumber()
        {
            while (true)
            {
                string? input;
                Console.Write(
                    "\n1 прочетать/редактировать Platform:  \n2 прочетать/редактировать Type:  \n3 прочетать/редактировать Target:  \nвыберите режим: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        var Platform = new Platform();
                        Console.WriteLine(Platform.Platformtext());
                        break;
                    case "2":
                        Console.Clear();
                        var type = new Type();
                        Console.WriteLine(type.Plat());
                        break;

                    case "3":
                        Console.Clear();
                        var Target = new Target();
                        Console.WriteLine(Target.Targertext());
                        break;
                    default:
                        Console.WriteLine("не верный ответ");
                        break;
                }
            }
        }
    }
}