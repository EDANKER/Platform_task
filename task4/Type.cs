using Microsoft;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace task4;

public class Type
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
                        string pathtype = @"C:\Users\edgar\Desktop\objects.json";
                        string listtypename = (File.ReadAllText(pathtype));
                        string listPatform = (File.ReadAllText(pathPlatform));
                        var read = JsonConvert.DeserializeObject<List<Types>>(listtypename);
                        var readplatform = JsonConvert.DeserializeObject<List<Plafrorms>>(listPatform);

                        var listtemp = new List<string>();
                        var listPlatformtemp = new List<string>();
                        var listTypetemp = new List<string>();

                        foreach (var jsontext in read)
                        {
                            listtemp.Add(jsontext.TittleType);
                        }

                        foreach (var warningType in readplatform)
                        {
                            listTypetemp.Add(warningType.Type.TittleType);
                        }

                        foreach (var jsonScan in readplatform)
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
                                if (listtemp.Contains(deletedtype))
                                {
                                    if (!listTypetemp.Contains(deletedtype))
                                    {
                                        string pathrename = @"C:\Users\edgar\Desktop\objects.json";
                                        using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                        {
                                            int index = listtemp.IndexOf(deletedtype);
                                            read.RemoveAt(index);
                                            var json = JsonSerializer.Serialize(read);
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
                                foreach (var jsonPlaform in readplatform)
                                {
                                    listPlatformtemp.Add(jsonPlaform.Type.TittleType);

                                    Console.Write("какой type вы хотите изменить: ");
                                    var renametype = Console.ReadLine();
                                    if (listtemp.Contains(renametype) || listPlatformtemp.Contains(renametype))
                                    {
                                        Console.WriteLine($"вы у строки {renametype}");
                                        Console.Write($"на какую строку вы хотите заменить {renametype}: ");
                                        var renameinput = Console.ReadLine();
                                        if (!listtemp.Contains(renameinput) && !listPlatformtemp.Contains(renameinput))
                                        {
                                            if (renameinput.Length == 0)
                                            {
                                                Console.WriteLine("нельзя перезаписать на пустую строку");
                                            }

                                            else
                                            {
                                                string pathPlatformrename = @"C:\Users\edgar\Desktop\students.json";
                                                string pathrename = @"C:\Users\edgar\Desktop\objects.json";

                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathPlatformrename, false))
                                                {
                                                    foreach (var jsonRanamePlatform in readplatform)
                                                    {
                                                        if (jsonRanamePlatform.Type.TittleType == renametype)
                                                        {
                                                            jsonRanamePlatform.Type.TittleType = renameinput;
                                                        }
                                                    }

                                                    var jsonPush = JsonSerializer.Serialize(readplatform);
                                                    streamWriter.WriteLine(jsonPush);
                                                    Console.WriteLine("файил записан");
                                                }

                                                using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                                {
                                                    int index = listtemp.IndexOf(renametype);
                                                    read[index].TittleType = renameinput;
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
                                }

                                break;


                                Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ваш json кривой");
                    }

                    Console.ReadKey();
                    break;
                case "2":
                    try
                    {
                        string path = @"C:\Users\edgar\Desktop\objects.json";
                        var typeread = (File.ReadAllText(path));
                        var typeJsons = JsonConvert.DeserializeObject<List<Types>>(typeread);

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
                                using (StreamWriter streamWriter = new StreamWriter(path, false))
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
                        Console.WriteLine("файи пуст");
                    }

                    Console.ReadKey();
                    break;
                case "3":
                    string pathtargeopen = @"C:\Users\edgar\Desktop\objects.json";
                    string listtargetopen = (File.ReadAllText(pathtargeopen));
                    var readrarget = JsonConvert.DeserializeObject<List<Types>>(listtargetopen);
                    try
                    {
                        foreach (var jsontargetlist in readrarget)
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
                    Console.WriteLine(programm.tasknumber());
                    break;
                default:
                    Console.WriteLine("не верный выриант");
                    break;
            }
        }
    }
}