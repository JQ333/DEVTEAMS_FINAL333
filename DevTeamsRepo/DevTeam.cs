public class DevTeam
{
    private static int _count = 0;
    private readonly List<Dev> _members = new List<Dev>();
    public int Id { get; private set; }
    public string Name { get; set; } = "Yellow Team";

    public DevTeam()
    {
        Id = ++_count;
    }

    public List<Dev> GetTeamMembers()
    {
        return _members;
    }

    public bool AddMember(Dev dev)
    {
        if (dev == null) return false;

        _members.Add(dev);
        return true;
    }

    public bool RemoveMember(Dev dev)
    {
        return _members.Remove(dev);
    }

    public bool IsDevOnTeam(Dev dev)
    {
        return _members.Contains(dev);
    }
}

