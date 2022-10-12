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
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.labelDirectory = new System.Windows.Forms.Label();
			this.buttonShowBackups = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonAboutMe = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.BackColor = System.Drawing.Color.Gainsboro;
			this.labelStatus.Font = new System.Drawing.Font("Source Code Pro", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.labelStatus.Location = new System.Drawing.Point(50, 153);
			this.labelStatus.MaximumSize = new System.Drawing.Size(950, 250);
			this.labelStatus.MinimumSize = new System.Drawing.Size(950, 250);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(950, 250);
			this.labelStatus.TabIndex = 0;
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(455, 88);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(118, 38);
			this.buttonStart.TabIndex = 2;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// labelDirectory
			// 
			this.labelDirectory.AutoSize = true;
			this.labelDirectory.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.labelDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelDirectory.Location = new System.Drawing.Point(118, 29);
			this.labelDirectory.MaximumSize = new System.Drawing.Size(831, 33);
			this.labelDirectory.MinimumSize = new System.Drawing.Size(831, 33);
			this.labelDirectory.Name = "labelDirectory";
			this.labelDirectory.Size = new System.Drawing.Size(831, 33);
			this.labelDirectory.TabIndex = 4;
			this.labelDirectory.Click += new System.EventHandler(this.labelDirectory_Click);
			// 
			// buttonShowBackups
			// 
			this.buttonShowBackups.Location = new System.Drawing.Point(398, 420);
			this.buttonShowBackups.Name = "buttonShowBackups";
			this.buttonShowBackups.Size = new System.Drawing.Size(255, 38);
			this.buttonShowBackups.TabIndex = 5;
			this.buttonShowBackups.Text = "Open Backup Directory";
			this.buttonShowBackups.UseVisualStyleBackColor = true;
			this.buttonShowBackups.Click += new System.EventHandler(this.buttonShowBackups_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(50, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 21);
			this.label1.TabIndex = 6;
			this.label1.Text = "Log";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(118, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 21);
			this.label2.TabIndex = 7;
			this.label2.Text = "Warcraft folder";
			// 
			// buttonAboutMe
			// 
			this.buttonAboutMe.Location = new System.Drawing.Point(894, 420);
			this.buttonAboutMe.Name = "buttonAboutMe";
			this.buttonAboutMe.Size = new System.Drawing.Size(106, 38);
			this.buttonAboutMe.TabIndex = 8;
			this.buttonAboutMe.Text = "About Me";
			this.buttonAboutMe.UseVisualStyleBackColor = true;
			this.buttonAboutMe.Click += new System.EventHandler(this.buttonAboutMe_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(1051, 475);
			this.Controls.Add(this.buttonAboutMe);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonShowBackups);
			this.Controls.Add(this.labelDirectory);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.labelStatus);
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Azeroth Archiver";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelStatus;
		private Button buttonStart;
		private FolderBrowserDialog folderBrowserDialog;
		private Label labelDirectory;
		private Button buttonShowBackups;
		private Label label1;
		private Label label2;
		private Button buttonAboutMe;
	}
}