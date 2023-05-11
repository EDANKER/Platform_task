using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Microsoft;

public class Type
{
    public async Task<string?> Plat()
    {
        while (true)
        {
            Console.Write(
                "\nвы в редакторе Type\n\n выберите режим \n1: редактор \n2: добавление \n3: чтение \n4: назад: \nваш режим: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    using (FileStream fileStream =
                           new FileStream(@"C:\Users\edgar\Desktop\objects.json", FileMode.OpenOrCreate))
                    {
                        
                        
                    }

                    break;
                case "2":

                    break;
                case "3":
                   
                    break;
                case "4":
                    Console.Clear();
                    var programm = new Product();
                    Console.WriteLine(programm.tasknumber());
                    break;
                default:
                    Console.WriteLine("не верный выриант");
                    break;
            }
        }
    }
}