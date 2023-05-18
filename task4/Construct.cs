namespace task4;

public class Construct
{
    public string? Id { get; set; }
    public string? Platform { get; }
    public string? Target { get; }
    public string? Type { get; }

    public Construct(string? id, string? platform, string? target, string? type)
    {
        Id = id;
        Platform = platform;
        Type = type;
        Target = target;
    }
}

public class Targetlist
{
    public string? Targetspisok { get; set; }

    public Targetlist(string target)
    {
        Targetspisok = target;
    }
}