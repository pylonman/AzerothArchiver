using Shared;
using System.Diagnostics;
using static System.Environment;		// Used to shorten Environment.NewLine

namespace WinForm
{
	public partial class Form1 : Form
	{
		UserConfig? Config;
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Try to load a valid game directory from the config file for the user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			try         // put game directory in label if it is available
			{
				Config = new UserConfig();
				labelDirectory.Text = Config.GameDirectory;
				labelDirectory.BackColor = Color.LightGreen;
			}
			catch
			{
				labelDirectory.BackColor = Color.Red;
				return;
			}
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			buttonStart.Enabled = false;
			labelStatus.Text = string.Empty;


			if (Config is null)
			{
				MessageBox.Show("No valid World of Warcraft directory entered.");
				buttonStart.Enabled = true;
				return;
			}

			List<Client> clients;

			try
			{
				clients = BuildInfoParser.GetClients(Config);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred while attempting to parse the .build.info file from :" +
								$"{Config.GameDirectory.value}{NewLine}{NewLine}" +
								$"{ex.Message}{NewLine}");
				Config = null;
				labelDirectory.BackColor = Color.Red;
				buttonStart.Enabled = true;
				return;
			}

			labelStatus.Text = Archiver.Start(clients, Config.GameDirectory);   // Archive clients, return and print status
			buttonStart.Enabled = true;
		}

		private void labelDirectory_Click(object sender, EventArgs e)
		{
			var result = folderBrowserDialog.ShowDialog();

			if (result != DialogResult.OK)
			{
				return;
			}

			try
			{
				NonEmptyString path = new(folderBrowserDialog.SelectedPath);
				Config = new UserConfig(path);
				labelDirectory.BackColor = Color.LightGreen;
				labelDirectory.Text = Config.GameDirectory;
			}
			catch (Exception)
			{
				Config = null;
				labelDirectory.Text = folderBrowserDialog.SelectedPath;
				labelDirectory.BackColor = Color.Red;
			}
		}

		/// <summary>
		/// Save config if a valid one is available
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Config is null) return;

			try
			{
				Config.UpdateFile();
			}
			catch(Exception)		// Silently fail and let form close
			{
				return;
			}
		}

		private void buttonShowBackups_Click(object sender, EventArgs e)
		{
			string status = Globals.OpenBackupDirectory();

			if (!string.IsNullOrEmpty(status))
			{
				MessageBox.Show(status);
			}
		}

		private void buttonAboutMe_Click(object sender, EventArgs e)
		{
			MessageBox.Show(Globals.AboutMe);
		}
	}
}