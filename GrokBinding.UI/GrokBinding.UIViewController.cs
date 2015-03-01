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

		async partial void ConnectButton_TouchUpInside (UIButton sender)
		{
			if (!CurrentUgi.IsAnythingPluggedIntoAudioJack)
			{
				new UIAlertView ("Error", "Nothing plugged into audio port", null, "OK", null).Show ();
				return;
			}

			ConnectionStateLabel.Text = "Connecting...";

			await Task.Run (async () =>
			{
				await Task.Delay (2000);
				CurrentUgi.OpenConnection ();
			});
		}

		async partial void DisconnectButton_TouchUpInside (UIButton sender)
		{
			if (!CurrentUgi.IsAnythingPluggedIntoAudioJack)
			{
				new UIAlertView ("Error", "Nothing plugged into audio port", null, "OK", null).Show ();
				return;
			}

			ConnectionStateLabel.Text = "Disconnecting...";

			await Task.Run (async () =>
			{
				await Task.Delay (2000);
				CurrentUgi.CloseConnection ();
			});
		}

		async partial void ReadTagsStartButton_TouchUpInside (UIButton sender)
		{
			ConnectionStateLabel.Text = "Starting Read...";
			await Task.Run (async () =>
			{
				await Task.Delay (1000);

				UgiRfidConfiguration config = UgiRfidConfiguration.ConfigWithInventoryType (UgiRfidConfiguration.InventoryTypes.LocateVeryShortRange);
				config.SoundType = UgiRfidConfiguration.SoundTypes.None;

				_runningInventory = CurrentUgi.StartInventory(this, config);
			});

			ConnectionStateLabel.Text = "Readings tags...";
		}

		async partial void ReadTagsStopButton_TouchUpInside (UIButton sender)
		{
			ConnectionStateLabel.Text = "Stopping Read...";
			await Task.Run (async () =>
			{
				await Task.Delay (1000);

				if (_runningInventory != null || CurrentUgi.ActiveInventory != null)
					_runningInventory.StopInventory (() => {});
			});
		}

		#endregion

		#region IUgiInventoryDelegate implementation

		public void InventoryDidStart ()
		{
			throw new NotImplementedException ();
		}

		public void InventoryDidStop (UgiInventory.InventoryResults result)
		{
			throw new NotImplementedException ();
		}

		public bool InventoryFilter (UgiEpc epc)
		{
			throw new NotImplementedException ();
		}

		public void InventoryTagChanged (UgiTag tag, bool firstFind)
		{
			throw new NotImplementedException ();
		}

		public void InventoryTagFound (UgiTag tag, UgiDetailedPerReadData[] detailedPerReadData)
		{
			throw new NotImplementedException ();
		}

		public void InventoryTagSubsequentFinds (UgiTag tag, int count, UgiDetailedPerReadData[] detailedPerReadData)
		{
			throw new NotImplementedException ();
		}

		public void InventoryHistoryInterval ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

