using System.Linq;
namespace Shared
{
	/// <summary>
	/// Gets the World of Warcraft install directory and saves the configuration
	/// </summary>
	sealed public class UserConfig
	{
		/// <summary>
		/// Get directory from the config file
		/// </summary>
		public UserConfig()
		{
			if (!File.Exists(configFile))
			{
				throw new FileNotFoundException("The config file does not exist, input required from the user.");
			}

			var lines = File.ReadAllLines(configFile);

			var directoryLine = File.ReadLines(configFile).FirstOrDefault(line => line.StartsWith(directoryToken)) ??
				throw new InvalidOperationException("Config file does not contain a valid directory entry.");

			var directory = directoryLine.Replace(directoryToken, "").TrimEnd('\\');
			GameDirectory = new NonEmptyString(directory);
			ValidateGameDirectory();
		}

		/// <summary>
		/// Get directory from user
		/// </summary>
		/// <param name="gameDirectoryFromUser"></param>
		public UserConfig(NonEmptyString gameDirectoryFromUser)
		{
			GameDirectory = gameDirectoryFromUser;
			ValidateGameDirectory();

			try
			{
				UpdateFile();
			}
			catch (IOException)
			{
				// silently fail on saving config for now
			}
		}

		/// <summary>
		/// Save GameDirectory to the config file
		/// </summary>
		public void UpdateFile()
		{
			string[] contents =
			{
				$"{directoryToken}{GameDirectory.value}{Environment.NewLine}",
			};

			try
			{
				Directory.CreateDirectory(Globals.UserDirectory);
				File.WriteAllLines(configFile, contents);
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// World of Warcraft install location
		/// </summary>
		public NonEmptyString GameDirectory { get; init; }

		private const string fileName = "config.ini";
		private const string directoryToken = "WarcraftDirectory=";
		private static string configFile => Path.Combine(Globals.UserDirectory, fileName);

		private bool IsValidGameDirectory() => Directory.Exists(GameDirectory) && GameDirectory.value.EndsWith("World of Warcraft");

		private void ValidateGameDirectory()
		{
			if (!IsValidGameDirectory())
			{
				throw new ArgumentException($"The Warcraft directory is not valid: {GameDirectory}");
			}
		}
	}
}