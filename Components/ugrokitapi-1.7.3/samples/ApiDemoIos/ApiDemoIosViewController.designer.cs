// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ApiDemoIos
{
	[Register ("ApiDemoIosViewController")]
	partial class ApiDemoIosViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton batteryButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton commissionButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton configureButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel connectionStateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton InfoButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch inventorySwitch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton readButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton writeButton { get; set; }

		[Action ("batteryButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void batteryButton_TouchUpInside (UIButton sender);

		[Action ("commissionButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void commissionButton_TouchUpInside (UIButton sender);

		[Action ("configureButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void configureButton_TouchUpInside (UIButton sender);

		[Action ("InfoButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void InfoButton_TouchUpInside (UIButton sender);

		[Action ("inventorySwitch_ValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void inventorySwitch_ValueChanged (UISwitch sender);

		[Action ("readButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void readButton_TouchUpInside (UIButton sender);

		[Action ("writeButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void writeButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (batteryButton != null) {
				batteryButton.Dispose ();
				batteryButton = null;
			}
			if (commissionButton != null) {
				commissionButton.Dispose ();
				commissionButton = null;
			}
			if (configureButton != null) {
				configureButton.Dispose ();
				configureButton = null;
			}
			if (connectionStateLabel != null) {
				connectionStateLabel.Dispose ();
				connectionStateLabel = null;
			}
			if (InfoButton != null) {
				InfoButton.Dispose ();
				InfoButton = null;
			}
			if (inventorySwitch != null) {
				inventorySwitch.Dispose ();
				inventorySwitch = null;
			}
			if (readButton != null) {
				readButton.Dispose ();
				readButton = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
			if (writeButton != null) {
				writeButton.Dispose ();
				writeButton = null;
			}
		}
	}
}
