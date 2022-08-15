using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs
{
	/// <summary>
	/// Detects and stores the game client type and associated directory 
	/// </summary>
	public class Client
	{
		public Client(string buildInfoLine)
		{
			if (string.IsNullOrEmpty(buildInfoLine))
			{
				throw new ArgumentException($"The .build.info line argument was not valid");
			}

			DirectoryName = parseLine(buildInfoLine);

			if (string.IsNullOrEmpty(DirectoryName))
			{
				throw new ArgumentException($"Error:  No supported client found in the following .build.info line:\t{buildInfoLine}.");
			}

		}

		/// <summary>
		/// The name of the client directory associated with the client type
		/// </summary>
		public string DirectoryName { get; }

		/// <summary>
		/// Returns a list of clients detected from the directory parameter
		/// </summary>
		/// <param name="warcraftDirectory"></param>
		/// <returns></returns>
		public static List<Client> GetList(string warcraftDirectory)
		{
			var buildInfoContents = BuildInfo.ReadClientLines(warcraftDirectory);

			var clients = new List<Client>();

			foreach (var line in buildInfoContents)
			{
				try
				{
					clients.Add(new Client(line));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}

			return clients;
		}

		/// <summary>
		/// Convert a .build.info line into tokens, look for a valid client type and return the result
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private static string parseLine(string line)
		{
			string[] tokens = line.Split(separator);

			foreach (var token in tokens.Reverse())
			{
				if (typeToDirectory.TryGetValue(token, out var directoryMatch))
				{
					return directoryMatch;
				}
			}
			return String.Empty;
		}

		/// <summary>
		/// Associates the client type found in the .build.info file with the client directory name
		/// </summary>
		private static readonly Dictionary<string, string> typeToDirectory = new()
		{
			{ "wow",                "_retail_" },					// retail
			{ "wowt",               "_ptr_"},						// retail ptr
			{ "wow_classic_era",    "_classic_era_"},				// classic vanilla
			{ "wow_classic",        "_classic_"},					// classic TBC
		};

		private const char separator = '|';
	}
}
