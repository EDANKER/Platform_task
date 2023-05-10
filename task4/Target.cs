using System.Text.Json;

namespace Microsoft;

public class Target
{
    public string? Targertext()
    {
        while (true)
        {
            Console.Write(
                "\nвы в редакторе Target\n\n выберите режим \n1: редактор \n2: добавление \n3: чтение \n4: назад: \nваш режим: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    using (FileStream fileStream =
                           new FileStream(@"C:\Users\edgar\Desktop\objects.json", FileMode.OpenOrCreate))
                    {
                        List<Construct> listtype = new List<Construct>();

                        foreach (var list in listtype)
                        {
                            Console.Write("выбирите id строки какой хотите заменить: ");
                            list._id = Console.ReadLine();
                            Console.Write($"Замените type у {list._id}: ");
                            JsonSerializer.Serialize(fileStream, list._id);
                            var type = Console.ReadLine();
                        }
                    }

                    break;
                case "2":

                    break;
                case "3":
                    string path = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                    using (var jsonDoc = JsonDocument.Parse(path))
                    {
                        foreach (var json in jsonDoc.RootElement.EnumerateObject())
                        {
                            if (json.Name.Length == 0)
                            {
                                Console.WriteLine("файл пуст");
                            }

                            else
                            {
                                Console.WriteLine($" {json.Name} {json.Value}");
                            }
                        }

                        Console.ReadKey();
                    }

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