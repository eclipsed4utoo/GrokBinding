using System;
using System.Drawing;

using Foundation;
using UIKit;
using UGrokItApi;
using System.Threading.Tasks;

namespace GrokBinding.UI
{
	public partial class GrokBinding_UIViewController : UIViewController, IUgiInventoryDelegate
	{
		private bool _isEditingTags;
		private UgiInventory _runningInventory;

		private Ugi CurrentUgi
		{
			get { return Ugi.Singleton (); }
		}

		public GrokBinding_UIViewController (IntPtr handle) : base (handle)
		{

		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TagsTextView.Layer.BorderColor = UIColor.Black.CGColor;

			CurrentUgi.ConnectionStateChanged += ConnectionStateHandler;

			ConnectionStateLabel.Text = "Disconnected";

			if (CurrentUgi.IsAnythingPluggedIntoAudioJack)
				GrokPluggedInStateLabel.Text = "Yes";
			else
				GrokPluggedInStateLabel.Text = "No";

			var tapGesture = new UITapGestureRecognizer (() => this.View.EndEditing (false));
			this.View.AddGestureRecognizer (tapGesture);
		}

		#endregion

		private void ConnectionStateHandler(Ugi.ConnectionStates state) 
		{
			if (state == Ugi.ConnectionStates.Connected) 
			{
				ConnectionStateLabel.Text = "Connected";
			}
			else if (state == Ugi.ConnectionStates.Connecting)
			{
				ConnectionStateLabel.Text = "Connecting";
			}
			else if (state == Ugi.ConnectionStates.NotConnected)
			{
				ConnectionStateLabel.Text = "Disconnected";
			}
		}

		#region Button Clicks

		partial void ConnectButton_TouchUpInside (UIButton sender)
		{
			if (!CurrentUgi.IsAnythingPluggedIntoAudioJack)
			{
				new UIAlertView ("Error", "Nothing plugged into audio port", null, "OK", null).Show ();
				return;
			}

			ConnectionStateLabel.Text = "Connecting...";
			CurrentUgi.OpenConnection ();
		}

		partial void DisconnectButton_TouchUpInside (UIButton sender)
		{
			if (!CurrentUgi.IsAnythingPluggedIntoAudioJack)
			{
				new UIAlertView ("Error", "Nothing plugged into audio port", null, "OK", null).Show ();
				return;
			}

			ConnectionStateLabel.Text = "Disconnecting...";

			CurrentUgi.CloseConnection ();

			ConnectionStateLabel.Text = "Disconnected";
		}

		partial void ReadTagsStartButton_TouchUpInside (UIButton sender)
		{
			ConnectionStateLabel.Text = "Starting Read...";

			UgiRfidConfiguration config = UgiRfidConfiguration.ConfigWithInventoryType (UgiRfidConfiguration.InventoryTypes.LocateVeryShortRange);
			config.SoundType = UgiRfidConfiguration.SoundTypes.None;
			config.PowerLevelWrite = 48f;
			_runningInventory = CurrentUgi.StartInventory(this, config);

			ConnectionStateLabel.Text = "Readings tags...";
		}

		partial void ReadTagsStopButton_TouchUpInside (UIButton sender)
		{
			ConnectionStateLabel.Text = "Stopping Read...";
			if (_runningInventory != null || CurrentUgi.ActiveInventory != null)
			{
				_runningInventory.StopInventory (() => {});
				_runningInventory = null;
			}

			ConnectionStateLabel.Text = "Reading Stopped";
		}

		partial void SetTagButton_TouchUpInside (UIButton sender)
		{
			var oldEPC = UgiEpc.FromString (CurrentTagEPCLabel.Text);
			var newEPC = UgiEpc.FromString (NewTagEPCTextField.Text);

			_runningInventory.ProgramTag(oldEPC, newEPC, UgiInventory.NO_PASSWORD,
				(UgiTag tag, UgiInventory.TagAccessReturnValues result) => {
					if (result == UgiInventory.TagAccessReturnValues.Ok) {
						// tag programmed successfully
					} else {
						// tag programming was unsuccessful
					Console.WriteLine ("Program failed");
					}
			});
		}

		partial void StopEditingButton_TouchUpInside (UIButton sender)
		{
			_isEditingTags = false;
		}

		partial void StartEditingButton_TouchUpInside (UIButton sender)
		{
			_isEditingTags = true;
		}

		#endregion

		#region IUgiInventoryDelegate implementation

		public void InventoryDidStart ()
		{
			Console.WriteLine ("Inventory Did Start");
		}

		public void InventoryDidStop (UgiInventory.InventoryResults result)
		{
			Console.WriteLine ("Inventory Did Stop");
		}

		public bool InventoryFilter (UgiEpc epc)
		{
			return false;
		}

		public void InventoryTagChanged (UgiTag tag, bool firstFind)
		{
			
		}

		public void InventoryTagFound (UgiTag tag, UgiDetailedPerReadData[] detailedPerReadData)
		{
			var epcTag = tag.Epc.ToString ();

			if (!_isEditingTags)
			{
				var shouldAddNewLine = !string.IsNullOrEmpty (TagsTextView.Text);

				if (shouldAddNewLine)
					TagsTextView.Text += "\n" + epcTag;
				else
					TagsTextView.Text += epcTag;	
			}
			else
			{
				CurrentTagEPCLabel.Text = epcTag.ToString ();
			}
		}

		public void InventoryTagSubsequentFinds (UgiTag tag, int count, UgiDetailedPerReadData[] detailedPerReadData)
		{
			Console.WriteLine ("Inventory subsequent finds");
		}

		public void InventoryHistoryInterval ()
		{
			
		}

		#endregion
	}
}

