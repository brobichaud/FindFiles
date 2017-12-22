using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FindFiles
{
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			InitializeComponent();
		}

		private void FormAbout_Load(object sender, EventArgs e)
		{
			FileVersionInfo fi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
			labelVersion.Text = "Version " + fi.ProductVersion;
			labelCopyright.Text = fi.LegalCopyright;
		}
	}
}
