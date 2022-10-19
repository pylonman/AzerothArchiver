using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	/// <summary>
	/// Takes a source and client directory, compresses the contents of the client and saves it to the destination folder
	/// </summary>
	sealed public class Archiver
	{
		private Archiver(string wowDirectory, string clientDirectory)
		{
			Source = wowDirectory;

			Destination = Path.Combine(backupDirectory, programName, clientDirectory);
			if (!Directory.Exists(Destination))
			{
				Directory.CreateDirectory(Destination);
			}

			// create filename based on the date
			var dt = DateTime.Now;
			string fileName = dt.ToString("MM-dd-yyyy") + ".zip";

			// Combine destination path with the filename
			DestinationFile = Path.Combine(Destination, fileName);
		}

		/// <summary>
		/// Perform data compression copy the zip file to the user folder
		/// </summary>
		private void Compress()
		{
			if (File.Exists(DestinationFile))
			{
				File.Delete(DestinationFile);
			}
			ZipFile.CreateFromDirectory(Source, DestinationFile);
		}

		public string Source { get; }
		public string Destination { get; }
		public string DestinationFile { get; }

		private readonly string backupDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		private const string programName = "AzerothArchiver";

		/// <summary>
		/// Archives clients and returns the status of the operation
		/// </summary>
		/// <param name="clients"></param>
		/// <param name="warcraftDirectory"></param>
		/// <returns></returns>
		public static string Start(List<Client> clients, string warcraftDirectory)
		{
			var status = new StringBuilder($"*** Begin Backup Operation ***{Environment.NewLine}");

			foreach (var client in clients)
			{
				string configDirectory = Path.Combine(warcraftDirectory, client.DirectoryName, "WTF");


				if (!Directory.Exists(configDirectory))
				{
					status.AppendLine("Error:  The path to the configuration folder does not exist, a backup cannot be made.");
					continue;
				}

				var ar = new Archiver(configDirectory, client.DirectoryName);

				status.AppendLine($"Backing up:   {ar.Source}{Environment.NewLine}" +
									$"To:           {ar.DestinationFile}");

				try
				{
					ar.Compress();
					status.AppendLine($"Completed Archiving client: {client.DirectoryName}");
				}
				catch (Exception ex)
				{
					status.AppendLine($"Failed to backup client: {client.DirectoryName}{Environment.NewLine}" +
										$"Reason:  {ex.Message}");
				}
			}

			status.AppendLine("*** End of Backup Operation ***");
			return status.ToString();
		}
	}
}
