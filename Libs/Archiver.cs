using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;        // Used to shorten NewLine, GetFolderPath, SpecialFolder

namespace Shared
{
	/// <summary>
	/// Takes a source and client directory, compresses the contents of the client and saves it to the destination folder
	/// </summary>
	sealed public class Archiver
	{
		private Archiver(NonEmptyString wowDirectory, Client client)
		{
			Source = wowDirectory;

			Destination = new NonEmptyString(Path.Combine(backupDirectory, programName, client.DirectoryName));
			if (!Directory.Exists(Destination))
			{
				Directory.CreateDirectory(Destination);
			}

			// create filename based on the date
			var dt = DateTime.Now;
			var fileName = new NonEmptyString(dt.ToString("MM-dd-yyyy") + ".zip");

			// Combine destination path with the filename
			DestinationFile = new NonEmptyString(Path.Combine(Destination, fileName));
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

		public NonEmptyString Source { get; init; }
		public NonEmptyString Destination { get; init; }
		public NonEmptyString DestinationFile { get; init; }

		private readonly string backupDirectory = GetFolderPath(SpecialFolder.UserProfile);
		private const string programName = "AzerothArchiver";

		/// <summary>
		/// Archives clients and returns the status of the operation
		/// </summary>
		/// <param name="clients"></param>
		/// <param name="warcraftDirectory"></param>
		/// <returns></returns>
		public static string Start(List<Client> clients, string warcraftDirectory)
		{
			var status = new StringBuilder($"*** Begin Backup Operation ***{NewLine}");

			foreach (var client in clients)
			{
				var configDirectory = new NonEmptyString(Path.Combine(warcraftDirectory, client.DirectoryName, "WTF"));


				if (!Directory.Exists(configDirectory))
				{
					status.AppendLine("Error:  The path to the configuration folder does not exist, a backup cannot be made.");
					continue;
				}

				var ar = new Archiver(configDirectory, client);

				status.AppendLine(	$"Backing up:   {ar.Source.value}{NewLine}" +
									$"To:           {ar.DestinationFile.value}");

				try
				{
					ar.Compress();
					status.AppendLine(	$"Completed Archiving client: {client.DirectoryName.Value}");
				}
				catch (Exception ex)
				{
					status.AppendLine(	$"Failed to backup client: {client.DirectoryName.Value}{NewLine}" +
										$"Reason:  {ex.Message}");
				}
			}

			status.AppendLine("*** End of Backup Operation ***");
			return status.ToString();
		}
		/// <summary>
		/// Spawn an exploer process to the directory where the game files are backed up
		/// </summary>
		/// <returns></returns>
		public static string OpenBackupDirectory()
		{
			if (!Directory.Exists(Globals.UserDirectory))
			{
				return $"Failed to open backup directory:{NewLine}" +
					   $"\t{Globals.UserDirectory}{NewLine}" +
					   $"It does not exist.";
			}

			ProcessStartInfo startInfo = new()
			{
				Arguments = Globals.UserDirectory, FileName = "explorer.exe"
			};

			try
			{
				Process.Start(startInfo);
			}
			catch (Exception ex)
			{
				return $"Failed to open explorer, reason:{NewLine}" +
					   $"\t{ex.Message}";
			}

			return string.Empty;
		}
	}
}
