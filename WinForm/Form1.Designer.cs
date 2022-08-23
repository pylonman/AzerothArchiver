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
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(1051, 428);
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
	}
}