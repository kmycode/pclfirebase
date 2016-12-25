using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PCLFirebase.Common;
using PCLFirebase.Core;

namespace PCLFirebase.Shared.Model
{
    class AuthModel : INotifyPropertyChanged
	{
		private string _email;
		public string Email
		{
			get
			{
				return this._email;
			}
			set
			{
				this._email = value;
				this.OnPropertyChanged();
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				this._password = value;
				this.OnPropertyChanged();
			}
		}

		private string _displayName;
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
			private set
			{
				this._displayName = value;
				this.OnPropertyChanged();
			}
		}

		private string _newDisplayName;
		public string NewDisplayName
		{
			get
			{
				return this._newDisplayName;
			}
			set
			{
				this._newDisplayName = value;
				this.OnPropertyChanged();
			}
		}

		private string _authResult;
		public string AuthResult
		{
			get
			{
				return this._authResult;
			}
			set
			{
				this._authResult = value;
				this.OnPropertyChanged();
			}
		}

		public void CreateUser()
		{
			if (this.Email == null || this.Password == null) return;
			FirebaseApp.Auth.CreateEmailPasswordUser(this.Email, this.Password, (user, err) =>
			{
				switch (err)
				{
					case FirebaseAuthError.InvalidUser:
						this.AuthResult = "Emailが間違っています";
						break;
					case FirebaseAuthError.EmailAlreadyInUse:
						this.AuthResult = "そのEmailはすでに登録されています";
						break;
					case FirebaseAuthError.OperationNotAllowed:
						this.AuthResult = "Emailでアカウントを作成することは許可されていません";
						break;
					case FirebaseAuthError.WeakPassword:
						this.AuthResult = "パスワードが弱すぎます";
						break;
					case FirebaseAuthError.None:
						this.DisplayName = user.DisplayName;
						this.AuthResult = "ユーザ新規作成に成功しました 名前:" + this.DisplayName;
						break;
					default:
						this.AuthResult = "不明なエラーです";
						break;
				}
			});
		}

		public void SignIn()
		{
			if (this.Email == null || this.Password == null) return;
			FirebaseApp.Auth.SignInWithEmailPassword(this.Email, this.Password, (user, err) =>
			{
				switch (err)
				{
					case FirebaseAuthError.InvalidUser:
						this.AuthResult = "Emailが間違っています";
						break;
					case FirebaseAuthError.UserDisabled:
						this.AuthResult = "そのユーザは無効です";
						break;
					case FirebaseAuthError.UserNotFound:
						this.AuthResult = "ユーザが見つかりません";
						break;
					case FirebaseAuthError.WrongPassword:
						this.AuthResult = "パスワードが違います";
						break;
					case FirebaseAuthError.None:
						this.DisplayName = user.DisplayName;
						this.AuthResult = "ログインに成功しました 名前:" + this.DisplayName;
						break;
					default:
						this.AuthResult = "不明なエラーです";
						break;
				}
			});
		}

		public void UpdateDisplayName()
		{
			if (this.NewDisplayName == null) return;
			FirebaseApp.Auth.CurrentUser.UpdateDisplayName(this.NewDisplayName, (err) =>
			{
				if (err != FirebaseAuthError.None)
				{
					this.AuthResult = "変更に失敗しました";
				}
				else
				{
					this.DisplayName = this.NewDisplayName;
					this.AuthResult = "変更に成功しました 名前:" + this.DisplayName;
				}
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
