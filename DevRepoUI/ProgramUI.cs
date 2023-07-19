public class ProgramUI
{
    private DevRepo _devRepo;
    private DevTeamRepo _teamRepo;

    public ProgramUI(DevRepo devRepo, DevTeamRepo teamRepo)
    {
        _devRepo = devRepo;
        _teamRepo = teamRepo;
    }

    public void Run()
    {
        Menu();
    }

    private void Menu()
    {
        bool continueToRun = true;

        while (continueToRun)
        {

            Console.Clear();
            Console.WriteLine("Welcome, Select an Option:\n\n" +
                "1. Developer List\n" +
                "2. Developer Teams List\n" +
                "3. Add Developer to Team\n" +
                "4. Remove Developer from Team\n" +
                "5. Create New Team\n" +
                "0. Exit\n");

            Console.Write("Selection: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListAllDevs();
                    break;
                case "2":
                    ListAllTeams();
                    break;
                case "3":
                    AddDevToTeam();
                    break;
                case "4":
                    SoftRemoveDevFromTeam();
                    break;
                case "5":
                    CreateTeam();
                    break;
                case "0":
                    continueToRun = false;
                    Exit();
                    break;
                default:
                    break;
            }
        }
    }

    private void ListAllDevs()
    {
        Console.Clear();
        ListDevs();
        PauseAndContinue();
    }


    private void ListAllTeams()
    {
        Console.Clear();
        ListTeams();
        PauseAndContinue();
    }


    private void ListDevs()
    {
        foreach (Dev dev in _devRepo.GetAllDevs())
        {
            Console.WriteLine(dev);
            Console.WriteLine($"Needs PluralSight: {!dev.HasPluralSight}");
            Console.WriteLine($"Needs License: {!dev.HasLicense}");
            Console.WriteLine();
        }
    }

    private void ListTeams()
    {
        foreach (DevTeam team in _teamRepo.GetTeams())
        {
            Console.WriteLine($"{team.Id} - {team.Name}");
            foreach (Dev member in team.GetTeamMembers())
            {
                Console.WriteLine("    " + member);
            }
        }
    }

    private void AddDevToTeam()
    {
        Console.Clear();
        Console.WriteLine("Which Team Do You Want to Add to?");
        ListTeams();
        Console.Write("\nId: ");
        string teamChoice = Console.ReadLine();

        DevTeam team = _teamRepo.GetTeamById(Convert.ToInt32(teamChoice));
        if (team == null)
        {
            ShowError("Invalid Team ID");
            PauseAndContinue();
            return;
        }

        Console.WriteLine("Which Developers Would You Like to Add to the Team?");

        List<Dev> availableDevs = _devRepo.GetAllDevs()
            .Where(dev => !team.IsDevOnTeam(dev))
            .ToList();

        foreach (Dev dev in availableDevs)
        {
            Console.WriteLine(dev);
        }

        Console.Write("\nEnter IDs of Developers to Add to Team (separated by commas or spaces): ");
        string devIdsInput = Console.ReadLine();
        string[] devIdStrings = devIdsInput.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string devIdString in devIdStrings)
        {
            if (int.TryParse(devIdString, out int devId))
            {
                Dev developer = availableDevs.FirstOrDefault(dev => dev.Id == devId);
                if (developer != null)
                {
                    team.AddMember(developer);
                    Console.WriteLine($"Added {developer.Name} to Team.");
                }
                else
                {
                    Console.WriteLine($"Invalid Developer ID '{devIdString}' or Developer Already Added to Team.");
                }
            }
            else
            {
                Console.WriteLine($"Invalid Developer ID '{devIdString}'. Skipping...");
            }
        }

        PauseAndContinue();
    }
    private void SoftRemoveDevFromTeam()
    {
        Console.Clear();
        Console.WriteLine("Which Team Would You Like to Remove a Developer From?");
        ListTeams();
        Console.Write("\nId: ");
        string teamChoice = Console.ReadLine();

        DevTeam team = _teamRepo.GetTeamById(Convert.ToInt32(teamChoice));
        if (team == null)
        {
            ShowError("Invalid Team ID");
            PauseAndContinue();
            return;
        }

        Console.WriteLine("Which Developer Would You Like to Remove from this Team?");

        foreach (Dev dev in team.GetTeamMembers())
        {
            Console.WriteLine(dev);
        }

        Console.Write("\nId: ");
        string devChoice = Console.ReadLine();
        int devId = Convert.ToInt32(devChoice);
        Dev developer = team.GetTeamMembers().FirstOrDefault(dev => dev.Id == devId);
        if (developer == null)
        {
            ShowError("Invalid Developer ID");
            PauseAndContinue();
            return;
        }

        bool removed = team.RemoveMember(developer);
        if (removed)
        {
            Console.WriteLine("Developer Successfully Removed from Team");
        }
        else
        {
            Console.WriteLine("Failed to Remove Developer from Team");
        }

        PauseAndContinue();
    }

    private void CreateTeam()
    {
        Console.Clear();
        Console.WriteLine("Creating a New Team...");

        Console.Write("Enter New Team Name: ");
        string teamName = Console.ReadLine();

        List<Dev> allDevs = _devRepo.GetAllDevs();

        Console.WriteLine("Available Developers:");

        foreach (Dev dev in allDevs)
        {
            Console.WriteLine(dev);
        }

        Console.Write("Enter IDs of Developers to Add to Team (separated by commas or spaces): ");
        string devIdsInput = Console.ReadLine();
        string[] devIdStrings = devIdsInput.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<Dev> teamMembers = new List<Dev>();

        foreach (string devIdString in devIdStrings)
        {
            if (int.TryParse(devIdString, out int devId))
            {
                Dev selectedDev = allDevs.FirstOrDefault(dev => dev.Id == devId);
                if (selectedDev != null && !teamMembers.Contains(selectedDev))
                {
                    teamMembers.Add(selectedDev);
                    Console.WriteLine($"Added {selectedDev.Name} to Team.");
                }
                else
                {
                    Console.WriteLine($"Invalid Developer ID '{devIdString}' or Developer Already Added to Team.");
                }
            }
            else
            {
                Console.WriteLine($"Invalid Developer ID '{devIdString}'. Skipping...");
            }
        }

        DevTeam createdTeam = _teamRepo.AddTeam(teamName, teamMembers);

        if (createdTeam != null)
        {
            Console.WriteLine($"Team '{teamName}' Created Successfully!");
            Console.WriteLine($"Team '{teamName}' Added to Repository.");
        }
        else
        {
            Console.WriteLine("Failed to Create Team.");
        }

        PauseAndContinue();
    }

    private void Exit()
    {
        Console.Clear();
        Console.WriteLine("\n\n        Catch You on the Flippity Flop!\n\n");
        Thread.Sleep(2000);
    }

    private void PauseAndContinue()
    {
        System.Console.WriteLine("Press Any Key to Continue...");
        Console.ReadKey();
    }

    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"## Error: {message}");
        Console.ResetColor();
    }
}