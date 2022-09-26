using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs
{
	public static class Globals
	{
		public static readonly string UserDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AzerothArchiver");
	}
}
