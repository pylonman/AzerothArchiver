using Shared;
using static System.Environment;            // Used to shorten Environment.NewLine and Environment.GetCommandLineArgs

Console.WriteLine(Globals.AboutMe);

bool closeOnCompletion = false;				// Leave app open when all operations have completed, otherwise let app close normally

foreach (var arg in GetCommandLineArgs())
{
	if (arg == "quiet" || arg == "-q")                  // When finished close immediately
	{
		closeOnCompletion = true;
	}
}

var config = GetConfig();

var clients = Client.GetList(config.GameDirectory);

string status = Archiver.Start(clients, config.GameDirectory);
Console.WriteLine(status);   // Archive clients, print status

if (!closeOnCompletion)
{
	WaitForKeyPress();
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

UserConfig GetConfig()
{
	UserConfig? config = null;
	bool configUpdateNeeded = false;

	try
	{
		config = new UserConfig();          // Get configuration from config file
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}

	while (config is null)                   // On failure get config from user
	{
		string input = GetDirectoryFromUser();

		try
		{
			config = new UserConfig(input);
			configUpdateNeeded = true;
			Console.WriteLine("Verified World of Warcraft directory");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Invalid path.  {ex.Message}");
		}
	}

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

	return config;
}

void WaitForKeyPress()
{
	Console.WriteLine("Press 'e' to open the backup folder in explorer, press any other key to quit");
	var input = Console.ReadKey().KeyChar;

	if (input == 'e')
	{
		Globals.OpenBackupDirectory();
	}
}