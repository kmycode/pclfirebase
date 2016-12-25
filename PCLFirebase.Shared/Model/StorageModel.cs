using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using PCLFirebase.Core;

namespace PCLFirebase.Shared.Model
{
	class StorageModel : INotifyPropertyChanged
	{
		private string _txtPath = "pcltest.txt";
		public string TxtPath
		{
			get
			{
				return this._txtPath;
			}
			set
			{
				this._txtPath = value;
				this.OnPropertyChanged();
			}
		}

		private string _storageSaveText;
		public string StorageSaveText
		{
			get
			{
				return this._storageSaveText;
			}
			set
			{
				this._storageSaveText = value;
				this.OnPropertyChanged();
			}
		}

		private string _storageResult;
		public string StorageResult
		{
			get
			{
				return this._storageResult;
			}
			set
			{
				this._storageResult = value;
				this.OnPropertyChanged();
			}
		}

		public void SaveStorage()
		{
			if (this.TxtPath == null || this.StorageSaveText == null) return;
			var stRef = FirebaseApp.Storage.Ref(this.TxtPath);
			stRef.Put(this.StorageSaveText, (err) =>
			{
				if (err == Common.FirebaseStorageError.None)
				{
					this.StorageResult = "ストレージへの保存に成功しました";
				}
				else
				{
					this.StorageResult = "ストレージへの保存でエラーが発生しました";
				}
			});
		}

		public void LoadStorage()
		{
			if (this.TxtPath == null) return;
			var stRef = FirebaseApp.Storage.Ref(this.TxtPath);
			stRef.GetDownloadUrl(async (uri, err) =>
			{
				if (err == Common.FirebaseStorageError.None)
				{
					var client = new HttpClient();
					var message = await client.GetAsync(uri);
					this.StorageResult = "ストレージからの取得に成功しました\n結果:" + (await message.Content.ReadAsStringAsync());
				}
				else
				{
					this.StorageResult = "ストレージからの読み込みでエラーが発生しました";
				}
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
