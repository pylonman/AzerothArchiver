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

			var lines = File.ReadAllLines(configFile);		// read and parse file

			foreach (var line in lines)
			{
				if (line.StartsWith(directoryToken))
				{
					string result = line.Replace(directoryToken, string.Empty).TrimEnd('\\');
					try
					{
						GameDirectory = new NonEmptyString(result);
					}
					catch (Exception)
					{ 
						throw new ArgumentException($"The Warcraft directory argument from the config file is empty.");
					}
				}
			}

			if (!gameDirectoryIsValid())
			{
				throw new ArgumentException($"The Warcraft directory from the config file is not valid:  {GameDirectory}");
			}
		}

		/// <summary>
		/// Get directory from user
		/// </summary>
		/// <param name="gameDirectoryFromUser"></param>
		public UserConfig(NonEmptyString gameDirectoryFromUser)
		{
			GameDirectory = gameDirectoryFromUser;
			
			if (!gameDirectoryIsValid())
			{
				throw new ArgumentException($"The Warcraft directory parameter is not valid:  {GameDirectory}");
			}
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
				if (!Directory.Exists(Globals.UserDirectory))
				{
					Directory.CreateDirectory(Globals.UserDirectory);
				}
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
		private static string configFile { get; } = Path.Combine($"{Globals.UserDirectory}", fileName);

		/// <summary>
		/// Checks that the GameDirectory is a valid World of Wardcraft location
		/// </summary>
		/// <returns></returns>
		private bool gameDirectoryIsValid()
		{
			if (Directory.Exists(GameDirectory) && GameDirectory.value.EndsWith("World of Warcraft"))
			{
				return true;
			}

			return false;
		}
	}
}