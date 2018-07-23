using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using System;
using Android.Util;

namespace AlertDialog_0
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		string[] sports = {"football", "baseball", "tennis", "golf"};

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			Button btn1 = FindViewById<Button>(Resource.Id.button1);
			Button btn2 = FindViewById<Button>(Resource.Id.button2);

			btn1.Click += delegate {
				Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
				builder.SetMessage("hi there!");

				// ----- OPTIONAL -----
				builder.SetTitle("Title");
				builder.SetPositiveButton("Ok", OkAction);
				builder.SetNegativeButton("Cancel", CancelAction);
				// ----- OPTIONAL -----

				var alert = builder.Create();
				alert.Show();
			};

			btn2.Click += delegate {
				Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
				builder.SetTitle("Choose one:");
				builder.SetItems(sports, ChooseItem);
				builder.SetNegativeButton("Cancel", CancelAction);
				var alert = builder.Create();
				alert.Show();
			};
		}

		private void ChooseItem(object sender, DialogClickEventArgs e)
		{
			var index = e.Which;
			Log.Debug("=== DEBUG ===", sports[index]);
		}

		private void CancelAction(object sender, DialogClickEventArgs e)
		{
			Log.Debug("=== DEBUG ===", "Cancel clicked!");
		}

		private void OkAction(object sender, DialogClickEventArgs e)
		{
			Log.Debug("=== DEBUG ===", "Ok clicked!");
		}
	}
}

