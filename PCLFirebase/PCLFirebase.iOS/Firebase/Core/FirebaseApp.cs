using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.iOS.Analytics;
using Firebase.iOS.Auth;
using PCLFirebase.Auth;
using PCLFirebase.Config;
using PCLFirebase.Core;
using PCLFirebase.Database;
using PCLFirebase.iOS.Auth;
using PCLFirebase.iOS.Storage;
using PCLFirebase.Storage;

namespace PCLFirebase.iOS.Core
{
	class FirebaseApp : IFirebaseApp
	{
		public FirebaseApp()
		{
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