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

List<Client> clients;
try
{
	clients = BuildInfoParser.GetClients(config);
}
catch (Exception ex)
{
	Console.WriteLine(ex.ToString());
	WaitForKeyPress();
	return;
}

var status = Archiver.Start(clients, config.GameDirectory);  // Archive clients, print status
Console.WriteLine(status);   

if (!closeOnCompletion)
{
	WaitForKeyPress();
}

UserConfig GetConfig()
{
	try
	{
		return new UserConfig();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
		return GetConfigFromUser();
	}
}

UserConfig GetConfigFromUser()
{
	while (true)
	{
		try
		{
			NonEmptyString input = QueryUser();
			return new UserConfig(input);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Invalid path. {ex.Message}");
		}
	}
}

static NonEmptyString QueryUser()
{
	Console.WriteLine("Enter the location of your World of Warcraft folder:");
	Console.WriteLine("\tExample: C:\\World of Warcraft\\");

	return new NonEmptyString(Console.ReadLine()?.Trim().TrimEnd('\\') ?? string.Empty);
}

void WaitForKeyPress()
{
	Console.WriteLine("Press 'e' to open the backup folder in explorer, press any other key to quit");
	var input = Console.ReadKey().KeyChar;

	if (input == 'e')
	{
		Archiver.OpenBackupDirectory();
	}
}