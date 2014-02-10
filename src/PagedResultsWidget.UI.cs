//
// PagedResultsWidget.UI.cs
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
using Xwt;
using Xwt.Drawing;

namespace MonoDevelop.PackageManagement
{
	public partial class PagedResultsWidget : Widget
	{
		HBox mainHBox;
		Button backButton;
		Button firstButton;
		Button secondButton;
		Button thirdButton;
		Button fourthButton;
		Button fifthButton;
		Button forwardButton;
		
		void Build ()
		{
			mainHBox = new HBox ();
			
			backButton = new Button ();
			backButton.Style = ButtonStyle.Flat;
			backButton.Label = "<";
			mainHBox.PackStart (backButton);
			
			firstButton = new Button ();
			firstButton.Style = ButtonStyle.Flat;
			firstButton.Label = "1";
			mainHBox.PackStart (firstButton);
			
			secondButton = new Button ();
			secondButton.Style = ButtonStyle.Flat;
			secondButton.Label = "2";
			mainHBox.PackStart (secondButton);
			
			thirdButton = new Button ();
			thirdButton.Style = ButtonStyle.Flat;
			thirdButton.Label = "3";
			mainHBox.PackStart (thirdButton);
		
			fourthButton = new Button ();
			fourthButton.Style = ButtonStyle.Flat;
			fourthButton.Label = "4";
			mainHBox.PackStart (fourthButton);
		
			fifthButton = new Button ();
			fifthButton.Style = ButtonStyle.Flat;
			fifthButton.Label = "5";
			mainHBox.PackStart (fifthButton);
		
			forwardButton = new Button ();
			forwardButton.Style = ButtonStyle.Flat;
			forwardButton.Label = ">";
			mainHBox.PackStart (forwardButton);
			
			Content = mainHBox;
		}
	}
}
