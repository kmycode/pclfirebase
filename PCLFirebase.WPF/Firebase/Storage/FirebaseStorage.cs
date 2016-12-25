using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Common;
using PCLFirebase.Core;
using PCLFirebase.Storage;

namespace PCLFirebase.WPF.Storage
{
	class FirebaseStorage : IFirebaseStorage
	{
		private Firebase.Windows.Storage.FirebaseStorage _storage;

		public FirebaseStorage(Firebase.Windows.Storage.FirebaseStorage storage)
		{
			this._storage = storage;

			//this._storageErrors.Add("auth/invalid-email", FirebaseAuthError.InvalidUser);
		}

		private Dictionary<string, FirebaseStorageError> _storageErrors = new Dictionary<string, FirebaseStorageError>();

		private FirebaseStorageError GetStorageError(string code)
		{
			return _storageErrors[code];
		}

		public IFirebaseStorageReference Ref()
		{
			return new FirebaseStorageReference(this._storage.Ref());
		}

		public IFirebaseStorageReference Ref(string path)
		{
			return new FirebaseStorageReference(this._storage.Ref(path));
		}
	}
}
