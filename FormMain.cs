using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using RobiSoft.Tools.Forms;

namespace FindFiles
{
	public partial class FormMain : Form, IDropFileTarget
	{
		private DropFileHandler _dropFileHandler;
		private SystemMenu _systemMenu;
		private string _searchFolder = "";
	
		private const int _InstallSysMenuId = 0x1000;
		private const int _AboutSysMenuId = 0x1001;

		private FileAttributes _includeAttributes = FileAttributes.Normal;
		private FileAttributes _excludeAttributes = FileAttributes.ReadOnly;
		private string _directory = "";
		private string _searchPattern = "";

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			_dropFileHandler = new DropFileHandler(this);
			_systemMenu = new SystemMenu(this);

			// add an item to the system menu
			_systemMenu.AppendSeparator();
			_systemMenu.AppendMenu(_InstallSysMenuId, "Add to Folder Context Menu");
			_systemMenu.AppendMenu(_AboutSysMenuId, "About FindFiles...");
			_systemMenu.SysCommandEvent += new SystemMenu.SysCommandEventHandler(_systemMenu_SysCommandEvent);
			
			// accept path as command line arg
			string[] args = Environment.GetCommandLineArgs();
			if (args.Length > 1)
				textPath.Text = args[1];

			// restore previous settings
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrettRobichaud\FindFiles");
				_includeAttributes = (FileAttributes)key.GetValue("IncludedAttributes", 32759);
				_excludeAttributes = (FileAttributes)key.GetValue("ExcludedAttributes", 0);
			}
			catch { }
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			// save settings
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\BrettRobichaud\FindFiles");
				key.SetValue("IncludedAttributes", Convert.ToInt32(_includeAttributes));
				key.SetValue("ExcludedAttributes", Convert.ToInt32(_excludeAttributes));
			}
			catch { }
		}

		protected override void WndProc(ref Message m)
		{
			// pass on to systemmenu manager
			if (_systemMenu != null)
				_systemMenu.WndProc(m);

			base.WndProc(ref m);
		}

		void _systemMenu_SysCommandEvent(object sender, SystemMenu.SysCommandEventArgs e)
		{
			if (e.CommandId == _InstallSysMenuId)
			{
				try
				{
					string[] args = Environment.GetCommandLineArgs();
					string commandLine = args[0] + " \"%1\"\\";

					RegistryKey keyMain = Registry.ClassesRoot.CreateSubKey("Directory\\Shell\\FindFilesNotCheckedIn");
					keyMain.SetValue("", "&Find Files Not Checked In...");
					RegistryKey keyCommand = keyMain.CreateSubKey("Command");
					keyCommand.SetValue("", commandLine);

					MessageBox.Show(this, "Registry entries have been added.  You can now right click on a folder to start this app.",
						"Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch { }
			}
			else if (e.CommandId == _AboutSysMenuId)
			{
				FormAbout form = new FormAbout();
				form.ShowDialog(this);
			}
		}

		private void buttonFind_Click(object sender, EventArgs e)
		{
			buttonCancel.Enabled = true;
			buttonFind.Enabled = false;
			textPath.Enabled = false;
			listFiles.Items.Clear();
			aviAnimator.Visible = true;
			aviAnimator.Open();
			aviAnimator.Play();

			//if (!textPath.Text.EndsWith(@"\"))
			//   textPath.Text += @"\";
			_searchFolder = textPath.Text;
			_directory = Path.GetDirectoryName(textPath.Text);
			_searchPattern = Path.GetFileName(textPath.Text);

			if (string.IsNullOrEmpty(_searchPattern))
				_searchPattern = "*.*";

			Searcher.InitializeAttributes(_includeAttributes, _excludeAttributes);
			backgroundWorker.RunWorkerAsync(backgroundWorker);
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Searcher.RecurseDirectory(_searchFolder, (BackgroundWorker)e.Argument);

			// notify sender work is complete
			backgroundWorker.ReportProgress(100, null);
		}

		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			buttonCancel.Enabled = false;
			buttonFind.Enabled = true;
			textPath.Enabled = true;
			aviAnimator.Visible = false;
			aviAnimator.Stop();
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState == null)
				return;

			string file = (string)e.UserState.ToString();
			if (!string.IsNullOrEmpty(file))
			{
				string fileShort = file.Replace(_directory, "");
				listFiles.Items.Add(fileShort);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (backgroundWorker.IsBusy)
				backgroundWorker.CancelAsync();
		}

		#region IDropFileTarget Members

		public void DroppedFiles(Array fileList)
		{
			textPath.Text = fileList.GetValue(0).ToString();
		}

		#endregion

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.Description = "Select the folder to search:";
			if (!string.IsNullOrEmpty(textPath.Text))
				folderBrowserDialog.SelectedPath = textPath.Text;

			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				textPath.Text = folderBrowserDialog.SelectedPath;
		}

		private void buttonAttributes_Click(object sender, EventArgs e)
		{
			FormAttributes form = new FormAttributes();
			form.InitializeAttributes(_includeAttributes, _excludeAttributes);
			if (form.ShowDialog(this) == DialogResult.OK)
				form.GetAttributes(ref _includeAttributes, ref _excludeAttributes);
		}
	}
}