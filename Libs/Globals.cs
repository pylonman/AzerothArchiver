using System.Diagnostics;
using static System.Environment;        // Used to shorten NewLine, GetFolderPath, SpecialFolder

namespace Shared
{
	public static class Globals
	{
		public static readonly string UserDirectory = Path.Combine(GetFolderPath(SpecialFolder.UserProfile), "AzerothArchiver");
		public static readonly string AboutMe = $"Azeroth Archiver is made by Felicine from Alleria{NewLine}" +
												$"Website:  https://github.com/pylonman/AzerothArchiver{NewLine}";
		/// <summary>
		/// Spawn an exploer process to display the directory where the game files are backed up to
		/// </summary>
		/// <returns></returns>
		public static string OpenBackupDirectory()
		{
			if (!Directory.Exists(Globals.UserDirectory))
			{
				return $"Failed to open backup directory:{NewLine}" +
					   $"\t{Globals.UserDirectory}{NewLine}" +
					   $"It does not exist.";
			}

			ProcessStartInfo startInfo = new()
			{
				Arguments = Globals.UserDirectory,
				FileName = "explorer.exe"
			};

			try
			{
				Process.Start(startInfo);
			}
			catch (Exception ex)
			{
				return $"Failed to open explorer, reason:{NewLine}" +
					   $"\t{ex.Message}";
			}

			return string.Empty;
		}
	}
}
