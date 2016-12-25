using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Firebase.iOS.Auth;
using Foundation;
using PCLFirebase.Auth;

namespace PCLFirebase.iOS.Auth
{
	class FirebaseUserInfo : IFirebaseUserInfo
	{
		private NSObject _userInfo;

		public FirebaseUserInfo(NSObject userInfo)
		{
			this._userInfo = userInfo;
		}
	}
}