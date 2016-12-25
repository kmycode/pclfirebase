using System;
using System.Collections.Generic;
using System.Text;
using PCLFirebase.Core;

namespace PCLFirebase.Storage
{
    public interface IFirebaseStorage
    {
		/// <summary>
		/// ルートへの参照を作成
		/// </summary>
		/// <returns>ストレージ参照</returns>
		IFirebaseStorageReference Ref();

		/// <summary>
		/// 指定パスへの参照を作成
		/// </summary>
		/// <param name="path">ストレージ参照</param>
		/// <returns></returns>
		IFirebaseStorageReference Ref(string path);
    }
}
