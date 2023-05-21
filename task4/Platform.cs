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
                        string pathtypeopen = @"C:\Users\edgar\Desktop\objects.json";
                        string pathtargetraname = @"C:\Users\edgar\Desktop\students.json";
                        string listtargetraname = (File.ReadAllText(pathtargetraname));
                        string listtypeopen = (File.ReadAllText(pathtypeopen));
                        var read = JsonConvert.DeserializeObject<List<Construct>>(listtargetraname);
                        var prowType = JsonConvert.DeserializeObject<List<Typelist>>(listtypeopen);

                        var list = new List<string>();
                        var listtype = new List<string>();

                        foreach (var jsontype in prowType)
                        {
                            listtype.Add(jsontype.TypeSpisok);
                            Console.WriteLine($"ваш type список {jsontype.TypeSpisok}");
                        }

                        foreach (var jsontext in read)
                        {
                            list.Add(jsontext.Platform);
                            list.Add(jsontext.Id);
                            list.Add(jsontext.Type);
                            list.Add(jsontext.Target);
                            Console.WriteLine(
                                $"id: {jsontext.Id} platform: {jsontext.Platform} type: {jsontext.Type} target: {jsontext.Target} ");
                        }

                        Console.WriteLine("\nчто вы хотите\n удалить 1 изменить 2");
                        var inputPlatform = Console.ReadLine();

                        switch (inputPlatform)
                        {
                            case "1":
                                Console.Write("какой id вы хотите удалить: ");
                                var deletedid = Console.ReadLine();
                                Console.Write("какой platfrom вы хотите удалить: ");
                                var deletedForm = Console.ReadLine();
                                Console.Write("какой type вы хотите удалить: ");
                                var deletedtype = Console.ReadLine();
                                Console.Write("какой target вы хотите удалить: ");
                                var deletedtarget = Console.ReadLine();
                                
                                if (list.Contains(deletedForm))
                                {
                                    {
                                        string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                        using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                        {
                                            int indexplatform = list.IndexOf(deletedForm);
                                            read.RemoveAt(indexplatform);
                                            int indextype = list.IndexOf(deletedtype);
                                            read.RemoveAt(indextype);
                                            int indextarget = list.IndexOf(deletedtarget);
                                            read.RemoveAt(indextarget);
                                            int id = list.IndexOf(deletedid);
                                            read.RemoveAt(id);
                                            var json = JsonSerializer.Serialize(read);
                                            streamWriter.WriteLine(json);
                                            Console.WriteLine("файил записан");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("такого поля нет");
                                    break;
                                }

                                break;
                            case "2":
                                Console.Write("какой platfrom вы хотите изменить: ");
                                var platForm = Console.ReadLine();
                                if (list.Contains(platForm))
                                {
                                    Console.WriteLine($"вы у строки {platForm}");
                                    Console.Write($"на какую строку вы хотите заменить {platForm}: ");
                                    var renameinputplatfrom = Console.ReadLine();
                                    if (!list.Contains(renameinputplatfrom))
                                    {
                                        if (platForm.Length == 0)
                                        {
                                            Console.WriteLine("нельзя перезаписать на пустую строку");
                                        }

                                        else
                                        {
                                            string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                            using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                            {
                                                int index = list.IndexOf(platForm);
                                                read[index].Platform = renameinputplatfrom;
                                                var json = JsonSerializer.Serialize(read);
                                                streamWriter.WriteLine(json);
                                                Console.WriteLine("файил записан");
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

                                foreach (var plattype in read)
                                {
                                    listtype.Add(plattype.Type);
                                    Console.WriteLine(
                                        $"id: {plattype.Id} platform: {plattype.Platform} type: {plattype.Type} target: {plattype.Target} ");
                                }

                                Console.Write("какой type вы хотите изменить: ");
                                var type = Console.ReadLine();
                                if (listtype.Contains(type))
                                {
                                    Console.WriteLine($"вы у строки {type}");
                                    Console.Write($"на какую строку вы хотите заменить {type}: ");
                                    var renameinputtype = Console.ReadLine();

                                    if (listtype.Contains(renameinputtype))
                                    {
                                        string pathrename = @"C:\Users\edgar\Desktop\students.json";
                                        using (StreamWriter streamWriter = new StreamWriter(pathrename, false))
                                        {
                                            int index = listtype.IndexOf(type);
                                            read[index].Type = renameinputtype;
                                            var json = JsonSerializer.Serialize(read);
                                            streamWriter.WriteLine(json);
                                            Console.WriteLine("файил записан");
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("такого поля нет");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("такого нет");
                                    break;
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
                        string pathplatformopen = @"C:\Users\edgar\Desktop\students.json";
                        string pathtargeopen = @"C:\Users\edgar\Desktop\Data.json";
                        string pathtypeopen = @"C:\Users\edgar\Desktop\objects.json";
                        string listplatformopen = (File.ReadAllText(pathplatformopen));
                        string listtypeopen = (File.ReadAllText(pathtypeopen));
                        string listtargetopen = (File.ReadAllText(pathtargeopen));
                        var prowPlatform = JsonConvert.DeserializeObject<List<Construct>>(listplatformopen);
                        var prowType = JsonConvert.DeserializeObject<List<Typelist>>(listtypeopen);
                        var prowTarget = JsonConvert.DeserializeObject<List<Targetlist>>(listtargetopen);

                        bool istype = false;
                        bool isTarget = false;

                        var list = new List<string>();

                        foreach (var jsonlist in prowPlatform)
                        {
                            list.Add(jsonlist.Id);
                            list.Add(jsonlist.Platform);
                            list.Add(jsonlist.Type);
                            list.Add(jsonlist.Target);

                            Console.WriteLine(
                                $"id: {jsonlist.Id} platform: {jsonlist.Platform} type: {jsonlist.Type} target: {jsonlist.Target} ");
                        }

                        Console.Write("выбирите свободную ячейку: ");
                        var id = Console.ReadLine();
                        if (!list.Contains(id))
                        {
                            Console.Write("выбирите PLatform: ");
                            var platforminput = Console.ReadLine();
                            if (!list.Contains(platforminput))
                            {
                                Console.Write("выбирите type: ");
                                var typeinput = Console.ReadLine();
                                if (!list.Contains(typeinput))
                                {
                                    Console.Write("выбирите Target: ");
                                    var targetinput = Console.ReadLine();
                                    if (!list.Contains(targetinput))
                                    {
                                        if (typeinput.Length == 0 || targetinput.Length == 0 ||
                                            platforminput.Length == 0 ||
                                            id.Length == 0)
                                        {
                                            Console.WriteLine(
                                                "ваш type или target или platfom пуст или id \nпопробуйте снова нажми enter");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }

                                        else
                                        {
                                            foreach (var jsontarget in prowTarget)
                                            {
                                                if (jsontarget.TargetSpisok == targetinput)
                                                {
                                                    isTarget = true;
                                                }

                                                else
                                                {
                                                    Console.WriteLine(
                                                        "отказзано мы не нашли такое в нашей базе данных target");
                                                }
                                            }

                                            foreach (var jsontype in prowType)
                                            {
                                                if (jsontype.TypeSpisok == typeinput)
                                                {
                                                    istype = true;
                                                }

                                                else
                                                {
                                                    Console.WriteLine(
                                                        "отказзано мы не нашли такое в нашей базе данных type");
                                                }
                                            }

                                            if (istype && isTarget)
                                            {
                                                using (StreamWriter streamWriter =
                                                       new StreamWriter(pathplatformopen, false))
                                                {
                                                    Construct construct = new Construct(id, platforminput, targetinput,
                                                        typeinput);
                                                    prowPlatform.Add(construct);
                                                    var json = JsonSerializer.Serialize(prowPlatform);
                                                    streamWriter.WriteLine(json);
                                                    Console.WriteLine("файл сохранен");
                                                }
                                            }

                                            else
                                            {
                                                Console.WriteLine("увы вы дурак");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{targetinput} занят");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{typeinput} занят");
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
                        Console.WriteLine("ошибка в json");
                    }

                    break;
                case "3":
                    try
                    {
                        string path = (File.ReadAllText(@"C:\Users\edgar\Desktop\students.json"));
                        var listdes = JsonConvert.DeserializeObject<List<Construct>>(path);

                        foreach (var listfor in listdes)
                        {
                            Console.WriteLine(
                                $"id: {listfor.Id} platform: {listfor.Platform} type: {listfor.Type} target: {listfor.Target} ");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("файл пуст");
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