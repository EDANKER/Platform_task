namespace task4;

public class Plafrorms
{
    public string? Id { get; set; }
    public string? Platform { get; set; }
    public Types Type { get; set; }
    public List<Targets> Target { get; set; }
    public Plafrorms(string? id, string? platform, Types type, List<Targets> target)
    {
        Id = id;
        Platform = platform;
        Type = type;
        Target = target;
    }
    
}

public class Targets
{
    public string TittleTarget { get; set; }

    public Targets(string tittleTarget)
    {
        TittleTarget = tittleTarget;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj == this)
            return true;

        var newObj = (Targets)obj;
        
        return TittleTarget == newObj.TittleTarget;
    }
}

public class Types
{ 
    public string? TittleType { get; set; }

    public Types(string? tittleType)
    {
        TittleType = tittleType;
    }
    
}
