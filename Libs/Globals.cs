using System.Diagnostics;
using static System.Environment;        // Used to shorten NewLine, GetFolderPath, SpecialFolder

namespace Shared
{
	public static class Globals
	{
		public static readonly string UserDirectory = Path.Combine(GetFolderPath(SpecialFolder.UserProfile), "AzerothArchiver");
		public static readonly string AboutMe = $"Azeroth Archiver is made by Felicene from Alleria{NewLine}" +
												$"Website:  https://github.com/pylonman/AzerothArchiver{NewLine}";
		public static string OpenBackupDirectory()
		{
			if (!Directory.Exists(Globals.UserDirectory))
			{
				return $"Failed to open backup directory:{NewLine}" +
					   $"\t{Globals.UserDirectory}{NewLine}" +
					   $"It does not exist.";
			}

			ProcessStartInfo startInfo = new ProcessStartInfo
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
