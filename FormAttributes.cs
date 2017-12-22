using System;
using System.IO;
using System.Windows.Forms;

namespace FindFiles
{
	public partial class FormAttributes : Form
	{
		private FileAttributes _includeAttributes = FileAttributes.Normal;
		private FileAttributes _excludeAttributes = FileAttributes.ReadOnly;

		public FormAttributes()
		{
			InitializeComponent();
		}

		public void InitializeAttributes(FileAttributes include, FileAttributes exclude)
		{
			_includeAttributes = include;
			_excludeAttributes = exclude;
		}

		public void GetAttributes(ref FileAttributes include, ref FileAttributes exclude)
		{
			GetListState(checkListInclude, ref _includeAttributes);
			GetListState(checkListExclude, ref _excludeAttributes);

			include = _includeAttributes;
			exclude = _excludeAttributes;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (!IncludedValid())
				return;

			if (!ExcludedValid())
				return;

			if (DuplicateSelection())
				return;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private bool IncludedValid()
		{
			bool atLeastOneChecked = false;
			for (int loop = 0; loop < checkListInclude.Items.Count; loop++)
			{
				if (checkListInclude.GetItemChecked(loop))
				{
					atLeastOneChecked = true;
					break;
				}
			}

			if (!atLeastOneChecked)
			{
				MessageBox.Show(this, "No files will match because you have selected no attributes to Include. Please select at least one Attribute to Include.",
					"Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private bool ExcludedValid()
		{
			bool atLeastOneUnchecked = false;
			for (int loop = 0; loop < checkListExclude.Items.Count; loop++)
			{
				if (!checkListExclude.GetItemChecked(loop))
				{
					atLeastOneUnchecked = true;
					break;
				}
			}

			if (!atLeastOneUnchecked)
			{
				MessageBox.Show(this, "No files will match because you have selected to Exclude all attributes. Please unselect at least one Attribute to Exclude.",
					"Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private bool DuplicateSelection()
		{
			for (int loop = 0; loop < checkListInclude.Items.Count; loop++)
			{
				if (checkListInclude.GetItemChecked(loop) && checkListExclude.GetItemChecked(loop))
				{
					string attr = checkListInclude.Items[loop].ToString();
					MessageBox.Show(this, "You have selected to Include and Exclude the same attribute [" + attr + "]. Please select it in only one list.",
						"Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return true;
				}
			}

			return false;
		}

		private void FormAttributes_Load(object sender, EventArgs e)
		{
			SetListState(checkListInclude, _includeAttributes);
			SetListState(checkListExclude, _excludeAttributes);
		}

		private void SetListState(CheckedListBox list, FileAttributes attributes)
		{
			list.SetItemChecked(0, ((attributes & FileAttributes.Archive) == FileAttributes.Archive));
			list.SetItemChecked(1, ((attributes & FileAttributes.Compressed) == FileAttributes.Compressed));
			list.SetItemChecked(2, ((attributes & FileAttributes.Device) == FileAttributes.Device));
			list.SetItemChecked(3, ((attributes & FileAttributes.Directory) == FileAttributes.Directory));
			list.SetItemChecked(4, ((attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted));
			list.SetItemChecked(5, ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden));
			list.SetItemChecked(6, ((attributes & FileAttributes.Normal) == FileAttributes.Normal));
			list.SetItemChecked(7, ((attributes & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed));
			list.SetItemChecked(8, ((attributes & FileAttributes.Offline) == FileAttributes.Offline));
			list.SetItemChecked(9, ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly));
			list.SetItemChecked(10, ((attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint));
			list.SetItemChecked(11, ((attributes & FileAttributes.SparseFile) == FileAttributes.SparseFile));
			list.SetItemChecked(12, ((attributes & FileAttributes.System) == FileAttributes.System));
			list.SetItemChecked(13, ((attributes & FileAttributes.Temporary) == FileAttributes.Temporary));
		}

		private void GetListState(CheckedListBox list, ref FileAttributes attributes)
		{
			attributes = 0;
			if (list.GetItemChecked(0))
				attributes |= FileAttributes.Archive;
			if (list.GetItemChecked(1))
				attributes |= FileAttributes.Compressed;
			if (list.GetItemChecked(2))
				attributes |= FileAttributes.Device;
			if (list.GetItemChecked(3))
				attributes |= FileAttributes.Directory;
			if (list.GetItemChecked(4))
				attributes |= FileAttributes.Encrypted;
			if (list.GetItemChecked(5))
				attributes |= FileAttributes.Hidden;
			if (list.GetItemChecked(6))
				attributes |= FileAttributes.Normal;
			if (list.GetItemChecked(7))
				attributes |= FileAttributes.NotContentIndexed;
			if (list.GetItemChecked(8))
				attributes |= FileAttributes.Offline;
			if (list.GetItemChecked(9))
				attributes |= FileAttributes.ReadOnly;
			if (list.GetItemChecked(10))
				attributes |= FileAttributes.ReparsePoint;
			if (list.GetItemChecked(11))
				attributes |= FileAttributes.SparseFile;
			if (list.GetItemChecked(12))
				attributes |= FileAttributes.System;
			if (list.GetItemChecked(13))
				attributes |= FileAttributes.Temporary;
		}

		private void linkClearInc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			for (int loop = 0; loop < checkListInclude.Items.Count; loop++)
				checkListInclude.SetItemChecked(loop, false);
		}

		private void linkCheckInc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			for (int loop = 0; loop < checkListInclude.Items.Count; loop++)
				checkListInclude.SetItemChecked(loop, true);
		}

		private void linkClearEx_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			for (int loop = 0; loop < checkListExclude.Items.Count; loop++)
				checkListExclude.SetItemChecked(loop, false);
		}

		private void linkCheckEx_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			for (int loop = 0; loop < checkListExclude.Items.Count; loop++)
				checkListExclude.SetItemChecked(loop, true);
		}
	}
}