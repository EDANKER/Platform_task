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
                    using (FileStream fileStream =
                           new FileStream(@"C:\Users\edgar\Desktop\objects.json", FileMode.OpenOrCreate))
                    {
                        
                        
                    }

                    break;
                case "2":
                    try
                    {
                        string pathtargetlist = @"C:\Users\edgar\Desktop\objects.json";
                        using (FileStream fileStream = new FileStream(pathtargetlist, FileMode.OpenOrCreate))
                        {
                            Console.Write("какой тип хотите добавить?: ");
                            var listtyperead = Console.ReadLine();

                            if (listtyperead.Length == 0)
                            {
                                Console.WriteLine("вы не чего не написали");
                            }

                            else
                            {
                                Typelist typelist = new Typelist(listtyperead);
                                List<Typelist> listtype = new List<Typelist>();
                                listtype.Add(typelist);
                                JsonSerializer.Serialize(fileStream, listtype);
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