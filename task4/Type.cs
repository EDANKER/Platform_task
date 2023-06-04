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
                        string pathtype = @"C:\Users\edgar\Desktop\objects.json";
                        string listtypename = (File.ReadAllText(pathtype));
                        var read = JsonConvert.DeserializeObject<List<Typelist>>(listtypename);

                        var list = new List<string>();

                        foreach (var jsontext in read)
                        {
                            list.Add(jsontext.TypeSpisok);
                            Console.WriteLine($"у вас есть type {jsontext.TypeSpisok}");
                        }

                        Console.WriteLine("\nчто вы хотите\n удалить 1 изменить 2");
                        var inputtype = Console.ReadLine();

                        switch (inputtype)
                        {
                            case "1":
                                Console.Write("какой type вы хотите удалить: ");
                                var deletedtype = Console.ReadLine();
                                if (list.Contains(deletedtype))
                                {
                                    string pathrename = @"C:\Users\edgar\Desktop\objects.json";
                                    using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                    {
                                        int index = list.IndexOf(deletedtype);
                                        read.RemoveAt(index);
                                        var json = JsonSerializer.Serialize(read);
                                        streamWriter.WriteLine(json);
                                        Console.WriteLine("файил записан");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("такого поля нет");
                                }

                                break;
                            case "2":
                                Console.Write("какой type вы хотите изменить: ");
                                var renametype = Console.ReadLine();
                                if (list.Contains(renametype))
                                {
                                    Console.WriteLine($"вы у строки {renametype}");
                                    Console.Write($"на какую строку вы хотите заменить {renametype}: ");
                                    var renameinput = Console.ReadLine();
                                    if (!list.Contains(renameinput))
                                    {
                                        if (renametype.Length == 0)
                                        {
                                            Console.WriteLine("нельзя перезаписать на пустую строку");
                                        }

                                        else
                                        {
                                            string pathrename = @"C:\Users\edgar\Desktop\objects.json";
                                            using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                            {
                                                int index = list.IndexOf(renametype);
                                                read[index].TypeSpisok = renameinput;
                                                var json = JsonSerializer.Serialize(read);
                                                streamWriter.WriteLine(json);
                                                Console.WriteLine("файил записан");
                                            }
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("такое поле занято");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("такого поля нет");
                                }

                                break;
                        }

                        Console.ReadKey();
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
                        var read = JsonConvert.DeserializeObject<List<Typelist>>(typeread);

                        var typeList = new List<string>();
                        
                        foreach (var typeJson in read)
                        {
                            typeList.Add(typeJson.TypeSpisok);   
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
                                    Typelist typelist = new Typelist(listtyperead);
                                    read?.Add(typelist);
                                    var json = JsonSerializer.Serialize(read);
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
                    var readrarget = JsonConvert.DeserializeObject<List<Typelist>>(listtargetopen);
                    try
                    {
                        foreach (var jsontargetlist in readrarget)
                        {
                            if (jsontargetlist.TypeSpisok.Length == 0)
                            {
                                Console.WriteLine("нет нужных данных");
                            }

                            else
                            {
                                Console.WriteLine(jsontargetlist.TypeSpisok);
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
