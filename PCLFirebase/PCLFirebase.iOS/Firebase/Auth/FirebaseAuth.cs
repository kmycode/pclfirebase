using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.iOS.Auth;
using Foundation;
using PCLFirebase.Auth;
using PCLFirebase.Common;

namespace PCLFirebase.iOS.Auth
{
	class FirebaseAuth : IFirebaseAuth
	{
		private FIRAuth _auth;
		public static FirebaseAuth Instance { get; } = new FirebaseAuth();

		private FirebaseAuth()
		{
			this._auth = FIRAuth.Auth;
		}

		public static FirebaseAuthError GetAuthError(FIRAuthErrorCode code)
		{
			switch (code)
			{
				case FIRAuthErrorCode.orCodeEmailAlreadyInUse:
					return FirebaseAuthError.EmailAlreadyInUse;
				case FIRAuthErrorCode.orCodeInvalidEmail:
					return FirebaseAuthError.InvalidUser;
				case FIRAuthErrorCode.orCodeOperationNotAllowed:
					return FirebaseAuthError.OperationNotAllowed;
				case FIRAuthErrorCode.orCodeRequiresRecentLogin:
					return FirebaseAuthError.RequiresRecentLogin;
				case FIRAuthErrorCode.orCodeUserDisabled:
					return FirebaseAuthError.UserDisabled;
				case FIRAuthErrorCode.orCodeUserNotFound:
					return FirebaseAuthError.UserNotFound;
				case FIRAuthErrorCode.orCodeWeakPassword:
					return FirebaseAuthError.WeakPassword;
				case FIRAuthErrorCode.orCodeWrongPassword:
					return FirebaseAuthError.WrongPassword;
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
			this._auth.CreateUserWithEmail(email, password, (user, err) =>
			{
				if (err == null)
				{
					callback(new FirebaseUser(user), FirebaseAuthError.None);
				}
				else
				{
					callback(null, FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}

		public void SignInWithEmailPassword(string email, string password, Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			this._auth.SignInWithEmail(email, password, (user, err) =>
			{
				if (err == null)
				{
					callback(new FirebaseUser(user), FirebaseAuthError.None);
				}
				else
				{
					callback(null, FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}

		public void SignInAnonymously(Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			this._auth.SignInAnonymouslyWithCompletion((user, err) =>
			{
				if (err == null)
				{
					callback(new FirebaseUser(user), FirebaseAuthError.None);
				}
				else
				{
					callback(null, FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
				}
			});
		}

		public void SignOut(Action<FirebaseAuthError> callback)
		{
			NSError err;
			this._auth.SignOut(out err);
			callback(err == null ? FirebaseAuthError.None : FirebaseAuth.GetAuthError((FIRAuthErrorCode)(uint)err.Code));
		}
	}
}