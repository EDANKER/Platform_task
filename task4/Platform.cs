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
                        string listtypefor = (File.ReadAllText(pathtarget));
                        string listtargetfor = (File.ReadAllText(pathtype));

                        var prowTyperename = JsonConvert.DeserializeObject<List<Typelist>>(listtypefor);
                        var prowTargetrename = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetfor);
                        var prowPlatformrename = JsonConvert.DeserializeObject<List<Construct>>(listplatfor);

                        var listplatform = new List<string>();
                        var listType = new List<string>();
                        var listTarget = new List<string>();

                        foreach (var jsonPlatformRead in prowPlatformrename)
                        {
                            listplatform.Add(jsonPlatformRead.Platform);
                        }


                        Console.Write("выбирите Platform который хотите изменить: ");
                        var inputPlatform = Console.ReadLine();
                        if (listplatform.Contains(inputPlatform))
                        {
                            Console.Write($"вы у строки {inputPlatform} на какой вы хотите изменить: ");
                            var renamePlatform = Console.ReadLine();
                            if (!listplatform.Contains(renamePlatform))
                            {
                                if (renamePlatform.Length == 0)
                                {
                                    Console.WriteLine("пусто");
                                }

                                else
                                {
                                    Console.Write("выбирите Type который хотите изменить: ");
                                    var inputType = Console.ReadLine();
                                    var inputTypeClaas = new Typelist(inputType);
                                    foreach (var jsonTyoeRead in prowTyperename)
                                    {
                                        if (jsonTyoeRead.TypeSpisok == inputTypeClaas.TypeSpisok)
                                        {
                                            Console.Write($"вы у строки {inputType} на какой вы хотите изменить: ");
                                            var renameType = Console.ReadLine();
                                            var renameTypeClass = new Typelist(renameType);
                                            if (!listType.Contains(renameType))
                                            {
                                                if (renamePlatform.Length == 0)
                                                {
                                                    Console.WriteLine("пусто");
                                                }
                                                else
                                                {
                                                    string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                                    using (StreamWriter streamWriter =
                                                           new StreamWriter(pathrename, false))
                                                    {
                                                        int indexPlatform = listplatform.IndexOf(inputPlatform);
                                                        int indexType = listplatform.IndexOf(inputType);

                                                        prowPlatformrename[indexPlatform].Platform = renamePlatform;
                                                        prowPlatformrename[indexType].Type = renameTypeClass;

                                                        var jsonPlatfrom = JsonSerializer.Serialize(prowPlatformrename);
                                                        streamWriter.WriteLine(jsonPlatfrom);
                                                        Console.WriteLine("файил записан");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("такого нет");
                                        }
                                    }
                                }
                            }


                            else
                            {
                                Console.WriteLine("такой Platfrom занят");
                            }
                        }

                        else
                        {
                            Console.WriteLine($"такого {inputPlatform} нет попробуйте еще");
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

                        foreach (var jsonlist in prowPlatform)
                        {
                            list.Add(jsonlist.Id);
                            list.Add(jsonlist.Platform);
                            listtype.Add(jsonlist.Type);
                            listtarget.Add(jsonlist.Target);

                            Console.WriteLine($"id: {jsonlist.Id} platform: {jsonlist.Platform}");
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
                                    Console.WriteLine(scanType.TypeSpisok);
                                }

                                Console.Write("выбирите type: ");
                                string? typeinput = Console.ReadLine();

                                var typelist = new Typelist(typeinput);
                                typelist.TypeSpisok = typeinput;
                                foreach (var variableTargetlist in prowTarget)
                                {
                                    Console.WriteLine(variableTargetlist.TargetSpisok);
                                }
                                foreach (var variableTargetnumber in prowTarget)
                                {
                                    Console.WriteLine(variableTargetnumber.TargetSpisok.Length);
                                }
                                foreach (var scanTarget in prowTarget)
                                {
                                    Console.Write("сколько вы хотите добавить target: ");
                                    var targetAddFile = Convert.ToInt32(Console.ReadLine());
                                    if (scanTarget.TargetSpisok.Length >= targetAddFile)
                                    {
                                        for (int i = 0; i < targetAddFile; i++)
                                        {
                                            Console.Write($"выбирите Target должно быть {targetAddFile}: ");
                                            targetAddFile = Console.ReadLine()[i];
                                            List<Targetlist> targetlist = new List<Targetlist>();

                                            targetlist.Add(new Targetlist(targetAddFile.ToString()));


                                            foreach (var jsontarget in prowTarget)
                                            {
                                                if (jsontarget.TargetSpisok == targetAddFile.ToString())
                                                {
                                                    isTarget = true;
                                                }
                                            }

                                            foreach (var jsontype in prowType)
                                            {
                                                if (jsontype.TypeSpisok == typeinput)
                                                {
                                                    istype = true;
                                                }
                                            }

                                            if (istype && isTarget)
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
                                                }
                                            }

                                            else
                                            {
                                                Console.WriteLine("такого нет");
                                            }
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
                                Console.Write(
                                    $"target: {jsonTarget.TargetSpisok} ");
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
