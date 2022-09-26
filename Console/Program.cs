using Libs;
using static System.Environment;			// Used to shorten Environment.NewLine and Environment.GetCommandLineArgs

bool closeOnCompletion = false;
bool configUpdateNeeded = false;

foreach (var arg in GetCommandLineArgs())
{
	if (arg == "quiet" || arg == "-q")                  // When finished close immediately
	{
		closeOnCompletion = true;
	}
}

UserConfig? config = null;

try
{
	config = new UserConfig();          // Get configuration from config file
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

while(config == null)                   // On failure get config from user
{
	string input = GetDirectoryFromUser();

	try
	{
		config = new UserConfig(input);
		configUpdateNeeded = true;
		Console.WriteLine("Verified World of Warcraft directory");
	}
	catch(Exception ex)
	{
		Console.WriteLine($"Invalid path.  {ex.Message}");
	}
}

var clients = Client.GetList(config.GameDirectory);

Console.WriteLine(Archiver.Start(clients, config.GameDirectory));   // Archive clients, print status

if (configUpdateNeeded)
{
	try
	{
		config.UpdateFile();
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Failed to save config file, reason:  {ex.Message}{NewLine}");
	}
}

if (!closeOnCompletion)
{
	Console.WriteLine("Press any key to quit");
	Console.ReadKey();
}

static string GetDirectoryFromUser()
{
	Console.WriteLine($"Enter the location of your World of Warcraft folder." +
					$"{NewLine}" +
					$"\tExample:  C:\\World of Warcraft\\" +
					$"{NewLine}");

	var input = Console.ReadLine();
	Console.WriteLine();

	input ??= String.Empty;

	return input;
}