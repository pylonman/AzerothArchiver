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

			GameDirectory = getDirectory();

			if (String.IsNullOrEmpty(GameDirectory))
			{
				throw new ArgumentException("The Warcraft directory is not valid:  null or empty");
			}
			else if (!Directory.Exists(GameDirectory))
			{
				throw new DirectoryNotFoundException($"The Warcraft directory in the config file does not exist: {GameDirectory}");
			}
		}

		/// <summary>
		/// Get directory from user
		/// </summary>
		/// <param name="userInput"></param>
		public UserConfig(string userInput)
		{
			if (String.IsNullOrEmpty(userInput))
			{
				throw new ArgumentException("The Warcraft directory is not valid:  null or empty");
			}

			if (!Directory.Exists(userInput))
			{
				throw new DirectoryNotFoundException($"The Warcraft directory does not exist: {GameDirectory}");
			}

			this.GameDirectory = userInput;
		}
		/// <summary>
		/// World of Warcraft install location
		/// </summary>
		public string GameDirectory { get; }

		private const string fileName = "config.ini";
		private const string directoryToken = "WarcraftDirectory=";
		private static readonly string UserDirectory =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AzerothArchiver");
		private static string configFile { get; } = Path.Combine($"{UserDirectory}", fileName);


		/// <summary>
		/// Save config to file
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

		private static string getDirectory()
		{
			var contents = File.ReadAllLines(configFile);

			foreach (var line in contents)
			{
				if (line.StartsWith(directoryToken))
				{
					return line.Replace(directoryToken, string.Empty);
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