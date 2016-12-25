using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Auth;
using PCLFirebase.Common;

namespace PCLFirebase.WPF.Auth
{
	class FirebaseAuth : IFirebaseAuth
	{
		private Firebase.Windows.Auth.FirebaseAuth _auth;

		public FirebaseAuth(Firebase.Windows.Auth.FirebaseAuth auth)
		{
			this._auth = auth;

			this._authErrors.Add("auth/invalid-email", FirebaseAuthError.InvalidUser);
			this._authErrors.Add("auth/user-disabled", FirebaseAuthError.UserDisabled);
			this._authErrors.Add("auth/user-not-found", FirebaseAuthError.UserNotFound);
			this._authErrors.Add("auth/wrong-password", FirebaseAuthError.WrongPassword);
			this._authErrors.Add("auth/expired-action-code", FirebaseAuthError.ExpiredActionCode);
			this._authErrors.Add("auth/invalid-action-code", FirebaseAuthError.InvalidActionCode);
			this._authErrors.Add("auth/weak-password", FirebaseAuthError.WeakPassword);
			this._authErrors.Add("auth/email-already-in-use", FirebaseAuthError.EmailAlreadyInUse);
			this._authErrors.Add("auth/operation-not-allowed", FirebaseAuthError.OperationNotAllowed);
			this._authErrors.Add("auth/account-exists-with-different-credential", FirebaseAuthError.AccountExistsWithDifferentCredential);
			this._authErrors.Add("auth/auth-domain-config-required", FirebaseAuthError.AuthDomainConfigRequired);
			this._authErrors.Add("auth/credential-already-in-use", FirebaseAuthError.CredentialAlreadyInUse);
			this._authErrors.Add("auth/operation-not-supported-in-this-environment", FirebaseAuthError.OperationNotSupportedInThisEnvironment);
			this._authErrors.Add("auth/timeout", FirebaseAuthError.Timeout);
		}

		private Dictionary<string, FirebaseAuthError> _authErrors = new Dictionary<string, FirebaseAuthError>();
		private FirebaseAuthError GetAuthError(string code)
		{
			return _authErrors[code];
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
			var promise = this._auth.CreateUserWithEmailAndPassword(email, password);
			promise.Resolved += (sender, e) =>
			{
				callback(new FirebaseUser(Firebase.Windows.Core.FirebaseApp.Default.Auth().CurrentUser), FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(null, this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}

		public void SignInWithEmailPassword(string email, string password, Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			var promise = this._auth.SignInWithEmailAndPassword(email, password);
			promise.Resolved += (sender, e) =>
			{
				callback(new FirebaseUser(Firebase.Windows.Core.FirebaseApp.Default.Auth().CurrentUser), FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(null, this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}

		public void SignInWithTwitter(Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			Task.Run(async () =>
			{
				var promise = await this._auth.SignInWithTwitterAsync();
				promise.Resolved += (sender, e) =>
				{
					callback(new FirebaseUser(Firebase.Windows.Core.FirebaseApp.Default.Auth().CurrentUser), FirebaseAuthError.None);
				};
				promise.Rejected += (sender, e) =>
				{
					callback(null, this.GetAuthError(e.ErrorCode));
				};
				promise.StartReceiving();
			}).Wait();
		}

		public void SignInWithGithub(Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			Task.Run(async () =>
			{
				var promise = await this._auth.SignInWithGithubAsync();
				promise.Resolved += (sender, e) =>
				{
					callback(new FirebaseUser(Firebase.Windows.Core.FirebaseApp.Default.Auth().CurrentUser), FirebaseAuthError.None);
				};
				promise.Rejected += (sender, e) =>
				{
					callback(null, this.GetAuthError(e.ErrorCode));
				};
				promise.StartReceiving();
			}).Wait();
		}

		public void SignInWithFacebook(Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			Task.Run(async () =>
			{
				var promise = await this._auth.SignInWithFacebookAsync();
				promise.Resolved += (sender, e) =>
				{
					callback(new FirebaseUser(Firebase.Windows.Core.FirebaseApp.Default.Auth().CurrentUser), FirebaseAuthError.None);
				};
				promise.Rejected += (sender, e) =>
				{
					callback(null, this.GetAuthError(e.ErrorCode));
				};
				promise.StartReceiving();
			}).Wait();
		}

		public void SignInAnonymously(Action<IFirebaseUser, FirebaseAuthError> callback)
		{
			var promise = this._auth.SignInAnonymously();
			promise.Resolved += (sender, e) =>
			{
				callback(new FirebaseUser(Firebase.Windows.Core.FirebaseApp.Default.Auth().CurrentUser), FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(null, this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}

		public void SignOut(Action<FirebaseAuthError> callback)
		{
			var promise = this._auth.SignOut();
			promise.Resolved += (sender, e) =>
			{
				callback(FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}

		public void SendPasswordResetEmail(string email, Action<FirebaseAuthError> callback)
		{
			var promise = this._auth.SendPasswordResetEmail(email);
			promise.Resolved += (sender, e) =>
			{
				callback(FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}

		public void VerifyPasswordResetCode(string code, Action<string, FirebaseAuthError> callback)
		{
			var promise = this._auth.VerifyPasswordResetCode(code);
			promise.Resolved += (sender, e) =>
			{
				callback(promise.StringValue, FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(promise.StringValue, this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}

		public void ConfirmPasswordReset(string code, string newPassword, Action<FirebaseAuthError> callback)
		{
			var promise = this._auth.ConfirmPasswordReset(code, newPassword);
			promise.Resolved += (sender, e) =>
			{
				callback(FirebaseAuthError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(this.GetAuthError(e.ErrorCode));
			};
			promise.StartReceiving();
		}
	}
}
