using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PCLFirebase.Common;
using PCLFirebase.Core;

namespace PCLFirebase.Shared.Model
{
	public class MainModel : INotifyPropertyChanged
	{
		private AuthModel _auth = new AuthModel();
		private StorageModel _storage = new StorageModel();

		public MainModel()
		{
			this._auth.PropertyChanged += (sender, e) => this.PropertyChanged(this, e);
			this._storage.PropertyChanged += (sender, e) => this.PropertyChanged(this, e);
		}

		public string Email
		{
			get
			{
				return this._auth.Email;
			}
			set
			{
				this._auth.Email = value;
			}
		}

		public string Password
		{
			get
			{
				return this._auth.Password;
			}
			set
			{
				this._auth.Password = value;
			}
		}

		public string DisplayName => this._auth.DisplayName;

		public string NewDisplayName
		{
			get
			{
				return this._auth.NewDisplayName;
			}
			set
			{
				this._auth.NewDisplayName = value;
			}
		}

		public string AuthResult => this._auth.AuthResult;

		public string TxtPath
		{
			get
			{
				return this._storage.TxtPath;
			}
			set
			{
				this._storage.TxtPath = value;
			}
		}

		public string StorageSaveText
		{
			get
			{
				return this._storage.StorageSaveText;
			}
			set
			{
				this._storage.StorageSaveText = value;
			}
		}

		public string StorageResult => this._storage.StorageResult;

		private RelayCommand _createUserCommand;
		public RelayCommand CreateUserCommand
		{
			get
			{
				return this._createUserCommand = this._createUserCommand ?? new RelayCommand((obj) =>
				{
					this._auth.CreateUser();
				});
			}
		}

		private RelayCommand _signInCommand;
		public RelayCommand SignInCommand
		{
			get
			{
				return this._signInCommand = this._signInCommand ?? new RelayCommand((obj) =>
				{
					this._auth.SignIn();
				});
			}
		}

		private RelayCommand _updateDisplayNameCommand;
		public RelayCommand UpdateDisplayNameCommand
		{
			get
			{
				return this._updateDisplayNameCommand = this._updateDisplayNameCommand ?? new RelayCommand((obj) =>
				{
					this._auth.UpdateDisplayName();
				});
			}
		}

		private RelayCommand _saveStorageCommand;
		public RelayCommand SaveStorageCommand
		{
			get
			{
				return this._saveStorageCommand = this._saveStorageCommand ?? new RelayCommand((obj) =>
				{
					this._storage.SaveStorage();
				});
			}
		}

		private RelayCommand _loadStorageCommand;
		public RelayCommand LoadStorageCommand
		{
			get
			{
				return this._loadStorageCommand = this._loadStorageCommand ?? new RelayCommand((obj) =>
				{
					this._storage.LoadStorage();
				});
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
