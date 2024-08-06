namespace WinForm
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			labelStatus = new Label();
			folderBrowserDialog = new FolderBrowserDialog();
			labelDirectory = new Label();
			buttonShowBackups = new Button();
			label1 = new Label();
			label2 = new Label();
			buttonAboutMe = new Button();
			buttonBackup = new Button();
			buttonRestore = new Button();
			SuspendLayout();
			// 
			// labelStatus
			// 
			labelStatus.AutoSize = true;
			labelStatus.BackColor = Color.Gainsboro;
			labelStatus.Font = new Font("Microsoft Sans Serif", 9.75F);
			labelStatus.Location = new Point(36, 153);
			labelStatus.MaximumSize = new Size(950, 250);
			labelStatus.MinimumSize = new Size(950, 250);
			labelStatus.Name = "labelStatus";
			labelStatus.Size = new Size(950, 250);
			labelStatus.TabIndex = 0;
			// 
			// labelDirectory
			// 
			labelDirectory.AutoSize = true;
			labelDirectory.BackColor = SystemColors.ControlLightLight;
			labelDirectory.BorderStyle = BorderStyle.Fixed3D;
			labelDirectory.Cursor = Cursors.Hand;
			labelDirectory.FlatStyle = FlatStyle.Flat;
			labelDirectory.Location = new Point(104, 29);
			labelDirectory.MaximumSize = new Size(831, 33);
			labelDirectory.MinimumSize = new Size(831, 33);
			labelDirectory.Name = "labelDirectory";
			labelDirectory.Size = new Size(831, 33);
			labelDirectory.TabIndex = 4;
			labelDirectory.Click += LabelDirectory_Click;
			// 
			// buttonShowBackups
			// 
			buttonShowBackups.Location = new Point(384, 421);
			buttonShowBackups.Name = "buttonShowBackups";
			buttonShowBackups.Size = new Size(255, 38);
			buttonShowBackups.TabIndex = 5;
			buttonShowBackups.Text = "Open Backup Directory";
			buttonShowBackups.UseVisualStyleBackColor = true;
			buttonShowBackups.Click += ButtonShowBackups_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(40, 128);
			label1.Name = "label1";
			label1.Size = new Size(36, 21);
			label1.TabIndex = 6;
			label1.Text = "Log";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(107, 4);
			label2.Name = "label2";
			label2.Size = new Size(114, 21);
			label2.TabIndex = 7;
			label2.Text = "Warcraft folder";
			// 
			// buttonAboutMe
			// 
			buttonAboutMe.Location = new Point(880, 421);
			buttonAboutMe.Name = "buttonAboutMe";
			buttonAboutMe.Size = new Size(106, 38);
			buttonAboutMe.TabIndex = 8;
			buttonAboutMe.Text = "About Me";
			buttonAboutMe.UseVisualStyleBackColor = true;
			buttonAboutMe.Click += ButtonAboutMe_Click;
			// 
			// buttonBackup
			// 
			buttonBackup.Location = new Point(452, 88);
			buttonBackup.Name = "buttonBackup";
			buttonBackup.Size = new Size(118, 38);
			buttonBackup.TabIndex = 2;
			buttonBackup.Text = "Backup";
			buttonBackup.UseVisualStyleBackColor = true;
			buttonBackup.Click += ButtonBackup_Click;
			// 
			// buttonRestore
			// 
			buttonRestore.Location = new Point(868, 88);
			buttonRestore.Name = "buttonRestore";
			buttonRestore.Size = new Size(118, 38);
			buttonRestore.TabIndex = 9;
			buttonRestore.Text = "Restore";
			buttonRestore.UseVisualStyleBackColor = true;
			buttonRestore.Click += ButtonRestore_Click;
			// 
			// Form1
			// 
			ClientSize = new Size(1023, 471);
			Controls.Add(buttonRestore);
			Controls.Add(buttonAboutMe);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(buttonShowBackups);
			Controls.Add(labelDirectory);
			Controls.Add(buttonBackup);
			Controls.Add(labelStatus);
			Font = new Font("Segoe UI", 14.25F);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "Form1";
			Text = "Azeroth Archiver";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelStatus;
		private FolderBrowserDialog folderBrowserDialog;
		private Label labelDirectory;
		private Button buttonShowBackups;
		private Label label1;
		private Label label2;
		private Button buttonAboutMe;
		private Button buttonBackup;
		private Button buttonRestore;
	}
}