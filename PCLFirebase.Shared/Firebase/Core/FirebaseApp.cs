using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PCLFirebase.Auth;
using PCLFirebase.Config;
using PCLFirebase.Database;
using PCLFirebase.Storage;

namespace PCLFirebase.Core
{
    public static class FirebaseApp
    {
		private static IFirebaseApp _app;
		private static Collection<Action<IFirebaseApp>> _invokeActions = new Collection<Action<IFirebaseApp>>();

		/// <summary>
		/// IFirebaseAppのデフォルトインスタンスをセットします
		/// </summary>
		/// <param name="app">IFirebaseAppのインスタンス</param>
		public static void SetFirebaseApp(IFirebaseApp app)
		{
			if (_app != null)
			{
				throw new InvalidOperationException("FirebaseApp can't set twice");
			}
			_app = app;

			foreach (var action in _invokeActions)
			{
				action.Invoke(_app);
			}
		}

		/// <summary>
		/// FirebaseAppのインスタンスがセットされた時に実行される処理を登録します
		/// </summary>
		/// <param name="action">登録する処理</param>
		public static void Invoke(Action<IFirebaseApp> action)
		{
			if (_app != null)
			{
				action.Invoke(_app);
			}
			else
			{
				_invokeActions.Add(action);
			}
		}

		public static IFirebaseAuth Auth
		{
			get
			{
				return _app.Auth;
			}
		}

		public static IFirebaseConfig Config
		{
			get
			{
				return _app.Config;
			}
		}

		public static IFirebaseDatabase Database
		{
			get
			{
				return _app.Database;
			}
		}

		public static IFirebaseStorage Storage
		{
			get
			{
				return _app.Storage;
			}
		}
	}
}
