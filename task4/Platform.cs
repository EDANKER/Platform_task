using System.Text.Json;
using Microsoft;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace task4;

public class Platform
{
    public string Platformtext()
    {
        while (true)
        {
            Console.Write(
                "\nвы в редакторе Platform\n\n выберите режим \n1: редактор \n2: добавление \n3: чтение \n4: назад: \nваш режим: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    try
                    {
                        string pathReadText = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                        var listRead = JsonConvert.DeserializeObject<List<Construct>>(pathReadText);
                   
                        foreach (var read in listRead)
                        {
                            Console.WriteLine($"у вас имеються ячейки: {read.Id} ");
                           
                            Console.ReadKey(); 
                            Console.Write("какую ячейку выбирите? ");
                            var idText = Console.ReadLine();

                            if (read.Id == idText)
                            {
                                while (true)
                                {
                                    Console.WriteLine($"вы у поля {read.Id}");
                                    Console.Write($"вы точно хотите заменить platform {read.Id} ");
                                    Console.ReadLine();
                                    if (input == "да")
                                    {
                                        Console.WriteLine("good");
                                    }
                                    
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("файл пуст");
                    }
                    
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

                        if (typeinput.Length == 0 || targetinput.Length == 0 || platforminput.Length == 0 || id.Length == 0)
                        {
                            Console.WriteLine("ваш type или target или platfom пуст или id \nпопробуйте снова нажми enter");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else
                        {
                            Construct construct = new Construct(id, platforminput, targetinput, typeinput);
                            List<Construct> list = new List<Construct>();
                            list.Add(construct);
                            JsonSerializer.Serialize(fileStream, list);
                            Console.WriteLine("файл сохранен");
                        }
                    }
                    break;
                case "3":
                    try
                    {
                        string path = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                        var listdes = JsonConvert.DeserializeObject<List<Construct>>(path);
                        
                        foreach (var listfor in listdes)
                        {
                                Console.WriteLine($"id: {listfor.Id} platform: {listfor.Platform} type: {listfor.Type} target: {listfor.Target} ");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("файл пуст");
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