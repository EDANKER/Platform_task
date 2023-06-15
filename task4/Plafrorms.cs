namespace Task;

public class Plafrorms
{
    public string? Id { get; set; }
    public string? TittlePlatform { get; set; }
    public Types Type { get; set; }
    public List<Targets> Target { get; set; }
    public Plafrorms(string? id, string? tittlePlatform, Types type, List<Targets> target)
    {
        Id = id;
        TittlePlatform = tittlePlatform;
        Type = type;
        Target = target;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj == this)
            return true;

        var newObj = (Plafrorms)obj;
        
        return Target == newObj.Target;
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
