using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
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
	class FirebaseAuth : IFirebaseAuth
	{
		private Firebase.Auth.FirebaseAuth _auth;
		public static FirebaseAuth Instance { get; } = new FirebaseAuth();

		private FirebaseAuth()
		{
			this._auth = Firebase.Auth.FirebaseAuth.Instance;
		}

		public static FirebaseAuthError GetAuthError(Exception e)
		{
			if (e is FirebaseAuthException)
			{
				return FirebaseAuthError.Unknown;
			}
			return FirebaseAuthError.Unknown;
		}

		public IFirebaseUser CurrentUser
		{
			get
			{
				return new FirebaseUser(this._auth.CurrentUser);
			}
		}

		public void CreateEmailPasswordUser(string email, string password, Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			try
			{
				this._auth.CreateUserWithEmailAndPassword(email, password).AddOnCompleteListener(new OnCompleteListener((task) =>
				{
					if (task.IsSuccessful)
					{
						callback(this.CurrentUser, FirebaseAuthError.None);
					}
					else
					{
						callback(null, FirebaseAuth.GetAuthError(task.Exception));
					}
				}));
			}
			catch (Exception e)
			{
				callback(null, FirebaseAuth.GetAuthError(e));
			}
		}

		public void SignInWithEmailPassword(string email, string password, Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			try
			{
				this._auth.SignInWithEmailAndPassword(email, password).AddOnCompleteListener(new OnCompleteListener((task) =>
				{
					if (task.IsSuccessful)
					{
						callback(this.CurrentUser, FirebaseAuthError.None);
					}
					else
					{
						callback(null, FirebaseAuth.GetAuthError(task.Exception));
					}
				}));
			}
			catch (Exception e)
			{
				callback(null, FirebaseAuth.GetAuthError(e));
			}
		}

		public void SignInAnonymously(Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			try
			{
				this._auth.SignInAnonymously().AddOnCompleteListener(new OnCompleteListener((task) =>
				{
					if (task.IsSuccessful)
					{
						callback(this.CurrentUser, FirebaseAuthError.None);
					}
					else
					{
						callback(null, FirebaseAuth.GetAuthError(task.Exception));
					}
				}));
			}
			catch (Exception e)
			{
				callback(null, FirebaseAuth.GetAuthError(e));
			}
		}

		public void SignOut(Action<FirebaseAuthError> callback)
		{
			this._auth.SignOut();
			callback(FirebaseAuthError.None);
		}
	}
}