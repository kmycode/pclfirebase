using System;
using System.Collections.Generic;
using System.Text;
using PCLFirebase.Common;

namespace PCLFirebase.Auth
{
    public interface IFirebaseAuth
    {
		/// <summary>
		/// 現在ログインしているユーザ
		/// </summary>
		IFirebaseUser CurrentUser { get; }

		/// <summary>
		/// Email Passwordアカウントを作成する
		/// </summary>
		/// <param name="email">Email</param>
		/// <param name="password">パスワード</param>
		/// <param name="callback">認証のコールバック関数</param>
		void CreateEmailPasswordUser(string email, string password, Action<IFirebaseUser, FirebaseAuthError> callback);

		/// <summary>
		/// Email Password認証を行う
		/// </summary>
		/// <param name="email">Email</param>
		/// <param name="password">パスワード</param>
		/// <param name="callback">認証のコールバック関数</param>
		void SignInWithEmailPassword(string email, string password, Action<IFirebaseUser, FirebaseAuthError> callback);

		/// <summary>
		/// 匿名認証を行う
		/// </summary>
		/// <param name="callback">認証のコールバック関数</param>
		void SignInAnonymously(Action<IFirebaseUser, FirebaseAuthError> callback);

		/// <summary>
		/// サインアウトを行う
		/// </summary>
		/// <param name="callback">サインアウト時のコールバック関数</param>
		void SignOut(Action<FirebaseAuthError> callback);
    }
}
