using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PCLFirebase.Droid.Core
{
	class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
	{
		private Action<Task> _callback;

		public OnCompleteListener(Action<Task> callback)
		{
			this._callback = callback;
		}

		public void OnComplete(Task task)
		{
			this._callback(task);
		}
	}
}