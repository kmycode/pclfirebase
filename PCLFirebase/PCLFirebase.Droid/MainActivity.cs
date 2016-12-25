using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PCLFirebase.Core;

namespace PCLFirebase.Droid
{
	[Activity(Label = "PCLFirebase.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			FirebaseApp.SetFirebaseApp(new PCLFirebase.Droid.Core.FirebaseApp(this,
											new Firebase.FirebaseOptions.Builder().SetApiKey("<Your API Key>")
																					.SetApplicationId("<Your Id>")
																					.SetDatabaseUrl("<Your Url>")
																					.SetStorageBucket("<Your Bucket>")
																					.Build()));

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}
	}
}

