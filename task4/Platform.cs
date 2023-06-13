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
                    Console.Write("выбирите режим 1 добавить 2 удалить: ");
                    var inputReadTarget = Console.ReadLine();
                    switch (inputReadTarget)
                    {
                        case "1":
                            try
                            {
                                string pathplatfor = @"C:\Users\edgar\Desktop\students.json";
                                string pathtarget = @"C:\Users\edgar\Desktop\Data.json";
                                string listplatfor = (File.ReadAllText(pathplatfor));
                                string listtargetraname = (File.ReadAllText(pathtarget));
                                var targetJson = JsonConvert.DeserializeObject<List<Targets>>(listtargetraname);
                                var prowPlatformrename = JsonConvert.DeserializeObject<List<Plafrorms>>(listplatfor);

                                int count = 0;
                                int countTarget = 0;

                                var listplatformtemp = new List<string>();

                                foreach (var jsonPlatformRead in prowPlatformrename)
                                {
                                    foreach (var jsonListAdd in jsonPlatformRead.Target)
                                    {
                                        listplatformtemp.Add(jsonListAdd.TittleTarget);
                                    }
                                }

                                foreach (var spisokTargetlist in prowPlatformrename)
                                {
                                    Console.WriteLine($"в базе данных есть id {spisokTargetlist.Id}");
                                    count++;
                                }


                                Console.Write(
                                    $"выбирите id к которому хотите добавить еще таргет: ");
                                string? inputPlatform = Console.ReadLine();
                                foreach (var listNumberTarget in targetJson)
                                {
                                    Console.WriteLine(
                                        $"\nу вас есть таргеты в базе данных {++countTarget} {listNumberTarget.TittleTarget}");
                                }

                                List<Targets> _targetlists = new List<Targets>();
                                Console.Write("сколько таргетов вы хотите добавить: ");
                                int addTarget = Convert.ToInt32(Console.ReadLine());
                                if (countTarget >= addTarget)
                                {
                                    for (int i = 0; i < addTarget; i++)
                                    {
                                        Console.Write(
                                            $"вы у строки {inputPlatform} какой target вы хотите ему добавить: ");
                                        var renamePlatform = Console.ReadLine();
                                        int indexAddTrget = Convert.ToInt32(renamePlatform);
                                        if (indexAddTrget < 1 && indexAddTrget > prowPlatformrename.Count)
                                        {
                                            Console.WriteLine("не верный ответ");
                                        }

                                        var newObgTargetAdd = targetJson[indexAddTrget - 1];

                                        if (_targetlists.Contains(newObgTargetAdd))
                                        {
                                            Console.WriteLine("занято повторять нельзя");
                                            Console.ReadKey();
                                            Console.Clear();
                                            var Platform = new Platform();
                                            Console.WriteLine(Platform.Platformtext());
                                        }

                                        // if (listplatform.Contains(newObgTargetAdd.TargetSpisok))
                                        // {
                                        //     Console.WriteLine("уже используется");
                                        //     break;
                                        // }


                                        _targetlists.Add(newObgTargetAdd);
                                    }

                                    foreach (var variableConstruct in prowPlatformrename)
                                    {
                                        if (variableConstruct.Id == inputPlatform)
                                        {
                                            foreach (var listString in _targetlists)
                                            {
                                                if (listString.TittleTarget != inputPlatform)
                                                {
                                                    variableConstruct.Target.Add(listString);
                                                }

                                                else
                                                {
                                                    Console.WriteLine("уже испульзуется");
                                                }
                                            }
                                        }
                                    }

                                    string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                    using (StreamWriter streamWriter =
                                           new StreamWriter(pathrename, false))
                                    {
                                        var jsonPlatfrom = JsonSerializer.Serialize(prowPlatformrename);
                                        streamWriter.WriteLine(jsonPlatfrom);
                                        Console.WriteLine("файил записан");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("столько нет");
                                }

                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("не верный формат");
                            }

                            break;
                        case "2":
                            try
                            {
                                string pathplatfor = @"C:\Users\edgar\Desktop\students.json";
                                string pathtarget = @"C:\Users\edgar\Desktop\Data.json";
                                string listplatfor = (File.ReadAllText(pathplatfor));
                                string listtargetraname = (File.ReadAllText(pathtarget));
                                var targetJson = JsonConvert.DeserializeObject<List<Targets>>(listtargetraname);
                                var prowPlatformrename = JsonConvert.DeserializeObject<List<Plafrorms>>(listplatfor);

                                int count = 0;
                                int countTarget = 0;

                                var listplatformtemp = new List<string>();

                                foreach (var jsonPlatformRead in prowPlatformrename)
                                {
                                    foreach (var jsonListAdd in jsonPlatformRead.Target)
                                    {
                                        listplatformtemp.Add(jsonListAdd.TittleTarget);
                                    }
                                }

                                foreach (var spisokTargetlist in prowPlatformrename)
                                {
                                    Console.WriteLine($"в базе данных есть id {spisokTargetlist.Id}");
                                    count++;
                                }


                                Console.Write(
                                    $"выбирите id к которому хотите добавить еще таргет: ");
                                string? inputPlatform = Console.ReadLine();
                                foreach (var listNumberTarget in targetJson)
                                {
                                    Console.WriteLine(
                                        $"\nу вас есть таргеты в базе данных {++countTarget} {listNumberTarget.TittleTarget}");
                                }

                                List<Targets> _targetlists = new List<Targets>();
                                Console.Write("сколько таргетов вы хотите удалить: ");
                                int addTarget = Convert.ToInt32(Console.ReadLine());
                                if (countTarget >= addTarget)
                                {
                                    for (int i = 0; i < addTarget; i++)
                                    {
                                        Console.Write(
                                            $"вы у строки {inputPlatform} какой target вы хотите ему удалить: ");
                                        var renamePlatform = Console.ReadLine();
                                        int indexAddTrget = Convert.ToInt32(renamePlatform);
                                        if (indexAddTrget < 1 && indexAddTrget > prowPlatformrename.Count)
                                        {
                                            Console.WriteLine("не верный ответ");
                                        }

                                        var newObgTargetAdd = targetJson[indexAddTrget - 1];

                                        if (_targetlists.Contains(newObgTargetAdd))
                                        {
                                            Console.WriteLine("занято повторять нельзя");
                                            Console.ReadKey();
                                            Console.Clear();
                                            var Platform = new Platform();
                                            Console.WriteLine(Platform.Platformtext());
                                        }

                                        _targetlists.Add(newObgTargetAdd);
                                    }

                                    foreach (var variableConstruct in prowPlatformrename)
                                    {
                                        if (variableConstruct.Id == inputPlatform)
                                        {
                                            foreach (var listString in _targetlists)
                                            {
                                                if (variableConstruct.Target.Count != 1)
                                                {
                                                    variableConstruct.Target.Remove(listString);
                                                }

                                                else
                                                {
                                                    Console.WriteLine("у вас один таргет нельзя");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    var Platform = new Platform();
                                                    Console.WriteLine(Platform.Platformtext());
                                                }
                                            }
                                        }
                                    }

                                    string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                    using (StreamWriter streamWriter =
                                           new StreamWriter(pathrename, false))
                                    {
                                        var jsonPlatfrom = JsonSerializer.Serialize(prowPlatformrename);
                                        streamWriter.WriteLine(jsonPlatfrom);
                                        Console.WriteLine("файил записан");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("столько нет");
                                }

                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("не верный формат");
                            }

                            break;
                        default:
                            Console.WriteLine("такого ответа нет");
                            break;
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

                        var prowType = JsonConvert.DeserializeObject<List<Types>>(listtypeopen);
                        var prowTarget = JsonConvert.DeserializeObject<List<Targets>>(listtargetopen);
                        var prowPlatform = JsonConvert.DeserializeObject<List<Plafrorms>>(listplatformopen);


                        bool istype = false;
                        bool isTarget = false;

                        var listtype = new List<Types>();
                        var listtarget = new List<List<Targets>>();
                        var list = new List<string?>();

                        var indextTarget = new List<string>();

                        foreach (var targetindex in prowTarget)
                        {
                            indextTarget.Add(targetindex.TittleTarget);
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
                                $"id: {jsonlist.Id} platform: {jsonlist.Platform} type:{jsonlist.Type.TittleType} ");
                            foreach (var targetConsole in jsonlist.Target)
                            {
                                Console.WriteLine($"target: {targetConsole.TittleTarget}");
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
                                    Console.WriteLine($"{++counttype} {scanType.TittleType}");
                                }

                                Console.Write("выбирите type: ");
                                string? typeinput = Console.ReadLine();
                                var indexType = Convert.ToInt32(typeinput);

                                if (indexType < 1 || indexType < prowType.Count)
                                {
                                    Console.WriteLine("чел ты даун");
                                }

                                var newObjType = prowType[indexType - 1];

                                var typelist = new Types(newObjType.TittleType);
                                typelist.TittleType = newObjType.TittleType;
                                foreach (var variableTargetlist in prowTarget)
                                {
                                    Console.WriteLine($"{++count} {variableTargetlist.TittleTarget}");
                                }

                                foreach (var scanTarget in prowTarget)
                                {
                                    Console.Write("сколько вы хотите добавить target: ");
                                    var targetAddFile = Convert.ToInt32(Console.ReadLine());
                                    if (scanTarget.TittleTarget.Length >= targetAddFile)
                                    {
                                        Console.WriteLine($"выбирите Target должно быть {targetAddFile}: ");
                                        List<Targets> targetlist = new List<Targets>();
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
                                                Plafrorms plafrorms =
                                                    new Plafrorms(id, platforminput, typelist, targetlist);

                                                prowPlatform.Add(plafrorms);

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
                        Console.WriteLine("не верный формат");
                    }

                    break;
                case "3":
                    try
                    {
                        string path = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                        var listdes = JsonConvert.DeserializeObject<List<Plafrorms>>(path);

                        foreach (var listfor in listdes)
                        {
                            Console.Write(
                                $"id: {listfor.Id} platform: {listfor.Platform} type: {listfor.Type.TittleType}");
                            foreach (var jsonTarget in listfor.Target)
                            {
                                Console.WriteLine(
                                    $"target: {jsonTarget.TittleTarget}");
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