
using System;
using MonoDevelop.PackageManagement;
using Xwt;

namespace XwtTest
{
	class Program
	{
		public static void Main (string[] args)
		{
			Application.Initialize (ToolkitType.Gtk);
			
			using (var addPackagesDialog = new AddPackagesDialog ()) {
				addPackagesDialog.Show ();
				Application.Run ();
			}
		}
	}
}