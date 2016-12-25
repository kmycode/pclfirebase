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
using PCLFirebase.Common;

namespace PCLFirebase.Droid.Auth
{
	class FirebaseUserInfo : IFirebaseUserInfo
	{
		private Firebase.Auth.IUserInfo _userInfo;

		public FirebaseUserInfo(Firebase.Auth.IUserInfo userInfo)
		{
			this._userInfo = userInfo;
		}
	}
}