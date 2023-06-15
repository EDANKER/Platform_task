using Microsoft;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Task;

public class TargetMenu
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
                    try
                    {
                        string pathPlatform = @"C:\Users\edgar\Desktop\students.json";
                        string pathTarget = @"C:\Users\edgar\Desktop\Data.json";
                        string listPlatform = (File.ReadAllText(pathPlatform));
                        string listTarget = (File.ReadAllText(pathTarget));
                        var targetJson = JsonConvert.DeserializeObject<List<Targets>>(listTarget);
                        var prowPlatformTarget = JsonConvert.DeserializeObject<List<Plafrorms>>(listPlatform);

                        var targetTemp = new List<string>();
                        var listTemp = new List<string>();

                        foreach (var jsonScanPlatformTarget in prowPlatformTarget)
                        {
                            foreach (var scan in jsonScanPlatformTarget.Target)
                            {
                                Console.WriteLine($"у вас в Platform есть target: {scan.TittleTarget}");
                            }
                        }

                        foreach (var deletedWarning in prowPlatformTarget)
                        {
                            foreach (var deletedScan in deletedWarning.Target)
                            {
                                targetTemp.Add(deletedScan.TittleTarget);
                            }
                        }

                        foreach (var jsonContains in prowPlatformTarget)
                        {
                            foreach (var renameJsonTarget in jsonContains.Target)
                            {
                                foreach (var jsontext in targetJson)
                                {
                                    listTemp.Add(jsontext.TittleTarget);
                                    Console.WriteLine($"у вас есть таргеты {jsontext.TittleTarget}");
                                }

                                Console.WriteLine("\nчто вы хотите\n удалить 1 изменить 2");
                                var inputtarget = Console.ReadLine();
                                switch (inputtarget)
                                {
                                    case "1":
                                        Console.Write("какой target вы хотите изменить: ");
                                        var deledettarget = Console.ReadLine();
                                        if (listTemp.Contains(deledettarget))
                                        {
                                            if (!targetTemp.Contains(deledettarget))
                                            {
                                                string pathPush = @"C:\Users\edgar\Desktop\Data.json";
                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathPush, false))
                                                {
                                                    int index = listTemp.IndexOf(deledettarget);
                                                    targetJson.RemoveAt(index);
                                                    var json = JsonSerializer.Serialize(targetJson);
                                                    streamWriter.WriteLine(json);
                                                    Console.WriteLine("файил записан");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("уже испульзуеться нельзя удалить");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("такого поля нет");
                                        }

                                        break;
                                    case "2":
                                        Console.Write("какой target вы хотите изменить: ");
                                        var renametarget = Console.ReadLine();
                                        if (listTemp.Contains(renametarget) &&
                                            renameJsonTarget.TittleTarget.Contains(renametarget))
                                        {
                                            Console.WriteLine($"вы у строки {renametarget}");
                                            Console.Write($"на какую строку вы хотите заменить {renametarget}: ");
                                            string? renameinput = Console.ReadLine();
                                            if (!listTemp.Contains(renameinput) &&
                                                !renameJsonTarget.TittleTarget.Contains(renameinput))
                                            {
                                                if (renameinput.Length == 0)
                                                {
                                                    Console.WriteLine("нельзя перезаписать на пустую строку");
                                                }
                                                else
                                                {
                                                    string pathPlatformRename = @"C:\Users\edgar\Desktop\students.json";
                                                    string pathRenameType = @"C:\Users\edgar\Desktop\Data.json";

                                                    using (StreamWriter streamWriter = new StreamWriter(pathPlatformRename, false))
                                                    {
                                                        foreach (var pushTarget in prowPlatformTarget)
                                                        {
                                                            foreach (var listRanameTragte in pushTarget.Target)
                                                            {
                                                                if (listRanameTragte.TittleTarget == renametarget)
                                                                {
                                                                    listRanameTragte.TittleTarget = renameinput;
                                                                }
                                                            }
                                                        }

                                                        var jsonTarget = JsonSerializer.Serialize(prowPlatformTarget);
                                                        streamWriter.WriteLine(jsonTarget);
                                                        Console.WriteLine("файл записан");
                                                    }

                                                    using (StreamWriter streamWriter = new StreamWriter(pathRenameType, false))
                                                    {
                                                        int index = listTemp.IndexOf(renametarget);
                                                        targetJson[index].TittleTarget = renameinput;
                                                        var json = JsonSerializer.Serialize(targetJson);
                                                        streamWriter.WriteLine(json);
                                                        Console.WriteLine("файил записан");
                                                        break;
                                                    }
                                                }
                                            }

                                            else
                                            {
                                                Console.WriteLine("такое поле занято");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("такого поля нет");
                                            break;
                                        }

                                        break;
                                }

                            }

                            Console.ReadKey();
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("не вернный формат");
                    }
                    break;
                case "2":
                    try
                    {
                        string pathTarget = @"C:\Users\edgar\Desktop\Data.json";
                        var readList = (File.ReadAllText(pathTarget));
                        var targetJson = JsonConvert.DeserializeObject<List<Targets>>(readList);

                        var listcontein = new List<string>();
                        foreach (var conteinJson in targetJson)
                        {
                            listcontein.Add(conteinJson.TittleTarget);
                        }

                        Console.Write("какой таргет хотите добавить?: ");
                        var listtarget = Console.ReadLine();
                        if (!listcontein.Contains(listtarget))
                        {
                            if (listtarget.Length == 0)
                            {
                                Console.WriteLine("вы не чего не написали");
                            }
                            else
                            {
                                using (StreamWriter streamReader = new StreamWriter(pathTarget, false))
                                {
                                    Targets targets = new Targets(listtarget);
                                    targetJson?.Add(targets);
                                    var jsontarget = JsonSerializer.Serialize(targetJson);
                                    streamReader.WriteLine(jsontarget);
                                    Console.WriteLine("файл записан");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("занято");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("не вернный формат");
                    }
                    break;
                case "3":
                    string pathTargetPush = @"C:\Users\edgar\Desktop\Data.json";
                    string listtargetopen = (File.ReadAllText(pathTargetPush));
                    var readrarget = JsonConvert.DeserializeObject<List<Targets>>(listtargetopen);
                    try
                    {
                        foreach (var jsontargetlist in readrarget)
                        {
                            if (jsontargetlist.TittleTarget.Length == 0)
                            {
                                Console.WriteLine("нужных данных нет");
                            }
                            else
                            {
                                Console.WriteLine(jsontargetlist.TittleTarget);
                            }
                        }
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Фаил пуст");
                    }
                    break;
                case "4":
                    Console.Clear();
                    var programm = new Product();
                    Console.WriteLine(programm.Menu());
                    break;
                default:
                    Console.WriteLine("не верный выриант");
                    break;
            }
        }
    }
}