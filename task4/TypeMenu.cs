using Microsoft;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Task;

public class TypeMenu
{
    public string Plat()
    {
        while (true)
        {
            Console.Write(
                "\nвы в редакторе Type\n\n выберите режим \n1: редактор \n2: добавление \n3: чтение \n4: назад: \nваш режим: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    try
                    {
                        string pathPlatform = @"C:\Users\edgar\Desktop\students.json";
                        string pathType = @"C:\Users\edgar\Desktop\objects.json";
                        string listType = (File.ReadAllText(pathType));
                        string listPatform = (File.ReadAllText(pathPlatform));
                        var readType = JsonConvert.DeserializeObject<List<Types>>(listType);
                        var readPlatform = JsonConvert.DeserializeObject<List<Plafrorms>>(listPatform);

                        var listTemp = new List<string>();
                        var listPlatformTemp = new List<string>();
                        var listTypeTemp = new List<string>();

                        foreach (var jsontext in readType)
                        {
                            listTemp.Add(jsontext.TittleType);
                        }

                        foreach (var warningType in readPlatform)
                        {
                            listTypeTemp.Add(warningType.Type.TittleType);
                        }

                        foreach (var jsonScan in readPlatform)
                        {
                            Console.WriteLine($"у вас в Platfomah есть type: {jsonScan.Type.TittleType}");
                        }

                        Console.WriteLine("\nчто вы хотите\n удалить 1 изменить 2");
                        var inputtype = Console.ReadLine();

                        switch (inputtype)
                        {
                            case "1":
                                Console.Write("какой type вы хотите удалить: ");
                                var deletedtype = Console.ReadLine();
                                if (listTemp.Contains(deletedtype))
                                {
                                    if (!listTypeTemp.Contains(deletedtype))
                                    {
                                        string pathrename = @"C:\Users\edgar\Desktop\objects.json";
                                        using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                        {
                                            int index = listTemp.IndexOf(deletedtype);
                                            readType.RemoveAt(index);
                                            var json = JsonSerializer.Serialize(readType);
                                            streamWriter.WriteLine(json);
                                            Console.WriteLine("файил записан");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("ельзя заменить уже используется");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("такого поля нет");
                                }

                                break;
                            case "2":
                                foreach (var jsonPlaform in readPlatform)
                                {
                                    listPlatformTemp.Add(jsonPlaform.Type.TittleType);

                                    Console.Write("какой type вы хотите изменить: ");
                                    var renametype = Console.ReadLine();
                                    if (listTemp.Contains(renametype) || listPlatformTemp.Contains(renametype))
                                    {
                                        Console.WriteLine($"вы у строки {renametype}");
                                        Console.Write($"на какую строку вы хотите заменить {renametype}: ");
                                        var renameinput = Console.ReadLine();
                                        if (!listTemp.Contains(renameinput) && !listPlatformTemp.Contains(renameinput))
                                        {
                                            if (renameinput.Length == 0)
                                            {
                                                Console.WriteLine("нельзя перезаписать на пустую строку");
                                            }
                                            else
                                            {
                                                string pathPlatformrename = @"C:\Users\edgar\Desktop\students.json";
                                                string pathPlatformrename1 = @"C:\Users\edgar\Desktop\students1.json";
                                                string pathrename = @"C:\Users\edgar\Desktop\objects.json";

                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathPlatformrename, false))
                                                {
                                                    foreach (var jsonRanamePlatform in readPlatform)
                                                    {
                                                        if (jsonRanamePlatform.Type.TittleType == renametype)
                                                        {
                                                            jsonRanamePlatform.Type.TittleType = renameinput;
                                                        }
                                                    }

                                                    var jsonPush = JsonSerializer.Serialize(readPlatform);
                                                    streamWriter.WriteLine(jsonPush);
                                                    Console.WriteLine("файил записан");
                                                }
                                                
                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathPlatformrename1, false))
                                                {
                                                    foreach (var jsonRanamePlatform in readPlatform)
                                                    {
                                                        if (jsonRanamePlatform.Type.TittleType == renametype)
                                                        {
                                                            jsonRanamePlatform.Type.TittleType = renameinput;
                                                        }
                                                    }

                                                    var jsonPush = JsonSerializer.Serialize(readPlatform);
                                                    streamWriter.WriteLine(jsonPush);
                                                }

                                                using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                                {
                                                    int index = listTemp.IndexOf(renametype);
                                                    readType[index].TittleType = renameinput;
                                                    var json = JsonSerializer.Serialize(readType);
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
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("не вернный формат");
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    try
                    {
                        string pathType = @"C:\Users\edgar\Desktop\objects.json";
                        var typeRead = (File.ReadAllText(pathType));
                        var typeJsons = JsonConvert.DeserializeObject<List<Types>>(typeRead);

                        var typeList = new List<string>();

                        foreach (var typeJson in typeJsons)
                        {
                            typeList.Add(typeJson.TittleType);
                        }

                        Console.Write("какой тип хотите добавить?: ");
                        var listtyperead = Console.ReadLine();

                        if (!typeList.Contains(listtyperead))
                        {
                            if (listtyperead.Length == 0)
                            {
                                Console.WriteLine("вы не чего не написали");
                            }
                            else
                            {
                                using (StreamWriter streamWriter = new StreamWriter(pathType, false))
                                {
                                    Types types = new Types(listtyperead);
                                    typeJsons?.Add(types);
                                    var json = JsonSerializer.Serialize(typeJsons);
                                    streamWriter.WriteLine(json);
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
                        Console.WriteLine("не верный формат");
                    }

                    Console.ReadKey();
                    break;
                case "3":
                    string pathTarget = @"C:\Users\edgar\Desktop\objects.json";
                    string readTarget = (File.ReadAllText(pathTarget));
                    var disType = JsonConvert.DeserializeObject<List<Types>>(readTarget);
                    try
                    {
                        foreach (var jsontargetlist in disType)
                        {
                            if (jsontargetlist.TittleType.Length == 0)
                            {
                                Console.WriteLine("нет нужных данных");
                            }
                            else
                            {
                                Console.WriteLine(jsontargetlist.TittleType);
                            }
                        }

                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("нужного типа нет");
                        Console.ReadKey();
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