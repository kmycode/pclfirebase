using System;
using System.Collections.Generic;
using System.Text;

namespace PCLFirebase.Common
{
    public enum FirebaseAuthError
    {
		None,
		Unknown,
		InvalidUser,
		UserDisabled,
		UserNotFound,
		WrongPassword,
		ExpiredActionCode,
		InvalidActionCode,
		WeakPassword,
		EmailAlreadyInUse,
		OperationNotAllowed,
		AccountExistsWithDifferentCredential,
		AuthDomainConfigRequired,
		CredentialAlreadyInUse,
		OperationNotSupportedInThisEnvironment,
		Timeout,
		RequiresRecentLogin,
		UserCollision,
    }

	public enum FirebaseStorageError
	{
		None,
		Unknown,
	}
}
