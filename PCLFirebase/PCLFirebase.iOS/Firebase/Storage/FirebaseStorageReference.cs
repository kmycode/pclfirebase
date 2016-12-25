using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Firebase.iOS.Storage;
using Foundation;
using PCLFirebase.Common;
using PCLFirebase.Storage;

namespace PCLFirebase.iOS.Storage
{
	class FirebaseStorageReference : IFirebaseStorageReference
	{
		private FIRStorageReference _reference;

		public FirebaseStorageReference(FIRStorageReference reference)
		{
			this._reference = reference;
		}

		public string FullPath
		{
			get
			{
				return this._reference.FullPath;
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
			this._reference.DeleteWithCompletion((err) => { });
		}

		public void GetDownloadUrl(Action<string, FirebaseStorageError> callback)
		{
			this._reference.DownloadURLWithCompletion((uri, err) =>
			{
				if (err == null)
				{
					callback(uri.ToString(), FirebaseStorageError.None);
				}
				else
				{
					callback(null, FirebaseStorageError.Unknown);
				}
			});
		}

		public void Put(string text, Action<FirebaseStorageError> callback)
		{
			this.Put(System.Text.Encoding.UTF8.GetBytes(text), "text/plain", callback);
		}

		public void Put(byte[] data, string contentType, Action<FirebaseStorageError> callback)
		{
			var meta = new FIRStorageMetadata();
			meta.ContentType = contentType;
			this._reference.PutData(NSData.FromArray(data), meta, (mt, err) =>
			{
				if (err == null)
				{
					callback(FirebaseStorageError.None);
				}
				else
				{
					callback(FirebaseStorageError.Unknown);
				}
			});
		}
	}
}