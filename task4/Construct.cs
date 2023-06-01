namespace task4;

public class Construct
{
    public string? Id { get; set; }
    public string? Platform { get; set; }
    public Typelist Type { get; set; }
    public List<Targetlist> Target { get; set; }
    public Construct(string? id, string? platform, Typelist type, List<Targetlist> target)
    {
        Id = id;
        Platform = platform;
        Type = type;
        Target = target;
    }
    
}

public class Targetlist
{
    public string TargetSpisok { get; set; }

    public Targetlist(string targetSpisok)
    {
        TargetSpisok = targetSpisok;
    }
}

public class Typelist
{ 
    public string? TypeSpisok { get; set; }

    public Typelist(string? typeSpisok)
    {
        TypeSpisok = typeSpisok;
    }
    
}
