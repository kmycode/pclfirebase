using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using PCLFirebase.Auth;
using PCLFirebase.Common;
using PCLFirebase.Droid.Core;

namespace PCLFirebase.Droid.Auth
{
	class FirebaseUser : IFirebaseUser
	{
		private Firebase.Auth.FirebaseUser _user;

		public FirebaseUser(Firebase.Auth.FirebaseUser user)
		{
			this._user = user;
		}
		
		public string DisplayName
		{
			get
			{
				return this._user.DisplayName;
			}
		}

		public string Email
		{
			get
			{
				return this._user.Email;
			}
		}

		public bool IsAnonymous
		{
			get
			{
				return this._user.IsAnonymous;
			}
		}

		public bool IsEmailVerified
		{
			get
			{
				return true;
			}
		}

		public string PhotoUrl
		{
			get
			{
				return this._user.PhotoUrl.ToString();
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
				return this._user.ProviderId;
			}
		}

		public string Uid
		{
			get
			{
				return this._user.Uid;
			}
		}

		public void Delete(Action<FirebaseAuthError> callback)
		{
			try
			{
				this._user.Delete().AddOnCompleteListener(new OnCompleteListener((task) =>
				{
					if (task.IsSuccessful)
					{
						callback(FirebaseAuthError.None);
					}
					else
					{
						callback(FirebaseAuth.GetAuthError(task.Exception));
					}
				}));
			}
			catch (Exception e)
			{
				callback(FirebaseAuth.GetAuthError(e));
			}
		}

		public void UpdateDisplayName(string newName, Action<FirebaseAuthError> callback)
		{
			try
			{
				this._user.UpdateProfile(
					new UserProfileChangeRequest.Builder().SetDisplayName(newName).Build());
				callback(FirebaseAuthError.None);
			}
			catch (Exception e)
			{
				callback(FirebaseAuth.GetAuthError(e));
			}
		}

		public void UpdateEmail(string newEmail, Action<FirebaseAuthError> callback)
		{
			try
			{
				this._user.UpdateEmail(newEmail).AddOnCompleteListener(new OnCompleteListener((task) =>
				{
					if (task.IsSuccessful)
					{
						callback(FirebaseAuthError.None);
					}
					else
					{
						callback(FirebaseAuth.GetAuthError(task.Exception));
					}
				}));
			}
			catch (Exception e)
			{
				callback(FirebaseAuth.GetAuthError(e));
			}
		}

		public void UpdatePassword(string newPassword, Action<FirebaseAuthError> callback)
		{
			try
			{
				this._user.UpdatePassword(newPassword).AddOnCompleteListener(new OnCompleteListener((task) =>
				{
					if (task.IsSuccessful)
					{
						callback(FirebaseAuthError.None);
					}
					else
					{
						callback(FirebaseAuth.GetAuthError(task.Exception));
					}
				}));
			}
			catch (Exception e)
			{
				callback(FirebaseAuth.GetAuthError(e));
			}
		}
	}
}