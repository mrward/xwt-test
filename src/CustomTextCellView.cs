// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using MonoDevelop.PackageManagement;
using Xwt;
using Xwt.Drawing;

namespace XwtTest
{
	public class CustomTextCellView : CanvasCellView
	{
		public IDataField<DummyPackageViewModel> PackageField { get; set; }
		
		protected override void OnDraw(Context ctx, Rectangle cellArea)
		{
			var downloadCountLayout = new TextLayout ();
			downloadCountLayout.Text = "10000002";
			Size downloadCountTextSize = downloadCountLayout.GetSize ();
			Point location = new Point (cellArea.Right, cellArea.Top);
			Point downloadLocation = location.Offset (-downloadCountTextSize.Width, 0);
			ctx.DrawTextLayout (downloadCountLayout, downloadLocation);
			
			var layout = new TextLayout ();
			layout.Markup = "<b>DotNetOpenAuth extensions for ASP.NET (WebPages)</b>";
			layout.Trimming = TextTrimming.WordElipsis;
			layout.Width = downloadLocation.X - cellArea.Left - 5;
			ctx.DrawTextLayout (layout, cellArea.Left, cellArea.Top);
			
			layout = new TextLayout ();
			layout.Width = cellArea.Width;
			layout.Height = cellArea.Height - downloadCountTextSize.Height;
			layout.Text = "lorem ipsum.asdfasdf jdsjldsjldfas lkljdfsajdfasjd a fadsf adsf dasf dasf dasf dasf asdf das faffas asdfjasdfdasf asd fa adsf asdf af asdf a as faf afzzzzzzzzzzzzzzzzzzzzzzz zzz";
			//layout.Trimming = TextTrimming.WordElipsis;
			layout.Trimming = TextTrimming.Word;
			ctx.DrawTextLayout (layout, cellArea.Left, cellArea.Top + downloadCountTextSize.Height + packageDescriptionPaddingHeight);
			
//			ctx.SetLineWidth (1);
//			ctx.Rectangle (cellArea);
//			ctx.SetColor (Colors.LightBlue);
//			ctx.FillPreserve ();
//			ctx.SetColor (Colors.Gray);
//			ctx.Stroke ();
		}
		
		protected override Size OnGetRequiredSize()
		{
			var layout = new TextLayout ();
			layout.Text = "W";
			Size size = layout.GetSize ();
			return new Size (365, size.Height * 3 + packageDescriptionPaddingHeight);
		}
		
		int packageDescriptionPaddingHeight = 5;
	}
}
