using System.Text.Json;

namespace Microsoft;

public class Platform
{
    public int Platformtext()
    {
        while (true)
        {
            Console.Write(
                "\nвы в редакторе Platform\n\n выберите режим \n1: редактор \n2: добавление \n3: чтение \n4: назад: \nваш режим: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    break;
                case "2":
                    using (FileStream fileStream =
                           new FileStream(@"C:\Users\edgar\Desktop\students.json", FileMode.OpenOrCreate))
                    {
                        Console.Write("выбирите свободную ячейку: ");
                        var id = Console.ReadLine();
                        Console.Write("выбирите PLatform: ");
                        var platforminput = Console.ReadLine();
                        Console.Write("выбирите type: ");
                        var typeinput = Console.ReadLine();
                        Console.Write("выбирите Target: ");
                        var targetinput = Console.ReadLine();

                        if (typeinput.Length == 0 || targetinput.Length == 0 || platforminput.Length == 0)
                        {
                            Console.WriteLine("ваш type или target или platfom пуст \nпопробуйте снова нажми enter");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else
                        {
                            Construct construct = new Construct($"{id}:", platforminput, targetinput, typeinput);
                            List<Construct> list = new List<Construct>();
                            list.Add(construct);
                            JsonSerializer.Serialize(fileStream, list);
                            Console.WriteLine("файл сохранен");
                        }
                    }

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
                    Console.WriteLine("не верный вариант ответа");
                    break;
            }

            Console.ReadKey();
        }
    }
}