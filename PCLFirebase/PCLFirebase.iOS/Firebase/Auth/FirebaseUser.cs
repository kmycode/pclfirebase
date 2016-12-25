using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Firebase.iOS.Auth;
using Foundation;
using PCLFirebase.Auth;
using PCLFirebase.Common;

namespace PCLFirebase.iOS.Auth
{
	class FirebaseUser : IFirebaseUser
	{
		private FIRUser _user;

		public FirebaseUser(FIRUser user)
		{
			this._user = user;
		}
		
		public string DisplayName
		{
			get
			{
				return this._user.ProviderData[0].ValueForKey(new NSString("displayName")).ToString();
			}
		}

		public string Email
		{
			get
			{
				return this._user.ProviderData[0].ValueForKey(new NSString("email")).ToString();
			}
		}

		public bool IsAnonymous
		{
			get
			{
				return this.IsAnonymous;
			}
		}

		public bool IsEmailVerified
		{
			get
			{
				return this.IsEmailVerified;
			}
		}

		public string PhotoUrl
		{
			get
			{
				return this._user.ProviderData[0].ValueForKey(new NSString("photoURL")).ToString();
			}
		}

		public ICollection<IFirebaseUserInfo> ProviderDatas
		{
			get
			{
				var result = new Collection<IFirebaseUserInfo>();
				var datas = this._user.ProviderData;
				foreach (var data in datas)
				{
					result.Add(new FirebaseUserInfo(data));
				}
				return result;
			}
		}

		public string ProviderId
		{
			get
			{
				return this._user.ProviderData[0].ValueForKey(new NSString("providerID")).ToString();
			}
		}

		public string Uid
		{
			get
			{
				return this._user.ProviderData[0].ValueForKey(new NSString("uid")).ToString();
			}
		}

		public void Delete(Action<FirebaseAuthError> callback)
		{
			this._user.DeleteWithCompletion((err) =>
			{
				if (err == null)
				{
					callback(FirebaseAuthError.None);
				}
				else
				{
					callback(FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}

		public void UpdateDisplayName(string newName, Action<FirebaseAuthError> callback)
		{
			this._user.ProfileChangeRequest.DisplayName = newName;
			this._user.ProfileChangeRequest.CommitChangesWithCompletion((err) =>
			{
				if (err == null)
				{
					callback(FirebaseAuthError.None);
				}
				else
				{
					callback(FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}

		public void UpdateEmail(string newEmail, Action<FirebaseAuthError> callback)
		{
			this._user.UpdateEmail(newEmail, (err) =>
			{
				if (err == null)
				{
					callback(FirebaseAuthError.None);
				}
				else
				{
					callback(FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}

		public void UpdatePassword(string newPassword, Action<FirebaseAuthError> callback)
		{
			this._user.UpdatePassword(newPassword, (err) =>
			{
				if (err == null)
				{
					callback(FirebaseAuthError.None);
				}
				else
				{
					callback(FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}
	}
}