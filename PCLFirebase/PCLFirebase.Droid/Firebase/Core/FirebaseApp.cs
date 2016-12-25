using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PCLFirebase.Auth;
using PCLFirebase.Config;
using PCLFirebase.Core;
using PCLFirebase.Database;
using PCLFirebase.Droid.Auth;
using PCLFirebase.Droid.Storage;
using PCLFirebase.Storage;

namespace PCLFirebase.Droid.Core
{
	class FirebaseApp : IFirebaseApp
	{
		public FirebaseApp(Context context, Firebase.FirebaseOptions options)
		{
			Firebase.FirebaseApp.InitializeApp(context, options);
		}

		public IFirebaseAuth Auth
		{
			get
			{
				return FirebaseAuth.Instance;
			}
		}

		public IFirebaseConfig Config
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IFirebaseDatabase Database
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IFirebaseStorage Storage
		{
			get
			{
				return FirebaseStorage.Instance;
			}
		}
	}
}