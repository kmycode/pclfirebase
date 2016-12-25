using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Auth;
using PCLFirebase.Common;

namespace PCLFirebase.WPF.Auth
{
	class FirebaseUser : IFirebaseUser
	{
		private Firebase.Windows.Auth.FirebaseUser _user;

		public FirebaseUser(Firebase.Windows.Auth.FirebaseUser user)
		{
			this._user = user;

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
			this._authErrors.Add("auth/requires-recent-login", FirebaseAuthError.RequiresRecentLogin);
		}

		private Dictionary<string, FirebaseAuthError> _authErrors = new Dictionary<string, FirebaseAuthError>();
		private FirebaseAuthError GetAuthError(string code)
		{
			return _authErrors[code];
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

		public bool IsEmailVerified
		{
			get
			{
				return this._user.IsEmailVerified;
			}
		}

		public bool IsAnonymous
		{
			get
			{
				return this._user.IsAnonymous;
			}
		}

		public string PhotoUrl
		{
			get
			{
				return this._user.PhotoUrl;
			}
		}

		public ICollection<IFirebaseUserInfo> ProviderDatas
		{
			get
			{
				var result = new Collection<IFirebaseUserInfo>();
				var datas = this._user.ProviderDatas;
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
			var promise = this._user.Delete();
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

		public void UpdateEmail(string newEmail, Action<FirebaseAuthError> callback)
		{
			var promise = this._user.UpdateEmail(newEmail);
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

		public void UpdatePassword(string newPassword, Action<FirebaseAuthError> callback)
		{
			var promise = this._user.UpdatePassword(newPassword);
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

		public void UpdateDisplayName(string newName, Action<FirebaseAuthError> callback)
		{
			var promise = this._user.UpdateProfile(newName, this.PhotoUrl);
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
