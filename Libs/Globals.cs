using System.Diagnostics;
using static System.Environment;        // Used to shorten NewLine, GetFolderPath, SpecialFolder

namespace Shared
{
	public static class Globals
	{
		public static readonly string UserDirectory = Path.Combine(GetFolderPath(SpecialFolder.UserProfile), "AzerothArchiver");
		public static readonly string AboutMe = $"Azeroth Archiver is made by Felicine from Alleria{NewLine}" +
												$"Website:  https://github.com/pylonman/AzerothArchiver{NewLine}";
	}
}
