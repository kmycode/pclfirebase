using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLFirebase.Shared.Model;
using Xamarin.Forms;

namespace PCLFirebase
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = new MainModel();
		}
	}
}
