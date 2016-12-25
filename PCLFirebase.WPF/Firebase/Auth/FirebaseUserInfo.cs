using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Auth;

namespace PCLFirebase.WPF.Auth
{
	class FirebaseUserInfo : IFirebaseUserInfo
	{
		private Firebase.Windows.Auth.FirebaseUserInfo _userInfo;

		public FirebaseUserInfo(Firebase.Windows.Auth.FirebaseUserInfo userInfo)
		{
			this._userInfo = userInfo;
		}
	}
}
