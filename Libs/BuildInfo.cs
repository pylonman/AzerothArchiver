using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs
{
	/// <summary>
	/// Finds the installed game clients by reading the .build.info file
	/// </summary>
	public static class BuildInfo
	{
		/// <summary>
		/// Returns a list of game clients found in the .build.info file in the wowDirectory
		/// </summary>
		/// <param name="gameDirectory"></param>
		/// <returns></returns>
		public static List<string> ReadClientLines(string gameDirectory)
		{
			string file = Path.Combine(gameDirectory, fileName);

			if (!File.Exists(file))
			{
				throw new FileNotFoundException("Error:  No .build.info file was found in the World of Warcraft directory.");
			}

			List<string> fileContents;

			try
			{
				fileContents = File.ReadAllLines(file).ToList();
			}
			catch
			{
				throw new Exception("Error reading the .build.info file.");
			}

			if (fileContents.Count < 2)             // if there are less than 2 entries in the buildinfo file then there is no useful data available
			{
				throw new Exception("Error:  The .build.info file does not contain any valid game clients.");
			}

			fileContents.RemoveAt(0);               // remove the header from the .build.info file
			return fileContents;
		}

		private const string fileName = ".build.info";
	}
}
