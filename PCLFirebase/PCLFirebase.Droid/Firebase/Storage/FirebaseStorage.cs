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
using PCLFirebase.Storage;

namespace PCLFirebase.Droid.Storage
{
	class FirebaseStorage : IFirebaseStorage
	{
		private Firebase.Storage.FirebaseStorage _storage;
		public static FirebaseStorage Instance { get; } = new FirebaseStorage();

		private FirebaseStorage()
		{
			this._storage = Firebase.Storage.FirebaseStorage.Instance;
		}

		public static FirebaseStorageError GetAuthError(Exception e)
		{
			if (e is Firebase.Storage.StorageException)
			{
				return FirebaseStorageError.Unknown;
			}
			return FirebaseStorageError.Unknown;
		}

		public IFirebaseStorageReference Ref()
		{
			return new FirebaseStorageReference(this._storage.Reference);
		}

		public IFirebaseStorageReference Ref(string path)
		{
			return new FirebaseStorageReference(this._storage.GetReference(path));
		}
	}
}