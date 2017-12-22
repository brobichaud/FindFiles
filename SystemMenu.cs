using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RobiSoft.Tools.Forms
{
	/// <summary>
	/// Helper class for manipulating the system menu
	/// 
	/// To use this class:
	///	1) Add member of this class to parent form:
	///		private SystemMenu _systemMenu;
	/// 
	///	2) Define menu ids for each item to add (between 0x0100 and 0xF000):
	///		private const int _InstallSysMenuId = 0x1000;
	/// 
	///	3) Initialize class instance in parent form Load event, add menu items, and subscribe to SysCommandEvent:
	///		private void Form1_Load(object sender, System.EventArgs e)
	///		{
	///			_systemMenu = new SystemMenu(this);
	///			_systemMenu.AppendSeparator();
	///			_systemMenu.AppendMenu(_InstallSysMenuId, "&Install");
	///			_systemMenu.SysCommandEvent += new SystemMenu.SysCommandEventHandler(_systemMenu_SysCommandEvent);
	///		}
	/// 
	///	4) Override WndProc in your form and call SystemMenu class WndProc:
	///		protected override void WndProc(ref Message m)
	///		{
	///			if (_systemMenu != null)
	///				_systemMenu.WndProc(m);
	///
	///			base.WndProc(ref m);
	///		}
	/// 
	///	5) Handle the SysCommandEvent:
	/// 		void _systemMenu_SysCommandEvent(object sender, SystemMenu.SysCommandEventArgs e)
	///		{
	///			if (e.CommandId == _InstallSysMenuId)
	///				MessageBox.Show("Install command selected");
	///		}
	/// </summary>
	public class SystemMenu
	{
		private IntPtr _systemMenuHandle = IntPtr.Zero;    // Handle to the System Menu

		#region P/Invoke Signatures
		[DllImport("USER32", EntryPoint = "GetSystemMenu", SetLastError = true,
			  CharSet = CharSet.Unicode, ExactSpelling = true,
			  CallingConvention = CallingConvention.Winapi)]
		private static extern IntPtr GetSystemMenu(IntPtr WindowHandle, int bReset);

		[DllImport("USER32", EntryPoint = "AppendMenuW", SetLastError = true,
					  CharSet = CharSet.Unicode, ExactSpelling = true,
					  CallingConvention = CallingConvention.Winapi)]
		private static extern int AppendMenu(IntPtr MenuHandle, int Flags, int NewID, String Item);

		[DllImport("USER32", EntryPoint = "InsertMenuW", SetLastError = true,
					  CharSet = CharSet.Unicode, ExactSpelling = true,
					  CallingConvention = CallingConvention.Winapi)]
		private static extern int InsertMenu(IntPtr hMenu, int Position, int Flags, int NewId, String Item);
		#endregion

		#region System Command Event Handling
		public delegate void SysCommandEventHandler(object sender, SysCommandEventArgs e);
		public event SysCommandEventHandler SysCommandEvent;

		public class SysCommandEventArgs : EventArgs
		{
			public SysCommandEventArgs(int commandId)
			{
				CommandId = commandId;
			}

			private int _CommandId;
			public int CommandId
			{
				get { return _CommandId; }
				set { _CommandId = value; }
			}
		}
		#endregion

		public SystemMenu()
		{
		}

		public SystemMenu(Form form)
		{
			SetForm(form);
		}

		// Retrieves a new object from a Form object
		public void SetForm(Form form)
		{
			_systemMenuHandle = GetSystemMenu(form.Handle, 0);

			if (_systemMenuHandle == IntPtr.Zero)
			{
				// Throw an exception on failure
				throw new NoSystemMenuException();
			}
		}

		// Insert a separator at the given position index starting at zero
		public bool InsertSeparator(int Pos)
		{
			return (InsertMenu(Pos, ItemFlags.mfSeparator | ItemFlags.mfByPosition, 0, ""));
		}

		// Simplified InsertMenu(), that assumes that Pos is a relative
		// position index starting at zero
		public bool InsertMenu(int Pos, int ID, String Item)
		{
			return (InsertMenu(Pos, ItemFlags.mfByPosition | ItemFlags.mfString, ID, Item));
		}

		// Insert a menu at the given position. The value of the position
		// depends on the value of Flags. See the article for a detailed
		// description.
		public bool InsertMenu(int Pos, ItemFlags Flags, int ID, String Item)
		{
			if (_systemMenuHandle == IntPtr.Zero)
			{
				// Throw an exception on failure
				throw new NoSystemMenuException();
			}

			return (InsertMenu(_systemMenuHandle, Pos, (Int32)Flags, ID, Item) == 0);
		}

		// Appends a seperator
		public bool AppendSeparator()
		{
			return AppendMenu(0, "", ItemFlags.mfSeparator);
		}

		// This uses the ItemFlags.mfString as default value
		public bool AppendMenu(int ID, String Item)
		{
			return AppendMenu(ID, Item, ItemFlags.mfString);
		}

		public bool AppendMenu(int ID, String Item, ItemFlags Flags)
		{
			if (_systemMenuHandle == IntPtr.Zero)
			{
				// Throw an exception on failure
				throw new NoSystemMenuException();
			}

			return (AppendMenu(_systemMenuHandle, (int)Flags, ID, Item) == 0);
		}

		// Handle WndProc override of form and sends events for ids in range
		public void WndProc(Message m)
		{
			if (m.Msg == (int)WindowMessages.wmSysCommand)
			{
				if ((m.WParam.ToInt32() >= 0x0100) && (m.WParam.ToInt32() <= 0xF000))
				{
					if (SysCommandEvent != null)
						SysCommandEvent(this, new SysCommandEventArgs(m.WParam.ToInt32()));
				}
			}
		}

		// Reset's the window menu to it's default
		public static void ResetSystemMenu(Form form)
		{
			GetSystemMenu(form.Handle, 1);
		}

		// Checks if an ID for a new system menu item is OK or not
		public static bool VerifyItemID(int ID)
		{
			return (bool)(ID < 0xF000 && ID > 0);
		}
	}

	public class NoSystemMenuException : System.ApplicationException
	{
	}

	public enum ItemFlags
	{
		mfUnchecked = 0x00000000,	// is not checked
		mfString = 0x00000000,		// contains a string as label
		mfDisabled = 0x00000002,	// is disabled
		mfGrayed = 0x00000001,		// is grayed
		mfChecked = 0x00000008,		// is checked
		mfPopup = 0x00000010,		// is a popup menu. Pass the menu handle of the popup menu into the ID parameter.
		mfBarBreak = 0x00000020,	// is a bar break
		mfBreak = 0x00000040,		// is a break
		mfByPosition = 0x00000400,	// is identified by the position
		mfByCommand = 0x00000000,	// is identified by its ID
		mfSeparator = 0x00000800	// is a seperator (String and ID parameters are ignored).
	}

	public enum WindowMessages
	{
		wmSysCommand = 0x0112
	}
}
