using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

using UGrokItApi;

namespace ApiDemoAndroid
{
  [Application]
  public class MyApp : Android.App.Application {
    public MyApp(IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
    {
    }

    public override void OnCreate()
    {
      base.OnCreate();
      Ugi.CreateSingleton (this);
      //Ugi.Singleton().LoggingStatus = Ugi.LoggingTypes.State | Ugi.LoggingTypes.Inventory;
      Ugi.Singleton().OpenConnection ();
    }

  }

  //----------------------------------------------------------------------------

  [Activity (Label = "ApiDemoAndroid", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity, IUgiInventoryDelegate
  {

    private UgiRfidConfiguration.InventoryTypes inventoryType = UgiRfidConfiguration.InventoryTypes.LocateDistance;
    private OurListAdapter listAdapter;
    private UgiTag selectedTag;

    protected override void OnCreate (Bundle savedInstanceState)
    {
      base.OnCreate (savedInstanceState);

      Ugi.Singleton().ActivityOnCreate (this, true);

      // Set our view from the "main" layout resource
      SetContentView (Resource.Layout.Main);

      ListView tagListView = FindViewById<ListView>(Resource.Id.tagList);
      listAdapter = new OurListAdapter(this);
      tagListView.Adapter = listAdapter;
      tagListView.ItemClick += tagListView_ItemClick;

      ToggleButton tv = FindViewById<ToggleButton> (Resource.Id.inventoryToggleButton);
      tv.Click += doStartStopInventory;

      ConnectionStateHandler (Ugi.ConnectionStates.NotConnected);
      Ugi.Singleton ().ConnectionStateChanged += ConnectionStateHandler;
    }

    protected override void OnDestroy ()
    {
      base.OnDestroy ();
      Ugi.Singleton ().ConnectionStateChanged -= ConnectionStateHandler;
      Ugi.Singleton().ActivityOnDestroy (this);
    }

    protected override void OnResume ()
    {
      base.OnDestroy ();
      Ugi.Singleton().ActivityOnResume (this);
    }

    protected override void OnPause ()
    {
      base.OnDestroy ();
      Ugi.Singleton().ActivityOnPause (this);    
    }

    //--------------------------------------------------------------------------
    // Connection state
    //--------------------------------------------------------------------------

    void ConnectionStateHandler(Ugi.ConnectionStates state) {
      if (Ugi.Singleton().IsConnected) {
        FindViewById<Button> (Resource.Id.batteryButton).Visibility = ViewStates.Visible;
        FindViewById<Button> (Resource.Id.configureButton).Visibility = ViewStates.Visible;
        FindViewById<Button> (Resource.Id.audioReconfigureButton).Visibility = ViewStates.Visible;
        FindViewById<TextView> (Resource.Id.disconnectedTextView).Visibility = ViewStates.Invisible;
      } else {
        FindViewById<Button> (Resource.Id.batteryButton).Visibility = ViewStates.Invisible;
        FindViewById<Button> (Resource.Id.configureButton).Visibility = ViewStates.Invisible;
        FindViewById<Button> (Resource.Id.audioReconfigureButton).Visibility = ViewStates.Invisible;
        FindViewById<TextView> (Resource.Id.disconnectedTextView).Visibility = ViewStates.Visible;
        TextView tv = FindViewById<TextView> (Resource.Id.disconnectedTextView);
        if (Ugi.Singleton().ConnectionState == Ugi.ConnectionStates.NotConnected) {
          tv.Text = "Not Connected";
        } else {
          tv.Text = "Connecting";
        }
      }
    }

    //--------------------------------------------------------------------------
    // Inventory
    //--------------------------------------------------------------------------

    void doStartStopInventory(object sender, EventArgs e) {
      ToggleButton tb = FindViewById<ToggleButton> (Resource.Id.inventoryToggleButton);
      if (tb.Checked) {
        UgiRfidConfiguration config = UgiRfidConfiguration.ConfigWithInventoryType (inventoryType);
        Ugi.Singleton ().StartInventory (this, config);
        this.selectedTag = null;
        FindViewById<Button> (Resource.Id.batteryButton).Enabled = false;
        FindViewById<Button> (Resource.Id.configureButton).Enabled = false;
        FindViewById<Button> (Resource.Id.audioReconfigureButton).Enabled = false;
        FindViewById<View>(Resource.Id.line4).Visibility = ViewStates.Visible;
        FindViewById<Button> (Resource.Id.commissionButton).Enabled = false;
        FindViewById<Button> (Resource.Id.readTagButton).Enabled = false;
        FindViewById<Button> (Resource.Id.writeTagButton).Enabled = false;
        UpdateTable ();
      } else {
        Ugi.Singleton ().ActiveInventory.StopInventory (() => {
          FindViewById<View>(Resource.Id.line4).Visibility = ViewStates.Invisible;
          FindViewById<Button> (Resource.Id.batteryButton).Enabled = true;
          FindViewById<View>(Resource.Id.configureButton).Enabled = true;
          FindViewById<View>(Resource.Id.audioReconfigureButton).Enabled = true;
        });
      }
    }

    public void InventoryDidStart() {
    }

    public void InventoryDidStop(UgiInventory.InventoryResults result) {
      if (result == UgiInventory.InventoryResults.LostConnection) {
      } else {
        if (result != UgiInventory.InventoryResults.Ok) {
          ToggleButton inventoryToggle = FindViewById<ToggleButton>(Resource.Id.inventoryToggleButton);
          if (inventoryToggle.Checked) {
            inventoryToggle.Checked = false;
            FindViewById<View>(Resource.Id.line4).Visibility = ViewStates.Invisible;
            FindViewById<Button> (Resource.Id.batteryButton).Enabled = true;
            FindViewById<View>(Resource.Id.configureButton).Enabled = true;
            FindViewById<View>(Resource.Id.audioReconfigureButton).Enabled = true;
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
      UpdateTable();
    }

    public void InventoryTagFound(UgiTag tag, UgiDetailedPerReadData[] detailedPerReadData) {
    }

    public void InventoryTagSubsequentFinds(UgiTag tag, int count,
                                     UgiDetailedPerReadData[] detailedPerReadData) {
    }

    public void InventoryHistoryInterval() {
      UpdateTable();
    }

    //--------------------------------------------------------------------------
    // List View
    //--------------------------------------------------------------------------

    private void UpdateTable() {
      listAdapter.NotifyDataSetChanged();
    }

    private class OurListAdapter : BaseAdapter<UgiTag> {

      readonly MainActivity mainActivity;

      public OurListAdapter(MainActivity mainActivity) : base() {
        this.mainActivity = mainActivity;
      }

      override public bool HasStableIds {
        get { return true; }
      }

      public override long GetItemId(int position)
      {
        return position;
      }


      override public int Count {
        get {
          UgiInventory inventory = Ugi.Singleton ().ActiveInventory;
          return inventory != null ? inventory.Tags.Count : 0;
        }
      }

      public override UgiTag this[int position] {  
        get {
          List<UgiTag> tags = Ugi.Singleton ().ActiveInventory.Tags;
          return position < tags.Count ? tags [position] : null;
        }
      }

      override public View GetView(int position, View convertView, ViewGroup parent) {
        UgiInventory inventory = Ugi.Singleton ().ActiveInventory;
        if (inventory == null) {
          return convertView;
        }
        UgiRfidConfiguration config = inventory.Configuration;
        if (convertView == null) {
          convertView = mainActivity.LayoutInflater.Inflate(config.ReportSubsequentFinds ? Resource.Layout.list_item : Resource.Layout.list_item_no_history, null);
          convertView.Click += (object sender, EventArgs e) => {
            //
          };
        }
        ListView lv = mainActivity.FindViewById<ListView>(Resource.Id.tagList);
        if (lv.CheckedItemPositions.Get(position)) {
          convertView.SetBackgroundColor(Color.ParseColor("#888888"));
        } else {
          convertView.SetBackgroundColor(Color.ParseColor("#222222"));
        }

        TextView tv = convertView.FindViewById<TextView>(Resource.Id.listItemText);
        tv.Text = "Item " + position;

        List<UgiTag> tags = Ugi.Singleton ().ActiveInventory.Tags;
        if (position < tags.Count) {
          UgiTag tag = tags[position];
          tv.Text = tag.Epc.ToString();
          if (config.ReportSubsequentFinds) {
            tv = convertView.FindViewById<TextView>(Resource.Id.listItemDetail);
            tv.Text = tag.ReadState.ReadHistoryString;
          }
        }
        return convertView;
      }

    }

    void tagListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
      this.selectedTag = listAdapter [e.Position];
      FindViewById<Button> (Resource.Id.commissionButton).Enabled = true;
      FindViewById<Button> (Resource.Id.readTagButton).Enabled = true;
      FindViewById<Button> (Resource.Id.writeTagButton).Enabled = true;
    }

    //--------------------------------------------------------------------------
    // Tag actions
    //--------------------------------------------------------------------------

    private const int READ_WRITE_OFFSET = 0;
    private const int READ_WRITE_MIN_BYTES = 16;
    private const int READ_WRITE_MAX_BYTES = 64;

    [Java.Interop.Export("doCommission")]
    public void doCommission(View v) {
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

    [Java.Interop.Export("doReadTag")]
    public void doReadTag(View v) {
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

    [Java.Interop.Export("doWriteTag")]
    public void doWriteTag(View v) {
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

    [Java.Interop.Export("doInfo")]
    public void doInfo (View v) {
      String grokker = "Not Connected";
      if (Ugi.Singleton ().IsConnected) {
        grokker = Ugi.Singleton ().ReaderDescription;
      }
      String message = "SDK " + Ugi.Singleton ().SdkVersionMajor + "." +
        Ugi.Singleton ().SdkVersionMinor + "." + Ugi.Singleton ().SdkVersionBuild + "\n" + grokker;
      ShowOkCancel ("Info", message, "", null, null, null);
    }

    [Java.Interop.Export("doBattery")]
    public void doBattery (View v) {
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

    private static string[] inventoryTypeNames = new String[] {
      //"Manual Configuration",
      "Locate Distance",
      "Inventory Short Range",
      "Inventory Distance",
      "Locate Short Range",
      "Locate Very Short Range"
    };

    [Java.Interop.Export("doConfigure")]
    public void doConfigure (View v) {
      this.ShowChoices ("Inventory Type",
                       "Set Type",
                       "",
                       inventoryTypeNames,
                       (int)inventoryType - 1,
                       (int choiceIndex, String choice) => {
                          this.inventoryType = (UgiRfidConfiguration.InventoryTypes) (choiceIndex + 1);
                       },
                       null);
    }

    [Java.Interop.Export("doAudio")]
    public void doAudio (View v) {
      Ugi.Singleton ().InvokeAudioReconfiguration ();
    }

    [Java.Interop.Export("doJack")]
    public void doJack (View v) {
      Ugi.Singleton ().InvokeAudioJackLocation ();
    }

    //--------------------------------------------------------------------------
    // UI
    //--------------------------------------------------------------------------

    public delegate void VoidDelegate();

    public delegate void ShowChoicesDelegate(int choiceIndex, String choice);

    private AlertDialog ShowChoices(String title,
                                     String actionButtonTitle,
                                     String cancelButtonTitle,
                                     string[] choices,
                                     int initialSelectedIndex,
                                     ShowChoicesDelegate showChoicesDelegate,
                                     VoidDelegate cancelDelegate) {
      AlertDialog.Builder builder = new AlertDialog.Builder(this);
      builder.SetTitle(title);
      int choice = initialSelectedIndex;
      builder.SetSingleChoiceItems(choices, initialSelectedIndex,
                                   (senderAlert, args) => {
        choice = args.Which;
        });
      if (actionButtonTitle == "") {
        actionButtonTitle = "ok";
      }
      builder.SetPositiveButton(actionButtonTitle, (senderAlert, args) => {
        showChoicesDelegate(choice, choices[choice]);
      });
      if (cancelButtonTitle != null) {
        if (cancelButtonTitle == "") {
          cancelButtonTitle = "cancel";
        }
        builder.SetNegativeButton(cancelButtonTitle, (senderAlert, args) => {
          if (cancelDelegate != null) {
            cancelDelegate();
          }
        });
      } else {
        builder.SetCancelable(false);
      }
      return builder.Show();
    }

    //--------------

    private AlertDialog ShowOkCancel(String title, String message, String okButtonTitle,
                                     String cancelButtonTitle, VoidDelegate okDekegate,
                                     VoidDelegate cancelDelegate) {
      AlertDialog.Builder builder = new AlertDialog.Builder(this);
      builder.SetTitle(title);
      builder.SetMessage(message);
      if (okButtonTitle != null) {
        if (okButtonTitle == "") {
          okButtonTitle = "ok";
        }
        builder.SetPositiveButton(okButtonTitle, (senderAlert, args) => {
          if (okDekegate != null) {
            okDekegate();
          }
        });
      }
      if (cancelButtonTitle != null) {
        if (cancelButtonTitle == "") {
          cancelButtonTitle = "cancel";
        }
        builder.SetNegativeButton(cancelButtonTitle, (senderAlert, args) => {
          if (cancelDelegate != null) {
            cancelDelegate();
          }
        });
      } else {
        builder.SetCancelable(false);
      }
      return builder.Show();
    }

  }
}


