//
// AddPackagesDialog.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Xwt.Formats;

namespace MonoDevelop.PackageManagement
{
	public partial class AddPackagesDialog
	{
		public AddPackagesDialog ()
		{
			Build ();
			AddDummyData ();
		}
		
		void AddDummyData ()
		{
			this.packageSourceComboBox.Items.Add ("1", "All Sources");
			this.packageSourceComboBox.Items.Add ("2", "nuget.org");
			this.packageSourceComboBox.Items.Add ("3", "xamarin.com");
			
			this.packageSourceComboBox.SelectedIndex = 0;
			
			this.packageNameLabel.Markup = "<b>Json.NET</b>";
			this.packageVersionLabel.Text = "6.0.1";
			
			this.packageIdLink.Text = "Newtonsoft.Json";
			this.packageIdLink.Uri = new Uri ("http://www.nuget.org/packages/Newtonsoft.Json/");
			this.packageDescription.LoadText ("Json.NET is a popular high-performance JSON framework for .NET", TextFormat.Plain);
			
			//AddLoadsOfPackageDescriptionText();
			
			this.packageAuthor.Text = "James Newton-King";
			this.packagePublishedDate.Text = DateTime.Now.ToShortDateString ();
			this.packageDownloads.Text = "10491";
			this.packageLicenseLink.Uri = new Uri ("https://raw.github.com/JamesNK/Newtonsoft.Json/master/LICENSE.md");
			this.packageProjectPageLink.Uri = new Uri ("http://james.newtonking.com/json");
			
			this.noPackageDependenciesLabel.Visible = false;
			this.packageDependenciesListHBox.Visible = true;
			
			this.packageDependenciesList.Text =
				"Microsoft.Bcl (> 1.1.3)\r\n" +
				"Microsoft.Bcl.Build (> 1.0.10)\r\n";
		}
		
		void AddLoadsOfPackageDescriptionText ()
		{
			string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam fermentum risus nec tincidunt egestas. Praesent pharetra posuere quam eget rhoncus. Ut eu placerat neque, ac convallis lectus. Etiam ut viverra lorem. Integer quis tempor neque. Maecenas hendrerit mauris vitae lorem pretium, ac pellentesque ante placerat. Nullam et porta ipsum. Nunc blandit leo enim, nec aliquam dolor dapibus sed.\r\n" +
				"Donec suscipit dictum erat a dictum. Vestibulum ut feugiat ante, vitae fermentum dui. Donec eget adipiscing urna, sagittis venenatis neque. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin tristique accumsan turpis, dictum dapibus elit lacinia ac. Aenean interdum dolor eu ornare dictum. Maecenas dapibus nisl at arcu mollis luctus. Sed enim magna, porta eget pretium in, ultrices ut neque. Morbi velit turpis, sodales et sagittis vitae, ultrices sed erat.\r\n";
			this.packageDescription.LoadText (text, TextFormat.Plain);
		}
	}
}
