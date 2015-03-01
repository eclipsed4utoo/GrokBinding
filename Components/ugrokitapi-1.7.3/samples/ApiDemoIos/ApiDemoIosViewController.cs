using System;
using System.Drawing;
using System.Collections.Generic;

using Foundation;
using UIKit;

using UGrokItApi;

namespace ApiDemoIos
{
  public partial class ApiDemoIosViewController : UIViewController, IUgiInventoryDelegate,
                                                  IUITableViewDataSource, IUITableViewDelegate
  {

    private UgiRfidConfiguration.InventoryTypes inventoryType = UgiRfidConfiguration.InventoryTypes.LocateDistance;

    private UgiTag selectedTag;

    //-----------------------

    public ApiDemoIosViewController (IntPtr handle) : base (handle)
    {
    }

    #region View lifecycle

    public override void ViewDidLoad ()
    {
      base.ViewDidLoad ();
      tableView.DataSource = this;
      tableView.Delegate = this;
      commissionButton.Hidden = true;
      readButton.Hidden = true;
      writeButton.Hidden = true;

      ConnectionStateHandler (Ugi.ConnectionStates.NotConnected);
      Ugi.Singleton ().ConnectionStateChanged += ConnectionStateHandler;
    }

    #endregion

    //--------------------------------------------------------------------------
    // Connection state
    //--------------------------------------------------------------------------

    void ConnectionStateHandler(Ugi.ConnectionStates state) {
      if (Ugi.Singleton().IsConnected) {
        batteryButton.Hidden = false;
        configureButton.Hidden = false;
        connectionStateLabel.Hidden = true;
      } else {
        batteryButton.Hidden = true;
        configureButton.Hidden = true;
        connectionStateLabel.Hidden = false;
        if (Ugi.Singleton().ConnectionState == Ugi.ConnectionStates.NotConnected) {
          connectionStateLabel.Text = "Not Connected";
        } else {
          connectionStateLabel.Text = "Connecting";
        }
      }
    }

    //--------------------------------------------------------------------------
    // Inventory
    //--------------------------------------------------------------------------

    partial void inventorySwitch_ValueChanged (UISwitch sender)
    {
      if (inventorySwitch.On) {
        selectedTag = null;
        UgiRfidConfiguration config = UgiRfidConfiguration.ConfigWithInventoryType (inventoryType);
        Ugi.Singleton ().StartInventory (this, config);
        batteryButton.Enabled = false;
        configureButton.Enabled = false;
        commissionButton.Hidden = false;
        readButton.Hidden = false;
        writeButton.Hidden = false;
        commissionButton.Enabled = false;
        readButton.Enabled = false;
        writeButton.Enabled = false;
        tableView.ReloadData();
      } else {
        Ugi.Singleton ().ActiveInventory.StopInventory (() => {
          batteryButton.Enabled = true;
          configureButton.Enabled = true;
          commissionButton.Hidden = true;
          readButton.Hidden = true;
          writeButton.Hidden = true;
        });
      }
    }

    public void InventoryDidStart() {
    }

    public void InventoryDidStop(UgiInventory.InventoryResults result) {
      if (result == UgiInventory.InventoryResults.LostConnection) {
      } else {
        if (result != UgiInventory.InventoryResults.Ok) {
          if (inventorySwitch.On) {
            inventorySwitch.On = false;
            batteryButton.Enabled = true;
            configureButton.Enabled = true;
            commissionButton.Hidden = true;
            readButton.Hidden = true;
            writeButton.Hidden = true;
          }
          String message;
          if (result == UgiInventory.InventoryResults.BatteryTooLow) {
            message = "Battery level too low\nPlease charge the Grokker";
          } else if (result == UgiInventory.InventoryResults.TemperatureTooHigh) {
            message = "Temperature too high\nAllow the Grokker to cool down";
          } else if (result == UgiInventory.InventoryResults.NotProvisioned) {
            message = "Grokker is not provisioned";
          } else if (result == UgiInventory.InventoryResults.RegionNotSet) {
            message = "Region is not set";
          } else if (result == UgiInventory.InventoryResults.ErrorSending) {
            message = "Error communicating with Grokker";
          } else {
            message = "Grokker error: " + result;
          }
          ShowOkCancel("Inventory Error", message, "", null, null, null);
        }
      }
    }

    public bool InventoryFilter(UgiEpc epc) {
      return false;
    }

    public void InventoryTagChanged(UgiTag tag, bool firstFind) {
      tableView.ReloadData();
    }

    public void InventoryTagFound(UgiTag tag, UgiDetailedPerReadData[] detailedPerReadData) {
    }

    public void InventoryTagSubsequentFinds(UgiTag tag, int count,
                                            UgiDetailedPerReadData[] detailedPerReadData) {
    }

    public void InventoryHistoryInterval() {
      tableView.ReloadData();
    }

    //--------------------------------------------------------------------------
    // Table view
    //--------------------------------------------------------------------------

    public nint RowsInSection (UITableView tableview, nint section)
    {
      UgiInventory inventory = Ugi.Singleton ().ActiveInventory;
      return inventory != null ? inventory.Tags.Count : 0;
    }

    public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
      UgiInventory inventory = Ugi.Singleton ().ActiveInventory;
      if (inventory == null) {
        UITableViewCell cell = tableView.DequeueReusableCell ("InventoryCell");
        if (cell == null) {
          cell = new UITableViewCell (UITableViewCellStyle.Default, "InventoryCell");
        }
        return cell;
      } else {
        UgiRfidConfiguration config = inventory.Configuration;
        string cellIdentifier = config.ReportSubsequentFinds ? "LocateCell" : "InventoryCell";
        UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
        if (cell == null) {
          cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
        }
        List<UgiTag> tags = Ugi.Singleton ().ActiveInventory.Tags;
        if (indexPath.Row < tags.Count) {
          UgiTag tag = tags [indexPath.Row];
          cell.TextLabel.Text = tag.Epc.ToString ();
          if (config.ReportSubsequentFinds) {
            cell.DetailTextLabel.Text = tag.ReadState.ReadHistoryString;
          }
        } else {
          cell.TextLabel.Text = "Item #" + indexPath.Row;
        }
        return cell;
      }
    }

    [Export ("tableView:didSelectRowAtIndexPath:")]
    public void RowSelected (UITableView tableView, NSIndexPath indexPath)
    {
      List<UgiTag> tags = Ugi.Singleton ().ActiveInventory.Tags;
      if (indexPath.Row < tags.Count) {
        selectedTag = tags [indexPath.Row];
        commissionButton.Enabled = true;
        readButton.Enabled = true;
        writeButton.Enabled = true;
      }
    }

    //--------------------------------------------------------------------------
    // Tag actions
    //--------------------------------------------------------------------------

    private const int READ_WRITE_OFFSET = 0;
    private const int READ_WRITE_MIN_BYTES = 16;
    private const int READ_WRITE_MAX_BYTES = 64;

    partial void commissionButton_TouchUpInside (UIButton sender) {
      byte[] b = this.selectedTag.Epc.Bytes;
      for (int i = 0; i < b.Length; i++) {
        b [i] = (byte)(b [i] + 0x11);
      }
      UgiEpc newEpc = UgiEpc.FromBytes (b);
      Ugi.Singleton ().ActiveInventory.ProgramTag (this.selectedTag.Epc,
                                                   newEpc, UgiInventory.NO_PASSWORD,
                                                   (UgiTag tag, UgiInventory.TagAccessReturnValues result) => {
        if (result == UgiInventory.TagAccessReturnValues.Ok) {
          ShowOkCancel("commission", "Success, new Epc = " + newEpc, "", null, null, null);
        } else {
          ShowOkCancel("commission", "Failure: " + result, "", null, null, null);
        }
      });
    }

    partial void readButton_TouchUpInside (UIButton sender) {
      Ugi.Singleton ().ActiveInventory.ReadTag (this.selectedTag.Epc, UgiRfidConfiguration.MemoryBank.User,
                                                READ_WRITE_OFFSET, READ_WRITE_MIN_BYTES, READ_WRITE_MAX_BYTES,
                                                (UgiTag tag, byte[] data, UgiInventory.TagAccessReturnValues result) => {
        if (result == UgiInventory.TagAccessReturnValues.Ok) {
          ShowOkCancel("read", "Success, data = " + BitConverter.ToString(data).Replace("-", ""),
                       "", null, null, null);
        } else {
          ShowOkCancel("read", "Failure: " + result, "", null, null, null);
        }
      });
    }

    partial void writeButton_TouchUpInside (UIButton sender) {
      Ugi.Singleton ().ActiveInventory.ReadTag (this.selectedTag.Epc, UgiRfidConfiguration.MemoryBank.User,
                                                READ_WRITE_OFFSET, READ_WRITE_MIN_BYTES, READ_WRITE_MAX_BYTES,
                                                (UgiTag tag, byte[] data, UgiInventory.TagAccessReturnValues result) => {
        if (result == UgiInventory.TagAccessReturnValues.Ok) {
          byte[] newData = new byte[data.Length];
          for (int i = 0; i < data.Length; i++) {
            newData [i] = (byte)(data [i] + 0x11);
          }
          Ugi.Singleton ().ActiveInventory.WriteTag(this.selectedTag.Epc, UgiRfidConfiguration.MemoryBank.User,
                                                    READ_WRITE_OFFSET, newData, data,
                                                    UgiInventory.NO_PASSWORD,
                                                    (UgiTag tag2, UgiInventory.TagAccessReturnValues result2) => {
            if (result2 == UgiInventory.TagAccessReturnValues.Ok) {
              ShowOkCancel("write", "Success, data = " + BitConverter.ToString(newData).Replace("-", ""),
                           "", null, null, null);
            } else {
              ShowOkCancel("write", "Failure: " + result2, "", null, null, null);
            }
          });
        } else {
          ShowOkCancel("write", "Failure reading: " + result, "", null, null, null);
        }
      });
    }

    //--------------------------------------------------------------------------
    // Alerts
    //--------------------------------------------------------------------------

    partial void InfoButton_TouchUpInside (UIButton sender)
    {
      String grokker = "Not Connected";
      if (Ugi.Singleton ().IsConnected) {
        grokker = Ugi.Singleton ().ReaderDescription;
      }
      String message = "SDK " + Ugi.Singleton ().SdkVersionMajor + "." +
        Ugi.Singleton ().SdkVersionMinor + "." + Ugi.Singleton ().SdkVersionBuild + "\n" + grokker;
      ShowOkCancel ("Info", message, "", null, null, null);
    }

    partial void batteryButton_TouchUpInside (UIButton sender)
    {
      Ugi.BatteryInfo info = Ugi.Singleton().GetBatteryInfo ();
      String message;
      if (info != null) {
        if (info.ExternalPowerIsConnected) {
          if (info.IsCharging) {
            message = @"Charging";
          } else {
            message = @"Fully Charged";
          }
        } else {
          message = info.PercentRemaining + "%";
        }
      } else {
        message = "Can't read battery level";
      }
      ShowOkCancel ("Battery Level", message, "", null, null, null);
    }

    partial void configureButton_TouchUpInside (UIButton sender)
    {
      ShowOkCancel("Configuration", "Choose configuration", "Locate", "Inventory",
                   () => { this.inventoryType = UgiRfidConfiguration.InventoryTypes.LocateDistance; },
                   () => { this.inventoryType = UgiRfidConfiguration.InventoryTypes.InventoryDistance; });
    }

    //--------------------------------------------------------------------------
    // UI
    //--------------------------------------------------------------------------

    private delegate void VoidDelegate();

    private UIAlertView ShowOkCancel(String title, String message, String okButtonTitle,
      String cancelButtonTitle, VoidDelegate okDekegate,
      VoidDelegate cancelDelegate) {
      UIAlertView alertView = new UIAlertView ();
      alertView.Title = title;
      alertView.Message = message;
      if (cancelButtonTitle != null) {
        if (cancelButtonTitle == "") {
          cancelButtonTitle = "cancel";
        }
        alertView.AddButton (cancelButtonTitle);
      }
      if (okButtonTitle != null) {
        if (okButtonTitle == "") {
          okButtonTitle = "ok";
        }
        alertView.AddButton (okButtonTitle);
      }
      alertView.Clicked += (object sender, UIButtonEventArgs args) => {
        if (args.ButtonIndex >= 0) {
          if ((args.ButtonIndex == 1) || (cancelButtonTitle == null)) {
            if (okDekegate != null) {
              okDekegate();
            }
          } else {
            if (cancelDelegate != null) {
              cancelDelegate();
            }
          }
        }
      };
      alertView.Show ();
      return alertView;
    }

  }
}

