public class DevTeamRepo
{
    private readonly List<DevTeam> _teams = new List<DevTeam>();

    public DevTeamRepo() { }

    public DevTeamRepo(List<DevTeam> teams)
    {
        _teams = teams;
    }

    public void Seed(DevRepo devRepo)
    {
        string teamName = "Dundie All-Stars";
        AddTeam(teamName);
        DevTeam team = GetTeamByName(teamName);
        team.AddMember(devRepo.GetDev(1));
        team.AddMember(devRepo.GetDev(2));

        string otherTeamName = "Best Friends";
        AddTeam(otherTeamName);
        DevTeam otherTeam = GetTeamByName(otherTeamName);
        otherTeam.AddMember(devRepo.GetDev(3));
        otherTeam.AddMember(devRepo.GetDev(4));

        string newTeamName = "Old Man & the Kid";
        AddTeam(newTeamName);
        DevTeam newTeam = GetTeamByName(newTeamName);
        newTeam.AddMember(devRepo.GetDev(5));
        newTeam.AddMember(devRepo.GetDev(6));

        string anotherTeamName = "Cats & Sandals";
        AddTeam(anotherTeamName);
        DevTeam otherTeam2 = GetTeamByName(anotherTeamName);
        otherTeam2.AddMember(devRepo.GetDev(7));
        otherTeam2.AddMember(devRepo.GetDev(8));

        string additionalTeamName = "Michael's Weirdos";
        AddTeam(additionalTeamName);
        DevTeam otherTeam3 = GetTeamByName(additionalTeamName);
        otherTeam3.AddMember(devRepo.GetDev(9));
        otherTeam3.AddMember(devRepo.GetDev(10));

        string awesomeTeamName = "Text Buddies";
        AddTeam(awesomeTeamName);
        DevTeam otherTeam4 = GetTeamByName(awesomeTeamName);
        otherTeam4.AddMember(devRepo.GetDev(11));
        otherTeam4.AddMember(devRepo.GetDev(12));
    }

    public List<DevTeam> GetTeams()
    {
        return _teams;
    }

    public DevTeam GetTeamByName(string name)
    {
        return _teams.FirstOrDefault(t => t.Name == name);
    }

    public DevTeam GetTeamById(int id)
    {
        return _teams.FirstOrDefault(t => t.Id == id);
    }

    public DevTeam AddTeam(string name)
    {
        if (string.IsNullOrEmpty(name)) return null;

        DevTeam team = new DevTeam();
        team.Name = name;

        _teams.Add(team);
        return team;
    }

    public DevTeam AddTeam(string name, List<Dev> members)
    {
        if (string.IsNullOrEmpty(name)) return null;

        DevTeam team = new DevTeam();
        team.Name = name;

        foreach (Dev dev in members)
        {
            team.AddMember(dev);
        }

        _teams.Add(team);
        return team;
    }




}
