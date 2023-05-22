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
                        string pathtargetraname = @"C:\Users\edgar\Desktop\objects.json";
                        string listtargetraname = (File.ReadAllText(pathtargetraname));
                        var read = JsonConvert.DeserializeObject<List<Typelist>>(listtargetraname);

                        var list = new List<string>();

                        foreach (var jsontext in read)
                        {
                            list.Add(jsontext.TypeSpisok);
                            Console.WriteLine($"у вас есть таргеты {jsontext.TypeSpisok}");
                        }

                        Console.WriteLine("\nчто вы хотите\n удалить 1 изменить 2");
                        var inputtype = Console.ReadLine();

                        switch (inputtype)
                        {
                            case "1":
                                Console.Write("какой target вы хотите изменить: ");
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
                                Console.Write("какой target вы хотите изменить: ");
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

                        Console.Write("какой тип хотите добавить?: ");
                        var listtyperead = Console.ReadLine();

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
                            Console.WriteLine(jsontargetlist.TypeSpisok);
                        }

                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("фаил пуст");
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