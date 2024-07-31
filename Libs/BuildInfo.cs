using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Environment;            // Used to shorten Environment.NewLine and Environment.GetCommandLineArgs

namespace Shared
{
	/// <summary>
	/// Finds the installed game clients by reading the .build.info file
	/// </summary>
	public static class BuildInfoParser
	{
		/// <summary>
		/// Returns all detected clients from the .build.info file
		/// </summary>
		/// <param name="config"></param>
		/// <returns></returns>
		/// <exception cref="FileNotFoundException"></exception>
		public static List<Client> GetClients(UserConfig config)
		{
			string filePath = Path.Combine(config.GameDirectory, fileName);
			
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException($"Error: .build.info file not found at {filePath}");
			}

			var clients = new List<Client>();

			var lines = File.ReadLines(filePath).Skip(1);               // skip the header
			foreach (var line in lines)                                 // each line contains data associated with the clients that are installed
			{
				string[] parts = line.Split('|');						// each element contains a '|' separator
				if (parts.Length > 0)
				{
					try
					{
						NonEmptyString clientName = new(parts[^1].Trim());  // store the last element of the .build.info line - the product(client) string
						clients.Add(new Client(clientName));
					}
					catch(Exception)		// Invalid or unsupported client detected on this line, silently fail for now
					{
						continue;
					}
				}
			}

			return clients;
		}

		private const string fileName = ".build.info";
	}
}