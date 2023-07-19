DevRepo repo = new();
DevTeamRepo teamRepo = new();

repo.Seed();

teamRepo.Seed(repo);

Console.WriteLine("What");

ProgramUI ui = new(repo, teamRepo);
ui.Run();