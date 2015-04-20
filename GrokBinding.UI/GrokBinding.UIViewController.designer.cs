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

namespace GrokBinding.UI
{
	[Register ("GrokBinding_UIViewController")]
	partial class GrokBinding_UIViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ConnectButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ConnectionStateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CurrentTagEPCLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton DisconnectButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel GrokPluggedInStateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField NewTagEPCTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ReadTagsStartButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ReadTagsStopButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SetTagButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StartEditingButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StopEditingButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView TagsTextView { get; set; }

		[Action ("ConnectButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ConnectButton_TouchUpInside (UIButton sender);

		[Action ("DisconnectButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void DisconnectButton_TouchUpInside (UIButton sender);

		[Action ("ReadTagsStartButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ReadTagsStartButton_TouchUpInside (UIButton sender);

		[Action ("ReadTagsStopButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ReadTagsStopButton_TouchUpInside (UIButton sender);

		[Action ("SetTagButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SetTagButton_TouchUpInside (UIButton sender);

		[Action ("StartEditingButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartEditingButton_TouchUpInside (UIButton sender);

		[Action ("StopEditingButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StopEditingButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (ConnectButton != null) {
				ConnectButton.Dispose ();
				ConnectButton = null;
			}
			if (ConnectionStateLabel != null) {
				ConnectionStateLabel.Dispose ();
				ConnectionStateLabel = null;
			}
			if (CurrentTagEPCLabel != null) {
				CurrentTagEPCLabel.Dispose ();
				CurrentTagEPCLabel = null;
			}
			if (DisconnectButton != null) {
				DisconnectButton.Dispose ();
				DisconnectButton = null;
			}
			if (GrokPluggedInStateLabel != null) {
				GrokPluggedInStateLabel.Dispose ();
				GrokPluggedInStateLabel = null;
			}
			if (NewTagEPCTextField != null) {
				NewTagEPCTextField.Dispose ();
				NewTagEPCTextField = null;
			}
			if (ReadTagsStartButton != null) {
				ReadTagsStartButton.Dispose ();
				ReadTagsStartButton = null;
			}
			if (ReadTagsStopButton != null) {
				ReadTagsStopButton.Dispose ();
				ReadTagsStopButton = null;
			}
			if (SetTagButton != null) {
				SetTagButton.Dispose ();
				SetTagButton = null;
			}
			if (StartEditingButton != null) {
				StartEditingButton.Dispose ();
				StartEditingButton = null;
			}
			if (StopEditingButton != null) {
				StopEditingButton.Dispose ();
				StopEditingButton = null;
			}
			if (TagsTextView != null) {
				TagsTextView.Dispose ();
				TagsTextView = null;
			}
		}
	}
}
