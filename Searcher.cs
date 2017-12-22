using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FindFiles
{
	public class Searcher
	{
		private static FileAttributes _includeAttributes = FileAttributes.Normal;
		private static FileAttributes _excludeAttributes = FileAttributes.ReadOnly;

		public static void InitializeAttributes(FileAttributes include, FileAttributes exclude)
		{
			_includeAttributes = include;
			_excludeAttributes = exclude;
		}

		/// <summary>
		/// Recurses the given path, adding all matching files on that path to 
		/// the list box. After it finishes with the files, it
		/// calls itself once for each directory on the path.
		/// </summary>
		public static void RecurseDirectory(string searchPath, BackgroundWorker worker)
		{
			if (worker.CancellationPending)
				return;

			string[] files;

			// split searchPath into a directory and a wildcard specification
			string directory = Path.GetDirectoryName(searchPath);
			string searchPattern = Path.GetFileName(searchPath);

			if (string.IsNullOrEmpty(searchPattern))
				searchPattern = "*.*";

			if (string.IsNullOrEmpty(directory))
				return;  // nothing to search

			try
			{
				files = Directory.GetFiles(directory, searchPattern);

				foreach (string file in files)
				{
					if (worker.CancellationPending)
						return;

					FileAttributes fileAttributes = File.GetAttributes(file);
					if (IncludeFile(fileAttributes, _includeAttributes) &&
						 !ExcludeFile(fileAttributes, _excludeAttributes))
					{
						worker.ReportProgress(0, file);
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				return;  // no access, ignore
			}
			catch (DirectoryNotFoundException)
			{
				return;  // no access, ignore
			}

			// recurse through all subdirectories
			string[] directories = Directory.GetDirectories(directory);
			foreach (string subdirectory in directories)
				RecurseDirectory(Path.Combine(subdirectory, searchPattern), worker);
		}

		private static bool IncludeFile(FileAttributes fileAttr, FileAttributes includeAttr)
		{
			if ((includeAttr == 0) && (fileAttr == 0))
				return true;  // no attributes

			if (includeAttr == 0)
				return false;  // nothing to include

			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Archive))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Compressed))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Device))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Directory))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Encrypted))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Hidden))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Normal))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.NotContentIndexed))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Offline))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.ReadOnly))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.ReparsePoint))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.SparseFile))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.System))
				return true;
			if (MatchAttribute(fileAttr, includeAttr, FileAttributes.Temporary))
				return true;

			return false;
		}

		private static bool ExcludeFile(FileAttributes fileAttr, FileAttributes excludeAttr)
		{
			if (excludeAttr == 0)
				return false;  // nothing to exclude

			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Archive))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Compressed))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Device))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Directory))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Encrypted))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Hidden))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Normal))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.NotContentIndexed))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Offline))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.ReadOnly))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.ReparsePoint))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.SparseFile))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.System))
				return true;
			if (MatchAttribute(fileAttr, excludeAttr, FileAttributes.Temporary))
				return true;

			return false;
		}

		private static bool MatchAttribute(FileAttributes file, FileAttributes check, FileAttributes state)
		{
			return (((check & state) == state) && ((file & state) == state));
		}
	}
}
