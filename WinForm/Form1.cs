using Libs;

namespace WinForm
{
	public partial class Form1 : Form
	{
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

		private void Form1_Load(object sender, EventArgs e)
		{
			try         // put game directory in textbox if it is available
			{
				var config = new UserConfig();
				textBoxGameDirectory.Text = config.GameDirectory;
			}
			catch       // silently fail and let user enter game directory
			{
				return;
			}
		}
	}
}