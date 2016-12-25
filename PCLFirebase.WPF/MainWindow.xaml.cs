using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PCLFirebase.Shared.Model;

namespace PCLFirebase.WPF
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			PCLFirebase.Core.FirebaseApp.SetFirebaseApp(new PCLFirebase.WPF.Core.FirebaseApp(
				new Firebase.Windows.Core.FirebaseAppOptions
				{
					ApiKey = "<Your API Key>",
					AuthDomain = "<Your Domain>",
					DatabaseUrl = "<Your Url>",
					StorageBucket = "<Your Bucket>",
					MessagingSenderId = "<Your Id>",
					FirebaseHtmlUrl = "<Your Url>",
				}
				));
			this.Closed += (sender, e) => Firebase.Windows.Core.FirebaseApp.Default.Dispose();

			this.DataContext = new MainModel();
		}
	}
}
