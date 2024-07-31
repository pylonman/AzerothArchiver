using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	/// <summary>
	/// Stores the game client type and its associated directory
	/// </summary>
	public record class Client
	{
		public Client(NonEmptyString name)
		{
			Name = name;

			if (!nameToDirectory.ContainsKey(Name))
			{
				throw new ArgumentException($"Unsupported client [{Name}], found.");
			}
			DirectoryName = nameToDirectory[Name];
		}
		public static implicit operator string(Client value) => value.Name;

		/// <summary>
		/// The name of the client directory associated with the client type
		/// </summary>
		public NonEmptyString DirectoryName { get; init; }
		public NonEmptyString Name { get; init; }

		/// <summary>
		/// Associates the client name found in the .build.info file with the client directory name
		/// </summary>
		private static readonly Dictionary<string, NonEmptyString> nameToDirectory = new()
		{
			["wow"] = new NonEmptyString("_retail_"),                   // retail
			["wowt"] = new NonEmptyString("_ptr_"),                     // retail ptr
			["wow_beta"] = new NonEmptyString("_beta_"),                // beta
			["wow_classic_era"] = new NonEmptyString("_classic_era_"),  // classic vanilla
			["wow_classic"] = new NonEmptyString("_classic_")           // classic Wrath
		};
	}
}
