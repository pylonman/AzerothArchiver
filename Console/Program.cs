using Libs;

bool closeOnCompletion = false;

foreach (var arg in Environment.GetCommandLineArgs())
{
	if (arg == "quiet" || arg == "-q")                  // When finished close immediately
	{
		closeOnCompletion = true;
	}
}

UserConfig config;                                      // Get configuration from config file

try
{
	config = new UserConfig();
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	string warcraftDirectory = GetDirectoryFromUser();
	config = new UserConfig(warcraftDirectory);         // On failure get config from user
	config.UpdateFile();
	Console.WriteLine("Updated Config file.");
}

var clients = Client.GetList(config.GameDirectory);

Console.WriteLine(Archiver.Start(clients, config.GameDirectory));   // Archive clients, return and print status

if (!closeOnCompletion)
{
	Console.WriteLine("Press any key to quit");
	Console.ReadKey();
}

static string GetDirectoryFromUser()
{
	var path = queryDirectory();

	while (!pathIsValid(path))
	{
		Console.WriteLine($"{Environment.NewLine}" +
							$"**Invalid path**" +
							$"{Environment.NewLine}");
		path = queryDirectory();
	}

	return path;
}

static string queryDirectory()
{
	Console.WriteLine($"Enter the location of the WoW folder." +
						$"{Environment.NewLine}" +
						$"\tExample:  C:\\Program Files (x86)\\World of Warcraft\\" +
						$"{Environment.NewLine}");

	var input = Console.ReadLine();
	Console.WriteLine();
	if (input == null)
	{
		input = String.Empty;
	}

	return input;
}

static bool pathIsValid(string input)
{
	if (Directory.Exists(input) && input.Contains("World of Warcraft"))
	{
		return true;
	}

	return false;
}