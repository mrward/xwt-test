//
// AddPackagesDialog.UI.cs
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
using Mono.Unix;
using Xwt;
using Xwt.Drawing;

namespace MonoDevelop.PackageManagement
{
	public partial class AddPackagesDialog : Dialog
	{
		ComboBox packageSourceComboBox;
		TextEntry packageSearchEntry;
		ScrollView packageInfoScrollView;
		Label packageNameLabel;
		Label packageVersionLabel;
		LinkLabel packageIdLink;
		RichTextView packageDescription;
		Label packageAuthor;
		Label packagePublishedDate;
		Label packageDownloads;
		LinkLabel packageLicenseLink;
		LinkLabel packageProjectPageLink;
		Label packageDependenciesList;
		HBox packageDependenciesListHBox;
		Label noPackageDependenciesLabel;
		PagedResultsWidget pagedResultsWidget;
		ListView packagesListView;
		
		void Build ()
		{
			Title = Catalog.GetString ("Add Packages");
			Width = 640;
			Height = 480;
			
			var mainVBox = new VBox ();
			
			// Top part of dialog:
			// Package sources and search text box.
			var topHBox = new HBox ();
			mainVBox.PackStart (topHBox);
			
			packageSourceComboBox = new ComboBox ();
			packageSourceComboBox.MinWidth = 200;
			topHBox.PackStart (packageSourceComboBox);
			
			packageSearchEntry = new TextEntry ();
			topHBox.PackEnd (packageSearchEntry);
			
			// Centre part of dialog:
			// Packages list and package information.
			var packagesPane = new HPaned ();
			mainVBox.PackStart (packagesPane, true, true);
			
			// Packages list.
			var packagesListVBox = new VBox ();
			packagesPane.Panel1.Content = packagesListVBox;
			packagesPane.Panel1.Resize = true;
			packagesPane.Panel1.Shrink = true;
			
			packagesListView = new ListView ();
			packagesListView.HeadersVisible = false;
			packagesListVBox.PackStart (packagesListView, true, true);
			
			// Paged results widget.
			var pagedResultsHBox = new HBox ();
			packagesListVBox.PackStart (pagedResultsHBox);
			
			pagedResultsWidget = new PagedResultsWidget ();
			
			var pagedResultsLeftLabel = new Label ();
			var pagedResultsRightLabel = new Label ();
			
			pagedResultsHBox.PackStart (pagedResultsLeftLabel, true, true);
			pagedResultsHBox.PackStart (pagedResultsWidget);
			pagedResultsHBox.PackStart (pagedResultsRightLabel, true, true);
			
			var packageInfoVBox = new VBox ();
			packagesPane.Panel2.Content = packageInfoVBox;
			packagesPane.Panel2.Resize = false;
			packagesPane.Panel2.Shrink = true;
			
			// Package information
			var packageInfoFrame = new Frame ();
			packageInfoVBox.PackStart (packageInfoFrame, true);
			
			var packageInfoFrameVBox = new VBox ();
			packageInfoFrameVBox.Margin = new WidgetSpacing (5, 5, 5, 5);
			//packageInfoFrame.Content = packageInfoFrameVBox;
			
			packageInfoScrollView = new ScrollView ();
			packageInfoScrollView.BorderVisible = false;
			packageInfoScrollView.Content = packageInfoFrameVBox;
			packageInfoFrame.Content = packageInfoScrollView;
			packageInfoFrame.MinWidth = 200;
			
			// Package name and version.
			var packageNameHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageNameHBox);
			
			packageNameLabel = new Label ();
			packageNameHBox.PackStart (packageNameLabel);
			
			packageVersionLabel = new Label ();
			packageNameHBox.PackEnd (packageVersionLabel);
			
			// Package description.
			packageDescription = new RichTextView ();
			packageDescription.Sensitive = false;
			packageInfoFrameVBox.PackStart (packageDescription, true, true);
			
			// Package id.
			var packageIdHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageIdHBox);
			
			var packageIdLabel = new Label ();
			packageIdLabel.Markup = Catalog.GetString ("<b>Id</b>");
			packageIdHBox.PackStart (packageIdLabel);
			
			packageIdLink = new LinkLabel ();
			packageIdHBox.PackEnd (packageIdLink);
			
			// Package author
			var packageAuthorHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageAuthorHBox);
			
			var packageAuthorLabel = new Label ();
			packageAuthorLabel.Markup = Catalog.GetString ("<b>Author</b>");
			packageAuthorHBox.PackStart (packageAuthorLabel);
			
			packageAuthor = new Label ();
			packageAuthorHBox.PackEnd (packageAuthor);
			
			// Package published
			var packagePublishedHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packagePublishedHBox);
			
			var packagePublishedLabel = new Label ();
			packagePublishedLabel.Markup = Catalog.GetString ("<b>Published</b>");
			packagePublishedHBox.PackStart (packagePublishedLabel);
			
			packagePublishedDate = new Label ();
			packagePublishedHBox.PackEnd (packagePublishedDate);
			
			// Package downloads
			var packageDownloadsHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageDownloadsHBox);
			
			var packageDownloadsLabel = new Label ();
			packageDownloadsLabel.Markup = Catalog.GetString ("<b>Downloads</b>");
			packageDownloadsHBox.PackStart (packageDownloadsLabel);
			
			packageDownloads = new Label ();
			packageDownloadsHBox.PackEnd (packageDownloads);
			
			// Package license.
			var packageLicenseHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageLicenseHBox);
			
			var packageLicenseLabel = new Label ();
			packageLicenseLabel.Markup = Catalog.GetString ("<b>License</b>");
			packageLicenseHBox.PackStart (packageLicenseLabel);
			
			packageLicenseLink = new LinkLabel ();
			packageLicenseLink.Text = Catalog.GetString ("View License");
			packageLicenseHBox.PackEnd (packageLicenseLink);
			
			// Package project page.
			var packageProjectPageHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageProjectPageHBox);
			
			var packageProjectPageLabel = new Label ();
			packageProjectPageLabel.Markup = Catalog.GetString ("<b>Project Page</b>");
			packageProjectPageHBox.PackStart (packageProjectPageLabel);
			
			packageProjectPageLink = new LinkLabel ();
			packageProjectPageLink.Text = Catalog.GetString ("Visit Page");
			packageProjectPageHBox.PackEnd (packageProjectPageLink);
			
			// Package dependencies
			var packageDependenciesHBox = new HBox ();
			packageInfoFrameVBox.PackStart (packageDependenciesHBox);
			
			var packageDependenciesLabel = new Label ();
			packageDependenciesLabel.Markup = Catalog.GetString ("<b>Dependencies</b>");
			packageDependenciesHBox.PackStart (packageDependenciesLabel);
			
			noPackageDependenciesLabel = new Label ();
			noPackageDependenciesLabel.Text = Catalog.GetString ("None");
			packageDependenciesHBox.PackEnd (noPackageDependenciesLabel);
			
			// Package dependencies list.
			packageDependenciesListHBox = new HBox ();
			packageDependenciesListHBox.Visible = false;
			packageInfoFrameVBox.PackStart (packageDependenciesListHBox);
			
			packageDependenciesList = new Label ();
			packageDependenciesListHBox.PackEnd (packageDependenciesList);
			
			// Bottom part of dialog:
			// Show pre-release packages and Close/Add to Project buttons.
			var bottomHBox = new HBox ();
			mainVBox.PackStart (bottomHBox);
			
			var showPrereleaseCheckBox = new CheckBox ();
			showPrereleaseCheckBox.Label = Catalog.GetString ("Show pre-release packages");
			bottomHBox.PackStart (showPrereleaseCheckBox);
			
			var closeButton = new DialogButton (Command.Close);
			closeButton.Clicked += (sender, e) => Close ();
			this.Buttons.Add (closeButton);
			
			var addToProjectButton = new DialogButton (Catalog.GetString ("Add to Project"));
			this.Buttons.Add (addToProjectButton);
			
			packageSearchEntry.SetFocus ();
			
			this.Content = mainVBox;
		}
	}
}
