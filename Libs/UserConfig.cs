namespace Libs
{
	/// <summary>
	/// Gets the World of Warcraft install directory and saves the configuration
	/// </summary>
	public class UserConfig
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

			GameDirectory = getDirectory() ?? throw new ArgumentNullException(GameDirectory, "The Warcraft directory value from the config file is null");

			if (!gameDirectoryIsValid())
			{
				throw new ArgumentException($"The Warcraft directory argument from the config file is not valid:  {GameDirectory}");
			}
		}

		/// <summary>
		/// Get directory from user
		/// </summary>
		/// <param name="gameDirectoryFromUser"></param>
		public UserConfig(string gameDirectoryFromUser)
		{
			if (gameDirectoryFromUser == null)
			{
				throw new ArgumentNullException(gameDirectoryFromUser, $"The Warcraft directory parameter is null");
			}

			GameDirectory = gameDirectoryFromUser.TrimEnd('\\');

			if (!gameDirectoryIsValid())
			{
				throw new ArgumentException($"The Warcraft directory parameter is not valid:  {GameDirectory}");
			}
		}

		/// <summary>
		/// Save GameDirectory to the config file
		/// </summary>
		public void UpdateFile()
		{
			string[] contents =
			{
				$"{directoryToken}{GameDirectory}{Environment.NewLine}",
			};

			try
			{
				if (!Directory.Exists(UserDirectory))
				{
					Directory.CreateDirectory(UserDirectory);
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
		public string GameDirectory { get; }

		private const string fileName = "config.ini";
		private const string directoryToken = "WarcraftDirectory=";
		private static readonly string UserDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AzerothArchiver");
		private static string configFile { get; } = Path.Combine($"{UserDirectory}", fileName);

		/// <summary>
		/// Checks that the GameDirectory is a valid World of Wardcraft location
		/// </summary>
		/// <returns></returns>
		private bool gameDirectoryIsValid()
		{
			if (Directory.Exists(GameDirectory) && GameDirectory.EndsWith("World of Warcraft"))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets the GameDirectory from the config file
		/// </summary>
		/// <returns></returns>
		private static string getDirectory()
		{
			var contents = File.ReadAllLines(configFile);

			foreach (var line in contents)
			{
				if (line.StartsWith(directoryToken))
				{
					string result = line.Replace(directoryToken, string.Empty);
					return result.TrimEnd('\\');
				}
				else
				{
					continue;
				}
			}

			return string.Empty;
		}
	}
}