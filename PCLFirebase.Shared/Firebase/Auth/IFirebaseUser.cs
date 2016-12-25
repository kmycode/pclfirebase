using System;
using System.Collections.Generic;
using System.Text;
using PCLFirebase.Common;

namespace PCLFirebase.Auth
{
    public interface IFirebaseUser
    {
		/// <summary>
		/// 表示名
		/// </summary>
		string DisplayName { get; }

		/// <summary>
		/// Email
		/// </summary>
		string Email { get; }

		/// <summary>
		/// Emailが認証済であるか
		/// </summary>
		bool IsEmailVerified { get; }

		/// <summary>
		/// 匿名認証によるユーザか
		/// </summary>
		bool IsAnonymous { get; }

		/// <summary>
		/// ユーザのサムネイル画像のURL
		/// </summary>
		string PhotoUrl { get; }

		/// <summary>
		/// プロバイダのデータの配列
		/// </summary>
		ICollection<IFirebaseUserInfo> ProviderDatas { get; }

		/// <summary>
		/// プロバイダのID（例：facebook.com）
		/// </summary>
		string ProviderId { get; }

		/// <summary>
		/// UID
		/// </summary>
		string Uid { get; }

		/// <summary>
		/// 現在のユーザを削除します
		/// </summary>
		/// <param name="callback">認証のコールバック関数</param>
		void Delete(Action<FirebaseAuthError> callback);

		/// <summary>
		/// Emailを更新します
		/// </summary>
		/// <param name="newEmail">新しいEmail</param>
		/// <param name="callback">更新のコールバック関数</param>
		void UpdateEmail(string newEmail, Action<FirebaseAuthError> callback);

		/// <summary>
		/// パスワードを更新します
		/// </summary>
		/// <param name="newPassword">新しいパスワード</param>
		/// <param name="callback">更新のコールバック関数</param>
		void UpdatePassword(string newPassword, Action<FirebaseAuthError> callback);

		/// <summary>
		/// 表示名を更新します
		/// </summary>
		/// <param name="newName">新しい名前</param>
		/// <param name="callback">更新のコールバック関数</param>
		void UpdateDisplayName(string newName, Action<FirebaseAuthError> callback);
    }
}
