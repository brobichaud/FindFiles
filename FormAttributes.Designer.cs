namespace FindFiles
{
	partial class FormAttributes
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
			this.checkListInclude = new System.Windows.Forms.CheckedListBox();
			this.checkListExclude = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.linkClearInc = new System.Windows.Forms.LinkLabel();
			this.linkCheckInc = new System.Windows.Forms.LinkLabel();
			this.linkClearEx = new System.Windows.Forms.LinkLabel();
			this.linkCheckEx = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// checkListInclude
			// 
			this.checkListInclude.CheckOnClick = true;
			this.checkListInclude.FormattingEnabled = true;
			this.checkListInclude.Items.AddRange(new object[] {
            "Archive",
            "Compressed",
            "Device",
            "Directory",
            "Encrypted",
            "Hidden",
            "Normal",
            "NotContentIndexed",
            "Offline",
            "ReadOnly",
            "ReparsePoint",
            "SparseFile",
            "System",
            "Temporary"});
			this.checkListInclude.Location = new System.Drawing.Point(12, 67);
			this.checkListInclude.Name = "checkListInclude";
			this.checkListInclude.Size = new System.Drawing.Size(135, 154);
			this.checkListInclude.TabIndex = 0;
			// 
			// checkListExclude
			// 
			this.checkListExclude.CheckOnClick = true;
			this.checkListExclude.FormattingEnabled = true;
			this.checkListExclude.Items.AddRange(new object[] {
            "Archive",
            "Compressed",
            "Device",
            "Directory",
            "Encrypted",
            "Hidden",
            "Normal",
            "NotContentIndexed",
            "Offline",
            "ReadOnly",
            "ReparsePoint",
            "SparseFile",
            "System",
            "Temporary"});
			this.checkListExclude.Location = new System.Drawing.Point(166, 67);
			this.checkListExclude.Name = "checkListExclude";
			this.checkListExclude.Size = new System.Drawing.Size(135, 154);
			this.checkListExclude.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Attributes to &Include:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(165, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Attributes to &Exclude:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(375, 39);
			this.label3.TabIndex = 2;
			this.label3.Text = "Select the attributes to find by. Included attributes will match files that have " +
				 "those attributes set. Excluded match files that do not have that attribute set.";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(312, 67);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(312, 93);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// linkClearInc
			// 
			this.linkClearInc.AutoSize = true;
			this.linkClearInc.Location = new System.Drawing.Point(86, 224);
			this.linkClearInc.Name = "linkClearInc";
			this.linkClearInc.Size = new System.Drawing.Size(45, 13);
			this.linkClearInc.TabIndex = 5;
			this.linkClearInc.TabStop = true;
			this.linkClearInc.Text = "Clear All";
			this.linkClearInc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearInc_LinkClicked);
			// 
			// linkCheckInc
			// 
			this.linkCheckInc.AutoSize = true;
			this.linkCheckInc.Location = new System.Drawing.Point(28, 224);
			this.linkCheckInc.Name = "linkCheckInc";
			this.linkCheckInc.Size = new System.Drawing.Size(52, 13);
			this.linkCheckInc.TabIndex = 5;
			this.linkCheckInc.TabStop = true;
			this.linkCheckInc.Text = "Check All";
			this.linkCheckInc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCheckInc_LinkClicked);
			// 
			// linkClearEx
			// 
			this.linkClearEx.AutoSize = true;
			this.linkClearEx.Location = new System.Drawing.Point(239, 224);
			this.linkClearEx.Name = "linkClearEx";
			this.linkClearEx.Size = new System.Drawing.Size(45, 13);
			this.linkClearEx.TabIndex = 5;
			this.linkClearEx.TabStop = true;
			this.linkClearEx.Text = "Clear All";
			this.linkClearEx.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearEx_LinkClicked);
			// 
			// linkCheckEx
			// 
			this.linkCheckEx.AutoSize = true;
			this.linkCheckEx.Location = new System.Drawing.Point(181, 224);
			this.linkCheckEx.Name = "linkCheckEx";
			this.linkCheckEx.Size = new System.Drawing.Size(52, 13);
			this.linkCheckEx.TabIndex = 5;
			this.linkCheckEx.TabStop = true;
			this.linkCheckEx.Text = "Check All";
			this.linkCheckEx.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCheckEx_LinkClicked);
			// 
			// FormAttributes
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(399, 249);
			this.ControlBox = false;
			this.Controls.Add(this.linkCheckEx);
			this.Controls.Add(this.linkClearEx);
			this.Controls.Add(this.linkCheckInc);
			this.Controls.Add(this.linkClearInc);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkListExclude);
			this.Controls.Add(this.checkListInclude);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormAttributes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Find By Attributes";
			this.Load += new System.EventHandler(this.FormAttributes_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox checkListInclude;
		private System.Windows.Forms.CheckedListBox checkListExclude;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.LinkLabel linkClearInc;
		private System.Windows.Forms.LinkLabel linkCheckInc;
		private System.Windows.Forms.LinkLabel linkClearEx;
		private System.Windows.Forms.LinkLabel linkCheckEx;
	}
}