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
                        string pathtargetraname = @"C:\Users\edgar\Desktop\Data.json";
                        string listtargetraname = (File.ReadAllText(pathtargetraname));
                        var read = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetraname);

                        var list = new List<string>();

                        foreach (var jsontext in read)
                        {
                            list.Add(jsontext.TargetSpisok);
                            Console.WriteLine($"у вас есть таргеты {jsontext.TargetSpisok}");
                        }
                        
                        Console.Write("какой target вы хотите изменить: ");
                        var renametarget = Console.ReadLine();
                        if (list.Contains(renametarget))
                        {
                            Console.WriteLine($"вы у строки {renametarget}");
                            Console.Write($"на какую строку вы хотите заменить {renametarget}: ");
                            var renameinput = Console.ReadLine();
                            if (!list.Contains(renameinput))
                            {
                                if (renametarget.Length == 0)
                                {
                                    Console.WriteLine("нельзя перезаписать на пустую строку");
                                }

                                else
                                {
                                    string pathrename = @"C:\Users\edgar\Desktop\Data.json";
                                    using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                    {
                                        int index = list.IndexOf(renametarget);
                                        read[index].TargetSpisok = renameinput;
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
                        string pathtargetlist = @"C:\Users\edgar\Desktop\Data.json";
                        var readlist = (File.ReadAllText(pathtargetlist));
                        var read = JsonConvert.DeserializeObject<List<Targetlist>>(readlist);
                        Console.Write("какой таргет хотите добавить?: ");
                        var listtarget = Console.ReadLine();

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
                            Console.WriteLine(jsontargetlist.TargetSpisok);
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