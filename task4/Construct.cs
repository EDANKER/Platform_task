using System.Collections;

namespace Microsoft;

public class Construct
{
    public string? _id { get; set; }
    public string _platform { get; set; }
    public string _target { get; set; }
    public string _type { get; set; }

    public Construct(string id, string platform, string targete, string type)
    {
        _id = id;
        _platform = platform;
        _type = type;
        _target = targete;
    }
}