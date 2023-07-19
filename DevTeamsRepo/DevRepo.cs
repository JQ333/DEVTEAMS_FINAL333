public class DevRepo
{
    private readonly List<Dev> _devs = new List<Dev>();

    public List<Dev> GetAllDevs()
    {
        return _devs;
    }

    public Dev GetDev(int id)
    {
        foreach (Dev dev in _devs)
        {
            if (dev.Id == id) return dev;
        }
        return null;
    }

    public Dev GetDev(string email)
    {
        return _devs.FirstOrDefault(d => d.Email == email);
    }

    public bool AddDev(Dev dev)
    {
        if (string.IsNullOrEmpty(dev.Email))
            return false;

        _devs.Add(dev);
        return true;
    }

    public void Seed()
    {
        Dev dev = new Dev();
        dev.Email = "michael@Komodo.com";
        dev.Name = "Michael";
        dev.HasPluralSight = false;
        dev.HasLicense = false;
        _devs.Add(dev);

        Dev pam = new Dev();
        pam.Email = "pam@Komodo.com";
        pam.Name = "Pam";
        pam.HasPluralSight = true;
        pam.HasLicense = true;
        _devs.Add(pam);

        Dev dwight = new Dev();
        dwight.Email = "dwight@Komodo.com";
        dwight.Name = "Dwight";
        dwight.HasPluralSight = true;
        dwight.HasLicense = true;
        _devs.Add(dwight);

        Dev jim = new Dev();
        jim.Email = "jim@Komodo.com";
        jim.Name = "Jim";
        jim.HasPluralSight = true;
        jim.HasLicense = true;
        _devs.Add(jim);

        Dev ryan = new Dev();
        ryan.Email = "ryan@Komodo.com";
        ryan.Name = "Ryan";
        ryan.HasPluralSight = false;
        ryan.HasLicense = false;
        _devs.Add(ryan);

        Dev creed = new Dev();
        creed.Email = "creed@Komodo.com";
        creed.Name = "Creed";
        creed.HasPluralSight = false;
        creed.HasLicense = true;
        _devs.Add(creed);

        Dev angela = new Dev();
        angela.Email = "angela@Komodo.com";
        angela.Name = "Angela";
        angela.HasPluralSight = true;
        angela.HasLicense = false;
        _devs.Add(angela);

        Dev oscar = new Dev();
        oscar.Email = "oscar@Komodo.com";
        oscar.Name = "Oscar";
        oscar.HasPluralSight = true;
        oscar.HasLicense = true;
        _devs.Add(oscar);

        Dev toby = new Dev();
        toby.Email = "toby@Komodo.com";
        toby.Name = "Toby";
        toby.HasPluralSight = false;
        toby.HasLicense = true;
        _devs.Add(toby);

        Dev erin = new Dev();
        erin.Email = "erin@Komodo.com";
        erin.Name = "Erin";
        erin.HasPluralSight = false;
        erin.HasLicense = false;
        _devs.Add(erin);

        Dev andy = new Dev();
        andy.Email = "andy@Komodo.com";
        andy.Name = "Andy";
        andy.HasPluralSight = true;
        andy.HasLicense = false;
        _devs.Add(andy);

        Dev darrell = new Dev();
        darrell.Email = "darrell@Komodo.com";
        darrell.Name = "Darrell";
        darrell.HasPluralSight = false;
        darrell.HasLicense = true;
        _devs.Add(darrell);
    }
}