using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Common;
using PCLFirebase.Storage;

namespace PCLFirebase.WPF.Storage
{
	class FirebaseStorageReference : IFirebaseStorageReference
	{
		private Firebase.Windows.Storage.FirebaseStorageReference _storageRef;

		public FirebaseStorageReference(Firebase.Windows.Storage.FirebaseStorageReference storageRef)
		{
			this._storageRef = storageRef;

			//this._storageErrors.Add("auth/invalid-email", FirebaseAuthError.InvalidUser);
		}

		private Dictionary<string, FirebaseStorageError> _storageErrors = new Dictionary<string, FirebaseStorageError>();

		private FirebaseStorageError GetStorageError(string code)
		{
			return _storageErrors[code];
		}

		public string FullPath
		{
			get
			{
				return this._storageRef.FullPath;
			}
		}

		public string Name
		{
			get
			{
				return this._storageRef.Name;
			}
		}

		public IFirebaseStorageReference Parent
		{
			get
			{
				var parent = this._storageRef.Parent;
				return parent != null ? new FirebaseStorageReference(this._storageRef.Parent) : null;
			}
		}

		public IFirebaseStorageReference Root
		{
			get
			{
				return new FirebaseStorageReference(this._storageRef.Root);
			}
		}

		public IFirebaseStorage Storage
		{
			get
			{
				return new FirebaseStorage(this._storageRef.Storage);
			}
		}

		public IFirebaseStorageReference Child(string path)
		{
			return new FirebaseStorageReference(this._storageRef.Child(path));
		}

		public void Delete()
		{
			this._storageRef.Delete();
		}

		public void GetDownloadUrl(Action<string, FirebaseStorageError> callback)
		{
			var promise = this._storageRef.GetDownloadUrl();
			promise.Resolved += (sender, e) =>
			{
				callback(promise.StringValue, FirebaseStorageError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(null, FirebaseStorageError.Unknown);
			};
			promise.StartReceiving();
		}

		public void Put(byte[] data, string contentType, Action<FirebaseStorageError> callback)
		{
			var promise = this._storageRef.Put(data, contentType);
			promise.Fulfilled += (sender, e) =>
			{
				callback(FirebaseStorageError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(FirebaseStorageError.Unknown);
			};
			promise.StartReceiving();
		}

		public void Put(string text, Action<FirebaseStorageError> callback)
		{
			var promise = this._storageRef.Put(text);
			promise.Fulfilled += (sender, e) =>
			{
				callback(FirebaseStorageError.None);
			};
			promise.Rejected += (sender, e) =>
			{
				callback(FirebaseStorageError.Unknown);
			};
			promise.StartReceiving();
		}
	}
}
