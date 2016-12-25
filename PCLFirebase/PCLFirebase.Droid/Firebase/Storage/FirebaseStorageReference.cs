using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PCLFirebase.Common;
using PCLFirebase.Droid.Core;
using PCLFirebase.Storage;

namespace PCLFirebase.Droid.Storage
{
	class FirebaseStorageReference : IFirebaseStorageReference
	{
		private Firebase.Storage.StorageReference _reference;

		public FirebaseStorageReference(Firebase.Storage.StorageReference reference)
		{
			this._reference = reference;
		}

		public string FullPath
		{
			get
			{
				return this._reference.Path;
			}
		}

		public string Name
		{
			get
			{
				return this._reference.Name;
			}
		}

		public IFirebaseStorageReference Parent
		{
			get
			{
				var parent = this._reference.Parent;
				return parent != null ? new FirebaseStorageReference(parent) : null;
			}
		}

		public IFirebaseStorageReference Root
		{
			get
			{
				return new FirebaseStorageReference(this._reference.Root);
			}
		}

		public IFirebaseStorage Storage
		{
			get
			{
				return FirebaseStorage.Instance;
			}
		}

		public IFirebaseStorageReference Child(string path)
		{
			return new FirebaseStorageReference(this._reference.Child(path));
		}

		public void Delete()
		{
			this._reference.Delete();
		}

		public void GetDownloadUrl(Action<string, FirebaseStorageError> callback)
		{
			var task = this._reference.DownloadUrl;
			task.AddOnCompleteListener(new OnCompleteListener((t) =>
			{
				if (t.IsSuccessful)
				{
					callback(task.Result.ToString(), FirebaseStorageError.None);
				}
				else
				{
					callback(null, FirebaseStorageError.Unknown);
				}
			}));
		}

		public void Put(string text, Action<FirebaseStorageError> callback)
		{
			this.Put(System.Text.Encoding.UTF8.GetBytes(text), "text/plain", callback);
		}

		public void Put(byte[] data, string contentType, Action<FirebaseStorageError> callback)
		{
			var task = this._reference.PutBytes(data,
									new Firebase.Storage.StorageMetadata.Builder().SetContentType(contentType).Build());
			task.AddOnCompleteListener(new OnCompleteListener((t) =>
			{
				if (t.IsSuccessful)
				{
					callback(FirebaseStorageError.None);
				}
				else
				{
					callback(FirebaseStorageError.Unknown);
				}
			}));
		}
	}
}