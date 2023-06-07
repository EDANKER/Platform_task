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
                        string pathplatfor = @"C:\Users\edgar\Desktop\students.json";
                        string pathtarget = @"C:\Users\edgar\Desktop\Data.json";
                        string pathtype = @"C:\Users\edgar\Desktop\objects.json";
                        string listplatfor = (File.ReadAllText(pathplatfor));
                        string listtargetraname = (File.ReadAllText(pathplatfor));
                        var read = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetraname);
                        var prowPlatformrename = JsonConvert.DeserializeObject<List<Construct>>(listplatfor);

                        var listplatform = new List<string>();

                        foreach (var jsonPlatformRead in prowPlatformrename)
                        {
                            listplatform.Add(jsonPlatformRead.Platform);
                        }

                        foreach (var spisokTargetlist in read)
                        {
                            Console.WriteLine($"у вас есть Target: {spisokTargetlist.TargetSpisok}");
                        }

                        foreach (var readTarget in read)
                        {
                            Console.Write("выбирите Platform который хотите изменить: ");
                            var inputPlatform = Console.ReadLine();
                            if (listplatform.Contains(inputPlatform))
                            {
                                Console.Write($"вы у строки {inputPlatform} какой target вы хотите ему добавить: ");
                                var renamePlatform = Console.ReadLine();
                                if (readTarget.TargetSpisok == renamePlatform)
                                {
                                    foreach (var variableConstruct in prowPlatformrename)
                                    {
                                        foreach (var taskTratget in variableConstruct.Target)
                                        {
                                            if (!taskTratget.TargetSpisok.Contains(renamePlatform))
                                            {
                                                string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathrename, false))
                                                {
                                                    int indexTarget = taskTratget.TargetSpisok.IndexOf(renamePlatform);
                                                    // prowPlatformrename[indexTarget];
                                                    var jsonPlatfrom = JsonSerializer.Serialize(prowPlatformrename);
                                                    streamWriter.WriteLine(jsonPlatfrom);
                                                    Console.WriteLine("файил записан");
                                                }
                                            }

                                            else
                                            {
                                                Console.WriteLine("он занят");
                                            }
                                        }
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("такого нет");
                                }
                            }

                            else
                            {
                                Console.WriteLine($"такого {inputPlatform} нет попробуйте еще");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
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

                        var prowType = JsonConvert.DeserializeObject<List<Typelist>>(listtypeopen);
                        var prowTarget = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetopen);
                        var prowPlatform = JsonConvert.DeserializeObject<List<Construct>>(listplatformopen);


                        bool istype = false;
                        bool isTarget = false;

                        var listtype = new List<Typelist>();
                        var listtarget = new List<List<Targetlist>>();
                        var list = new List<string?>();

                        var indextTarget = new List<string>();

                        foreach (var targetindex in prowTarget)
                        {
                            indextTarget.Add(targetindex.TargetSpisok);
                        }

                        int count = 0;
                        int counttype = 0;

                        foreach (var jsonlist in prowPlatform)
                        {
                            list.Add(jsonlist.Id);
                            list.Add(jsonlist.Platform);
                            listtype.Add(jsonlist.Type);
                            listtarget.Add(jsonlist.Target);

                            Console.Write(
                                $"id: {jsonlist.Id} platform: {jsonlist.Platform} type:{jsonlist.Type.TypeSpisok} ");
                            foreach (var targetConsole in jsonlist.Target)
                            {
                                Console.WriteLine($"target: {targetConsole.TargetSpisok}");
                            }
                        }

                        Console.Write("выбирите свободную ячейку: ");
                        var id = Console.ReadLine();
                        if (!list.Contains(id))
                        {
                            Console.Write("выбирите PLatform: ");
                            var platforminput = Console.ReadLine();
                            if (!list.Contains(platforminput))
                            {
                                foreach (var scanType in prowType)
                                {
                                    Console.WriteLine($"{++counttype} {scanType.TypeSpisok}");
                                }

                                Console.Write("выбирите type: ");
                                string? typeinput = Console.ReadLine();
                                var indexType = Convert.ToInt32(typeinput);

                                if (indexType < 1 || indexType < prowType.Count)
                                {
                                    Console.WriteLine("чел ты даун");
                                }

                                var newObjType = prowType[indexType - 1];

                                var typelist = new Typelist(newObjType.TypeSpisok);
                                typelist.TypeSpisok = newObjType.TypeSpisok;
                                foreach (var variableTargetlist in prowTarget)
                                {
                                    Console.WriteLine($"{++count} {variableTargetlist.TargetSpisok}");
                                }

                                foreach (var scanTarget in prowTarget)
                                {
                                    Console.Write("сколько вы хотите добавить target: ");
                                    var targetAddFile = Convert.ToInt32(Console.ReadLine());
                                    if (scanTarget.TargetSpisok.Length >= targetAddFile)
                                    {
                                        Console.WriteLine($"выбирите Target должно быть {targetAddFile}: ");
                                        List<Targetlist> targetlist = new List<Targetlist>();
                                        for (int i = 0; i < targetAddFile; i++)
                                        {
                                            Console.Write("напишите цифру target: ");
                                            var inputtarget = Console.ReadLine();
                                            var index = Convert.ToInt32(inputtarget);

                                            if (index < 1 || index > prowTarget.Count)
                                            {
                                                Console.WriteLine("чел, ты даун");
                                                break;
                                            }

                                            var newObj = prowTarget[index - 1];

                                            if (targetlist.Contains(newObj))
                                            {
                                                Console.WriteLine("уже занят");
                                            }

                                            else
                                            {
                                                targetlist.Add(newObj);
                                            }
                                        }

                                        if (true)
                                        {
                                            using (StreamWriter streamWriter =
                                                   new StreamWriter(pathplatformopen, false))
                                            {
                                                Construct construct =
                                                    new Construct(id, platforminput, typelist, targetlist);

                                                prowPlatform.Add(construct);

                                                var json = JsonSerializer.Serialize(prowPlatform);

                                                streamWriter.WriteLine(json);
                                                Console.WriteLine("файл сохранен");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("такого нет");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("столько нет");
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine($"{platforminput} занят");
                            }
                        }

                        else
                        {
                            Console.WriteLine($"{id} занят");
                        }
                    }
                    catch
                        (Exception e)
                    {
                        Console.WriteLine("ошибка в json" + e);
                    }

                    break;
                case "3":
                    try
                    {
                        string path = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                        var listdes = JsonConvert.DeserializeObject<List<Construct>>(path);

                        foreach (var listfor in listdes)
                        {
                            Console.Write(
                                $"id: {listfor.Id} platform: {listfor.Platform} type: {listfor.Type.TypeSpisok}");
                            foreach (var jsonTarget in listfor.Target)
                            {
                                Console.WriteLine(
                                    $"target: {jsonTarget.TargetSpisok}");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("файл пуст" + e);
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