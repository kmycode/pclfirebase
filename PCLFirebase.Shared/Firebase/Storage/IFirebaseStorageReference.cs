using System;
using System.Collections.Generic;
using System.Text;
using PCLFirebase.Common;

namespace PCLFirebase.Storage
{
    public interface IFirebaseStorageReference
    {
		/// <summary>
		/// 参照のフルパス
		/// </summary>
		string FullPath { get; }

		/// <summary>
		/// 参照ファイル・ディレクトリ名
		/// </summary>
		string Name { get; }

		/// <summary>
		/// 親ディレクトリの参照を取得
		/// </summary>
		IFirebaseStorageReference Parent { get; }

		/// <summary>
		/// ルートの参照を取得
		/// </summary>
		IFirebaseStorageReference Root { get; }

		/// <summary>
		/// 参照のもとになっているストレージを取得
		/// </summary>
		IFirebaseStorage Storage { get; }

		/// <summary>
		/// 子ディレクトリ・ファイルへの参照を取得
		/// </summary>
		/// <param name="path">参照先の相対パス</param>
		/// <returns>ストレージ参照</returns>
		IFirebaseStorageReference Child(string path);

		/// <summary>
		/// 現在の参照を削除
		/// </summary>
		void Delete();

		/// <summary>
		/// 現在の参照のダウンロードURIを取得
		/// </summary>
		/// <param name="callback">取得のコールバック関数</param>
		void GetDownloadUrl(Action<string, FirebaseStorageError> callback);

		/// <summary>
		/// 現在の参照にデータを格納する
		/// </summary>
		/// <param name="data">アップロードするデータ</param>
		/// <param name="contentType">アップロードするデータのコンテンツタイプ</param>
		/// <param name="callback">アップロードのコールバック関数</param>
		void Put(byte[] data, string contentType, Action<FirebaseStorageError> callback);

		/// <summary>
		/// 現在の参照に文字列データを格納する
		/// </summary>
		/// <param name="text">アップロードする文字列</param>
		/// <param name="callback">アップロードのコールバック関数</param>
		void Put(string text, Action<FirebaseStorageError> callback);
    }
}
