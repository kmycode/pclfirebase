using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Auth;
using PCLFirebase.Config;
using PCLFirebase.Core;
using PCLFirebase.Database;
using PCLFirebase.Storage;
using PCLFirebase.WPF.Auth;
using PCLFirebase.WPF.Storage;

namespace PCLFirebase.WPF.Core
{
	class FirebaseApp : IFirebaseApp
	{
		global::Firebase.Windows.Core.FirebaseApp _app;

		public FirebaseApp(Firebase.Windows.Core.FirebaseAppOptions options)
		{
			this._app = new Firebase.Windows.Core.FirebaseApp(options);
		}

		public IFirebaseAuth Auth
		{
			get
			{
				return new FirebaseAuth(this._app.Auth());
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
				return new FirebaseStorage(this._app.Storage());
			}
		}
	}
}
