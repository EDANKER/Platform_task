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
                    using (FileStream fileStream =
                           new FileStream(@"C:\Users\edgar\Desktop\objects.json", FileMode.OpenOrCreate))
                    {
                        List<Construct> listtype = new List<Construct>();

                        foreach (var list in listtype)
                        {
                            Console.Write("выбирите id строки какой хотите заменить: ");
                            list.Id = Console.ReadLine();
                            Console.Write($"Замените type у {list.Id}: ");
                            JsonSerializer.Serialize(fileStream, list.Id);
                            var type = Console.ReadLine();
                        }
                    }

                    break;
                case "2":
                    
                    try
                    {
                        string pathtargetlist = @"C:\Users\edgar\Desktop\Data.json";
                        using (FileStream fileStream = new FileStream(pathtargetlist, FileMode.OpenOrCreate))
                        {
                            Console.Write("какой таргет хотите добавить?: ");
                            var listtarget = Console.ReadLine();

                            if (listtarget.Length == 0)
                            {
                                Console.WriteLine("вы не чего не написали");
                            }

                            else
                            {
                                Targetlist targetlist = new Targetlist(listtarget);
                                List<Targetlist> list = new List<Targetlist>();
                                list.Add(targetlist);
                                JsonSerializer.Serialize(fileStream, list);
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
                            Console.WriteLine(jsontargetlist.Targetspisok);
                        }

                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("айил пуст");
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