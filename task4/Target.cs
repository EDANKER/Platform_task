using Microsoft;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace task4;

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
                    try
                    {
                        string pathplatformopen = @"C:\Users\edgar\Desktop\students.json";
                        string pathtargetraname = @"C:\Users\edgar\Desktop\Data.json";
                        string listplatformopen = (File.ReadAllText(pathplatformopen));
                        string listtargetraname = (File.ReadAllText(pathtargetraname));
                        var read = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetraname);
                        var prowPlatformTarget = JsonConvert.DeserializeObject<List<Construct>>(listplatformopen);

                        var listTarget = new List<string>();
                        var list = new List<string>();

                        foreach (var jsonScanPlatformTarget in prowPlatformTarget)
                        {
                            foreach (var scan in jsonScanPlatformTarget.Target)
                            {
                                Console.WriteLine($"у вас в Platform есть target: {scan.TargetSpisok}");
                            }
                        }

                        foreach (var deletedWarning in prowPlatformTarget)
                        {
                            foreach (var deletedScan in deletedWarning.Target)
                            {
                                listTarget.Add(deletedScan.TargetSpisok);
                            }
                        }

                        foreach (var jsonContains in prowPlatformTarget)
                        {
                            foreach (var renameJsonTarget in jsonContains.Target)
                            {
                                foreach (var jsontext in read)
                                {
                                    list.Add(jsontext.TargetSpisok);
                                    Console.WriteLine($"у вас есть таргеты {jsontext.TargetSpisok}");
                                }

                                Console.WriteLine("\nчто вы хотите\n удалить 1 изменить 2");
                                var inputtarget = Console.ReadLine();
                                switch (inputtarget)
                                {
                                    case "1":
                                        Console.Write("какой target вы хотите изменить: ");
                                        var deledettarget = Console.ReadLine();
                                        if (list.Contains(deledettarget))
                                        {
                                            if (!listTarget.Contains(deledettarget))
                                            {
                                                string pathrename = @"C:\Users\edgar\Desktop\Data.json";
                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathrename, false))
                                                {
                                                    int index = list.IndexOf(deledettarget);
                                                    read.RemoveAt(index);
                                                    var json = JsonSerializer.Serialize(read);
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
                                        if (list.Contains(renametarget) &&
                                            renameJsonTarget.TargetSpisok.Contains(renametarget))
                                        {
                                            Console.WriteLine($"вы у строки {renametarget}");
                                            Console.Write($"на какую строку вы хотите заменить {renametarget}: ");
                                            string? renameinput = Console.ReadLine();
                                            if (!list.Contains(renameinput) &&
                                                !renameJsonTarget.TargetSpisok.Contains(renameinput))
                                            {
                                                if (renameinput.Length == 0)
                                                {
                                                    Console.WriteLine("нельзя перезаписать на пустую строку");
                                                }

                                                else
                                                {
                                                    string pathPlatformrename = @"C:\Users\edgar\Desktop\students.json";
                                                    string pathrename = @"C:\Users\edgar\Desktop\Data.json";

                                                    using (StreamWriter streamWriter =
                                                           new StreamWriter(pathPlatformrename, false))
                                                    {
                                                        foreach (var pushTarget in prowPlatformTarget)
                                                        {
                                                            foreach (var listRanameTragte in pushTarget.Target)
                                                            {
                                                                if (listRanameTragte.TargetSpisok == renametarget)
                                                                {
                                                                    listRanameTragte.TargetSpisok = renameinput;
                                                                }
                                                            }
                                                        }

                                                        var jsonTarget = JsonSerializer.Serialize(prowPlatformTarget);
                                                        streamWriter.WriteLine(jsonTarget);
                                                        Console.WriteLine("файл записан");
                                                    }

                                                    using (StreamWriter streamWriter =
                                                           new StreamWriter(pathrename, false))
                                                    {
                                                        int index = list.IndexOf(renametarget);
                                                        read[index].TargetSpisok = renameinput;
                                                        var json = JsonSerializer.Serialize(read);
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

                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ваш json кривой");
                    }
                    break;
                case "2":
                    try
                    {
                        string pathtargetlist = @"C:\Users\edgar\Desktop\Data.json";
                        var readlist = (File.ReadAllText(pathtargetlist));
                        var read = JsonConvert.DeserializeObject<List<Targetlist>>(readlist);

                        var listcontein = new List<string>();
                        foreach (var conteinJson in read)
                        {
                            listcontein.Add(conteinJson.TargetSpisok);
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
                                using (StreamWriter streamReader = new StreamWriter(pathtargetlist, false))
                                {
                                    Targetlist targetlist = new Targetlist(listtarget);
                                    read?.Add(targetlist);
                                    var jsontarget = JsonSerializer.Serialize(read);
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
                        Console.WriteLine("файи пуст");
                    }

                    break;
                case "3":
                    string pathtargeopen = @"C:\Users\edgar\Desktop\Data.json";
                    string listtargetopen = (File.ReadAllText(pathtargeopen));
                    var readrarget = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetopen);
                    try
                    {
                        foreach (var jsontargetlist in readrarget)
                        {
                            if (jsontargetlist.TargetSpisok.Length == 0)
                            {
                                Console.WriteLine("нужных данных нет");
                            }

                            else
                            {
                                Console.WriteLine(jsontargetlist.TargetSpisok);
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
                    Console.WriteLine(programm.tasknumber());
                    break;
                default:
                    Console.WriteLine("не верный выриант");
                    break;
            }
        }
    }
}