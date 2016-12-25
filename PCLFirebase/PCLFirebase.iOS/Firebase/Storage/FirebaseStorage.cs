using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.iOS.Storage;
using PCLFirebase.Common;
using PCLFirebase.Storage;

namespace PCLFirebase.iOS.Storage
{
	class FirebaseStorage : IFirebaseStorage
	{
		private FIRStorage _storage;
		public static FirebaseStorage Instance { get; } = new FirebaseStorage();

		private FirebaseStorage()
		{
			this._storage = FIRStorage.Storage;
		}

		public static FirebaseStorageError GetAuthError(Exception e)
		{
			return FirebaseStorageError.Unknown;
		}

		public IFirebaseStorageReference Ref()
		{
			return new FirebaseStorageReference(this._storage.Reference);
		}

		public IFirebaseStorageReference Ref(string path)
		{
			return new FirebaseStorageReference(this._storage.ReferenceWithPath(path));
		}
	}
}