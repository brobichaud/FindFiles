namespace FindFiles
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.listFiles = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textPath = new System.Windows.Forms.TextBox();
			this.buttonFind = new System.Windows.Forms.Button();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.aviAnimator = new Animate.Animation.CGAnimation();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.buttonAttributes = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listFiles
			// 
			this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.listFiles.FormattingEnabled = true;
			this.listFiles.HorizontalScrollbar = true;
			this.listFiles.Location = new System.Drawing.Point(12, 73);
			this.listFiles.Name = "listFiles";
			this.listFiles.Size = new System.Drawing.Size(420, 212);
			this.listFiles.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Folder:";
			// 
			// textPath
			// 
			this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.textPath.Location = new System.Drawing.Point(55, 13);
			this.textPath.Name = "textPath";
			this.textPath.Size = new System.Drawing.Size(347, 20);
			this.textPath.TabIndex = 1;
			// 
			// buttonFind
			// 
			this.buttonFind.Location = new System.Drawing.Point(55, 44);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(69, 23);
			this.buttonFind.TabIndex = 4;
			this.buttonFind.Text = "&Find";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(126, 44);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(69, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// aviAnimator
			// 
			this.aviAnimator.AutoPlay = false;
			this.aviAnimator.AVIFileType = Animate.Animation.AVIFileType.Search4File;
			this.aviAnimator.Location = new System.Drawing.Point(20, 44);
			this.aviAnimator.Name = "aviAnimator";
			this.aviAnimator.Size = new System.Drawing.Size(23, 23);
			this.aviAnimator.TabIndex = 3;
			this.aviAnimator.TabStop = false;
			this.aviAnimator.Text = "dfsdf";
			this.aviAnimator.Visible = false;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(405, 12);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(27, 22);
			this.buttonBrowse.TabIndex = 2;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// buttonAttributes
			// 
			this.buttonAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAttributes.Location = new System.Drawing.Point(327, 44);
			this.buttonAttributes.Name = "buttonAttributes";
			this.buttonAttributes.Size = new System.Drawing.Size(75, 23);
			this.buttonAttributes.TabIndex = 7;
			this.buttonAttributes.Text = "Attributes...";
			this.buttonAttributes.UseVisualStyleBackColor = true;
			this.buttonAttributes.Click += new System.EventHandler(this.buttonAttributes_Click);
			// 
			// FormMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 304);
			this.Controls.Add(this.buttonAttributes);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.aviAnimator);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.textPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listFiles);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(350, 250);
			this.Name = "FormMain";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Find Files (not checked in)";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listFiles;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textPath;
		private System.Windows.Forms.Button buttonFind;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Button buttonCancel;
		private Animate.Animation.CGAnimation aviAnimator;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button buttonAttributes;
	}
}

