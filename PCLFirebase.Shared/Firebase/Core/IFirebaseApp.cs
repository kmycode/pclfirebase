using System;
using System.Collections.Generic;
using System.Text;
using PCLFirebase.Auth;
using PCLFirebase.Config;
using PCLFirebase.Database;
using PCLFirebase.Storage;

namespace PCLFirebase.Core
{
    public interface IFirebaseApp
    {
		IFirebaseAuth Auth { get; }
		IFirebaseConfig Config { get; }
		IFirebaseDatabase Database { get; }
		IFirebaseStorage Storage { get; }
    }
}
