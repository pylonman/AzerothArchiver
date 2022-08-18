using Libs;

namespace WinForm
{
	public partial class Form1 : Form
	{
		private string ConfigFileDirectory = string.Empty;
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			buttonStart.Enabled = false;
			labelStatus.Text = string.Empty;

			UserConfig config;

			try
			{
				config = new UserConfig(textBoxGameDirectory.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				buttonStart.Enabled = true;
				return;
			}

			List<Client> clients;

			try
			{
				clients = Client.GetList(config.GameDirectory);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex.Message}{Environment.NewLine}" +
								$"{config.GameDirectory}{Environment.NewLine}{Environment.NewLine}" +
								$"Make sure it is the root World of Warcraft directory.{Environment.NewLine}" +
								$"Example:  C:\\World of Warcraft\\");
				textBoxGameDirectory.Text = string.Empty;
				buttonStart.Enabled = true;
				return;
			}

			labelStatus.Text = Archiver.Start(clients, config.GameDirectory);   // Archive clients, return and print status
			buttonStart.Enabled = true;
		}

		private void buttonFolderDialog_Click(object sender, EventArgs e)
		{
			var result = folderBrowserDialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				textBoxGameDirectory.Text = folderBrowserDialog.SelectedPath;
			}
		}

		/// <summary>
		/// Try to load a valid game directory from the config file for the user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			try         // put game directory in textbox if it is available
			{
				var config = new UserConfig();
				ConfigFileDirectory = config.GameDirectory;
				textBoxGameDirectory.Text = config.GameDirectory;
			}
			catch       // silently fail and let user enter game directory
			{
				return;
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (String.IsNullOrEmpty(ConfigFileDirectory))  // no valid game directory in the config file, check textbox try to write to config file
			{
				try
				{
					var config = new UserConfig(textBoxGameDirectory.Text);
					config.UpdateFile();
				}
				catch(Exception)	// no valid directory to save in the textbox, silently fail and let program close
				{
					return;
				}

			}
			else // valid config file game directory is present, check to see if the user has entered a new directory in the textbox, if so try to validate it with userconfig
			{
				if (ConfigFileDirectory != textBoxGameDirectory.Text)	// if user supplied a new game directory when a valid directory was present on load then validate/save this new input
				{
					try
					{
						var config = new UserConfig(textBoxGameDirectory.Text);
						config.UpdateFile();
					}
					catch(Exception)
					{
						return;     // no valid directory to save in the textbox, silently fail and let program close
					}
				}
			}
		}
	}
}