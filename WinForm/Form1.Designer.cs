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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.labelStatus = new System.Windows.Forms.Label();
			this.textBoxGameDirectory = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonFolderDialog = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.BackColor = System.Drawing.Color.Gainsboro;
			this.labelStatus.Font = new System.Drawing.Font("Source Code Pro", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.labelStatus.Location = new System.Drawing.Point(69, 220);
			this.labelStatus.MaximumSize = new System.Drawing.Size(950, 250);
			this.labelStatus.MinimumSize = new System.Drawing.Size(950, 250);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(950, 250);
			this.labelStatus.TabIndex = 0;
			// 
			// textBoxGameDirectory
			// 
			this.textBoxGameDirectory.Location = new System.Drawing.Point(137, 96);
			this.textBoxGameDirectory.Name = "textBoxGameDirectory";
			this.textBoxGameDirectory.Size = new System.Drawing.Size(831, 33);
			this.textBoxGameDirectory.TabIndex = 1;
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(474, 158);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(118, 38);
			this.buttonStart.TabIndex = 2;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonFolderDialog
			// 
			this.buttonFolderDialog.Image = ((System.Drawing.Image)(resources.GetObject("buttonFolderDialog.Image")));
			this.buttonFolderDialog.Location = new System.Drawing.Point(98, 96);
			this.buttonFolderDialog.Name = "buttonFolderDialog";
			this.buttonFolderDialog.Size = new System.Drawing.Size(31, 32);
			this.buttonFolderDialog.TabIndex = 3;
			this.buttonFolderDialog.UseVisualStyleBackColor = true;
			this.buttonFolderDialog.Click += new System.EventHandler(this.buttonFolderDialog_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(1051, 494);
			this.Controls.Add(this.buttonFolderDialog);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.textBoxGameDirectory);
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
		private TextBox textBoxGameDirectory;
		private Button buttonStart;
		private Button buttonFolderDialog;
		private FolderBrowserDialog folderBrowserDialog;
	}
}