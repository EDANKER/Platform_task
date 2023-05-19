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
                    try
                    {
                        string pathplatformopen = @"C:\Users\edgar\Desktop\students.json";
                        string pathtargeopen = @"C:\Users\edgar\Desktop\Data.json";
                        string pathtypeopen = @"C:\Users\edgar\Desktop\objects.json";
                        string listplatformopen = (File.ReadAllText(pathplatformopen));
                        string listtypeopen = (File.ReadAllText(pathtypeopen));
                        string listtargetopen = (File.ReadAllText(pathtargeopen));
                        var prowPlatform = JsonConvert.DeserializeObject<List<Construct>>(listplatformopen);
                        var prowType = JsonConvert.DeserializeObject<List<Typelist>>(listtypeopen);
                        var prowTarget = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetopen);

                        bool istype = false;
                        bool isTarget = false;

                        foreach (var jsonlist in prowPlatform)
                        {
                            Console.WriteLine($"у вас есть ячейки {jsonlist.Id}");
                        }

                        foreach (var jsonPlatform in prowPlatform)
                        {
                            Console.Write("выбирите свободную ячейку: ");
                            var id = Console.ReadLine();
                            if (jsonPlatform.Id != id)
                            {
                                Console.Write("выбирите PLatform: ");
                                var platforminput = Console.ReadLine();
                                foreach (var listtype in prowType)
                                {
                                    Console.WriteLine($"в базе данных есть {listtype.TypeSpisok}");
                                }

                                Console.Write("выбирите type: ");
                                var typeinput = Console.ReadLine();
                                foreach (var listtarget in prowTarget)
                                {
                                    Console.WriteLine($"в базе данных есть {listtarget.TargetSpisok}");
                                }

                                Console.Write("выбирите Target: ");
                                var targetinput = Console.ReadLine();

                                if (typeinput.Length == 0 || targetinput.Length == 0 || platforminput.Length == 0 ||
                                    id.Length == 0)
                                {
                                    Console.WriteLine(
                                        "ваш type или target или platfom пуст или id \nпопробуйте снова нажми enter");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                else
                                {
                                    foreach (var jsontarget in prowTarget)
                                    {
                                        if (jsontarget.TargetSpisok == targetinput)
                                        {
                                            isTarget = true;
                                        }

                                        else
                                        {
                                            Console.WriteLine(
                                                "отказзано мы не нашли такое в нашей базе данных target");
                                        }
                                    }

                                    foreach (var jsontype in prowType)
                                    {
                                        if (jsontype.TypeSpisok == typeinput)
                                        {
                                            istype = true;
                                        }

                                        else
                                        {
                                            Console.WriteLine(
                                                "отказзано мы не нашли такое в нашей базе данных type");
                                        }
                                    }

                                    if (istype && isTarget)
                                    {
                                        using (StreamWriter streamWriter = new StreamWriter(pathplatformopen, false))
                                        {
                                            Construct construct = new Construct(id, platforminput, targetinput,
                                                typeinput);
                                            prowPlatform.Add(construct);
                                            var json = JsonSerializer.Serialize(prowPlatform);
                                            streamWriter.WriteLine(json);
                                            Console.WriteLine("файл сохранен");
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("увы вы дурак");
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine($"{id} занят");
                            }
                        }
                    }
                    catch
                        (Exception e)
                    {
                        Console.WriteLine("ошибка в json");
                    }

                    break;
                case "3":
                    try
                    {
                        string path = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                        var listdes = JsonConvert.DeserializeObject<List<Construct>>(path);

                        foreach (var listfor in listdes)
                        {
                            Console.WriteLine(
                                $"id: {listfor.Id} platform: {listfor.Platform} type: {listfor.Type} target: {listfor.Target} ");
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